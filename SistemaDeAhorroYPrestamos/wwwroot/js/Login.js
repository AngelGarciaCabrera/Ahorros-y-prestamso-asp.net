const formularioL = document.getElementById("formulario__login");
const CedulaL = document.getElementById("cedula1");
const ContraseñaL = document.getElementById("contrasena1");

const IngresarL = document.getElementById("ingresar4")
let elementoP = document.getElementById('mi-elemento-p');
let contrasenap = document.getElementById('contraseñap');






function validacion2() {
   
    

    let isValid = true;

    const valuecedula1 = CedulaL.value;
    if (valuecedula1 == "" || valuecedula1 == null || valuecedula1 == undefined || valuecedula1.length !== 11) {
        elementoP.style.display = 'block';

        isValid = false;
    } else {

        elementoP.style.display = 'none';

    }

    const contrasena1Value = ContraseñaL.value;
    if (contrasena1Value == "" || contrasena1Value == null || contrasena1Value == undefined) {
        contrasenap.style.display = 'block';

        isValid = false;
    } else {

        contrasenap.style.display = 'none';

    }

    return isValid;
}

function ingresarDatos() {

    const Datol = {
        contrasena: ContraseñaL.value,
        cedula: CedulaL.value,

    };
    console.log(Datol)
    window.location.href = '/Home/SegundoHome';

}


IngresarL.addEventListener("click", function (Datol) {

    Datol.preventDefault();
    if (validacion2()) {
        ingresarDatos();

    }

})





