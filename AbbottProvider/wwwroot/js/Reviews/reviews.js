$(document).ready(function () {

});

function getDoc(idDoc) {
    console.log('idDOC');
    console.log(idDoc);

    $('#idDocHidden').append(idDoc);

    $.ajax({
        url: "/Reviews/Reviews/GetDocs",
        data: { id: idDoc },
        type: "GET",
    }).done(function (result) {

        if (result.success) {
            $('.btnNo').attr('onClick', 'rejectDoc(' + idDoc + ');');
            $('.btnOk').attr('onClick', 'approveDoc(' + idDoc + ');');

            PDFObject.embed(result.result, "#pdfContainer");
            $('#pdfDisplay').modal();
        }
        else {
            console.error("Error ver documentos");
        }

    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.error("Error en el servidor");
    });

}

function approveDoc(idDoc) {

    $.ajax({
        url: "/Reviews/Reviews/ApproveDoc",
        data: { id: idDoc },
        type: "GET",
    }).done(function (result) {

       

        if (result.success) {
            console.log('todo bien');
            ModalFn("exito", "Documentos", "Documento aprobado", "Continuar", "", "", "");
        }
        else {
            console.error("Error municipios");
        }

    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.error("Error en el servidor");
    });
}

function rejectDoc(idDoc) {
    console.log('Rechazado');

    $.ajax({
        url: "/Reviews/Reviews/RejectDoc",
        data: { id: idDoc },
        type: "GET",
    }).done(function (result) {

        console.log('Response');
        console.log(result);

        if (result.success) {
            console.log('todo bien');
        }
        else {
            console.error("Error municipios");
        }

    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.error("Error en el servidor");
    });
}