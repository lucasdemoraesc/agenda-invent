using AgendaInvent.Business.Services;
using AgendaInvent.Domain.Contracts.Repositories;
using AgendaInvent.Domain.Contracts.Services;
using AgendaInvent.Domain.Models;
using AgendaInvent.Infrastructure.Data;
using AgendaInvent.Infrastructure.Repositories;
using Unity;
using Unity.Lifetime;

namespace AgendaInvent.Startup
{
	public static class DependencyResolver
	{
		public static void Resolve(UnityContainer container)
		{
			container.RegisterType<AppDataContext, AppDataContext>(new HierarchicalLifetimeManager());
			container.RegisterType<IContactRepository, ContactRepository>(new HierarchicalLifetimeManager());
			container.RegisterType<IContactService, ContactService>(new HierarchicalLifetimeManager());

			container.RegisterType<Contact, Contact>(new HierarchicalLifetimeManager());
		}
	}
}
