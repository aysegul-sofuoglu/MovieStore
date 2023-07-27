using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if(context.Movies.Any())
                {
                    return;
                }

                context.Directors.AddRange(
                new Director { Name = "Olivia", Surname = "Wilde", FilmsDirected = "Don't Worry Darling", IsActive = true },
                new Director { Name = "James", Surname = "Cameron", FilmsDirected = "Avatar", IsActive = true },
                new Director { Name = "Pete", Surname = "Docter", FilmsDirected = "Inside Out", IsActive = true }
          );
                context.SaveChanges();

                context.Actors.AddRange(
                  new Actor { Name = "Florence", Surname = "Pugh", PlayedMovies = "Don't Worry Darling", IsAvtive = true },
                  new Actor { Name = "Harry", Surname = "Styles", PlayedMovies = "Don't Worry Darling", IsAvtive = true },
                  new Actor { Name = "Olivia", Surname = "Wilde", PlayedMovies = "Don't Worry Darling", IsAvtive = true },
                  new Actor { Name = "Chris", Surname = "Pine", PlayedMovies = "Don't Worry Darling", IsAvtive = true },
                  new Actor { Name = "Sam", Surname = "Worthington", PlayedMovies = "Avatar", IsAvtive = true },
                  new Actor { Name = "Zoe", Surname = "Saldana", PlayedMovies = "Avatar", IsAvtive = true },
                  new Actor { Name = "Stephen", Surname = "Lang", PlayedMovies = "Avatar", IsAvtive = true },
                  new Actor { Name = "Amy", Surname = "Poehler", PlayedMovies = "Inside Out", IsAvtive = true },
                  new Actor { Name = "Nana", Surname = "Spier", PlayedMovies = "Inside Out", IsAvtive = true }
                  );
                context.SaveChanges();

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

                context.Genres.AddRange(
                   new Genre
                   {
                       Name = "Horror thriller"
                   },
                   new Genre
                   {
                       Name = "Bilimkurgu "
                   },
                   new Genre
                   {
                       Name = "Animasyon"
                   }
               );
                context.SaveChanges();

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


                context.SaveChanges();

                context.Orders.AddRange(
                  new Order { CustomerId = 1 , MovieId = 1, purchasedTime = new DateTime(2023, 07, 11) , IsActive = true },
                  new Order { CustomerId = 2 , MovieId = 1, purchasedTime = new DateTime(2023, 12, 09) , IsActive = true },
                  new Order { CustomerId = 3 , MovieId = 2, purchasedTime = new DateTime(2012, 05, 25) , IsActive = true }
                  );

                context.SaveChanges();
            }
        }
    }
}