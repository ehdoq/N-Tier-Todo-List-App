using Autofac;
using System.Reflection;
using TodoList.Core.Repositories;
using TodoList.Core.Services;
using TodoList.Core.UnitOfWorks;
using TodoList.Repository.AppDBContexts;
using TodoList.Repository.Repositories;
using TodoList.Repository.UnitOfWorks;
using TodoList.Service.Mapping;
using TodoList.Service.Services;
using Module = Autofac.Module;

namespace TodoList.Extension.Modules
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<>))
                   .As(typeof(IRepository<>))
                   .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Service<>))
                   .As(typeof(IService<>))
                   .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                   .As<IUnitOfWork>();

            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                  .Where(x => x.Name.EndsWith("Repository"))
                  .AsImplementedInterfaces()
                  .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                   .Where(x => x.Name.EndsWith("Service"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}