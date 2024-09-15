using AutoMapper;
using Backend.Data;
using Backend.Data.Entities;
using Backend.Data.Entities.DTOs;
using Backend.Helpers;
using Backend.Helpers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasherHelper _passwordHelper;
        private readonly IMapper _mapper;

        public UserController(ApplicationDbContext context, IMapper mapper, IPasswordHasherHelper passwordHelper)
        {
                _context = context;
                _mapper = mapper;
                _passwordHelper = passwordHelper;
        }

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
    }
}
