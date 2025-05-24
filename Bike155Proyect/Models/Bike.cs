using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Bike155Proyect.Models
{
    public class Bike
    {
        public int Id { get; set; }

        [Required]
        public string Tipo { get; set; }

    }

}
