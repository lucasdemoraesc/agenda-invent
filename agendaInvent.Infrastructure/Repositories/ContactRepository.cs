using System;
using System.Data.Entity;
using System.Linq;
using AgendaInvent.Domain.Contracts.Repositories;
using AgendaInvent.Domain.Models;
using AgendaInvent.Infrastructure.Data;

namespace AgendaInvent.Infrastructure.Repositories
{
	public class ContactRepository : IContactRepository
	{
		private AppDataContext _context;

		public ContactRepository(AppDataContext context)
		{
			this._context = context;
		}

		public Contact GetById(Guid Id)
		{
			return _context.Ctts.Where(x => x.Id == Id).FirstOrDefault();
		}

		public Contact GetByName(string name)
		{
			return _context.Ctts.Where(x => x.Name == name.ToLower()).First();
		}

		public Contact GetByPhone(string phone)
		{
			return _context.Ctts.Where(x => x.Phone == phone).First();
		}

		public void Create(Contact ctt)
		{
			_context.Ctts.Add(ctt);
			_context.SaveChanges();
		}

		public void Update(Contact ctt)
		{
			_context.Entry<Contact>(ctt).State = EntityState.Modified;
			_context.SaveChanges();
		}

		public void Delete(Contact ctt)
		{
			_context.Ctts.Remove(ctt);
			_context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();
		}

	}
}
