// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function ModalFn($mod_tipo, $mod_titulo, $mod_texto, $mod_labelOK, $mod_labelNO, $mod_customFnOK, $mod_customFnNO) {
    let $new_modal = $("#modal-gen").clone();
    let $new_contain = $new_modal.find(".modal-body");
    let $new_modal_id = "mod" + Date.now();
    $new_modal.attr("id", $new_modal_id);
    $new_modal.attr("aria-label", $mod_titulo);
    switch ($mod_tipo) {
        case "exito":
            $new_modal.find(".govco-icon").addClass("text-success fas fa-check");
            $new_modal.find(".headline-xl-govco").addClass("text-success");
            break;
        case "alerta":
            $new_modal.find(".govco-icon").addClass("text-warning fas fa-exclamation");
            $new_modal.find(".headline-xl-govco").addClass("text-warning");
            break;

        case "error":
            $new_modal.find(".govco-icon").addClass("text-danger fas fa-sad-tear");
            $new_modal.find(".headline-xl-govco").addClass("text-danger");
            break;

        case "mensaje":
            $new_modal.find(".govco-icon").addClass("text-primary fas fa-exclamation");
            $new_modal.find(".headline-xl-govco").addClass("text-primary");
            break;

        case "custom":
            $new_contain.html($mod_texto);
            break;
    }

    if ($mod_titulo) {
        $new_modal.find(".headline-xl-govco").text($mod_titulo);
    }

    if ($mod_texto) {
        $new_modal.find("p").html($mod_texto);
    } else { $new_modal.find("p").addClass("d-none"); }

    if ($mod_labelOK) {
        $new_modal.find(".btn-modal-ok").text($mod_labelOK);
    }

    if ($mod_labelNO) {
        $new_modal.find(".btn-modal-cancel").text($mod_labelNO);
    } else {
        $new_modal.find(".btn-modal-ok").attr("data-dismiss", "modal");
        $new_modal.find(".btn-modal-cancel").addClass("d-none");
    }

    if ($mod_customFnOK) {
        $new_modal.find(".btn-modal-ok").click(function () {
            var fn = window[$mod_customFnOK.split('(')[0]];
            var params = $mod_customFnOK.split("'")[1];
            if (typeof fn === "function") fn(params);

        });
    }

    if ($mod_customFnNO) {
        $new_modal.find(".btn-modal-cancel").click(function () {
            var fn = window[$mod_customFnNO.split('(')[0]];
            var params = $mod_customFnNO.split("'")[1];
            if (typeof fn === "function") fn(params);
        });
    }

    $("body").append($new_modal);
    $($new_modal).modal();
    $('#' + $new_modal_id).on('hidden.bs.modal', function (e) {
        $(this).remove();
    })
}

function Redirect(url) {
    // ShowLoader(true);
    window.location.href = url;
}

