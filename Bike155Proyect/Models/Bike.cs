using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Bike155Proyect.Models
{
    public class Bike
    {
        [Key]
        [JsonRequired]
        public int BikeId { get; set; }
        [JsonRequired]
        public string Tipo { get; set; }
        //[JsonIgnore]
        public string Descripcion { get; set; }


    }
}
