using AutoMapper;
using Backend.Data.Entities.DTOs;

namespace Backend.Data.Entities.Mappers
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<UserDTO, User>();
        }
    }
}
