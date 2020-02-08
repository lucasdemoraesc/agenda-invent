using System;
using AgendaInvent.Domain.Contracts.Repositories;
using AgendaInvent.Domain.Models;
using AgendaInvent.Infrastructure.Repositories;

namespace AgendaInvent.Test
{
	class Program
	{
		static void Main(string[] args)
		{
			var contato = new Contact("Lucas", "62995048152", "lucasdemoraesc@gmail.com");
			contato.Validate();

			using (IContactRepository CttRepo = new ContactRepository())
			{
					CttRepo.Create(contato);
			}

			using (IContactRepository CttRepo = new ContactRepository())
			{
				var test = CttRepo.GetByPhone("62996692322");
				Console.WriteLine(test.Email);
			}
		}
	}
}
