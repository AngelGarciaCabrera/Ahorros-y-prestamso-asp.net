﻿/*
//botones
const CedulaFiador = document.getElementById("Fiador");
const Garantia = document.getElementById("garantia");
const Solicitar = document.getElementById("Solicitar");
const Limpiar = document.getElementById("LimpiarP");
const FechaI = document.getElementById("FechaI");
const FechaF = document.getElementById("FechaF");


//apartados de garatia

const tipo_garantia = document.getElementById("TipoGarantia");
const valorEstimadoDGarantia = document.getElementById("");
const ubicacionDGarantia = document.getElementById("");

const AddGarantia = document.getElementById("addgarantia");
let codigoR = crypto.randomUUID()

function AsignacionDeCodigoP() {
    let codigoR = crypto.randomUUID()
    console.log(codigoR)
    const Codigo = document.getElementById("Codigo").value = codigoR;
}

function Validate() {
   
    const GarantiaValue = Garantia.value;
    const FiadorValue = CedulaFiador.value;
    const valueFechaI = FechaI.value;
    const valueFechaF = FechaF.value;
    const valueMonto = Monto.value;
    let isValidate = true;
    if (valueFechaI == "" || valueFechaI == null || valueFechaI == undefined) {
        FechaI.classList.remove("input-correct");
        FechaI.classList.add("input-error");
        isValidate = false;
    } else {
        FechaI.classList.remove("input-error");
        FechaI.classList.add("input-correct");
    }

    if (valueFechaF == "" || valueFechaF == null || valueFechaF == undefined) {
        FechaF.classList.remove("input-correct");
        FechaF.classList.add("input-error");
        isValid = false;
    } else {
        FechaF.classList.remove("input-error");
        FechaF.classList.add("input-correct");
    }
    if (valueMonto == "" || valueMonto == null || valueMonto == undefined || valueMonto <= 999) {
        Monto.classList.remove("input-correct");
        Monto.classList.add("input-error");
       
        isValid = false;
    } else {
        Monto.classList.remove("input-error");
        Monto.classList.add("input-correct");
    }
    
    
    if (GarantiaValue.length == 0 && FiadorValue.length !== 11) {
       
        AddGarantia.style.display = 'none';
        CedulaFiador.classList.remove("input-correct"); 
        CedulaFiador.classList.add("input-error")


    } else {
        AddGarantia.style.display = 'block';
        CedulaFiador.classList.add("input-correct")
        CedulaFiador.classList.remove("input-error"); 
      
    }

    
    return isValidate;
    const Si = isValidate


};

function CalcularInteres1() {
   
    
    const Monto = document.getElementById("Monto").value;
    const FechaI = document.getElementById("FechaI").value;
    const FechaF = document.getElementById("FechaF").value;
    if (Validate()) {
        VerificarFecha()
        calcularTasaDeInteres1()

    } else {
        alert("los datos deben ser correctos ")

    }



};
//para cambiar el minimo de la fecha final
FechaI.addEventListener('change', () => {
    const valuefechaSelected = new Date(FechaI.value)
    const dateTOChange = new Date(valuefechaSelected)
    console.log("coño")
    dateTOChange.setMonth(valuefechaSelected.getMonth() + 1)
    debugger
    FechaF.setAttribute("min", dateTOChange.toISOString().split('T')[0]);
})
function VerificarFecha() {
    
    let FechaIsValida = true;
    var inical = FechaI.value
    var final = FechaF.value
    var fechaObj1 = new Date(inical);
    var fechaObj2 = new Date(final);
    var fechaI = fechaObj1.toISOString();
    var fechaF = fechaObj2.toISOString();
    var FechaInicialConFormato = fechaI.substring(0, 10);
    var FechaFinalConFormato = fechaF.substring(0, 10);

    if (FechaInicialConFormato < FechaFinalConFormato) {
        
        return FechaIsValida = true;
    } else if (FechaInicialConFormato > FechaFinalConFormato) {
        alert("La fecha final debe ser despues que la fecha inical");
        alert("Favor ingresar la fecha final nuevamente");
        FechaF.value = null;
        return FechaIsValida = false;
    } else {
        alert("Ambas fechas son iguales, Favor ingresar las fechas nuevamente");
        
        FechaF.value = null;
        FechaI.value = null;
        return FechaIsValida = false;
    }
    return FechaIsValida;
}

function limpiar() {
    
    Monto.value = null;
    FechaI.value = null;
    FechaF.value = null;
    CedulaFiador.value = null;
    Garantia.value = null;
    console.log(Garantia)
    console.log(Garantia.value)


}


function calcularTasaDeInteres1() {
    const fechaInicial = new Date(document.getElementById("FechaI").value);
    const fechaFinal = new Date(document.getElementById("FechaF").value);
    const monto = parseFloat(document.getElementById("Monto").value);

    const unDiaEnMilisegundos = 1000 * 60 * 60 * 24;
    const dias = (fechaFinal - fechaInicial) / unDiaEnMilisegundos;
    let meses = (fechaFinal.getFullYear() - fechaInicial.getFullYear()) * 12 + (fechaFinal.getMonth() - fechaInicial.getMonth());
    const tasaBase = 0.05; // tasa base del 5%
    const tasaAdicional = 0.02; // tasa adicional del 2% por año adicional
    const anos = dias / 365; // calcula el número de años

    let tasaDeInteres = (1 + tasaBase + tasaAdicional * anos) ** anos - 1; // aplica la fórmula de interés compuesto
    debugger
    let tasaDeInteresInput = document.getElementById("Interes");
    debugger//captura el elemento
    tasaDeInteresInput.value = `${(tasaDeInteres * 100).toFixed(2)}%`;
    const interesFinal = tasaDeInteresInput.value

    const cuotaMensuales = monto / meses * (1 + tasaDeInteres);
    const cuotaMensualRedondeada = cuotaMensuales.toFixed(2);

    console.log(`Monto: ${monto}`);
    console.log(`Fecha inicial: ${fechaInicial}`);
    console.log(`Fecha final: ${fechaFinal}`);
    console.log("Hay " + meses + " meses entre las fechas.");
    console.log(`Días: ${dias}`);
    console.log(`Años: ${anos}`);
    console.log(`Tasa de interés: ${tasaDeInteres}`);
    console.log(`cuotasMensuales: ${cuotaMensualRedondeada}`);
    console.log(`Tasa de interés final: ${tasaDeInteresInput.value}`);
    const opcionesSeleccionadas = document.getElementsByName("tipo-garantia");
    const opciones = {};
    let opcionSeleccionada = '';

    opcionesSeleccionadas.forEach((opcion) => {
        if (opcion.checked) {
            opciones[opcion.value] = opcion.value;
            opcionSeleccionada = opcion.value;
        } else {
            opciones[opcion.value] = false;
        }
    });

    const opcionesString = JSON.stringify(opciones);
    const opcionesFinalString = opciones.toString();

    let opcionTrue = '';
    for (const opcion in opciones) {
        if (opciones[opcion]) {
            opcionTrue = opcion;
        }
    }
    const ValorGarantia = document.getElementById("valor");
    const ubicacion = document.getElementById("ubicacion");
    JSON.parse
    const KeyPrestamos= "Prestamo"
    
    const resultados = {};
  
    // agregar propiedades y valores al objeto
   
    resultados.id = Codigo.value;
    resultados.monto = monto;
    resultados.FechaInicial = fechaInicial.toLocaleDateString();
    resultados.FechaInicial = fechaInicial.toLocaleDateString();
    resultados.FechaFinal = fechaFinal.toLocaleDateString();
    resultados.dias = dias;
    resultados.meses = meses;
    resultados.anos = anos;
    resultados.interesFinal = interesFinal;
    resultados.Garantia = Garantia.value
    resultados.Ceduladelfiador = CedulaFiador.value
    resultados.ValorGarantia = ValorGarantia.value
    resultados.CantidadDeCuotas = meses;
    resultados.MontoDeCuotas = cuotaMensualRedondeada;
    resultados.ubicacion = ubicacion.value
    resultados.tipo = opcionTrue;

    const PrestamosGuardados = JSON.parse(localStorage.getItem(KeyPrestamos) || '[]');
    PrestamosGuardados.push(resultados)

 /*
    localStorage.setItem('Prestamo', JSON.stringify(PrestamosGuardados));
    console.log("subido al local")
    // devolver el objeto con los resultados
    return resultados;

}
*/

/*
function enviar() {

   if (Validate()) {
       VerificarFecha()
       CalcularInteres1()

       calcularTasaDeInteres1();
       Buscar()
       calcular()
       

   } else {
       alert("debe completar los datos")
   }




}

function mostrarOpciones() {
   document.getElementById("opciones").style.display = "block";
}

function mostrarCampos() {
   document.getElementById("campos").style.display = "block";
}

function calcular() {

   const cuotas = {};

   for (let i = 0; i <= meses; i++) {
       const saldoPendiente = monto * Math.pow(1 + (tasaDeInteres / 12), i) - cuotaMensual * (Math.pow(1 + (tasaDeInteres / 12), i) - 1) / (tasaDeInteres / 12);
       const interesMensual = saldoPendiente * (tasaDeInteres / 12);
       const capitalMensual = cuotaMensual - interesMensual;
       const fechaCuota = new Date(fechaInicial.getFullYear(), fechaInicial.getMonth() + i, fechaInicial.getDate());
       const fechaFormato = `${fechaCuota.getDate()}/${fechaCuota.getMonth() + 1}`;
       cuotas.push({
           fecha: fechaFormato,
           capital: capitalMensual.toFixed(2),
           interes: interesMensual.toFixed(2),
           cuota: cuotaMensual.toFixed(2),
           saldo: saldoPendiente.toFixed(2)

       })
                   
   }
   console.log(cuotas)
}
//presentar codigo en formulario Prestamos



sd
*/
const FechaI = document.getElementById("FechaI");
const FechaF = document.getElementById("FechaF");

function setDatesFormValues(date = new Date()) {
    FechaI.value = date.toISOString().split('T')[0]
    const dateToChange = new Date(date)
    debugger
    dateToChange.setMonth(date.getMonth() + 1)

    if (!FechaF.value) {
        FechaF.value = ''
    }
    FechaF.setAttribute("min", dateToChange.toISOString().split('T')[0]);
}

FechaI.addEventListener('change', () => {
    const FechaIDate = new Date(FechaI.value)
    setDatesFormValues(FechaIDate);
});

window.addEventListener('DOMContentLoaded', () => {
    console.log('Subio el onload')
    setDatesFormValues();
})
