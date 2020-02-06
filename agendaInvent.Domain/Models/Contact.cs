using System;
using AgendaInvent.Common.Resources;
using AgendaInvent.Common.Validation;

namespace AgendaInvent.Domain.Models
{
	public class Contact
	{
		#region Builders
		protected Contact() { }

		public Contact(string name, string phone)
		{
			this.Id = Guid.NewGuid();
			this.Name = name;
			this.Phone = phone;
		}

		public Contact(string name, string phone, string email) : this(name, phone)
		{
			Email = email;
		}
		#endregion

		#region Properties
		public Guid Id { get; private set; }
		public string Name { get; private set; }
		public string Phone { get; private set; }
		public string Email { get; private set; }
		#endregion

		#region Methods
		public void ChangeName(string name)
		{
			this.Name = name;
		}

		public void ChangePhone(string phone)
		{
			this.Phone = phone;
		}

		public void ChangeEmail(string Email)
		{
			this.Email = Email;
		}

		public void Validate()
		{
			AssertionConcern.AssertArgumentLength(this.Name, 3, 50, Errors.InvalidName);
			EmailAssertionConcern.AssertIsValid(this.Email);
			PhoneAssertionConcern.AssertIsValid(this.Phone);
		}
		#endregion
	}
}
