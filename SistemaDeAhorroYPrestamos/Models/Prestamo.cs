using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeAhorroYPrestamos.Models;

public partial class Prestamo
{

    [Required]
    public int Codigo { get; set; }
  
    [Required(ErrorMessage = "El monto es requerido")]
    [Range(1000, 3_000_000, ErrorMessage = "El monto debe ser entre mil y 3 millones")]
    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El monto debe tener un máximo de 2 decimales")]

    public decimal Monto { get; set; }
    [Required(ErrorMessage = "La fecha inicial es requerida")]
    [DataType(DataType.Date, ErrorMessage = "La fecha inicial debe ser de tipo DateTime")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime FechaBeg { get; set; }
    [Required]
    public DateTime FechaEnd { get; set; }
    [Required]
    public decimal Interes { get; set; }
    [Required]
    public string ClienteCedula { get; set; } = null!;

    public virtual Cliente ClienteCedulaNavigation { get; set; } = null!;

    public virtual ICollection<Garantium> Garantia { get; } = new List<Garantium>();
    public virtual ICollection<CuotaPrestamo> CuotasPrestamo { get; } = new List<CuotaPrestamo>();
}
