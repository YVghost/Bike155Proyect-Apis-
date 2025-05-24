using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Bike155Proyect.Models
{
    public class Bike
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("tipo")]
        public string Tipo { get; set; } // "BMX", "DH", "Ruta"

        [Required]
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonIgnore] 
        public User User { get; set; }

        [JsonIgnore]
        public ICollection<Ruta> Rutas { get; set; }
    }

}
