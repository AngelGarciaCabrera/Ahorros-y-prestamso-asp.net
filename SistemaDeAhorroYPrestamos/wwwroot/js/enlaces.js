
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

const boton = document.getElementById("generar");
function mostrarFormulario() {
    const loginG = document.createElement("loginG");
    loginG.innerHTML = ' <section id="formularioP" style="padding-top: 60px;"> \
        <center> \
        <div class="card shadow p-3 mb-5 bg-body-tertiary rounded" style="max-width: 500px;"> \
            <div class="card-header p-3 mb-2 bg-success text-white" id="card-header"> \
                <h3 class="card-title">Solicitud de Prestamos</h3> \
            </div> \
            <div class="card-body" id="car-body"> \
                <div class="mb-3" style="float: left"> \
                    <label for="" class="form-label">Codigo</label> \
                    <input type="text" id="Codigo" class="form-control" readonly> \
                </div> \
                <div style="float:right"> \
                    <label for="" class="form-label"> Interes</label> \
                    <input type="text" value="12%" id="Interes" class="form-control" readonly> \
                </div> \
                <div class="mb-3" style="padding-top: 100px;"> \
                    <label for="" class="form-label" style="float: left">Monto</label> \
                    <input type="number" id="Monto" class="form-control"> \
                </div> \
                <div class="mb-3"> \
                    <label for="" class="form-label">Fecha Inicio</label> \
                    <input type="datetime-local" value="" id="FechaI" class="form-control"> \
                </div> \
                <div class="mb-3"> \
                    <label for="" class="form-label">Fecha Final</label> \
                    <input type="datetime-local" id="FechaF" class="form-control"> \
                </div> \
            </div> \
            <div style="padding-left: 20px;"> \
                <button style="float:left;" type="button" class="btn btn-outline-success" id="Calcularinteres" onclick="CalcularInteres()">Calcular Interes</button> \
            </div> \
            <div class="d-grid gap-2 d-md-flex justify-content-md-end" style="padding-top: 80px; padding: 1em;"> \
                <button type="button" class="btn btn-outline-info" id="Solicitar" onclick="enviar()">Solicitar</button> \
                <button type="button" class="btn btn-outline-danger" id="LimpiarP" onclick="limpiar()"> Limpiar</button> \
            </div> \
        </div> \
    </center> \
    </section>';
    document.getElementById("loginG").appendChild(loginG);
}
const eliminar2 = document.getElementById("eliminar2");
eliminar2.addEventListener('click', function (e) {
    e.preventDefault()
    loginG.remove()
})



boton.addEventListener('click', function (e) {
    e.preventDefault()
    mostrarFormulario()
})



//Login Logica-------------------------------------------------






