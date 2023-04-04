const solicitarPrestamo = document.getElementById("solicitarPrestamos");

solicitarPrestamo.addEventListener('click'function (e) {
    e.preventDefault();
    window.location.href = '/Home/SolicitudDePrestamo';
})