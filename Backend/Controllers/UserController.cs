using AutoMapper;
using Backend.Data;
using Backend.Data.Entities;
using Backend.Data.Entities.DTOs;
using Backend.Helpers;
using Backend.Helpers.Interfaces;
using Backend.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(ApplicationDbContext context, IMapper mapper, IPasswordHasherHelper passwordHelper) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IPasswordHasherHelper _passwordHelper = passwordHelper;
        private readonly IMapper _mapper = mapper;

        [HttpPost("register")]
        public async Task<ActionResult<User>> CreateUser(UserDTO request)
        {
            var existingUser = await _context.Users
                .SingleOrDefaultAsync(x => x.Username == request.Username);

            if (existingUser != null)
            {
                throw new Exception("Username already exists");
            }

            request.Password = _passwordHelper.Hash(request.Password);

            var newRequest = _mapper.Map<User>(request);

            _context.Users.Add(newRequest);

            await _context.SaveChangesAsync();

            return Ok(newRequest);
        }

        [HttpPost("login")]

        public async Task<IActionResult> LoginUser([FromBody] UserDTO user)
        {
            var existingUser = await _context.Users.SingleOrDefaultAsync(x => x.Username == user.Username);
            if (existingUser == null)
            {
                throw new Exception("User doesn't exist");
            }

            var passwordMatches = _passwordHelper.VerifyPassword(user.Password, existingUser.Password);

            if (passwordMatches)
            {
                var mappedUser = _mapper.Map<User>(user);
                var jwtToken = AuthHelpers.GenerateJWTToken(mappedUser);

                return Ok(new { Token = jwtToken });
            }
            else
            {
                return Unauthorized("Your credentials are incorrect");
            }
          
        }
    }
}
