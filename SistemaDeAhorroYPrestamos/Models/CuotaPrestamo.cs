using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeAhorroYPrestamos.Models;

public partial class CuotaPrestamo
{
    [Required]
    public DateTime FechaPlanificacion { get; set; }
    [Required]
    public decimal Monto { get; set; }
    [Required]
    public string Tipo { get; set; } = null!;
    [Required]
    public DateTime? FechaRealizado { get; set; }
    [Required]
    public int? CodigoComprobante { get; set; }
    [Key]
    [Required]
    public int PrestamoCodigo { get; set; }

    public virtual Prestamo PrestamoCodigoNavigation { get; set; } = null!;
}
