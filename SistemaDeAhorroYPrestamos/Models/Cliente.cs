using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeAhorroYPrestamos.Models;

public class Cliente
{
    [Key]
    [Required(ErrorMessage = "La cedula es requerida")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "La cedula no es valida")]
    public string Cedula { get; set; } = null!;

    [Required(ErrorMessage = "El nombre es requerida")]
    [StringLength(15, MinimumLength = 11, ErrorMessage = "La nombre no es valida")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "La Apellido es requerida")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "La Apellido no es valida")]
    public string Apellido { get; set; } = null!;

    [Required(ErrorMessage = "La Direccion es requerida")]
    [StringLength(50, MinimumLength = 20, ErrorMessage = "La Direccion no es valida")]
    public string? Direccion { get; set; }

    [RegularExpression(@"^\d{10}$", ErrorMessage = "El campo Teléfono debe tener un formato válido")]
    public string? Telefono { get; set; }

    [Required(ErrorMessage = "La contraseña es requerida")]
    [StringLength(50, MinimumLength = 8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
    /// [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,50}$", ErrorMessage = "La contraseña debe tener al menos 1 letra mayúscula, 1 letra minúscula, 1 número y 1 carácter especial")]
    public string? Contrasena { get; set; }
    
    public string? IdCuentaBanco { get; set; }
    
    
    
    public virtual CuentaBanco? CuentaBancoNavigation { get; set; }

    public virtual ICollection<Inversiones> Inversiones { get; } = new List<Inversiones>();

    public virtual ICollection<Prestamo> Prestamos { get; } = new List<Prestamo>();
}