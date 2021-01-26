using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleAPI.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {               
                entity.HasData(new Customer { Id = 1, Firstname = "Jack", Lastname = "Sparrow" });
            }
          );

            modelBuilder.Entity<Order>(entity => {              
                entity.HasData(
                    new Order { Id = 1, CustomerId = 1, Details = "Sale 1", Total = 19M },
                    new Order { Id = 2, CustomerId = 1, Details = "Sale 2", Total = 9.99M }
                   );
            });
        }
    }
}
