using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeAhorroYPrestamos.Models;

public partial class Garantium
{
    [Required]
    public int Codigo { get; set; }
    [Required]
    public string Tipo { get; set; } = null!;
    [Required]
    public decimal Valor { get; set; }
    [Required]
    public string? Ubicacion { get; set; }
    [Required]
    public int PrestamoCodigo { get; set; }

    public virtual Prestamo PrestamoCodigoNavigation { get; set; } = null!;
}
