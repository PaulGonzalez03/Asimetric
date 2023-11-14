window.onbeforeunload = function () {
    $.ajax({
        url: '/Home/Limpiar',
        method: 'GET',
        data: {},
        success: function (res) {

        }
    });
}

window.onload = function () {
    $.ajax({
        url: '/Home/Verificar',
        method: 'GET',
        data: {},
        success: function (res) {

        }
    });
}