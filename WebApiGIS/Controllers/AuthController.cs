using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiGIS.Data;
using WebApiGIS.Dtos.Request;
using WebApiGIS.Models;
using WebApiGIS.Utils;
using WebApiGIS.Validators;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiGIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(WebGisDbContext db, IMapper mapper, IConfiguration configuration) : ControllerBase
    {
        private readonly WebGisDbContext _db = db;
        private readonly IMapper _mapper = mapper;
        private readonly IConfiguration _configuration = configuration;

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginReq loginReq)
        {
            var validator = new LoginValidator();
            try
            {
                var validationResult = await validator.ValidateAsync(loginReq);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());

                var user = await _db.Users
                    .Include(a => a.Role)
                    .FirstOrDefaultAsync(a => a.Email == loginReq.Email);

                if (user is null)
                    return Unauthorized(new { message = "Email or password is incorrect!" });

                if (!BCrypt.Net.BCrypt.Verify(loginReq.Password, user.Password))
                    return Unauthorized(new { message = "Email or password is incorrect!" });

                Claim[] claims = [
                    new Claim(ConstConfig.UserIdClaimType, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ConstConfig.AvatarClaimType, user.Avatar),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role.Name.ToString())
                ];

                var token = new JwtSecurityToken
                (
                    issuer: _configuration.GetSection("Jwt")["Issuer"],
                    audience: _configuration.GetSection("Jwt")["Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(ConstConfig.ExperyTimeJwtToken),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt")["Key"]!)),
                        SecurityAlgorithms.HmacSha256)
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { token = tokenString });
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { message = "Something went wrong" });
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] RegisterReq registerReq)
        {
            try
            {
                var validation = new RegisterValidator();
                var validationResult = await validation.ValidateAsync(registerReq);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());

                var existingAccount = await _db.Users.FirstOrDefaultAsync(a => a.Email == registerReq.Email);
                if (existingAccount is not null)
                    return BadRequest(new { message = "Email account is registerd!" });

                var newAccount = _mapper.Map<User>(registerReq);

                await _db.AddAsync(newAccount);
                await _db.SaveChangesAsync();

                return Created();
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { message = "Something went wrong" });
            }
        }
    }
}
