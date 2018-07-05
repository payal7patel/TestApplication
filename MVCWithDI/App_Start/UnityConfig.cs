using System;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using TestApplication.Service;
using Data.Repository;

namespace TestApplication
{
    public static class UnityConfig
    {
        public static Type IUserRepository { get; private set; }

        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all components with the container here

            //container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            container.RegisterType<IUserService, UserService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}