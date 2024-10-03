function approveRequestSuccess(result) {

    $('#Pop-UP-Modal').modal('hide');


    if (result.success) {
        swal.fire({
            title: "تم قبول الطلب بنجاح",
            text: "",
            imageUrl: '/Cms_Lib/img/icons/add-user-popup.svg',
            showConfirmButton: false,
            showCancelButton: false,
            timer: 1000
        }).then(() => { window.location.replace("/ProductBanner/index"); });
    }
    else {
        Swal.fire({
            imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
            title: result.errors[0],
            showCancelButton: false,
            showConfirmButton: false
        });
    }
}
function approveRequestFailed(result) {
    $('#Pop-UP-Modal').modal('hide');
    Swal.fire({
        imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
        title: "حدث خطأ ما",
        showCancelButton: false,
        showConfirmButton: false,
    });
}




function RejectRequestSuccess(result) {

    $('#Pop-UP-Modal').modal('hide');


    if (result.success) {
        swal.fire({
            title: "تم رفض الطلب بنجاح",
            text: "",
            imageUrl: '/Cms_Lib/img/icons/add-user-popup.svg',
            showConfirmButton: false,
            showCancelButton: false,
            timer: 1000
        }).then(() => {
            $("#reject-Modal").modal('hide');
            window.location.replace("/AwqafProduct/index");
        });
    }
    else {
        Swal.fire({
            imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
            title: result.errors[0],
            showCancelButton: false,
            showConfirmButton: false
        });
    }
}
function RejectRequestFailed(result) {
    $('#Pop-UP-Modal').modal('hide');
    Swal.fire({
        imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
        title: "حدث خطأ ما",
        showCancelButton: false,
        showConfirmButton: false,
    });
}