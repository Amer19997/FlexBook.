function dowenloadFile(fileId) {
    debugger
    var Id = $("#RequestId").val();
    debugger
    $.ajax({
        url: "?handler=DownloadFile",
        method: "GET",
        data: { "id": fileId, "requestId": Id },
        success: function (response) {
            var a = document.createElement("a");
            a.href = `data:${response.result.contentType};base64,${response.result.file}`;
            a.download = response.result.fileName;
            a.click();
        }
    });
}
function previewFile(fileId) {
    debugger
    var Id = $("#RequestId").val();
    debugger
    $.ajax({
        url: "?handler=DownloadFile",
        method: "GET",
        data: { "id": fileId, "requestId": Id },
        success: function (response) {

            const base64String = response.result.file; // Replace with actual Base64-encoded string
            const contentType = response.result.contentType; // Replace with actual content type
            const byteCharacters = atob(base64String);
            const byteNumbers = new Array(byteCharacters.length);
            for (let i = 0; i < byteCharacters.length; i++) {
                byteNumbers[i] = byteCharacters.charCodeAt(i);
            }
            const byteArray = new Uint8Array(byteNumbers);
            const blob = new Blob([byteArray], { type: contentType });
            const url = URL.createObjectURL(blob);
            window.open(url, '_blank');
        }
    });
}
function swlSuccess(result) {
    
    if (result.errors.length > 0)
    {
        Swal.fire({
            imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
            title: result.errors[0],
            showCancelButton: false
        });
    }
    else
    {
        Swal.fire({
            imageUrl: `/Cms_Lib/img/icons/add-user-popup.svg`,
            title: 'تم رفض الطلب',
            showCancelButton: false,
            showConfirmButton: false,
            timer: 1200
        }).then((result) => {
            window.location.href = "/Provider/ProvidersRequests";
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
  
    $("#RejectionReason").val($("#RejectionReason").val().trim());
}


