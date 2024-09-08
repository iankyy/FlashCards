using AutoMapper;
using Backend.Data;
using Backend.Data.Entities;
using Backend.Data.Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeckController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeckController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost("createDeck")]
        public async Task<ActionResult<Deck>> CreateDeck(int id , [FromBody] DeckDTO deck)
        {
            if (deck == null || string.IsNullOrEmpty(deck.Name))
            {
                return BadRequest("Invalid Deck Name");
            }

            var user = await _context.Users.Include(u => u.Decks)
                .FirstOrDefaultAsync(u => u.Id == id);

            var newDeck = _mapper.Map<Deck>(deck);

            user.Decks.Add(newDeck);

            await _context.SaveChangesAsync();
            return Ok(deck);

        }

        //private Deck MapDeckDTOToDeck(DeckDTO deckDTO)
        //{
        //    return new Deck
        //    {
        //        Name = deckDTO.Name,
        //        // Initialize other properties if needed
        //    };
        //}

    }
}
