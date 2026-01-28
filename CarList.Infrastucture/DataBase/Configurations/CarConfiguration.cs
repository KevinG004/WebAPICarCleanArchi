using CarList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarList.Infrastucture.DataBase.Configurations
{
    internal class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable(t => t.HasCheckConstraint(
                   "CK_Car_Tire",
                   "[Tire] IN (3,4,6)"
               ));

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Models)
                .IsRequired()
                .HasMaxLength(40);
        }
    }
}
