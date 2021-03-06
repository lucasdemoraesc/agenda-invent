﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using AgendaInvent.Domain.Models;

namespace AgendaInvent.Infrastructure.Data.Map
{
	public class ContactMap : EntityTypeConfiguration<Contact>
	{
		public ContactMap()
		{
			ToTable("Contact");

			Property(x => x.Id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			Property(x => x.Name)
				.HasMaxLength(50)
				.IsRequired();

			Property(x => x.Phone)
				.HasMaxLength(12)
				.HasColumnAnnotation(
					IndexAnnotation.AnnotationName,
					new IndexAnnotation(new IndexAttribute("IX_PHONE", 2) { IsUnique = true }))
				.IsRequired();
		}
	}
}
