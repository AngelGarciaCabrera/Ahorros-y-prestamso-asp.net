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
/*  form.addEventListener('submit', validarFormulario);*/
