
const formulario = document.getElementById("Formulario");
const Name = document.getElementById("name");
const contrasena = document.getElementById("contrasena");
const apellido = document.getElementById("lastname");
const cedula = document.getElementById("cedula");
const Direccion = document.getElementById("Direccion");
const Telefono = document.getElementById("Telefono");
const Guardar = document.getElementById("guardar");

let nombreP = document.getElementById('Nombrep');
let apellidoP = document.getElementById('ApellidoP');
let cedulaP = document.getElementById("cedulaP")
let DireccionP = document.getElementById('DireccionP');
let TelefonoP = document.getElementById('telefonoP');
let contrasenaP = document.getElementById('contraseñaP');





//validacion

function validacion() {

    let isValid = true;
    const valueName = Name.value;
    if (valueName == "" || valueName == null || valueName == undefined) {
        nombreP.style.display = 'block';
        isValid = false;

    } else {

        nombreP.style.display = 'none';
    }
    const valueapellido = apellido.value;

    if (valueapellido == "" || valueapellido == null || valueapellido == undefined) {
        apellidoP.style.display = 'block';
        isValid = false;
    } else {
        apellidoP.style.display = 'none';
    }
    const valuecedula = cedula.value;
    if (valuecedula == "" || valuecedula == null || valuecedula == undefined || valuecedula.length !== 11) {
        cedulaP.style.display = 'block';
        isValid = false;
    } else {
        cedulaP.style.display = 'none';
    }
    const valueDireccion = Direccion.value;
    if (valueDireccion == "" || valueDireccion == null || valueDireccion == undefined) {
        DireccionP.style.display = 'block';
        isValid = false;
    } else {
        DireccionP.style.display = 'none';
    }
    const valueTelefono = Telefono.value;
    if (valueTelefono == "" || valueTelefono == null || valueTelefono == undefined) {
        TelefonoP.style.display = 'block';
        isValid = false;
    } else {
        TelefonoP.style.display = 'none';
    }
    const contrasenaValue = contrasena.value;
    if (contrasenaValue == "" || contrasenaValue == null || contrasenaValue == undefined || contrasenaValue < 3) {
        contrasenaP.style.display = 'block';
        isValid = false;
    } else {
        contrasenaP.style.display = 'none';
    }
    return isValid;
}
//funcion clear

//fucion de remover

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
    window.location.href = '/Home/SegundoHome';
}

Guardar.addEventListener("click", function (datos) {
    datos.preventDefault();
    if (validacion()) {
        guardarDatos();
        console.log(Datos).value
    }
});






