
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Actors
    {
        public static void AddActors(this MovieStoreDbContext context)
        {
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
        }
    }
}