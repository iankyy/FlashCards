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
    public class CardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CardController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("adicionar")]
        public async Task<ActionResult<Card>> AddCard(int deckId, [FromBody] CardDTO request)
        {
            if (request == null )
            {
                return BadRequest("Deu merda, nengue");
            }

            var deck = await _context.Decks.Include(u => u.Cards)
                .FirstOrDefaultAsync(u => u.Id == deckId);

            var newCard = _mapper.Map<Card>(request);

            deck.Cards.Add(newCard);

            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
