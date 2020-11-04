using Customer.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Order.Persistence.Database.Configuration
{
    public class ParentConfiguration
    {
        public ParentConfiguration(EntityTypeBuilder<Parent> entityBuilder)
        {
            entityBuilder.HasKey(x => x.ParentId);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Surname).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Dni).IsRequired();
            entityBuilder.Property(x => x.Email).IsRequired().HasMaxLength(200);
            entityBuilder.Property(x => x.Phone).IsRequired();
            entityBuilder.Property(x => x.Adress).IsRequired().HasMaxLength(200);

            var parents = new List<Parent>();
            var random = new Random();

            for (var i = 1; i <= 10; i++)
            {
                parents.Add(new Parent
                {
                    ParentId = i,
                    Name = $"Parent {i}",
                    Surname= $"Surname {i}",
                    Dni= random.Next(1000000,99999999),
                    Email=$"Email{i}@email.com",
                    Phone=random.Next(100000000,999999999),
                    Adress=$"Adress{i}",
                });
            }

            entityBuilder.HasData(parents);
        }
    }
}
