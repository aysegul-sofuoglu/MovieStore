using AutoMapper;
using WebApi.Application.MovieOperations.Commands.CreateMovie;
using WebApi.Applications.ActorOperations.Queries.GetActor;
using WebApi.Applications.ActorOperations.Queries.GetActorDetail;
using WebApi.Applications.Commands.CreateActor;
using WebApi.Applications.CustomerOperations.Commands.CreateCustomer;
using WebApi.Applications.DirectorOperations.Commands.CreateDirector;
using WebApi.Applications.DirectorOperations.Commands.UpdateDirector;
using WebApi.Applications.DirectorOperations.Queries.GetDirector;
using WebApi.Applications.DirectorOperations.Queries.GetDirectorDetail;
using WebApi.Applications.MovieOperations.Commands.UpdateMovie;
using WebApi.Applications.MovieOperations.Queries.GetMovie;
using WebApi.Applications.MovieOperations.Queries.GetMovieDetail;
using WebApi.Applications.OrderOperations.Commands.CreateOrder;
using WebApi.Applications.OrderOperations.Commands.UpdateOrder;
using WebApi.Applications.OrderOperations.Queries.GetOrder;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //actor
            CreateMap<Actor, CreateActorModel>().ReverseMap();
            CreateMap<Actor, GetActorModel>().ReverseMap();
            CreateMap<Actor, ActorDetailModel>();

            //customer
            CreateMap<Customer, CreateCustomerModel>().ReverseMap();

            //movie
            CreateMap<Movie, MovieViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Movie, MovieDetailModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Movie, CreateMovieModel>().ReverseMap();
            CreateMap<UpdateMoveiModel, Movie>().ReverseMap();

            //director
            CreateMap<Director, CreateDirectorModel>().ReverseMap();
            CreateMap<Director, UpdateDirectorModel>().ReverseMap();
            CreateMap<Director, GetDirectorModel>().ReverseMap();
            CreateMap<Director, GetDirectorDetailModel>().ReverseMap();

            //order
            CreateMap<CreateOrderModel, Order>().ReverseMap();
            CreateMap<UpdateOrderModel, Order>().ReverseMap();

           
            CreateMap<Customer, OrderViewModel>()
                .ForMember(dest => dest.NameSurname, opt => opt.MapFrom(m => m.Name + " " + m.Surname))
                .ForMember(dest => dest.Movies, opt => opt.MapFrom(m => m.Orders.Select(s => s.Movie.Title)))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(m => m.Orders.Select(s => s.Movie.Price)))
                .ForMember(dest => dest.PurchasedDate, opt => opt.MapFrom(m => m.Orders.Select(s => s.purchasedTime)));
        }
    }
}