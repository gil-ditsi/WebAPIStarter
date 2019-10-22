using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPIStarter.Data;
using WebAPIStarter.Data.Models;

namespace WebAPIStarter
{
    public class DatabaseSeed
    {
        public void Initialize(IApplicationBuilder app){
            using (var servicesScope = app.ApplicationServices.CreateScope())
            {
                var context = 
                    servicesScope
                        .ServiceProvider
                        .GetRequiredService<WebAPIStarterContext>();

                if(context.Database.GetPendingMigrations().Any()){
                    context.Database.Migrate();
                }

                if (!context.AddressTypes.Any())
                {
                    context.AddressTypes.AddRange(
                    new AddressType
                        {
                            Id = 1,
                            AddressTypeName = "Home"
                        },
                    new AddressType
                    {
                        Id = 2,
                        AddressTypeName = "Work"
                    },
                    new AddressType
                    {
                        Id = 3,
                        AddressTypeName = "Bill To"
                    },
                    new AddressType
                    {
                        Id = 4,
                        AddressTypeName = "Ship To"
                    });
                }

                if (!context.Addresses.Any())
                {
                    context.Addresses.AddRange(
                        new Address
                        {
                            Id = 1,
                            Line1 = "123 Evergreen Av.",
                            City = "Springfield",
                            StateProvice = "YourKokoro",
                            Zipcode = "00001",
                            AddressTypeId = 1
                        },
                            new Address
                            {
                                Id = 2,
                                Line1 = "237 Charming St.",
                                City = "Brooklyn",
                                StateProvice = "NineNine",
                                Zipcode = "11111",
                                AddressTypeId = 2
                            }
                    );
                }

                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(
                        new Customer
                        {
                            Id = 1,
                            FirstName = "Gil",
                            LastName = "Hdz",
                            Email = "mail.fromwork@udem.com",
                            CustomerAddresses = new List<CustomerAddress> {
                                    new CustomerAddress{ CustomerId = 1, AddressId = 2 }
                                }
                        },
                            new Customer
                            {
                                Id = 2,
                                FirstName = "Paul",
                                LastName = "Goldschmidt",
                                Email = "paul@cardinals.com",
                                CustomerAddresses = new List<CustomerAddress> {
                                    new CustomerAddress{ CustomerId = 2, AddressId = 2 }
                                }
                            },
                            new Customer
                            {
                                Id = 3,
                                FirstName = "Bilbo",
                                LastName = "Baggins",
                                Email = "BilboB@theshire.net",
                                CustomerAddresses = new List<CustomerAddress> {
                                    new CustomerAddress{ CustomerId = 3, AddressId = 1 }
                                }
                            }
                    );
                }

                context.SaveChanges();
                
            }
        }
    }
}