

const usuarioGuardado = localStorage.getItem('Prestamo');
const miObjetoRecuperado = JSON.parse(usuarioGuardado);

function LlenarTablaPrestmaos() {
   
    console.log(miObjetoRecuperado);
    var id = miObjetoRecuperado['id']
    console.log(id)
  // Obtener la tabla y la fila de encabezado
    var tabla = document.getElementById('tabla');
    var filaEncabezado = tabla.insertRow();
    // Crear las celdas de encabezado
    var celdaidEncabezado = filaEncabezado.insertCell();
    celdaidEncabezado.innerHTML = '<th>id</th>';

    var celdaMontoMenusalEncabezado = filaEncabezado.insertCell();
    celdaMontoMenusalEncabezado.innerHTML = '<th>Monto Menusal</th>';

    var cueotas = filaEncabezado.insertCell();
    cueotas.innerHTML = '<th>Cantidad de cuotas</th>';

    var fechadepago = filaEncabezado.insertCell();
    fechadepago.innerHTML = '<th>fecha de pagos </th>';

    // Crear la fila de datos
    var filaDatos = tabla.insertRow();
    // Crear las celdas de datos
    var celdaIDValor = filaDatos.insertCell();
    celdaIDValor.innerHTML = '<td>' + miObjetoRecuperado['id'] + '</td>';

    var celdaMontoMensualValor = filaDatos.insertCell();
    celdaMontoMensualValor.innerHTML = '<td>' + miObjetoRecuperado['MontoDeCuotas'] + '</td>';

    var cueotasVALOR = filaDatos.insertCell();
    cueotasVALOR.innerHTML = '<td>' + miObjetoRecuperado['CantidadDeCuotas'] + '</td>';

    var FECHADEPAGOVALOR = filaDatos.insertCell();
    FECHADEPAGOVALOR.innerHTML = '<td>' + miObjetoRecuperado['FechaInicial'] + '</td>';
}

