using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeAhorroYPrestamos.Models;

public partial class Inversione
{
    [Required]
    public int Codigo { get; set; }
    [Required(ErrorMessage = "El monto es requerido")]
    [Range(1000, 3_000_000, ErrorMessage = "El monto debe ser entre mil y 3 millones")]
    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El monto debe tener un máximo de 2 decimales")]
    public decimal Monto { get; set; }
    [Required]
    public DateTime FechaBeg { get; set; }
    [Required]
    public DateTime FechaEnd { get; set; }
   
    [Required]
    [StringLength(14, MinimumLength = 10, ErrorMessage = "La Cuenta no es valida")]
    public string? CuentaBancoNumero { get; set; }
    [Required]
    public string ClienteCedula { get; set; } = null!;
   
    public virtual Cliente ClienteCedulaNavigation { get; set; } = null!;

    public virtual CuentaBanco? CuentaBancoNumeroNavigation { get; set; }

    public virtual ICollection<CuotaInversion>? CuetasInverion { get; set; }
}
