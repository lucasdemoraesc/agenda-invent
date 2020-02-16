using System;
using AgendaInvent.Common.Validation;
using AgendaInvent.Common.Resources;

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
		#endregion

		#region Properties
		public Guid Id { get; private set; }
		public string Name { get; private set; }
		public string Phone { get; private set; }
		#endregion

		#region Methods
		public void Validate()
		{
			AssertionConcern.AssertArgumentLength(this.Name, 3, 50, Errors.InvalidName);
			PhoneAssertionConcern.AssertIsValid(this.Phone);
		}
		#endregion
	}
}
