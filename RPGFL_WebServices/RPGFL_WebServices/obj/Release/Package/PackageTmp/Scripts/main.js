$(document).ready(function () {
    // TEST AJAX
    $.ajax({
        type: "post",
        url: "RPGFL/GetAllCharacters",
        data: {},
        dataType: "json"
    }).success(function (data) {
        alert(data);
    });
});