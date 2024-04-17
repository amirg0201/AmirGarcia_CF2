using System.ComponentModel.DataAnnotations;

namespace AmirGarcia_EjercicioCF.Models
{
    public class AG_Promo
    {
        public int ID { get; set; }
        public string? descripcion { get; set; }
        public DateTime fechaProm { get; set; }
        public int BurgerId { get; set; }
        public Burger? Burger { get; set; }
    }
}
