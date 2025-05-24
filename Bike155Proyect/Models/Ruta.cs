using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Bike155Proyect.Models
{
    public class Ruta
    {
        public int Id { get; set; }

        [Required]
        public string Ubicacion { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [ForeignKey("Bike")]
        public int BikeId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        
        public User User { get; set; }

        public Bike Bike { get; set; }

    }


}
