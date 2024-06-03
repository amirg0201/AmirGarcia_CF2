namespace AmirGarcia_EjercicioCF.Models
{
    public class Promo
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public DateTime fechaPromo { get; set; }

        public int Burgerid { get; set; }
        public Burger? Burger { get; set; }
    }
}
