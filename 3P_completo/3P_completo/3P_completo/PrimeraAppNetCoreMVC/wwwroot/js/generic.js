async function fetchGet(url, tipoRespuesta, callback) {
    try {
        let raiz = document.getElementById("hdfOculto").value;

        //http://localhost
        let urlCompleta = window.location.protocol + "//" + window.location.host + "/" + raiz + url;

        let res = await fetch(urlCompleta)

        if (tipoRespuesta == "json") {
            res = await res.json();
        }
        else if (tipoRespuesta == "text") {
            res = await res.text();
        }

        //JSON (object)
        console.log("Datos recibidos del backend:", res);

        callback(res)

    } catch (e) {
        console.error(e)
        alert("Ocurrió un problema");
    }
}

let objConfiguracionGlobal;

//(url:"", nombreColumnas[], nombrePropiedades: [])
function pintar(objConfiguracion) {
    objConfiguracionGlobal = objConfiguracion;


    fetchGet(objConfiguracion.url, "json", function (res) {
        console.log(res);
        let contenido = "";

        contenido += "<div id='divContenedorTabla'>"

        contenido += generarTabla(res);

        contenido += "</div>";

        document.getElementById("divtabla").innerHTML = contenido;
    })
}

function generarTabla(res) {

    let contenido = " ";



    //cabeceras: ["id Tipo Medicamento", "Nombre", "Descripcion"],
    let cabeceras = objConfiguracionGlobal.cabeceras;

    //propiedades: ["idMedicamento", "nombre", "descripcion"]
    let nombrePropiedades = objConfiguracionGlobal.propiedades;

    contenido = '<table class="table">';
    contenido += "<thead>"

/* Primera fila de la tabla con los headers */
        
    contenido += "<tr>"

    for (var i = 0; i < cabeceras.length; i++) {
        contenido += "<td>" + cabeceras[i] + "</td>";
    }

        /*
        contenido += "<th>Id Tipo de Medicamento</th>"
        contenido += "<th>Nombre</th>"
        contenido += "<th>Descripción</th>"
        */
        contenido += "</tr>"

        contenido += "</thead>"
        contenido += "<tbody>"
     
        let nroRegistros = res.length;
        let obj;
        let propiedadActual;
        
        for (let i = 0; i < nroRegistros; i++) {
            obj = res[i];
            contenido += "<tr>";

            for (var j = 0; j < nombrePropiedades.length; j++) {
                propiedadActual = nombrePropiedades[j];
                contenido += "<td>" + obj[propiedadActual] + "</td>";
            }

            /*
            contenido += "<td>" + obj.idMedicamento + "</td>";
            contenido += "<td>" + obj.nombre + "</td>";
            contenido += "<td>" + obj.descripcion + "</td>";
            */
            contenido += "</tr>";
        }
      

        contenido += "</tbody>"
        contenido += "</table>"

    return contenido;
}