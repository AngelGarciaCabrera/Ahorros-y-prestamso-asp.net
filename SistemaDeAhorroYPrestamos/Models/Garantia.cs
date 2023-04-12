using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeAhorroYPrestamos.Models;

public class Garantia
{
    [Required]
    [Key]
    public int Codigo { get; set; }
    [Required]
    public string Tipo { get; set; } = null!;
    [Required]
    [Column(TypeName = "decimal(9,2)")]
    public decimal Valor { get; set; }
    [Required]
    public string? Ubicacion { get; set; }
    [Required]
    public int PrestamoCodigo { get; set; }

    public virtual Prestamo PrestamoCodigoNavigation { get; set; } = null!;
}
