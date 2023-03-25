namespace SistemaDeAhorroYPrestamos.Controllers.Models.entities
{
    public class Prestamos
    {
        public Prestamos()
        {

        }
        public string Codigo { get; set; }
        public Int32 Monto { get; set; }
        public DateTime FechaInicio { get; set; }

        public DateTime FechaFinal { get; set; }
        public Int32 interese { get; set; }
    }
}
