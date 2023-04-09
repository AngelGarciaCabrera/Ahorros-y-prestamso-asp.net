namespace SistemaDeAhorroYPrestamos.Models
{
    public class Prestamos
    {
       
        public string Codigo { get; set; }
        public int Monto { get; set; }
        public DateTime FechaInicio { get; set; }

        public DateTime FechaFinal { get; set; }
        public int interese { get; set; }
    }
}
