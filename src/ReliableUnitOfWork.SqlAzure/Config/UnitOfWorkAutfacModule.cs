using Autofac;

namespace ReliableUnitOfWork.SqlAzure.Config
{
    public class UnitOfWorkAutfacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(GetType().Assembly)
                .AsImplementedInterfaces()
                .InstancePerMatchingLifetimeScope();
        }
    }
}
