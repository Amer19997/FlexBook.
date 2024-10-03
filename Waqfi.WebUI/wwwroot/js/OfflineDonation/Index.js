function dowenloadFile(fileId) {

    $.ajax({
        url: "?handler=DownloadFile",
        method: "GET",
        data: { "requiestId": fileId },
        success: function (response) {

            var a = document.createElement("a");
            a.href = `data:${response.result.contentType};base64,${response.result.file}`;
            a.download = response.result.fileName;
            a.click();
        }
    });
}


$(document).on('click', '.RejectResonsReqs', function () {

    var GetRes = $(this).data("id");
    $('#ReasonRes').text(GetRes);

    $('#Resject-Reason-Modal').modal('show');
})

$('#returnRequestAction').on('click', function (e) {

    $('#Offline-Action-Modal').modal('show');
    $('#ApproveRequestDonation').attr("data-id", Getval);
    $('#RejRequestDonation').attr("data-id", Getval);
});



$(document).on('click', '.RequestAction', function () {

    var Getval = $(this).data("id");

    $('#Offline-Action-Modal').modal('show');
    $('#ApproveRequestDonation').attr("data-id", Getval);
    $('#RejRequestDonation').attr("data-id", Getval);
})

//$('.RequestAction').on('click', function (e) {
//    var Getval = $(this).data("id");

//    $('#Offline-Action-Modal').modal('show');
//    $('#ApproveRequestDonation').attr("data-id", Getval);
//    $('#RejRequestDonation').attr("data-id", Getval);
//});

$('#RejRequestDonation').on('click', function (e) {

    $('#RejectionReason').val('');
    var Getvals = $(this).data("id");
    $('#reject-Modal').modal('show');
    $('#deactive-id').attr("data-id", Getvals);
});

$('#deactive-id').on('click', function (e) {
    var Getvalss = $(this).data("id");

    var RejectRes = $('#RejectionReason').val();
    if (RejectRes == "") {

        $('#errorReject').removeClass('d-none');
        $('#errorReject').addClass('d-block');
        return false;
    }

    $.ajax({
        url: "?handler=RejectRequest",
        method: "Post",
        contentType: 'application/x-www-form-urlencoded',
        dataType: "json",
        data: { "RequestId": Getvalss, "RejectReson": RejectRes },
        headers:
        {
            "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        success: function (response) {
            debugger
            $('#reject-Modal').modal('hide');
            if (response.success) {
                window.location.replace("/OfflineDonation/Index");
            }
            else {
                Swal.fire({
                    imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
                    title: response.errors[0],
                    showCancelButton: false,
                    showConfirmButton: false
                });
            }
            

        }
        ,
        error: function () {
            Swal.fire({
                imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
                title: "حدث خطأ ما",
                showCancelButton: false,
                showConfirmButton: false,
            });
        }
    });
});

$('#ApproveRequestDonation').on('click', function (e) {

    $('#Offline-Action-Modal').modal('hide');

    var Getval = $(this).data("id");
    $.ajax({
        url: "?handler=ApproveRequest",
        method: "GET",
        data: { "RequestId": Getval },
        success: function (response) {
            debugger
            if (response.success) {
                $('#ApprovedR').modal('show');
                setTimeout(function () {
                    window.location.replace("/OfflineDonation/Index");
                }, 2000);
            } else {
                Swal.fire({
                    imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
                    title: response.errors[0],
                    showCancelButton: false,
                    showConfirmButton: false
                });
            }
           


        },
        error: function () {
            Swal.fire({
                imageUrl: `/Cms_Lib/img/icons/warning-popup.svg`,
                title: "حدث خطأ ما",
                showCancelButton: false,
                showConfirmButton: false,
            });
        }
    });
});

$('.filteration').on('input', function (e) {
    debugger
    var Getval = $(this).val();
    if (Getval != '') {
        $('.btnclose').removeClass('d-none');
        $('.btnclose').addClass('d-block');
    } else {
        $('.btnclose').addClass('d-none');
        $('.btnclose').removeClass('d-block');
    }
});

