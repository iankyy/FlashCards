using AutoMapper;
using Backend.Data;
using Backend.Data.Entities;
using Backend.Data.Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserController(ApplicationDbContext context, IMapper mapper)
        {
                _context = context;
                _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> CreateUser(UserDTO request)
        {

            var newRequest = _mapper.Map<User>(request);

            _context.Users.Add(newRequest);

            await _context.SaveChangesAsync();

            return Ok(newRequest);
        }
    }
}
