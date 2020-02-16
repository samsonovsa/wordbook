using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;
using WordBook.Models;
using WordBook.Services.DataServices;
using WordBook.Services.DataServices.LocalDB;

namespace WordBook
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IConnections, ConnectionsService>();
            container.RegisterType<IWordBookContext, WordBookContext>();
            container.RegisterType<IGenericRepository<Vocabulary>, GenericRepository<Vocabulary>>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}