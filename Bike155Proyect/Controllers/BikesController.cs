using Bike155Proyect.Models;
using Bike155Proyect.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bike155Proyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikesController : ControllerBase
    {
        private ClassBikesRepositories _bikeRepository;
        public BikesController()
        {
            _bikeRepository = new ClassBikesRepositories();
        }

        [HttpGet]
        public IEnumerable<Bike> ObtenerBikes()
        {
            var bikes = _bikeRepository.ObtenerListaBikes();
            return bikes;
        }
    }
}
