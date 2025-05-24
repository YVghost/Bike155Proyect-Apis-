using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Bike155Proyect.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Correo { get; set; }

        [JsonIgnore]
        public ICollection<Bike> Bikes { get; set; }
    }

}
