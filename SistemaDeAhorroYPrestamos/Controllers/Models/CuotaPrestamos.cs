namespace SistemaDeAhorroYPrestamos.Models
{
    public class CuotaPrestamos
    {
        
        public DateTime FechaPlanificada { get; set; }
        public int Monto { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaRealizada { get; set; }
        public string CodigoComproante { get; set; }

    }
}
