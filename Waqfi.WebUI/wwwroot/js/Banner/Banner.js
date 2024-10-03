
// Back to List
$(document).on("click", "#BackList", function () {

    BackToList();
});

function BackToList() {

    window.location.replace("/Banner/Index");
}

// check dimentions images
function CheckDimension(event, W, H, id, imageId, uploadId, buttonId) {
    debugger;
    var _URL = window.URL || window.webkitURL;
    var file, img, width, height;
    var files = event.target.files;
    var uploadFile = files[0];

    if ((file = uploadFile)) {
        debugger;
        if (file.type.startsWith('video/')) {
            readImage(uploadFile, imageId, uploadId, buttonId)
        } else {
            img = new Image();
            var objectUrl = _URL.createObjectURL(file);
            img.onload = function () {
                width = this.width;
                height = this.height;
                _URL.revokeObjectURL(objectUrl);
                if (W!=0 && H!=0 && (width != W || height != H)) {
                    $('#' + id).val('');

                    FailedUploadImage("المقاس " + H + " * " + W)
                }
                else {
                    readImage(uploadFile, imageId, uploadId, buttonId)
                }
            };
            img.src = objectUrl;
        }
        


    }
};
/***************************************************** */
function CheckDimensionPhoneImage(event, W, H, id, imageId, uploadId, buttonId) {
    debugger;
    var _URL = window.URL || window.webkitURL;
    var file, img, width, height;
    var files = event.target.files;
    var uploadFile = files[0];

    if ((file = uploadFile)) {
        debugger;
        if (file.type.startsWith('video/')) {
            readPhoneImage(uploadFile, imageId, uploadId, buttonId)
        } else {
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
                }
            };
            img.src = objectUrl;
        }



    }
};



function readPhoneImage(file, imageId, upload, buttonId) {
    debugger;
    var image = document.getElementById(imageId);
    // Check if the file is an image.

    if (file.type && !file.type.startsWith('image/') && !file.type.startsWith('video/')) {
        console.log('File is not an image or video.', file.type, file);
        return;
    }
    $('#' + imageId).attr("hidden", false);
    $('#' + upload).attr("hidden", true);

    const reader = new FileReader();
    reader.addEventListener('load', (event) => {
        if (file.type.startsWith('video/')) {
            image.src = "/Cms_Lib/img/icons/Group 48542.svg";
        } else {
            image.src = event.target.result;
        }

    });
    reader.readAsDataURL(file);
    $('#' + buttonId).attr("hidden", false);
}







/********************************* */


function FailedUploadImage(mssage) {
    Swal.fire({
        imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
        title: mssage,
        showCancelButton: false,
        showConfirmButton: false,
    });
}

function readImage(file, imageId, upload, buttonId) {
    console.log(imageId);
    debugger;
    var image = document.getElementById(imageId);
    // Check if the file is an image.

    console.log(imageId);

    if (file.type && !file.type.startsWith('image/') && !file.type.startsWith('video/')) {
        console.log('File is not an image or video.', file.type, file);
        return;
    } 
    $('#' + imageId).attr("hidden", false);
    $('#' + upload).attr("hidden", true);

    const reader = new FileReader();
    reader.addEventListener('load', (event) => {
        if (file.type.startsWith('video/')) {
            image.src = "/Cms_Lib/img/icons/Group 48542.svg";
        } else {
            image.src = event.target.result;
        }
       
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

function deleteBannerPhoneImage(imageId, buttonId, inputId, uploadId) {
    $('#' + imageId).attr("hidden", true);
    $('#' + buttonId).attr("hidden", true);
    $('#' + uploadId).attr("hidden", false);
    $('#' + inputId).val('');
}


