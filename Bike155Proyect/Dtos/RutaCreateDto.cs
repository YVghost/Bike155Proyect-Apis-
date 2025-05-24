using System;
using System.ComponentModel.DataAnnotations;

namespace Bike155Proyect.Dtos
{
    public class RutaCreateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Ubicacion { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int BikeId { get; set; }
    }
}
