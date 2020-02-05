using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using agendaInvent.Domain;

namespace agendaInvent.Test
{
	class Program
	{
		static void Main(string[] args)
		{
			var contato = new Contact("Lucas", "6299692322", "lucasdemoraesc@gmail.com");
			contato.Validate();

			Console.WriteLine(contato.Name);
			Console.WriteLine(contato.Phone);
			Console.WriteLine(contato.Email);
		}
	}
}
