using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommand
    {
        public CreateCustomerModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateCustomerCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
           
            _dbContext = dbContext;
            _mapper = mapper;
        }

          public void Handle()
        {
            var customer = _dbContext.Customers.SingleOrDefault(x => x.Email == Model.Email);

            if (customer != null)
                throw new InvalidOperationException("Film zaten mevcut.");

            customer = _mapper.Map<Customer>(Model);

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
        }
    }

    public class CreateCustomerModel
    {
       
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    
}