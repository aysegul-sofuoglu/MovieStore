using WebApi.DBOperations;

namespace WebApi.Applications.Commands.DeleteActor
{
    public class DeleteActorCommand
    {
        public int ActorId { get; set; }

        private readonly IMovieStoreDbContext _dbContext;

        public DeleteActorCommand(IMovieStoreDbContext dbContext)
        {
            
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(x => x.Id == ActorId);

            if (actor == null)
                throw new InvalidOperationException("Oyuncu Bulunamadı ! ");

            _dbContext.Actors.Remove(actor);
            _dbContext.SaveChanges();
        }
    }
}

    