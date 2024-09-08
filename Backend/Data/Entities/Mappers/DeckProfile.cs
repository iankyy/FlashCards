using AutoMapper;
using Backend.Data.Entities.DTOs;

namespace Backend.Data.Entities.Mappers
{
    public class DeckProfile : Profile
    {

        public DeckProfile()
        {
            CreateMap<DeckDTO, Deck>();
        }
    }
}
