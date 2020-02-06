using System;
using AgendaInvent.Domain.Models;

namespace AgendaInvent.Domain.Contracts.Repositories
{
	public interface IContactRepository : IDisposable
	{
		Contact GetById(Guid Id);
		Contact GetByName(string name);
		Contact GetByPhone(string phone);
		Contact GetByEmail(string email);

		void Create(Contact ctt);
		void Update(Contact ctt);
		void Delete(Contact ctt);
	}
}
