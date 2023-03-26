namespace SistemaDeAhorroYPrestamos.Controllers.Models.entities
{
    public class CuotaPrestamos
    {
        public CuotaPrestamos()
        {

        }
        public DateTime FechaPlanificada { get; set; }
        public Int32 Monto { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaRealizada { get; set; }
        public string CodigoComproante { get; set; }

    }
}
