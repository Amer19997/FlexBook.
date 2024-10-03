function addBankSuccess(result) {
    if (result.success && result.result != null) {
        swal.fire({
            title: 'تمت عملية الحفظ بنجاح',
            imageUrl: '/Cms_Lib/img/icons/add-user-popup.svg',
            showConfirmButton: false,
            showCancelButton: false,
            timer: 5000
        }).then(() => { window.location.replace("/Bank/Index"); });
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
function addBankFailed(result) {
    Swal.fire({
        imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
        title: "حدث خطأ ما",
        showCancelButton: false,
        showConfirmButton: false,
    });
}



function editBankSuccess(result) {
    if (result.success) {
        swal.fire({
            title: result.result,
            imageUrl: '/Cms_Lib/img/icons/add-user-popup.svg',
            showConfirmButton: false,
            showCancelButton: false,
            timer: 5000
        }).then(() => { window.location.replace("/Bank/Index"); });
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
function editBankFailed(result) {
    Swal.fire({
        imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
        title: "حدث خطأ ما",
        showCancelButton: false,
        showConfirmButton: false,
    });
}

function showDeletePopup(id) {
    $("#bankId").val(id);
    $("#deleteModal").modal('show');
}

function deleteBankSuccess(result) {
    var page = 0;
    if ($("#currentPageNumber").length)
        page = $("#currentPageNumber").val();

    if (result.success) {
        swal.fire({
            title: result.result,
            imageUrl: '/Cms_Lib/img/icons/add-user-popup.svg',
            showConfirmButton: false,
            showCancelButton: false,
            timer: 5000
        }).then(() => { window.location.replace("/Bank/Index"); });
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
function deleteBankFailed(result) {
    Swal.fire({
        imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
        title: "حدث خطأ ما",
        showCancelButton: false,
        showConfirmButton: false,
    });
}


function showActivateOrDeactivatePopup(id,text) {
    $("#bank_Id").val(id);
    $("#activateOrDeactivateText").html(text);
    $("#activateOrDeactivateModal").modal('show');
}

function activateOrDeactivateBankSuccess(result) {
    var page = 0;
    if ($("#currentPageNumber").length)
        page = $("#currentPageNumber").val();

    if (result.success) {
        swal.fire({
            title: result.result,
            imageUrl: '/Cms_Lib/img/icons/add-user-popup.svg',
            showConfirmButton: false,
            showCancelButton: false,
            timer: 5000
        }).then(() => { window.location.replace("/Bank/Index"); });
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
function activateOrDeactivateBankFailed(result) {
    Swal.fire({
        imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
        title: "حدث خطأ ما",
        showCancelButton: false,
        showConfirmButton: false,
    });
}