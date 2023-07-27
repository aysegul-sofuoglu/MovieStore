using WebApi.DBOperations;

namespace WebApi.Applications.Commands.UpdateActor{
    public class UpdateActorCommand
    {
        public UpdateActorModel Model { get; set; }
        public int ActorId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        public UpdateActorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

         public void Handle()
            {
            var actor = _dbContext.Actors.SingleOrDefault(x => x.Id == ActorId);
            if(actor is null)
            throw new InvalidOperationException("Actor Does Not Found.");

            if(_dbContext.Actors.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Surname.ToLower() == Model.Surname.ToLower() && x.Id != ActorId))
                throw new InvalidOperationException("There is already an actor with given name.");

            actor.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? actor.Name : Model.Name;
            actor.Surname = string.IsNullOrEmpty(Model.Surname.Trim()) ? actor.Surname : Model.Surname;
            _dbContext.SaveChanges();
            }
    }

    public class UpdateActorModel 
	{
		public string Name { get; set; }
		public string Surname { get; set; }
	}
}