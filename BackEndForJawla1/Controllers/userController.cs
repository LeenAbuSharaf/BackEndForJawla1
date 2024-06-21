using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndForJawla1.Data;
using BackEndForJawla1.Models;
using BCrypt.Net;

namespace BackEndForJawla1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext _context;

        public UserController(MyDbContext context)
        {
            _context = context;
        }

        // Register a new user
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] user user)
        {
            // Check if the phone number already exists
            if (await _context.user.AnyAsync(u => u.phoneNumber == user.phoneNumber))
            {
                return BadRequest(new { message = "Phone number already exists" });
            }

            // Hash the password
            user.password = BCrypt.Net.BCrypt.HashPassword(user.password);
            _context.user.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User created successfully" });
        }

        // User login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _context.user.SingleOrDefaultAsync(u => u.phoneNumber == request.PhoneNumber);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.password))
            {
                return Unauthorized(new { message = "Invalid phone number or password" });
            }

            return Ok(new { message = "Valid credentials" });
        }

        // Change password
        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var user = await _context.user.SingleOrDefaultAsync(u => u.phoneNumber == request.PhoneNumber);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            if (!BCrypt.Net.BCrypt.Verify(request.OldPassword, user.password))
            {
                return Unauthorized(new { message = "Old password is incorrect" });
            }

            user.password = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            _context.user.Update(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Password changed successfully" });
        }
    }

    public class LoginRequest
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }

    public class ChangePasswordRequest
    {
        public string PhoneNumber { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
