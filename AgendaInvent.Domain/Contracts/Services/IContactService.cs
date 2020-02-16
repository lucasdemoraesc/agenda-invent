using AgendaInvent.Domain.Models;
using System;
using System.Collections.Generic;

namespace AgendaInvent.Domain.Contracts.Services
{
	public interface IContactService : IDisposable
	{
		Contact GetByName(string name);
		Contact GetByPhone(string phone);
		List<Contact> GetByRange(int skip, int take);

		void Register(string name, string phone);
		void Remove(string phone);
	}
}
