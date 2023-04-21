using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SistemaDeAhorroYPrestamos.Helpers.Validators
{
    public class InversionValidator
    {
        public InversionValidator() 
        {
        
        }
        public bool validateErrors(ModelStateDictionary keys)
        {
            return keys.ContainsKey("Monto") && keys["Monto"].Errors.Count != 0 ||
                keys.ContainsKey("FechaBeg") && keys["FechaBeg"].Errors.Count != 0 ||
                keys.ContainsKey("FechaEnd") && keys["FechaEnd"].Errors.Count != 0 ||
                 keys.ContainsKey("ClienteCedula") && keys["ClienteCedula"].Errors.Count != 0 ||
                 keys.ContainsKey("CuentaBancoNumero") && keys["CuentaBancoNumero"].Errors.Count != 0;
        }
    }
}
