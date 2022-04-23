using Autofac;
using StudentManager.DataAccess.Common;
using StudentManager.DataAccess.EF;

namespace StudentManager.WebApp.DependencyInjection
{
    public class EFModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(StudentManagerDbContext)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}
