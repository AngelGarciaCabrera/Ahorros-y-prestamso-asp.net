﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeAhorroYPrestamos.Models;

public class Inversiones
{
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Codigo { get; set; }
    [Required(ErrorMessage = "El monto es requerido")]
    [Range(1000, 3_000_000, ErrorMessage = "El monto debe ser entre mil y 3 millones")]
    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El monto debe tener un máximo de 2 decimales")]
    [Column(TypeName = "decimal(9,2)")]
    public decimal Monto { get; set; }
    [Required]
    [DataType(DataType.Date, ErrorMessage = "La fecha inicial debe ser de tipo DateTime")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime FechaBeg { get; set; }
    
    [Required]
    [DataType(DataType.Date, ErrorMessage = "La fecha final debe ser de tipo DateTime")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime FechaEnd { get; set; }
   
    [Required]
    [StringLength(14, MinimumLength = 10, ErrorMessage = "La Cuenta no es valida")]

    public string? CuentaBancoNumero { get; set; }
    [Required]
    public string ClienteCedula { get; set; } = null!;
   
    public virtual Cliente ClienteCedulaNavigation { get; set; } = null!;

    public virtual CuentaBanco? CuentaBancoNumeroNavigation { get; set; }

    public virtual ICollection<CuotaInversion>? CuetasInversion { get; set; }
    [Required]
    [Column(TypeName = "decimal(5,2)")]
    public decimal Interes { get; set; }
}
