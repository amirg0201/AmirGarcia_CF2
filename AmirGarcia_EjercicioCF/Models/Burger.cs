using System.ComponentModel.DataAnnotations;

namespace AmirGarcia_EjercicioCF.Models
{
    public class Burger
    {
        public int id { get; set; }

        [Required]
        public string? Name { get; set; }
        public bool WithCheese { get; set; }
        [Range(0.01, 9999.99)]
        public decimal Precio { get; set; }
    }
}
