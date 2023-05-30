// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('#file').on("change", function () {
    for (i = 0; i < $('form').length; i++) {
        if ($('form').get(i)[0].value != "") {
            var formdata = new FormData($('form').get(i));
            CallService(formdata);
            break;
        }
    }
});
function CallService(file) {
    $.ajax({
        url: '@Url.Action("Scan", "Home")',
        type: 'POST',
        data: file,
        cache: false,
        processData: false,
        contentType: false,
        success: function (barcode) {
            alert(barcode);
        },
        error: function () {
            alert("ERROR");
        }
    });
}
