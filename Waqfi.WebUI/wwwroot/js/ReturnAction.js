function AssignSteps() {

    var Steps = [];
    $('input[type="checkbox"]:checked').each(function () {
        Steps.push(parseInt($(this).attr('id')));
    });

    $("#StepsList").val(Steps);
}
function Clear() {
    document.querySelectorAll('input[type=checkbox]').forEach(el => el.checked = false);
    $("#ReturnReason").val('');
    $("#ReturnReason-error").text(' ');
    $("#StepsList-error").text('');
}
function TrimReturn() {

    $("#ReturnReason").val($("#ReturnReason").val().trim());
}
function SwlReturnSuccess(result) {

    if (result.errors.length > 0) {
        Swal.fire({
            imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
            title: result.errors[0],
            showCancelButton: false
        });
    }
    else {
        Swal.fire({
            imageUrl: `/Cms_Lib/img/icons/add-user-popup.svg`,
            title: 'تم إرسال الطلب التعديل بنجاح',
            showCancelButton: false,
            showConfirmButton: false,
            timer: 1200
        }).then((result) => {
            window.location.href = "/Provider/ProvidersRequests";
        })

    }
}
function SwlReturnError() {
    Swal.fire({
        imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
        title: 'حدث خطأ ما .',
        showCancelButton: false
    });
}

$(document).on('change', 'input[type="checkbox"]', function (e) {
    $("#StepsList-error").text('');
});