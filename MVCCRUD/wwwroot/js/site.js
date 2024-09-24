function mostrarAlerta(titulo, texto, icono) {
    Swal.fire({
        title: titulo,       // Usando el parámetro 'titulo'
        text: texto,         // Usando el parámetro 'texto'
        icon: icono,         // Usando el parámetro 'icono'
        confirmButtonText: 'Aceptar'
    });
}
