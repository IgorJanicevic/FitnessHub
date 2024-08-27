using FitnessAppAPI.IRepositories;
using FitnessAppAPI.IServices;
using FitnessAppAPI.Repositories;
using FitnessAppAPI.Services;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace FitnessAppAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers


            // Register your services here
            // e.g. container.RegisterType<ITestService, TestService>();4 
            container.RegisterType<IGymRepository, GymRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IMembershipRepository, MembershipRepository>(new HierarchicalLifetimeManager());


            container.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());
            container.RegisterType<IGymService, GymService>(new HierarchicalLifetimeManager());
            container.RegisterType<IMembershipService, MembershipService>(new HierarchicalLifetimeManager());



            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}