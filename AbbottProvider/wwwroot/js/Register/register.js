$(document).ready(function () {

    $('#Person_IdDepartPlace').change(function () {
        var city = $('#Person_Birthplace');

        $.ajax({
            url: "/Utils/GetCities",
            data: { id: $('#Person_IdDepartPlace').val() },
            type: "GET",
        }).done(function (result) {

            if (result.success) {
                $.each(result.result, function (i, item) {
                    city.append('<option value="' + item.id + '">' + item.name + '</option>');
                });
            }
            else {
                console.error("Error municipios");
            }

        }).fail(function (jqXHR, textStatus, errorThrown) {
            console.error("Error en el servidor");
        });

    });

    $('#Person_IdDepartment').change(function () {

        var cities = $('#Person_IdCity');

        $.ajax({
            url: "/Utils/GetCities",
            data: { id: $('#Person_IdDepartment').val() },
            type: "GET",
        }).done(function (result) {

            if (result.success) {
                $.each(result.result, function (i, item) {
                    cities.append('<option value="' + item.id + '">' + item.name + '</option>');
                });
            }
            else {
                console.error("Error municipios");
            }

        }).fail(function (jqXHR, textStatus, errorThrown) {
            console.error("Error en el servidor");
        });
    });
});