
//declaracion de valores
const formulario = document.getElementById("Formulario");
const Name = document.getElementById("name");
const contrasena = document.getElementById("contrasena");
const apellido = document.getElementById("lastname");
const cedula = document.getElementById("cedula");
const Direccion = document.getElementById("Direccion");
const Telefono = document.getElementById("Telefono");
const Guardar = document.getElementById("guardar");
const eliminar = document.getElementById("eliminar");
//validacion
function validacion() {

    let isValid = true;
    const valueName = Name.value;
    if (valueName == "" || valueName == null || valueName == undefined) {
        Name.classList.add("input-error");
        isValid = false;

    } else {

        Name.classList.remove("input-error");
        Name.classList.add("input-correct");
    }
    const valueapellido = apellido.value;
    apellido.classList.remove("input-error")
    if (valueapellido == "" || valueapellido == null || valueapellido == undefined) {
        apellido.classList.add("input-error");
        isValid = false;
    } else {
        apellido.classList.remove("input-error");
        apellido.classList.add("input-correct");
    }
    const valuecedula = cedula.value;
    if (valuecedula == "" || valuecedula == null || valuecedula == undefined) {
        cedula.classList.add("input-error");
        isValid = false;
    } else {
        cedula.classList.remove("input-error");
        cedula.classList.add("input-correct");
    }
    const valueDireccion = Direccion.value;
    if (valueDireccion == "" || valueDireccion == null || valueDireccion == undefined) {
        Direccion.classList.add("input-error");
        isValid = false;
    } else {
        Direccion.classList.remove("input-error");
        Direccion.classList.add("input-correct");
    }
    const valueTelefono = Telefono.value;
    if (valueTelefono == "" || valueTelefono == null || valueTelefono == undefined) {
        Telefono.classList.add("input-error");
        isValid = false;
    } else {
        Telefono.classList.remove("input-error");
        Telefono.classList.add("input-correct");
    }
    const contrasenaValue = contrasena.value;
    if (contrasenaValue == "" || contrasenaValue == null || contrasenaValue == undefined || contrasenaValue < 3) {
        contrasena.classList.add("input-error");
        isValid = false;
    } else {
        contrasena.classList.remove("input-error");
        contrasena.classList.add("input-correct");
    }
    return isValid;
}
//funcion clear
function clear() {
    const inputs = formulario.getElementsByTagName("input");


    for (let i = 0; i < inputs.length; i++) {
        if (inputs[i].value === "Enviar") {
            continue
        }
        inputs[i].value = null;
    }
}
//fucion de remover
function RemoverClases() {
    const valueName = Name.value;

    if (valueName == "" || valueName == null || valueName == undefined) {
        Name.classList.remove("input-error");
        Name.classList.remove("input-correct")
        apellido.classList.remove("input-error");
        apellido.classList.remove("input-correct")
        cedula.classList.remove("input-error");
        cedula.classList.remove("input-correct")
        Direccion.classList.remove("input-error")
        Direccion.classList.remove("input-correct")
        Telefono.classList.remove("input-error")
        Telefono.classList.remove("input-correct")
        contrasena.classList.remove("input-error")
        contrasena.classList.remove("input-correct")
    }


}
//eventos 
function guardarDatos() {
    const Datos = {
        name: Name.value,
        contrasena: contrasena.value,
        apellido: apellido.value,
        Telefono: Telefono.value,
        cedula: cedula.value,
        Direccion: Direccion.value,
    };
    console.log(Datos);
}

Guardar.addEventListener("click", function (datos) {
    datos.preventDefault();
    if (validacion()) {
        guardarDatos();
        console.log(Datos).value
    }
});
eliminar.addEventListener("click", function (datos) {
    datos.preventDefault();
    clear();
    RemoverClases();
});

//Register Logica---------------------------------------------------------------------------------




//Login Logica-------------------------------------------------






