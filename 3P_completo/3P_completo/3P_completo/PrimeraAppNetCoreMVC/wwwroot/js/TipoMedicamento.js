window.onload = function () {
    listarTipoMedicamento();
}

async function listarTipoMedicamento() {


    const select = document.querySelector("select");
    let option;

    select.addEventListener("change", function () {
        option = select.value;
        console.log(option)
        if (option == 1) {
            pintar({
                url: "TipoMedicamento/listarTipoMedicamento",
                cabeceras: ["Id Medicamento", "Nombre", "Descripcion"],
                propiedades: ["idTipoMedicamento", "nombre", "descripcion"]
            })
        } else if (option == 2) {
            pintar({
                url: "Medicamento/listarUsuario",
                cabeceras: ["Id Usuario", "Nombre", "Descripcion"],
                propiedades: ["idTipoUsuario", "nombre", "descripcion"]
            })
        }
    })


    //pintar({
    //    url: "TipoMedicamento/listarTipoMedicamento",
    //    cabeceras: ["Id Medicamento", "Nombre", "Descripcion"],
    //    propiedades: ["idTipoMedicamento", "nombre", "descripcion"]
    //})
    /*
    fetchGet("TipoMedicamento/listarTipoMedicamento", "json", function (res) {
    
        let contenido = " ";
        contenido = '<table class="table">';
        contenido += "<thead>"

        /* Primera fila de la tabla con los headers */
        /*
        contenido += "<tr>"
        contenido += "<th>Id Tipo de Medicamento</th>"
        contenido += "<th>Nombre</th>"
        contenido += "<th>Descripción</th>"
        contenido += "</tr>"

        contenido += "</thead>"
        contenido += "<tbody>"

        let nroRegistros = res.length;
        let obj;


        for (let i = 0; i < nroRegistros; i++) {
            obj = res[i];
            contenido += "<tr>";
            contenido += "<td>" + obj.idMedicamento + "</td>";
            contenido += "<td>" + obj.nombre + "</td>";
            contenido += "<td>" + obj.descripcion + "</td>";
            contenido += "</tr>";
        }

        contenido += "</tbody>"
        contenido += "</table>"

        document.getElementById("divTabla").innerHTML = contenido;
    })*/
}