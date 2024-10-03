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
            title: "تمت عملية الحفظ بنجاح",
            imageUrl: '/Cms_Lib/img/icons/add-user-popup.svg',
            showConfirmButton: false,
            showCancelButton: false,
            timer: 5000
        }).then(() => { window.location.replace("/Masarat/index/"); });
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
        }).then(() => { window.location.replace("/Masarat/index/"); });
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

function CheckDimension(event, W, H, isIcon,id, imageId, uploadId, buttonId) {
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
            if (width != W || height != H)
            {
                $('#' + id).val('');
                FailedUploadImage("المقاس " + W + " * " + H)
            }
            else
            {
                if (isIcon == true) {
                    readImage(uploadFile, imageId, uploadId, buttonId)
                }
                else {
                    var length = document.getElementById("imgUpload2").files.length + document.getElementById("imgUpload3").files.length;
                   
                    if (length > ImageMax) {
                        Swal.fire({
                            imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
                            title: " الحد الأقصى لعدد  الصور لا يزيد عن " + ImageMax +" صورة ",
                            showCancelButton: false,
                            showConfirmButton: false,
                        });
                        document.getElementById("imgUpload2").value = "";

                    }
                    else if (CheckSize() > (MasaratImgMaxMB * 1048576))
                    {

                        Swal.fire({
                            imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
                            title: " الحد الأقصى لحجم كل الصور لا يزيد عن" + " MB " + MasaratImgMaxMB,
                            showCancelButton: false,
                            showConfirmButton: false,
                        });
                        document.getElementById("imgUpload2").value = "";
                    }
                    else {
                        var file = document.getElementById("imgUpload2").files;
                        var secondFile = document.getElementById("imgUpload3").files;
                        var filesa = new DataTransfer();
                        for (var i = 0; i < file.length; i++) {
                            filesa.items.add(file[i]);
                        }
                        for (var i = 0; i < secondFile.length; i++) {
                            filesa.items.add(secondFile[i]);
                        }
                        document.getElementById("imgUpload3").files = filesa.files;
                        var myFile = document.getElementById("imgUpload3").files;
                        $("#DynamicAttachment").children().remove();

                        for (var i = 0; i < myFile.length; i++) {
                            var id = "img" + i;
                            PreviewImage(myFile[i], id, i);
                        }
                        document.getElementById("imgUpload2").value = "";

                    }
                }
            }
        };
        img.src = objectUrl;
    }

   
  
   
}
async function PreviewImage(file,id,index) {
    var reader = new FileReader();

    reader.addEventListener('load', (event) => {
        $("#DynamicAttachment").append("<div class='col-2 mb-2 d-flex flex-column'><div class= 'attachFile' ><img id='" + id + "'  style='width: 140px;height: 140px; display: inline-flex;' /></div>" +
            "<button style='justify-content:center ;align-items:center' type='button' class='btn btn-warning' onclick='RemoveImage($(this), " +index +")'> <img class='m-0' src = '/cms_lib/img/icons/Delete.svg' ></button ></div>");
        var img = document.getElementById(id);
        img.src = event.target.result;
    });
    await reader.readAsDataURL(file);
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
function RemoveImage(input,index)
{
    debugger
    document.getElementById("imgUpload2").value = "";
    var secondFile = document.getElementById("imgUpload3").files;
    var filesa = new DataTransfer();
    for (var i = 0; i < secondFile.length; i++)
    {
        if (i != index)
        {
            filesa.items.add(secondFile[i]);
        }
    }
    document.getElementById("imgUpload3").value = "";
    document.getElementById("imgUpload3").files = filesa.files;
    $("#DynamicAttachment").children().remove();
    for (var indexItem = 0; indexItem < filesa.files.length; indexItem++) {
        var id = "img" + indexItem;
        PreviewImage(filesa.files[indexItem], id, indexItem);
    }
    $("html, body").animate({ scrollTop: $("#myID").scrollTop() }, 500);
}
function CheckSize()
{
    debugger
    var firstFiles = document.getElementById("imgUpload2").files;
    var secondFiles = document.getElementById("imgUpload3").files;
    var totalSize = 0;

    for (var i = 0; i < firstFiles.length; i++) {
        totalSize = totalSize + firstFiles[i].size;
    }
    for (var i = 0; i < secondFiles.length; i++)
    {
        totalSize = totalSize + secondFiles[i].size;
    }

    return totalSize;
}