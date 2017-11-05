using Autofac;

namespace SgConAPI.Modules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Scan an assembly for components
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces();
            base.Load(builder);
        }
    }
}
