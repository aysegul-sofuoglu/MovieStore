using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.DirectorOperations.Commands.UpdateDirector
{
public class UpdateDirectorCommand
    {

        public UpdateDirectorModel Model { get; set; }
        public int GenreId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateDirectorCommand(IMovieStoreDbContext movieStoreDbContext, IMapper mapper)
        {
            _dbContext = movieStoreDbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(x => x.Id == GenreId);

            if (director == null)
            {
                throw new InvalidOperationException("Yönetmen Bulunamadı !");
            }


            _mapper.Map<UpdateDirectorModel, Director>(Model, director);

            _dbContext.Directors.Update(director);
            _dbContext.SaveChanges();
        }
    }

    public class UpdateDirectorModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FilmsDirected { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
