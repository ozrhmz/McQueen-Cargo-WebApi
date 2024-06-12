using Autofac;
using Repositories.EFCore;
using System;
using System.Reflection;
using WebApi.Utilities.AutoMapper;
using Module = Autofac.Module;
namespace WebUI.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(RepositoryContext));   //Herhangi bir assembly versek yeterli diğerlerini oto alıyor
            var serviceAssembly = Assembly.GetAssembly(typeof(MappingProfile));//Herhangi bir assembly versek yeterli diğerlerini oto alıyor

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith
            ("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith
            ("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
