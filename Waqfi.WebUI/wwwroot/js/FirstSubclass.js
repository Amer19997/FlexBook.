function addProductUnitSuccess(result) {
    if (result.success && result.result !=null) {
        swal.fire({
            title: 'تمت عملية الحفظ بنجاح',
            imageUrl: '/Cms_Lib/img/icons/add-user-popup.svg',
            showConfirmButton: false,
            showCancelButton: false,
            timer: 5000
        }).then(() => { window.location.replace("/FirstSubclass/Index"); });
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
function addProductUnitFailed(result) {
    Swal.fire({
        imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
        title: "حدث خطأ ما",
        showCancelButton: false,
        showConfirmButton: false,
    });
}



function editProductUnitSuccess(result) {
    if (result.success) {
        swal.fire({
            title: result.result,
            imageUrl: '/Cms_Lib/img/icons/add-user-popup.svg',
            showConfirmButton: false,
            showCancelButton: false,
            timer: 5000
        }).then(() => { window.location.replace("/FirstSubclass/Index"); });
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
function editProductUnitFailed(result) {
    Swal.fire({
        imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
        title: "حدث خطأ ما",
        showCancelButton: false,
        showConfirmButton: false,
    });
}

function showDeletePopup(id) {
    $("#unitId").val(id);
    $("#deleteModal").modal('show');
}

function deleteProductUnitSuccess(result) {
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
        }).then(() => { window.location.replace("/FirstSubclass/Index");});
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
function deleteProductUnitFailed(result) {
    Swal.fire({
        imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
        title: "حدث خطأ ما",
        showCancelButton: false,
        showConfirmButton: false,
    });
}

function showhiddenPopup(id) {
    $("#hiddenId").val(id);
    $("#hiddenModal").modal('show');
}