function approveRequestSuccess(result) {
    if (result.success) {
        swal.fire({
            title: "تم قبول الطلب بنجاح",
           // text: "تم اضافة المستخدم الي المنصة واضافة الصلاحيات الخاصة به والمهام",
            imageUrl: '/Cms_Lib/img/icons/add-user-popup.svg',
            showConfirmButton: false,
            showCancelButton: false,
            timer: 5000 
        }).then(() => { window.location.replace("/Provider/ProvidersRequests"); });
    }
    else {
        Swal.fire({
            imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
            title: "حدث خطأ ما",
            showCancelButton: false,
            showConfirmButton: false
        });
    }
}
function approveRequestFailed(result){
    Swal.fire({
        imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
        title: "حدث خطأ ما",
        showCancelButton: false,
        showConfirmButton: false,
    });
}

$("#dueDateProvider").click(function () {
     
    $("#DueDate").datepicker("show");
});

$("#DueDate").change(function () {
    debugger
    var dueDate = $(this).val().split("/")[0];
    $.ajax({
        url: "?handler=DueDate",
        type: "Post",
        contentType: 'application/x-www-form-urlencoded',
        dataType: "json",
        data: { "dueDate": parseInt(dueDate) },
        headers:
        {
            "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        success: function (result) {
             
            var IfSucces = result.success;
            if (IfSucces) {
                swal.fire({
                    title: "تمت عملية الحفظ بنجاح",
                    imageUrl: '/Cms_Lib/img/icons/add-user-popup.svg',
                    showConfirmButton: false,
                    showCancelButton: false,
                    timer: 5000
                }).then(() => { window.location.replace("/ApprovedProvider/Index/"); });

            }
        }
    });
});