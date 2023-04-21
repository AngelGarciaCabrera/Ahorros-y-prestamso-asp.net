using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeAhorroYPrestamos.Models;

public class CuotaInversion
{
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    [Required]
    public DateTime FechaPlanificada { get; set; }
    [Required]
    public string? Tipo { get; set; }
    [Required]
    public DateTime? FechaRealizada { get; set; }
    [Required]
    public int? CodigoComprobante { get; set; }
    [Required]
    public string? CuentaBancoNumero { get; set; }
    [Required]
    public int? CodigoInversion { get; set; }

    public virtual Inversiones? CodigoInversionNavigation { get; set; }

    public virtual CuentaBanco? CuentaBancoNumeroNavigation { get; set; }
}
