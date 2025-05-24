using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Bike155Proyect.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [JsonIgnore] 
        public ICollection<Bike> Bikes { get; set; }
    }

}
