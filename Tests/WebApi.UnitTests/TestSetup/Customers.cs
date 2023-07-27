using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Customers
    {
        public static void AddCustomers(this MovieStoreDbContext context)
        {
            context.Customers.AddRange(
            new Customer
            {
                Name = "Ayşegül",
                Surname = "Sofuoğlu",
                Email = "aysegulsofuoglu@gmail.com",
                Password = "123456",
                IsActive = true

            },
            new Customer
            {
                Name = "Ayse",
                Surname = "Sofu",
                Email = "aysesofu@gmail.com",
                Password = "123456",
                IsActive = true

            });
        }
    }
}