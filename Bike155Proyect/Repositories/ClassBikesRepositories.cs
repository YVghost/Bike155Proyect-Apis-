using Bike155Proyect.Models;

namespace Bike155Proyect.Repositories
{
    public class ClassBikesRepositories
    {
        public IEnumerable<Bike> ObtenerListaBikes()
        {
            List<Bike> bikes = new List<Bike>();
            Bike TipoBike1 = new Bike
            {
                Id = 1,
                Tipo = "BMX"
            };
            Bike TipoBike2 = new Bike
            {
                Id = 2,
                Tipo = "DH"
            };

            Bike TipoBike3 = new Bike
            {
                Id = 3,
                Tipo = "RUTA"
            };
            bikes.Add(TipoBike1);
            bikes.Add(TipoBike2);
            bikes.Add(TipoBike3);
            return bikes;
        }
    }
}
