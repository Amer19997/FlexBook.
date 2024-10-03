function AddItemSuccess(result) {
    if (result.errors.length > 0) {
        Swal.fire({
            imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
            title: result.errors[0],
            showCancelButton: false,
            showConfirmButton: false
        });

    }
    else {
        swal.fire({
            title: "تمت عملية التعديل بنجاح",
            imageUrl: '/Cms_Lib/img/icons/add-user-popup.svg',
            showConfirmButton: false,
            showCancelButton: false,
            timer: 5000
        }).then(() => { window.location.replace("/ContactUsRequest/index/"); });
    }
}
function AddItemFailed(xhr) {
    Swal.fire({
        imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
        title: "حدث خطأ ما",
        showCancelButton: false,
        showConfirmButton: false,
    });
}

function swlSuccess(result) {
    debugger

    if (result.errors.length > 0) {
        Swal.fire({
            imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
            title: result.errors[0],
            showCancelButton: false
        });
    }
    else {
        debugger

        Swal.fire({
            imageUrl: `/Cms_Lib/img/icons/add-user-popup.svg`,
            title: 'تم ارسال الرد ',
            showCancelButton: false,
            showConfirmButton: false,
            timer: 1200
        }).then((result) => {
            window.location.href = "/contactusRequest/index";
        })

    }
}

function swlerror() {
    Swal.fire({
        imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
        title: 'حدث خطأ ما .',
        showCancelButton: false
    });
}
function ClearError() {
    $("#RejectionReason-error").text(' ');
    $("#RejectionReason").val('');
}

function Trim() {
    $("#TextAreaId").val($("#TextAreaId").val().trim())
    $("#approve-request-form").css("z-index", -1);
}





function CloseSuccess(result) {

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
            title: 'تم الاغلاق بنجاح ',
            showCancelButton: false,
            showConfirmButton: false,
            timer: 1200
        }).then((result) => {
            window.location.href = "/contactusRequest/index";
        })

    }
}
