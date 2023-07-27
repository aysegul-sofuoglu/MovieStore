using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Applications.OrderOperations.Queries.GetOrder;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.OrderOperations.Queries.GetOrderDetail
{
    public class GetOrderDetailQuery
    {

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int OrderId;

        public GetOrderDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public OrderViewModel Handle()
        {
            Customer customer = _dbContext.Customers.Include(i => i.Orders).ThenInclude(t => t.Movie).SingleOrDefault(s => s.Id == OrderId);
            OrderViewModel vm = _mapper.Map<OrderViewModel>(customer);

            return vm;
        }
    }

    

}