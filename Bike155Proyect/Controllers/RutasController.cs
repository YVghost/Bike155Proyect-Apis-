using Bike155Proyect.Models;
using Bike155Proyect.Dtos;  // Asegúrate de tener el namespace correcto para RutaCreateDto
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Bike155Proyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutasController : ControllerBase
    {
        private readonly BikeBdMateoOrtegaHerrera _context;

        public RutasController(BikeBdMateoOrtegaHerrera context)
        {
            _context = context;
        }

        // DTO para modificar fecha
        public class UpdateFechaDto
        {
            public DateTime Fecha { get; set; }
        }

        // POST api/rutas -> crear nueva ruta usando DTO
        [HttpPost]
        public async Task<IActionResult> CrearRuta([FromBody] RutaCreateDto nuevaRutaDto)
        {
            if (nuevaRutaDto == null)
                return BadRequest("Datos de ruta inválidos.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Verificar que el UserId y BikeId existen
            var userExiste = await _context.Users.AnyAsync(u => u.Id == nuevaRutaDto.UserId);
            var bikeExiste = await _context.Bike.AnyAsync(b => b.Id == nuevaRutaDto.BikeId);

            if (!userExiste)
                return BadRequest($"El usuario con ID {nuevaRutaDto.UserId} no existe.");

            if (!bikeExiste)
                return BadRequest($"La bicicleta con ID {nuevaRutaDto.BikeId} no existe.");

            // Crear la entidad Ruta desde el DTO
            var nuevaRuta = new Ruta
            {
                Ubicacion = nuevaRutaDto.Ubicacion,
                Fecha = nuevaRutaDto.Fecha,
                UserId = nuevaRutaDto.UserId,
                BikeId = nuevaRutaDto.BikeId
            };

            try
            {
                _context.Rutas.Add(nuevaRuta);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al guardar la ruta: {ex.Message}");
            }

            return CreatedAtAction(nameof(ObtenerRutaPorId), new { id = nuevaRuta.Id }, nuevaRuta);
        }

        // GET api/rutas -> listar todas las rutas con usuario y bicicleta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ruta>>> ListarRutas()
        {
            var rutas = await _context.Rutas
                .Include(r => r.User)
                .Include(r => r.Bike)
                .ToListAsync();

            return Ok(rutas);
        }

        // GET api/rutas/{id} -> obtener ruta por ID (opcional)
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerRutaPorId(int id)
        {
            var ruta = await _context.Rutas
                .Include(r => r.User)
                .Include(r => r.Bike)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (ruta == null)
                return NotFound();

            return Ok(ruta);
        }

        // PUT api/rutas/{id} -> modificar fecha de la ruta
        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarFechaRuta(int id, [FromBody] UpdateFechaDto dto)
        {
            if (dto == null || dto.Fecha == default)
                return BadRequest("Fecha inválida.");

            var ruta = await _context.Rutas.FindAsync(id);
            if (ruta == null)
                return NotFound();

            ruta.Fecha = dto.Fecha;
            _context.Rutas.Update(ruta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/rutas/{id} -> eliminar ruta
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarRuta(int id)
        {
            var ruta = await _context.Rutas.FindAsync(id);
            if (ruta == null)
                return NotFound();

            _context.Rutas.Remove(ruta);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
