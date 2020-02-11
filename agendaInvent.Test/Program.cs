using System;
using AgendaInvent.Domain.Contracts.Repositories;
using AgendaInvent.Domain.Models;
using AgendaInvent.Infrastructure.Data;
using AgendaInvent.Infrastructure.Repositories;

namespace AgendaInvent.Test
{
	class Program
	{
		static void Main(string[] args)
		{
			var contato = new Contact("Sâmea", "62995048152");
			contato.Validate();

			using (IContactRepository CttRepo = new ContactRepository(new AppDataContext()))
			{
				try
				{
					CttRepo.Create(contato);
				}
				catch(Exception ex)
				{
					Console.WriteLine("Usuário já existe");
				}
			}

			using (IContactRepository CttRepo = new ContactRepository(new AppDataContext()))
			{
				var test = CttRepo.GetByPhone(contato.Phone);
				Console.WriteLine(test.Name);
				Console.WriteLine(test.Phone);
			}
		}
	}
}
