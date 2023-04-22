using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeAhorroYPrestamos.Models;

public class CuotaPrestamo
{
    [Column(TypeName = "datetime2")]
    public DateTime? FechaPlanificacion { get; set; }
    
   
    [Column(TypeName = "decimal(9,2)")]
    public decimal? Monto { get; set; }
  
    public string? Tipo { get; set; } 
    [Column(TypeName = "datetime2")]
    public DateTime? FechaRealizado { get; set; }
    
    
    
   
    public int? CodigoComprobante { get; set; }
  
   
   
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int PrestamoCodigo { get; set; }
    [Required]
    [StringLength(11)]
    public string ClienteCedula { get; set; }
   

    public virtual Prestamo PrestamoCodigoNavigation { get; set; }
}
