﻿





//botones

const Solicitar = document.getElementById("Solicitar");
const Limpiar = document.getElementById("LimpiarP");
const FechaI = document.getElementById("FechaI");
const FechaF = document.getElementById("FechaF");

function AsignacionDeCodigo() {

    let codigoR = crypto.randomUUID()
    console.log(codigoR)
    const Codigo = document.getElementById("Codigo").value = codigoR;

};

function Validate() {
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

    return isValidate;
    const Si = isValidate


};

function CalcularInteres() {
    const Monto = document.getElementById("Monto").value;
    const FechaI = document.getElementById("FechaI").value;
    const FechaF = document.getElementById("FechaF").value;
    if (Validate()) {
        VerificarFecha()
        calcularTasaDeInteres()

    } else {
        alert("los datos deben ser correctos ")

    }



};
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
        alert("la fecha es correcta");
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



}

function calcularTasaDeInteres() {
    const fechaInicial = new Date(document.getElementById("FechaI").value);
    const fechaFinal = new Date(document.getElementById("FechaF").value);
    const monto = parseFloat(document.getElementById("Monto").value);

    const unDiaEnMilisegundos = 1000 * 60 * 60 * 24;
    const dias = (fechaFinal - fechaInicial) / unDiaEnMilisegundos;

    const tasaBase = 0.05; // tasa base del 5%
    const tasaAdicional = 0.02; // tasa adicional del 2% por año adicional
    const anos = dias / 365; // calcula el número de años

    let tasaDeInteres = (1 + tasaBase + tasaAdicional * anos) ** anos - 1; // aplica la fórmula de interés compuesto

    let tasaDeInteresInput = document.getElementById("Interes"); //captura el elemento
    tasaDeInteresInput.value = `${(tasaDeInteres * 100).toFixed(2)}%`;
    const interesFinal = tasaDeInteresInput.value
    console.log(`Monto: ${monto}`);
    console.log(`Fecha inicial: ${fechaInicial}`);
    console.log(`Fecha final: ${fechaFinal}`);
    console.log(`Días: ${dias}`);
    console.log(`Años: ${anos}`);
    console.log(`Tasa de interés: ${tasaDeInteres}`);
    console.log(`Tasa de interés final: ${tasaDeInteresInput.value}`);


    const resultados = {};

    // agregar propiedades y valores al objeto
    resultados.monto = monto;
    resultados.FechaInicial = fechaInicial.value;
    resultados.FechaFinal = fechaFinal.value;
    resultados.dias = dias;
    resultados.anos = anos;
    resultados.tasaDeInteres = tasaDeInteres;
    resultados.interesFinal = interesFinal;
    console.log(resultados)

    // devolver el objeto con los resultados
    return resultados;
}
function enviar() {

    if (Validate()) {
        calcularTasaDeInteres();
        alert("Enviando...");

    } else {
        alert("debe completar los datos")
    }




}