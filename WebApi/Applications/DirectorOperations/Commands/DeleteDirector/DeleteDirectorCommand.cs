using WebApi.DBOperations;

namespace WebApi.Applications.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        public int DirectorId { get; set; }

        private readonly IMovieStoreDbContext _dbContext;


        public DeleteDirectorCommand(IMovieStoreDbContext movieStoreDbContext)
        {
            _dbContext = movieStoreDbContext;

        }
        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(m => m.Id == DirectorId);

            if (director == null)
                throw new InvalidOperationException("Yönetmen Bulunamadı ! ");

            _dbContext.Directors.Remove(director);
            _dbContext.SaveChanges();



        }
    }
}