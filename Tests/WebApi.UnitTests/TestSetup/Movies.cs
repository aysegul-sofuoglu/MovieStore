using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
  public static class Movies
  {
    public static void AddMovies(this MovieStoreDbContext context)
    {
        context.Movies.AddRange(

                    new Movie
                    {
                        // ID = 1,
                        GenreId = 1,
                        Title = "Don't Worry Darling",
                        Year = "2022",
                        Director = "Olivia Wilde",
                        Actors = "Florence Pugh, Harry Styles, Olivia Wilde, Chris Pine ",
                        Price = 100,
                        IsActive = true

                    },

                    new Movie
                    {
                        // ID = 2,
                        GenreId = 2,
                        Title = "Avatar",
                        Year = "2009",
                        Director = "James Cameron",
                        Actors = "Sam Worthington, Zoe Saldana, Stephen Lang",
                        Price = 155,
                        IsActive = true

                    },

                    new Movie
                    {
                        // ID = 3,
                        GenreId = 3,
                        Title = "Inside Out",
                        Year = "2015",
                        Director = "Pete Docter",
                        Actors = "Amy Poehler, Nana Spier",
                        Price = 75,
                        IsActive = true

                    }
                    );
    }
  }
}