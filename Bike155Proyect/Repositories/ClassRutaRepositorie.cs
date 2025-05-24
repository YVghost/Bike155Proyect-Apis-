using Bike155Proyect.Models;
using Microsoft.EntityFrameworkCore;

namespace Bike155Proyect.Repositories
{
    public class ClassRutaRepositorie
    {
        private readonly BikeBdMateoOrtegaHerrera _context;

        public ClassRutaRepositorie(BikeBdMateoOrtegaHerrera context)
        {
            _context = context;
        }

        // 1. Crear ruta
        public async Task<Ruta> CrearRutaAsync(Ruta ruta)
        {
            _context.Ruta.Add(ruta);
            await _context.SaveChangesAsync();
            return ruta;
        }


        // 3. Eliminar ruta por ID
        public async Task<bool> EliminarRutaPorIdAsync(int id)
        {
            var ruta = await _context.Ruta.FindAsync(id);
            if (ruta == null) return false;

            _context.Ruta.Remove(ruta);
            await _context.SaveChangesAsync();
            return true;
        }

        // 4. Modificar fecha por ID
        public async Task<bool> ModificarFechaRutaAsync(int id, DateTime nuevaFecha)
        {
            var ruta = await _context.Ruta.FindAsync(id);
            if (ruta == null) return false;

            ruta.Fecha = nuevaFecha;
            await _context.SaveChangesAsync();
            return true;
        }

        // 5. Modificar ubicación por ID
        public async Task<bool> ModificarUbicacionRutaAsync(int id, string nuevaUbicacion)
        {
            var ruta = await _context.Ruta.FindAsync(id);
            if (ruta == null) return false;

            ruta.Ubicacion = nuevaUbicacion;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
