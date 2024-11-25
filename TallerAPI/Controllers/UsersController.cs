using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taller.Domain.Entities;
using Taller.infraestructure.interfaces;
using TallerAPI.Services;
using Microsoft.AspNetCore.Identity;
using Taller.Web.Models;
using TallerAPI.DTOS;

namespace TallerAPI.Controllers
{
    public class AuthController : ControllerBase
    {

        private readonly IUsersRepository _usersRepository;
        private readonly AuthService _authService;

        public AuthController(IUsersRepository usersRepository, AuthService authService)
        {
            _usersRepository = usersRepository;
            _authService = authService;
        }

        //Endpoint para loguear a los usuarios
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            //Obtenemos el usuario por el username pasado
            var user = await _usersRepository.GetByUsernameAsync(loginDto.Username);
            //verificamos si es nulo
            if (user == null)
            {
                //retornamos 401, de que no esta autenticado
                return Unauthorized(new { Message = "Usuario o contraseña incorrectos" });
            }


            // Al estar autenticado, hasheamos la password, para compararla con la de la DB
            var passwordHasher = new PasswordHasher<User>();
            //Retorna el valor de la comparacion realizada entre la pass de la bd y la obtenida
            var verificationResult = passwordHasher.VerifyHashedPassword(null, user.Password, loginDto.Password);

            //Verificacion de si la password tiene un resultado distinto a succes, es decir si no son iguales
            if (verificationResult != PasswordVerificationResult.Success)
            {
                //retornamos error de autenticacion (401) al la pass estar incorrecta
                return Unauthorized(new { Message = "Usuario o contraseña incorrectos" });
            }

            // Generamos un token JWT, al usuario colocar sus credenciales correctamente
            var token = _authService.GenerateToken(user);
            //Retornamos el token, junto a un 200
            return Ok(new { Token = token });
        }

        //Endpoint para registar un usuario
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO registerDto)
        {
            //Verificamos si ya existe otro usuario en la bd para evitar errores de integridad
            var existingUser = await _usersRepository.GetByUsernameAsync(registerDto.Username);
            //Si obtenemos un resultado distinto a nulo, quiere decir que existe un usuario ya con ese username
            if (existingUser != null)
            {
                //retornamos un 400, indicando que ya existe un usuario
                return BadRequest(new { Message = "El usuario ya existe" });
            }

            // Creamos el hash de la password del User a crear
            var passwordHasher = new PasswordHasher<User>();

            // Se crea un nuevo user con la pass encriptada
            var newUser = new User
            {
                Username = registerDto.Username,
                Password = passwordHasher.HashPassword(null, registerDto.Password), // Hashing de la contraseña
            };

            //Agregamos los cambios 
            await _usersRepository.AddUserAsync(newUser);
            
            return Ok(new { Message = "Usuario registrado exitosamente" });
        }
    }
}
