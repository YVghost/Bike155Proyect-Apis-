using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Bike155Proyect.Models
{
    public class Ruta
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Ubicacion { get; set; }

        [Required]
        public string Dificultad { get; set; }

        [ForeignKey("Bike")]
        public int BikeId { get; set; }

        [JsonIgnore]
        public Bike Bike { get; set; }

    }


}
