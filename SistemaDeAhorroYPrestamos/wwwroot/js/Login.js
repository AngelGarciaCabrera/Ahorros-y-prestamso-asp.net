const formularioL = document.getElementById("formularioLogin");
const CedulaL = document.getElementById("cedula1");
const ContraseñaL = document.getElementById("contrasena1");
const eliminarL = document.getElementById("LimpiarL")
const IngresarL = document.getElementById("ingresar4")






function validacion2() {


    let isValid1 = true;

    const valuecedula1 = CedulaL.value;
    if (valuecedula1 == "" || valuecedula1 == null || valuecedula1 == undefined || valuecedula1.length !== 11) {
        CedulaL.classList.add("input-error");
        isValid = false;
    } else {
        CedulaL.classList.remove("input-error");
        CedulaL.classList.add("input-correct");
    }

    const contrasena1Value = ContraseñaL.value;
    if (contrasena1Value == "" || contrasena1Value == null || contrasena1Value == undefined) {
        ContraseñaL.classList.add("input-error");
        isValid = false;
    } else {
        ContraseñaL.classList.remove("input-error");
        ContraseñaL.classList.add("input-correct");
    }

    return isValid1;
}

function ingresarDatos() {

    const Datol = {
        contrasena: ContraseñaL.value,
        cedula: CedulaL.value,

    };
    console.log(Datol)
}


 IngresarL.addEventListener("click", function (Datol) {
   
    Datol.preventDefault();
    if (validacion2()) {
        ingresarDatos();
        console.log(Datol)

    }
})



eliminarL.addEventListener('click', function (a) {

    a.preventDefault();

    clearl();
    RemoverClasesL();
})




function clearl() {
    const inputs = formularioL.getElementsByTagName("input");


    for (let i = 0; i < inputs.length; i++) {
        if (inputs[i].value === "Enviar") {
            continue
        }
        inputs[i].value = null;
    }
}

function RemoverClasesL() {

    const valuecedula1 = CedulaL.value;

    if (valuecedula1 == "" || valuecedula1 == null || valuecedula1 == undefined) {
        ContraseñaL.classList.remove("input-error");
        ContraseñaL.classList.remove("input-correct")
        CedulaL.classList.remove("input-error");
        CedulaL.classList.remove("input-correct")

    }



}
const boton = document.getElementById("general");

/*
boton.addEventListener('click', function (a) {
    a.preventDefault()
    generarFormulario()

})

let GEnerar = document.createElement("GEnerar");
function generarFormulario() {
    alert("Hola")
 
    GEnerar.innerHTML = `
     <section id="formularioP" style="padding-top: 60px;">
        <center>
        <div class="card shadow p-3 mb-5 bg-body-tertiary rounded " style="max-width: 500px; " >
            <div class="card-header p-3 mb-2 bg-success text-white" id="card-header" >
                <h3 class="card-title">Solicitud de Prestamos</h3>
            </div>
                <div class="card-body " id="car-body" >
                    <div class="mb-3" style="float: left">
                        <label for="" class="form-label">Codigo</label>
                        <input type="text" id="Codigo"  class="form-control"  readonly>
                    </div>
                    <div  style="float:right"> 
                        <label for="" class="form-label"> Interes</label>
                        <input type="text" value="12%" id="Interes"  class="form-control" readonly>
                    </div>
                    
                    <div class="mb-3" style="padding-top: 100px;">  
                        <label for="" class="form-label" style="float: left">Monto</label>
                        <input type="number" id="Monto"  class="form-control">
                    </div>
                    <div class="mb-3">
                        <label for="" class="form-label">Fecha Inicio</label>
                        <input type="datetime-local" value="" id="FechaI"  class="form-control">
                    </div>
                    <div class="mb-3" >
                        <label for="" class="form-label">Fecha Final</label>
                        <input type="datetime-local" id="FechaF"  class="form-control">
                    </div>
               
                </div>
                    <div style="padding-left: 20px;" >
                        <button  style="float:left;"  type="button" class="btn btn-outline-success" id="Calcularinteres" onclick="CalcularInteres()" >Calcular Interes</button>
                    </div>
                <div class="d-grid gap-2 d-md-flex justify-content-md-end" style="padding-top: 80px; padding: 1em;"> 
                    <button type="button" class="btn btn-outline-info" id="Solicitar" onclick="enviar()">Solicitar</button>
                     <button type="button" class="btn btn-outline-danger " id="LimpiarP" onclick="limpiar()"> Limpiar</button>
                </div>
        </div>
    </center>
      
    </section>
  `;
    document.getElementById("GEnerar").appendChild(GEnerar);
}

//*