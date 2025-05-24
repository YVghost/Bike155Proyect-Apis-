using Bike155Proyect.Models;
using System.Collections.Generic;

namespace Bike155Proyect.Repositories
{
    public class ClassBikesRepositories
    {
        public List<Bike> ObtenerListaBikes()
        {
            return new List<Bike>
            {
                new Bike
                {
                    Tipo = "BMX",
                },
                new Bike
                {
                    Tipo = "Ruta",
                },
                new Bike
                {
                    Tipo = "Gravel",
                },
                new Bike
                {
                    Tipo = "DH",
                }
            };
        }
    }
}
