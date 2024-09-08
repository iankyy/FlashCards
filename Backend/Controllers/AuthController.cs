using AutoMapper;
using Backend.Data;
using Backend.Data.Entities;
using Backend.Data.Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public AuthController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO request)
        {
            if(request == null || string.IsNullOrEmpty(request.Username))
            {
                return BadRequest();
            }

            var newUser = _mapper.Map<User>(request);

            _context.Users.Add(newUser);

            await _context.SaveChangesAsync();
            

            return Ok(newUser);
        }

    }
}
