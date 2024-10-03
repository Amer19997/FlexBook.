// Back to List
$(document).on("click", "#BackList", function () {

    window.location.replace("/TopGivers/Index");
});

function AddNewDonationSuccess(result) {
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
            title: "تمت عملية الحفظ بنجاح",
            imageUrl: '/Cms_Lib/img/icons/add-user-popup.svg',
            showConfirmButton: false,
            showCancelButton: false,
            timer: 5000
        }).then(() => { window.location.replace("/TopGivers/index"); });
    }
}
function AddNewDonationFailed(xhr) {
    Swal.fire({
        imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
        title: "حدث خطأ ما",
        showCancelButton: false,
        showConfirmButton: false,
    });
}

// check dimentions images
function CheckDimension(event, id, imageId, uploadId, buttonId) {
    var _URL = window.URL || window.webkitURL;
    var file, img;
    var files = event.target.files;
    var uploadFile = files[0];

    if ((file = uploadFile)) {
        img = new Image();
        var objectUrl = _URL.createObjectURL(file);
        img.onload = function () {
            _URL.revokeObjectURL(objectUrl);
            readImage(uploadFile, imageId, uploadId, buttonId);
        };
        img.src = objectUrl;
    }
};

function FailedUploadImage(mssage) {
    Swal.fire({
        imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
        title: mssage,
        showCancelButton: false,
        showConfirmButton: false,
    });
}


function ChangeMasarMethod() {

    $("#Productdropdown").prop("hidden", true)
    $("#Masardropdown").prop("hidden", false)

    var dropdown = document.getElementById('ProductId');

    // Set the selected index to 0 (which represents the default option)
    dropdown.selectedIndex = null;

    document.getElementById('IsQuickDonation').value = false;


}
function ChangeProductMethod() {

    $("#Productdropdown").prop("hidden", false)
    $("#Masardropdown").prop("hidden", true)
    var dropdownMasart = document.getElementById('Masarid');

    // Set the selected index to 0 (which represents the default option)
    dropdownMasart.selectedIndex = null;

    document.getElementById('IsQuickDonation').value = false;


}

function ChangeQuickMethod(value) {

    $("#Productdropdown").prop("hidden", true)
    $("#Masardropdown").prop("hidden", true)
    var dropdown = document.getElementById('ProductId');

    // Set the selected index to 0 (which represents the default option)
    dropdown.selectedIndex = null;

    var dropdownMasart = document.getElementById('Masarid');
    dropdownMasart.selectedIndex = null;

   



}

function readImage(file, imageId, upload, buttonId) {
    var image = document.getElementById(imageId);
    // Check if the file is an image.
    if (file.type && !file.type.startsWith('image/')) {
        console.log('File is not an image.', file.type, file);
        return;
    }
    $('#' + imageId).attr("hidden", false);
    $('#' + upload).attr("hidden", true);

    const reader = new FileReader();
    reader.addEventListener('load', (event) => {
        image.src = event.target.result;
    });
    reader.readAsDataURL(file);
    $('#' + buttonId).attr("hidden", false);
}

// delete image 
function deleteImage(imageId, buttonId, inputId, uploadId) {
    $('#' + imageId).attr("hidden", true);
    $('#' + buttonId).attr("hidden", true);
    $('#' + uploadId).attr("hidden", false);
    $('#' + inputId).val('');
}