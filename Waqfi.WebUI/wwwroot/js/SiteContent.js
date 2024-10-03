function EditItemSuccess(result) {
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
        }).then(() => { window.location.replace("/SiteContents/index/"); });
    }
}
function EditItemFailed(xhr) {
    Swal.fire({
        imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
        title: "حدث خطأ ما",
        showCancelButton: false,
        showConfirmButton: false,
    });
}
function CheckDimension(event, W, H, id, imageId, uploadId, buttonId) {
    var _URL = window.URL || window.webkitURL;
    var file, img, width, height;
    var files = event.target.files;
    var uploadFile = files[0];

    if ((file = uploadFile)) {
        img = new Image();
        var objectUrl = _URL.createObjectURL(file);
        img.onload = function () {
            width = this.width;
            height = this.height;
            _URL.revokeObjectURL(objectUrl);
            if (width != W || height != H) {
                $('#' + id).val('');

                FailedUploadImage("المقاس " + H + " * " + W)
            }
            else {
                readImage(uploadFile, imageId, uploadId, buttonId)
                /*  myFunction(id, imageId)*/
            }
        };
        img.src = objectUrl;


    }
};

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
function FailedUploadImage(mssage) {
    Swal.fire({
        imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
        title: mssage,
        showCancelButton: false,
        showConfirmButton: false,
    });
}
function deleteImage(imageId, buttonId, inputId, uploadId) {
    debugger
    $('#' + imageId).attr("hidden", true);
    $('#' + buttonId).attr("hidden", true);
    $('#' + uploadId).attr("hidden", false);
    $('#' + inputId).val('');
}


function DeleteIcon() {

    $("#IconFileId").attr("hidden", true);
    $("#IconFileDefultId").attr("hidden", false);
    $("#MIconIsEdit").attr("value", true);
    $("#imgUpload1").attr("hidden", false);


}
