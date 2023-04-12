using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeAhorroYPrestamos.Models;

public class Prestamo
{

    [Required]
    [Key]
    public int Codigo { get; set; }


    [Required(ErrorMessage = "El Monto es requerido")]
    [Range(1000, 3_000_000, ErrorMessage = "El monto debe ser entre mil y 3 millones")]
    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El monto debe tener un máximo de 2 decimales")]
    [Column(TypeName = "decimal(9,2)")]
    public decimal Monto { get; set; }
   
    [DataType(DataType.Date, ErrorMessage = "La fecha inicial debe ser de tipo DateTime")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime FechaBeg { get; set; }

    [DataType(DataType.Date, ErrorMessage = "La fecha final debe ser de tipo DateTime")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Required]
    public DateTime FechaEnd { get; set; }
    [Required]
    [Column(TypeName = "decimal(9,2)")]
    public decimal Interes { get; set; }
    [Required]
    public string ClienteCedula { get; set; } = null!;

    public virtual Cliente ClienteCedulaNavigation { get; set; } = null!;

    public virtual ICollection<Garantia> Garantia { get; } = new List<Garantia>();
    public virtual ICollection<CuotaPrestamo> CuotasPrestamo { get; } = new List<CuotaPrestamo>();
}
