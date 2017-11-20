

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SgConAPI.Jwt;
using SgConAPI.Models;
using SgConAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SgConAPI.EntityFramework
{
    public class SgConContext : DbContext
    {
        private JwtCurrentUserFactory _jwtCurrentUsertFactory;
#if MIGRATION
            public SgConContext()
            {

            }
#endif

        public DbSet<Condominium> Condominiums { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<ProfilePolicy> ProfilePolicies { get; set; }
        public DbSet<Tower> Towers { get; set; }
        public DbSet <Resident> Residents { get; set; }
        public DbSet <Company> Companies { get; set; }


        public SgConContext(DbContextOptions<SgConContext> options) : base(options)
        {
            
        }

        public void SetJwtCurrentUser(JwtCurrentUserFactory jwtCurrentUsertFactory) => this._jwtCurrentUsertFactory = jwtCurrentUsertFactory;

        public override void Dispose()
        {
            if (_jwtCurrentUsertFactory != null)
            {
                this._jwtCurrentUsertFactory.Dispose();
                this._jwtCurrentUsertFactory = null;
            }
            base.Dispose();
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseModel
        {
            return base.Set<TEntity>();
        }

#if MIGRATION
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            string currentPath = System.IO.Directory.GetCurrentDirectory();
            var connectionStringName = "DefaultConnection";
            Console.WriteLine(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                connectionStringName = "ProductionConnection";
            }
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Homolog")
            {
                connectionStringName = "HomologConnection";
            }
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Staging")
            {
                connectionStringName = "StagingConnection";
            }
            optionsBuilder.UseMySql(
                new ConfigurationBuilder()
                    .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                    .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: false)
                    .Build()
                    .GetConnectionString(connectionStringName)
            )
            .ConfigureWarnings(warnings => warnings.Default(WarningBehavior.Ignore)
                        .Log(CoreEventId.IncludeIgnoredWarning,
                                CoreEventId.PossibleUnintendedCollectionNavigationNullComparisonWarning,
                                CoreEventId.PossibleUnintendedReferenceComparisonWarning)
                        .Throw(RelationalEventId.QueryClientEvaluationWarning)
                );
        }
#endif

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Condominium>().ToTable("Condominium").Property(a => a.Active).HasDefaultValueSql("1");

            modelBuilder.Entity<Apartment>().ToTable("Apartment")
                .Property(a => a.Active).HasDefaultValueSql("1");

            modelBuilder.Entity<Apartment>()
                .HasOne(h => h.Tower)
                .WithMany(h => h.Apartment)
                .HasForeignKey(h => h.TowerId);

            modelBuilder.Entity<Employee>().ToTable("Employee").Property(a => a.Active).HasDefaultValueSql("1");
            modelBuilder.Entity<Employee>().HasIndex(e => e.UserName).IsUnique();
            modelBuilder.Entity<Employee>().HasIndex(e => e.Email).IsUnique();

            modelBuilder.Entity<Role>().ToTable("Role").Property(a => a.Active).HasDefaultValueSql("1");

            modelBuilder.Entity<Profile>().ToTable("Profile").Property(a => a.Active).HasDefaultValueSql("1");

            modelBuilder.Entity<ProfilePolicy>().ToTable("ProfilePolicies").HasKey(t => new { t.ProfileId, t.PolicyId });

            modelBuilder.Entity<ProfilePolicy>()
                .HasOne(pp => pp.Profile)
                .WithMany(pp => pp.ProfilePolicies)
                .HasForeignKey(pp => pp.ProfileId);

            modelBuilder.Entity<ProfilePolicy>()
                .HasOne(pt => pt.Policy)
                .WithMany(t => t.ProfilePolicies)
                .HasForeignKey(pt => pt.PolicyId);

            modelBuilder.Entity<Tower>().ToTable("Tower").Property(a => a.Active).HasDefaultValueSql("1");

            modelBuilder.Entity<Tower>()
                .HasOne(a => a.Condominium)
                .WithMany(a => a.Tower)
                .HasForeignKey(a => a.CondominiumId);

            modelBuilder.Entity<Resident>().ToTable("Resident").Property(a => a.Active).HasDefaultValueSql("1");

            modelBuilder.Entity<Company>().ToTable("Company").Property(a => a.Active).HasDefaultValueSql("1");

        }

        public override int SaveChanges()
        {
            int result = 0;

            IssueTimestamps();
            var entities = this.getChangedEntities();
            result = base.SaveChanges();
            return result;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            IssueTimestamps();
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        private IEnumerable<EntityEntry> getChangedEntities()
        {
            var entities = ChangeTracker.Entries().Where(
                //r => !(r.Entity is Log)
                //&& !(r.State == EntityState.Unchanged)
                r => !(r.State == EntityState.Unchanged)
            );
            return entities;
        }

        public void IssueTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(
                r => (r.Entity is BaseModel)
                && (r.State == EntityState.Added || r.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseModel)entity.Entity).CreatedAt = DateTime.Now;
                }

                ((BaseModel)entity.Entity).UpdatedAt = DateTime.Now;
            }
        }

        private void IssueUserInformation()
        {
            string userName = string.Empty;

            if (_jwtCurrentUsertFactory != null)
            {
                ApplicationUser appUser = _jwtCurrentUsertFactory.getCurrentLoggedUser();

                if (appUser != null)
                    userName = appUser.UserName;
            }

            var entities = ChangeTracker.Entries().Where(
                  r => (r.Entity is BaseModel)
                  && (r.State == EntityState.Added || r.State == EntityState.Modified)
              );

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseModel)entity.Entity).CreatedBy = userName;
                }

               ((BaseModel)entity.Entity).UpdatedBy = userName;
            }
        }

    }
}
