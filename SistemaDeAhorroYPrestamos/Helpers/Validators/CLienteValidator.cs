using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SistemaDeAhorroYPrestamos.Helpers.Validators
{
    public class ClienteValidator
    {

        public ClienteValidator()
        {

        }

        //Login

        public bool validateErrors(ModelStateDictionary keys)
        {
            return keys.ContainsKey("Cedula") && keys["Cedula"].Errors.Count != 0 ||
                    keys.ContainsKey("Contrasena") && keys["Contrasena"].Errors.Count != 0;
        }

        public bool validateRegisterErrors(ModelStateDictionary keys)
        {
            return keys.ContainsKey("Cedula") && keys["Cedula"].Errors.Count != 0 ||
                keys.ContainsKey("Nombre") && keys["Nombre"].Errors.Count != 0 ||
                keys.ContainsKey("Apellido") && keys["Apellido"].Errors.Count != 0 ||
                keys.ContainsKey("Direccion") && keys["Direccion"].Errors.Count != 0 ||
                keys.ContainsKey("Telefono") && keys["Telefono"].Errors.Count != 0 ||
                keys.ContainsKey("Contrasena") && keys["Contrasena"].Errors.Count != 0;
        }
    }
}
