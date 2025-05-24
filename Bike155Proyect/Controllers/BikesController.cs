using Bike155Proyect.Models;
using Bike155Proyect.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bike155Proyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikesController : ControllerBase
    {
        private readonly BikeBdMateoOrtegaHerrera _context;
        private readonly ClassBikesRepositories _bikeRepository;

        public BikesController(BikeBdMateoOrtegaHerrera context)
        {
            _context = context;
            _bikeRepository = new ClassBikesRepositories();

            // Cargar las bicicletas si no existen
            InsertarBikesInicialesSiNoExisten();
        }

        private void InsertarBikesInicialesSiNoExisten()
        {
            var listaInicial = _bikeRepository.ObtenerListaBikes();

            foreach (var bike in listaInicial)
            {
                // Si no existe una bicicleta con el mismo nombre o ID, se inserta
                var existe = _context.Bike.Any(b => b.Tipo == bike.Tipo);

                if (!existe)
                {
                    _context.Bike.Add(bike);
                }
            }

            _context.SaveChanges();
        }

        [HttpGet]
        public IEnumerable<Bike> ObtenerBikes()
        {
            return _context.Bike.ToList();
        }
    }
}
