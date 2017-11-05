

using Microsoft.EntityFrameworkCore;
using SgConAPI.Jwt;
using SgConAPI.Models;
using SgConAPI.Models.Base;
using System;
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

        public DbSet<Condominio> Condominio { get; set; }
        public DbSet<Predio> Predio { get; set; }

        public SgConContext(DbContextOptions<SgConContext> options) : base(options)
        {
            
        }

        public void SetJwtCurrentUser(JwtCurrentUserFactory jwtCurrentUsertFactory)
        {
            this._jwtCurrentUsertFactory = jwtCurrentUsertFactory;
        }

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
            modelBuilder.Entity<Condominio>().ToTable("Condominio").Property(a => a.Ativo).HasDefaultValueSql("1");

            modelBuilder.Entity<Predio>().ToTable("Predio")
                .Property(a => a.Ativo).HasDefaultValueSql("1");

            modelBuilder.Entity<Predio>()
                .HasOne(p => p.Condominio)
                .WithMany(p => p.Predios)
                .HasForeignKey(p => p.CondominioId);
        }

        public override int SaveChanges()
        {
            int result = 0;
            IssueTimestamps();
            result = base.SaveChanges();
            return result;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            IssueTimestamps();
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
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
                    ((BaseModel)entity.Entity).CriadoEm = DateTime.Now;
                }

                ((BaseModel)entity.Entity).AtualizadoEm = DateTime.Now;
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
                    ((BaseModel)entity.Entity).CriadoPor = userName;
                }

               ((BaseModel)entity.Entity).AtualizadoPor = userName;
            }
        }

    }
}
