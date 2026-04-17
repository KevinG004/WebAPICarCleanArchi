using CarList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarList.Infrastucture.DataBase.Configurations
{
    internal class PersonneConfiguration : IEntityTypeConfiguration<Personne>
    {
        public void Configure(EntityTypeBuilder<Personne> builder)
        {
            builder.ToTable(t => t.HasCheckConstraint(
                    "CK_Personne_Email",
                    "[Email] LIKE '%_@%_.%_'"
                ));

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.FirstName)
                .HasMaxLength(40);

            builder.Property(p => p.LastName)
                .HasMaxLength(40);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(p => p.Cars)
                .WithOne(p => p.personne)
                .HasForeignKey(p => p.PersonneId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
