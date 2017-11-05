using Autofac;

namespace SgConAPI.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Scan an assembly for components
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces();
            base.Load(builder);
        }
    }
}