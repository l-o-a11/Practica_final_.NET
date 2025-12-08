using Microsoft.AspNetCore.Mvc;
using PracticaFinal.Inderfaces;
using PracticaFinal.Services;
using PracticaFinal.DTOs;
using PracticaFinal.Model;


namespace PracticaFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _users;
        private readonly PasswordService _password;
        private readonly JwtServices _jwt;

        public AuthController(IUserRepository users, PasswordService password, JwtServices jwt)
        {
            _users = users;
            _password = password;
            _jwt = jwt;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(UserRegisterDto dto)
        {
            var exist = await _users.GetByUsernameAsync(dto.Username);
            if (exist != null)
                return BadRequest("El usuario ya existe");

            var user = new User
            {
                Username = dto.Username,
                PasswordHash = _password.Hash(dto.Password)
            };
            await _users.RegisterAsync(user);
            return Ok("Usuario registrado correctamente");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(UserLoginDto dto)
        {
            var user = await _users.GetByUsernameAsync(dto.Username);
            if (user == null)
                return Unauthorized("Usuario no encontrado");
            if (!_password.Verify(dto.Password, user.PasswordHash))
                return Unauthorized("Usuario o contraseña incorrectos");
            var token = _jwt.Generate(user);
            return Ok(new { token });
        }

    }
}