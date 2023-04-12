using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeAhorroYPrestamos.Models;

public class CuentaBanco
{
    [Key]
    [Required]
    [StringLength(14, MinimumLength =10,ErrorMessage ="La Cuenta no es valida")]
    public string Numero { get; set; } = null!;
    [Required]
    public string Banco { get; set; } = null!;
    [Required]
    public string Tipo { get; set; } = null!;

    [Required(ErrorMessage = "La cedula es requerida")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "La cedula no es valida")]
    public string? ClienteCedula { get; set; }

    public virtual Cliente? ClienteCedulaNavigation { get; set; }

    public virtual Inversiones? Inversione { get; set; }
}
