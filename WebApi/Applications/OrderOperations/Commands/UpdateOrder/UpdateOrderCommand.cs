using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.OrderOperations.Commands.UpdateOrder
{
    public class UpdateOrderCommand
    {
        public UpdateOrderModel Model { get; set; }
        public int OrderId;


        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
       
       
        public UpdateOrderCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            Customer customer = _dbContext.Customers.SingleOrDefault(x => x.Id == Model.CustomerId);
            Movie movies = _dbContext.Movies.SingleOrDefault(x => x.Id == Model.MovieId);
           
            Order order = _dbContext.Orders.SingleOrDefault(x => x.Id == OrderId);

            if (customer is null)
                throw new InvalidOperationException("Müşteri bulunamadı!");
            else if (movies is null)
                throw new InvalidOperationException("Film bulunamadı!");
            else if (order is null)
                throw new InvalidOperationException("ilgili kayda ait veri bulunamadı.");
                
            _mapper.Map<UpdateOrderModel, Order>(Model, order);

            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
        }

    }

    public class UpdateOrderModel
    {
        public int MovieId { get; set; }
        public int CustomerId { get; set; }

    }
}