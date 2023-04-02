
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



//Registro inversioes logic---------------------------
const monto = document.getElementById("monto");
const fechaInicial = document.getElementById("fechabeng");
const fechaFinal = document.getElementById("fechaend");
const interes = document.getElementById("interes");
const form = document.querySelector('form');

// Generar código aleatorio
function AsignacionDeCodigo() {
    let codigoR = crypto.randomUUID()
    console.log(codigoR)
    const Codigo = document.getElementById("codigo").value = codigoR;
};

function validarFormulario(evento) {
    evento.preventDefault();

    if (monto.value.trim() === '' || fechaInicial.value.trim() === '' || fechaFinal.value.trim() === '') {
        alert('Por favor, complete todos los campos obligatorios.');
        return;
    }

    if (fechaInicial.value >= fechaFinal.value) {
        alert('La fecha de fin debe ser después de la fecha de inicio.');
        return;
    }

    const interes = calcularTasaDeInteres();

    const inversion = {
        codigo: codigo.value,
        monto: monto.value,
        fechaInicial: fechaInicial.value,
        fechaFinal: fechaFinal.value,
        interes: interes.toFixed(2) + '%'
    };

    console.log(inversion);
}


function calcularTasaDeInteres() {
    const fechaInicial = new Date(document.getElementById("fechabeng").value);
    const fechaFinal = new Date(document.getElementById("fechaend").value);
    const monto = parseFloat(document.getElementById("monto").value);

    const unDiaEnMilisegundos = 1000 * 60 * 60 * 24;
    const dias = (fechaFinal - fechaInicial) / unDiaEnMilisegundos;

    const tasaBase = 0.05; // tasa base del 5%
    const tasaAdicional = 0.02; // tasa adicional del 2% por año adicional
    const anos = dias / 365; // calcula el número de años

    let tasaDeInteres = (1 + tasaBase + tasaAdicional * anos) ** anos - 1; // aplica la fórmula de interés compuesto
    let tasaDeInteresPorcentaje = (tasaDeInteres * 100).toFixed(2) + "%"; // convierte la tasa de interés en un porcentaje

    const tasaDeInteresInput = document.getElementById('interes');
    tasaDeInteresInput.value = tasaDeInteresPorcentaje; // muestra la tasa de interés calculada en porcentaje en el input

    console.log(`Monto: ${monto}`);
    console.log(`Fecha inicial: ${fechaInicial}`);
    console.log(`Fecha final: ${fechaFinal}`);
    console.log(`Días: ${dias}`);
    console.log(`Años: ${anos}`);
    console.log(`Tasa de interés: ${tasaDeInteres}`);
    console.log(`Tasa de interés final: ${tasaDeInteresPorcentaje}`);

    return tasaDeInteres; // retorna la tasa de interés calculada
}


// Agregar evento de envío del formulario
form.addEventListener('submit', validarFormulario);


//registro inversion logic-------------



