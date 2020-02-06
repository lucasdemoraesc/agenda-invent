using System;
using AgendaInvent.Domain.Models;

namespace AgendaInvent.Test
{
	class Program
	{
		static void Main(string[] args)
		{
			var contato = new Contact("Lucas", "62996692322", "lucasdemoraesc@gmail.com");
			contato.Validate();

			Console.WriteLine(contato.Name);
			Console.WriteLine(contato.Phone);
			Console.WriteLine(contato.Email);
		}
	}
}
