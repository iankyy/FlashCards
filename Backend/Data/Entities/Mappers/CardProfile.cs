using AutoMapper;
using Backend.Data.Entities.DTOs;

namespace Backend.Data.Entities.Mappers
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<CardDTO, Card>();
        }
    }
}
