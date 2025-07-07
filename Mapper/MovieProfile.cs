using AutoMapper;
using ETickets.Data.Enums;
using ETickets.Models;
using ETickets.ViewModels;

namespace ETickets.Mapper
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Cinema.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.ImgUrl, opt => opt.MapFrom(src => $"/Images/{src.ImgUrl}"))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.CinemaId, opt => opt.MapFrom(src => src.CinemaId))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.MovieStatus, opt => opt.MapFrom(src =>
                    DateTime.Now < src.StartDate ? MovieStatus.UpComing :
                    DateTime.Now > src.EndDate ? MovieStatus.Expired :
                    MovieStatus.Available
                ));
        }
    }
}
