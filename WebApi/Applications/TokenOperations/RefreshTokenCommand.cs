using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.TokenOperations
{
    public class RefreshTokenCommand
    {
        public string RefrehToken;

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public RefreshTokenCommand(IMovieStoreDbContext movieStoreDbContext, IConfiguration configuration)
        {
            _dbContext = movieStoreDbContext;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.RefreshToken == RefrehToken && x.RefreshTokenExpireDate > DateTime.Now);
            if (customer != null)
            {

                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(customer);

                customer.RefreshToken = token.RefreshToken;
                customer.RefreshTokenExpireDate = token.Experation.AddMinutes(5);

                _dbContext.SaveChanges();
                return token;

            }
            else
            {
                throw new InvalidOperationException("Valid bir refresh token bulunamadı !");
            }
        }

    }
}