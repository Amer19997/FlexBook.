// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {


    $("#Roles").select2({
        closeOnSelect:false,
        placeholder: "اختر دور المستخدم",
        tags: true,
        allowClear: true
    });

    GetRole();
});


function GetRole() {

    var RoleSelect = $('#Roles');
    $.ajax({
        url: "?handler=GetRoles",
        type: "Post",
        contentType: 'application/x-www-form-urlencoded',
        dataType: "json",
        headers:
        {
            "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
        }
    }).then(function (data) {
        

        $.each(data, function (key, val) {
            
            var option = new Option(val.descriptionAr, val.id, true, false);
            RoleSelect.append(option).trigger('change');
        });


    });
}

$('#UserName').on("cut copy paste", function (e) {
    e.preventDefault();
});

$('#UserName').on("keyup", function (e) {

    var GetVal = $(this).val();

    if (GetVal.length >= 1) {

        $('#ValidNamel').removeClass('d-block');
        $('#ValidNamel').addClass('d-none');
    }
});

$('#Email').on("keyup", function (e) {

    var GetVal = $(this).val();

    if (GetVal.length >= 1) {

        $('#ValidEmail').removeClass('d-block');
        $('#ValidEmail').addClass('d-none');
    }
});


$('#Phone').on("keyup", function (e) {

    var GetVal = $(this).val();

    if (GetVal.length >= 1) {

        $('#ValidPhone').removeClass('d-block');
        $('#ValidPhone').addClass('d-none');
    }
});


function CreateUser(e) {

    

    

    var flag = false;
    $("#UserName").val($("#UserName").val().trim());
    $("#Email").val($("#Email").val().trim());
    var GetUserName = $("#UserName").val().trim();
    var GetEmail = $("#Email").val().trim();
    var GetPhone = $("#Phone").val().trim();
    var GetRoles = $("#Roles").val();


    $('#ValidNamel').removeClass('d-block');
    $('#ValidNamel').addClass('d-none');

    $('#ValidEmail').removeClass('d-block');
    $('#ValidEmail').addClass('d-none');

    $('#ValidPhone').removeClass('d-block');
    $('#ValidPhone').addClass('d-none');


    $('#ValidRole').removeClass('d-block');
    $('#ValidRole').addClass('d-none');


    if (GetUserName == "" || GetEmail == "" || GetRoles == "")
    {

   

        if (GetUserName == "")
        {

            $('#ValidNamel').removeClass('d-none');
            $('#ValidNamel').addClass('d-block');
        }

        if (GetEmail == "") 
        {
            $('#ValidEmail').removeClass('d-none');
            $('#ValidEmail').addClass('d-block');
        }
        if (GetRoles == "") {
            $('#ValidRole').removeClass('d-none');
            $('#ValidRole').addClass('d-block');
        }
      
        flag = true;
    }

    $("#Roles").change(function () {

        var getLength = $(this).select2('data');
        if (getLength.length >= 1) {
            $('#ValidRole').removeClass('d-block');
            $('#ValidRole').addClass('d-none');
        }

    });

    //if (GetUserName != "" ) {


    //    if (/^[a-zA-Z0-9- ]*$/.test(GetUserName) == false) {

    //        $('#ValidNamel').text('يجب ادخال الاسم صحيح');
    //        $('#ValidNamel').removeClass('d-none');
    //        $('#ValidNamel').addClass('d-block');
    //        flag = true;

    //    }

    //}



    if (GetEmail != "")
    {
        var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;

        var CheckRegax = regex.test(GetEmail);
        if (CheckRegax == false) {
            $('#ValidEmail').text('يجب أن يكون البريد الإلكتروني بالصيغة التالية: test@test.com');
            $('#ValidEmail').removeClass('d-none');
            $('#ValidEmail').addClass('d-block');
            flag = true;
           
        }
    }


    if (GetPhone != "") {
        
        var GetMaxLenth = GetPhone.length
        if (GetMaxLenth != 10)
        {
            $('#ValidPhone').removeClass('d-none');
            $('#ValidPhone').addClass('d-block');
            $('#ValidPhone').text('يجب ادخال رقم جوال صحيح');
            flag = true;
         
        }
        var GetFirstNum = GetPhone.charAt(0) + GetPhone.charAt(1)

        if (GetFirstNum != "05")
        {
            $('#ValidPhone').text('يجب ادخال رقم جوال صحيح');
            $('#ValidPhone').removeClass('d-none');
            $('#ValidPhone').addClass('d-block');
            flag = true;
          
        }
       
    }


    if (flag == true)
        return false;

    //$('#AddAction').prop('disabled', true)
    $.ajax({
        url: "?handler=CreateUser",
        type: "Post",
        contentType: 'application/x-www-form-urlencoded',
        dataType: "json",
        data: { "UserName": GetUserName, "Email": GetEmail, "Phone": GetPhone, "Roles": GetRoles },
        headers:
        {
            "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        success: function (Result) {

            var IfSucces = Result.success;

            if (IfSucces) {
                $("#UserName").val('');
                $("#Email").val('');
                $("#Phone").val('');
                $("#Roles").val("");
                $("#Roles").trigger("change");
                $('#add-user-Modal').modal('show');
                setTimeout(function () {

                    window.location.replace("/UserMangment/Index");

                }, 1000);

            } else {
                $('#Active-Warning-Modal').modal('show');
                $('#TextValidation').text(Result.message)
            }

        
        }
    });

}

$(document).on("click", "#add-user-Modal", function () {
    
    BackToList();
});


function BackToList() {

    window.location.replace("/UserMangment/Index");
}

$(document).on("click", "#BackList", function () {
    
    BackToList();
});

