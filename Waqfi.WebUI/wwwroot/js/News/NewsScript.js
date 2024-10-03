function addNewsSuccess(result) {
    if (result.success && result.result != null) {
      
        swal.fire({
            title: 'تمت عملية الحفظ بنجاح',
            imageUrl: '/Cms_Lib/img/icons/add-user-popup.svg',
            showConfirmButton: false,
            showCancelButton: false,
            timer: 5000
        }).then(() => {
            $("#saveNewsbutton").attr("disabled", false);
            window.location.replace("/News/Index"
            );
        });
    }
    else {
        $("#saveNewsbutton").attr("disabled", false);
        Swal.fire({
            imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
            title: result.errors[0],
            showCancelButton: false,
            showConfirmButton: false
        });
    }
}
function addNewsFailed(result) {
    $("#saveNewsbutton").attr("disabled", false);

    Swal.fire({
        imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
        title: "حدث خطأ ما",
        showCancelButton: false,
        showConfirmButton: false,
    });
}



function editNewsSuccess(result) {
    if (result.success) {
        $("#btnSaveEdit").attr("disabled", true);
        swal.fire({
            title: result.result,
            imageUrl: '/Cms_Lib/img/icons/add-user-popup.svg',
            showConfirmButton: false,
            showCancelButton: false,
            timer: 5000
        }).then(() => { window.location.replace("/News/Index"); });
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
function editNewsFailed(result) {
    Swal.fire({
        imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
        title: "حدث خطأ ما",
        showCancelButton: false,
        showConfirmButton: false,
    });
}

function showDeletePopup(id) {
    $("#newsId").val(id);
    $("#deleteModal").modal('show');
}

function deleteNewsSuccess(result) {
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
        }).then(() => { window.location.replace("/News/Index");});
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
function deleteNewsFailed(result) {
    Swal.fire({
        imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
        title: "حدث خطأ ما",
        showCancelButton: false,
        showConfirmButton: false,
    });
}

//// copied
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
    $('#' + imageId).attr("hidden", true);
    $('#' + buttonId).attr("hidden", true);
    $('#' + uploadId).attr("hidden", false);
    $('#' + inputId).val('');
}

function DeleteMainImage() {
    $("#MainImageId").attr("hidden", true);
    $("#MainImageDefultId").attr("hidden", false);
    $("#editImgHidden").attr("value", true);
    $("#imgUpload").attr("hidden", false);
}