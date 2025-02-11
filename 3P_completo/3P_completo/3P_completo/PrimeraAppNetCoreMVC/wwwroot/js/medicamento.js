window.onload = function () {
    listarUsuario();
}

async function listarUsuario() {

    pintar({
        url: "Medicamento/listarUsuario",
        cabeceras: ["Id Usuario", "Nombre", "Descripcion"],
        propiedades: ["idTipoUsuario", "nombre", "descripcion"]
    })
}