using AutoMapper;
using Pamonharia.Application.ViewModels;
using Pamonharia.Domain.Entities;

namespace Pamonharia.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapeia a Entidade para a ViewModel e vice-versa
            CreateMap<Pamonha, PamonhaViewModel>().ReverseMap();
        }
    }
}