using AgendaInvent.Domain.Models;
using System;

namespace AgendaInvent.Domain.Contracts.Services
{
	public interface IContactService : IDisposable
	{
		Contact GetByName(string name);
		Contact GetByPhone(string phone);

		void Register(string name, string phone);
		void Remove(string phone);
	}
}
