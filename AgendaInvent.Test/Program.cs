using AgendaInvent.Domain.Contracts.Services;
using AgendaInvent.Common.Resources;
using AgendaInvent.Startup;
using System;
using System.Globalization;
using System.Threading;
using Unity;

namespace AgendaInvent.Test
{
	class Program
	{
		static void Main(string[] args)
		{
			// Idioma
			CultureInfo ci = new CultureInfo("pt-BR");
			Thread.CurrentThread.CurrentCulture = ci;
			Thread.CurrentThread.CurrentUICulture = ci;

			var container = new UnityContainer();
			DependencyResolver.Resolve(container);

			var service = container.Resolve<IContactService>();
			try
			{
				service.Register("Leny Teodoro", "66999221160");
				Console.WriteLine(Messages.RegisteredSuccessfully);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				service.Dispose();
			}
			Console.ReadKey();
		}
	}
}
