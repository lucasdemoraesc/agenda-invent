using System.Data.Entity;
using AgendaInvent.Domain.Models;
using AgendaInvent.Infrastructure.Data.Map;

namespace AgendaInvent.Infrastructure.Data
{
	public class AppDataContext : DbContext
	{
		public AppDataContext()
			: base("AppConnectionString")
		{
			Configuration.LazyLoadingEnabled = false;
			Configuration.ProxyCreationEnabled = false;
		}

		public DbSet<Contact> Ctts { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new ContactMap());
		}
	}
}
