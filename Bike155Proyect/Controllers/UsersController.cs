using Bike155Proyect.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bike155Proyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly BikeBdMateoOrtegaHerrera _context;

        public UsersController(BikeBdMateoOrtegaHerrera context)
        {
            _context = context;
        }

        // DTO para actualizar correo
        public class UpdateEmailDto
        {
            public string Correo { get; set; }
        }

        // POST api/users -> crear nuevo usuario
        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] User nuevoUsuario)
        {
            if (nuevoUsuario == null)
                return BadRequest("Usuario inválido.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _context.Users.Add(nuevoUsuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Devuelve el error para diagnóstico
                return StatusCode(500, $"Error al guardar usuario: {ex.Message}");
            }

            return CreatedAtAction(nameof(ObtenerUsuarioPorId), new { id = nuevoUsuario.Id }, nuevoUsuario);
        }

        // GET api/users/{id} -> obtener usuario por id
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerUsuarioPorId(int id)
        {
            var usuario = await _context.Users.FindAsync(id);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        // PUT api/users/{id} -> modificar correo del usuario
        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarCorreoUsuario(int id, [FromBody] UpdateEmailDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.Correo))
                return BadRequest("Correo inválido.");

            var usuario = await _context.Users.FindAsync(id);
            if (usuario == null)
                return NotFound();

            usuario.Correo = dto.Correo;
            _context.Users.Update(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/users/{id} -> eliminar usuario por id
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            var usuario = await _context.Users.FindAsync(id);
            if (usuario == null)
                return NotFound();

            _context.Users.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
