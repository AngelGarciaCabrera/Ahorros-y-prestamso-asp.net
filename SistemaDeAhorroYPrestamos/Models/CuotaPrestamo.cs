using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeAhorroYPrestamos.Models;

public class CuotaPrestamo
{
    [Required]
    public DateTime FechaPlanificacion { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(9,2)")]
    public decimal Monto { get; set; }
    [Required]
    public string? Tipo { get; set; } = null!;
    [Required]
    public DateTime? FechaRealizado { get; set; }
    [Required]
    public int? CodigoComprobante { get; set; }
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int PrestamoCodigo { get; set; }
    
    public string ClienteCedula { get; set; }

    public virtual Prestamo PrestamoCodigoNavigation { get; set; } = null!;
}
