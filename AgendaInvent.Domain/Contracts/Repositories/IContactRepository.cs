using AgendaInvent.Domain.Models;
using System;
using System.Collections.Generic;

namespace AgendaInvent.Domain.Contracts.Repositories
{
	public interface IContactRepository : IDisposable
	{
		Contact GetById(Guid Id);
		Contact GetByName(string name);
		Contact GetByPhone(string phone);
		List<Contact> GetList(int skip, int take);

		void Create(Contact ctt);
		void Update(Contact ctt);
		void Delete(Contact ctt);
	}
}
