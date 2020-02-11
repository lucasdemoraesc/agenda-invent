using AgendaInvent.Domain.Contracts.Repositories;
using AgendaInvent.Infrastructure.Data;
using AgendaInvent.Infrastructure.Repositories;
using Unity;
using Unity.Lifetime;

namespace AgendaInvent.Startup
{
	public static class DependecyResolver
	{
		public static void Resolve(UnityContainer container)
		{
			container.RegisterType<AppDataContext, AppDataContext>(new HierarchicalLifetimeManager());
			container.RegisterType<IContactRepository, ContactRepository>(new HierarchicalLifetimeManager());
			//container.RegisterType<IContactService, ContactService>(new HierarchicalLifetimeManager());
			//container.RegisterType<Contact, Contact>(new HierarchicalLifetimeManager());

		}
	}
}
