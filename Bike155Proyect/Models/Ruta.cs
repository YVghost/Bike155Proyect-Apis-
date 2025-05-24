using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Bike155Proyect.Models
{
    public class Ruta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }

        [Required]
        [JsonPropertyName("bike_id")]
        public int BikeId { get; set; }

        [JsonIgnore]
        public Bike Bike { get; set; }
    }


}
