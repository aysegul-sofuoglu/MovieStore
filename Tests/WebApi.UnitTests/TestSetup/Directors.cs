using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Directors
    {
        public static void AddDirectors(this MovieStoreDbContext context)
        {
            context.Directors.AddRange(
                new Director { Name = "Olivia", Surname = "Wilde", FilmsDirected = "Don't Worry Darling", IsActive = true },
                new Director { Name = "James", Surname = "Cameron", FilmsDirected = "Avatar", IsActive = true },
                new Director { Name = "Pete", Surname = "Docter", FilmsDirected = "Inside Out", IsActive = true }
            );
        }
    }
}