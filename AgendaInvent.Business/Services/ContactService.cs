using AgendaInvent.Common.Resources;
using AgendaInvent.Domain.Contracts.Repositories;
using AgendaInvent.Domain.Contracts.Services;
using AgendaInvent.Domain.Models;
using System;

namespace AgendaInvent.Business.Services
{
	public class ContactService : IContactService
	{
		private IContactRepository _repository;

		public ContactService(IContactRepository repository)
		{
			_repository = repository;
		}

		public Contact GetByPhone(string phone)
		{
			var ctt = _repository.GetByPhone(phone);
			if (ctt == null)
				throw new Exception(Errors.ContactNotFound);

			return ctt;
		}

		public Contact GetByName(string name)
		{
			var ctt = _repository.GetByName(name);
			if (ctt == null)
				throw new Exception(Errors.ContactNotFound);

			return ctt;
		}

		public void Register(string name, string phone)
		{
			var hasPhone = _repository.GetByPhone(phone);
			var hasName = _repository.GetByName(name);
			if (hasPhone != null)
				throw new Exception(Errors.ContactPhoneExists);
			if (hasName != null)
				throw new Exception(Errors.ContactNameExists);


			var Ctt = new Contact(name, phone);
			Ctt.Validate();
			_repository.Create(Ctt);
		}

		public void Remove(string phone)
		{
			var Ctt = GetByPhone(phone);
			if (Ctt == null)
				throw new Exception(Errors.ContactNotFound);

			_repository.Delete(Ctt);
		}

		public void Dispose()
		{
			_repository.Dispose();
		}
	}
}
