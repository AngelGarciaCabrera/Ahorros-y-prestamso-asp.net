const monto = document.getElementById("monto");
const cuenta = document.getElementById("cuenta")
const fechaInicial = document.getElementById("fechabeng");
const fechaFinal = document.getElementById("fechaend");
const interes = document.getElementById("interes");
const form = document.querySelector('form');
const limpia = document.getElementById('limpiar')

// Generar código aleatorio
function AsignacionDeCodigo() {
    let codigoR = crypto.randomUUID()
    console.log(codigoR)
    const Codigo = document.getElementById("codigo").value = codigoR;
};

function validarFormulario(evento) {
    evento.preventDefault();

    if (cuenta.value.trim() === '' || monto.value.trim() === '' || fechaInicial.value.trim() === '' || fechaFinal.value.trim() === '') {
        alert('Por favor, complete todos los campos obligatorios.');
        return;
    }

    if (cuenta.value.trim().length !== 20) {
        alert('El número de cuenta debe tener exactamente 20 dígitos.');
        return;
    }

    //validar que cuenta tenga 20 digitos

    if (fechaInicial.value >= fechaFinal.value) {
        alert('La fecha de fin debe ser después de la fecha de inicio.');
        return;
    }

    const interes = calcularTasaDeInteres();

    const inversion = {
        codigo: codigo.value,
        cuenta: cuenta.value,
        monto: monto.value,
        fechaInicial: fechaInicial.value,
        fechaFinal: fechaFinal.value,
        interes: interes.toFixed(2) + '%',
        cuotas: calcularCuotas()
    };

    console.log(inversion);

    // Guardar las cuotas en el LocalStorage
    localStorage.setItem('cuotas', JSON.stringify(inversion.cuotas));

    mostrarCuotas(calcularCuotas());

}

function limpiar() {
    monto.value = null;
    cuenta.value = null;
    fechaFinal.value = null;
    fechaInicial.value = null;
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

function calcularCuotas() {
    const monto = parseFloat(document.getElementById("monto").value);
    const tasaDeInteres = calcularTasaDeInteres();
    const fechaInicial = new Date(document.getElementById("fechabeng").value);
    const fechaFinal = new Date(document.getElementById("fechaend").value);
    const plazoEnMeses = (fechaFinal.getFullYear() - fechaInicial.getFullYear()) * 12 + (fechaFinal.getMonth() - fechaInicial.getMonth());
    const cuotaMensual = monto * (tasaDeInteres / 12) / (1 - Math.pow(1 + (tasaDeInteres / 12), -plazoEnMeses));
    const cuotas = [];

for (let i = 0; i <= plazoEnMeses; i++) {
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
        });
    }

    console.log(`Plazo en meses: ${plazoEnMeses}`);
    console.log(`Cuota mensual: ${cuotaMensual.toFixed(2)}`);
    console.log(cuotas);

    return cuotas;
}

function mostrarCuotas() {
    const cuotasString = localStorage.getItem('cuotas');
    if (cuotasString) {
        const cuotas = JSON.parse(cuotasString);
        console.log(cuotas);
    } else {
        console.log('No hay cuotas guardadas en el LocalStorage');
    }
}



// Agregar evento de envío del formulario
form.addEventListener('submit', validarFormulario);

//limpiar campos

function limpiarCampos() {
    monto.value = '';
    cuenta.value = '';
    fechaInicial.value = '';
    fechaFinal.value = '';
    form.reset();
    AsignacionDeCodigo();
    calcularTasaDeInteres();
}