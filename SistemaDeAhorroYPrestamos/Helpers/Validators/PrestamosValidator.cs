using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SistemaDeAhorroYPrestamos.Helpers.Validators
{
    public class PrestamosValidator
    {

        public PrestamosValidator()
        {

        }

        public bool validate(ModelStateDictionary keys)
        {
            return keys.ContainsKey("Monto") && keys["Monto"].Errors.Count != 0 ||
                keys.ContainsKey("FechaBeg") && keys["FechaBeg"].Errors.Count != 0 ||
                keys.ContainsKey("FechaEnd") && keys["FechaEnd"].Errors.Count != 0 ||
                 keys.ContainsKey("ClienteCedula") && keys["ClienteCedula"].Errors.Count != 0;
        }
    }
}
