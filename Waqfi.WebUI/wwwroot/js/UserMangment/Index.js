var table;
var Data = {};

var GetUser = $('#UserName').val().trim();
var GetEmail = $('#EmailSerch').val().trim();
var GetPhone = $('#phoneSearch').val().trim();
//var GetRole = $('#Roles').find(":selected").val();
//var GetStatus = $('#Status').find(":selected").val();



//$('#UserName').on("cut copy paste", function (e) {
//    e.preventDefault();
//});



var GetRole = $('#Roles').val();
var GetStatus = $('#Status').val();

$(document).ready(function () {
    
    GetRoleList();
    
    DataTableFun();
});


//Ajax Form
function DataTableFun() {
    
    //table.clear().draw();

    table = $('#UserMangment').DataTable({
        ajax: {
            url: "/UserMangment/Index?handler=GetAjax",
            type: "Post",
            contentType: 'application/x-www-form-urlencoded',
            dataType: "json",
            data: { "User": GetUser, "Email": GetEmail, "Phone": GetPhone, "Roles": GetRole, "Status": GetStatus },
            headers:
            {
                "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
            },
            error: function (xhr, error, thrown) {
                if (xhr.status == 401) {
                    location = '/Admin/Login';
                }
                if (xhr.status == 403) {
                    location = '/Admin/AccessDenied';
                }
            }
        },
        processing: true,
        serverSide: true,
        clear: true,
        filter: false,
        destroy: true,
        dom: '<"toolbar">frtip',
        lengthChange: false,
        pageLength: 10,
        drawCallback: function (data, type, row, counter) {
            var Total = data._iRecordsDisplay;

            var page_min = 10;
            var $api = this.api();
            var pages = $api.page.info().pages;
            var rows = $api.data().length;

            if ((rows < page_min && Total <= 10) || Total <= 10) {


                $('.dataTables_paginate').css('display', 'none')


            }
            else {
                // SHow everything
                $('#UserMangment')
                    .next('.dataTables_info').css('display', 'block')
                    .next('.dataTables_paginate').css('display', 'block');
            }

        },
        info: false,
        language: {
            emptyTable: "لا يوجد نتائج للبحث",
            paginate: {
                next: '&#8592;', // or '→'
                previous: '&#8594;' // or '←'
            }
        },
        columns: [
            //{ data: "id", name: "ID" },
            {
                "render": function (data, type, row, counter) {
                   
                    return  row.pageNumber+ counter.row + 1;
                },
                "orderable": false
            },
            { data: "name" },
            {

                "render": function (data, type, row, counter) {
                    
                    if (row.mobileNumber == "") {
                        return ''
                    } else {
                        return `${row.mobileNumber}(${row.countryCode})`

                    }

                },

                "orderable": false
            },
            { data: "email" },
            { data: "roles" },
            { data: "registerAt" },
            {
                "render": function (data, type, row, counter) {

                    if (row.status == 1) {

                        return `بانتظار التفعيل`
                    }
                    if (row.status == 2) {

                        return `مفعل`
                    }
                    if (row.status == 3) {

                        return `موقوف`
                    }


                },

                "orderable": false
                /* data: "status"*/
            },
            {
                //"render": function (data, type, row) { return '<a href="#" class="btn btn-danger" onclick=DeleteCustomer("' + row.id + '"); > Delete </a>' },
                "render": function (data, type, row, counter) {
                    var result = ` <div class="controls">
                                                    <ul>
                                                        <li>
                                                            <a  class="EditUser"  href="/UserMangment/edit?UserId=${row.id}" ><img  src="/cms_lib/img/icons/Edit.svg" alt="Edit-icon" /></a>
                                                        </li>`;
                   
                    if (HasDeactivateUserRole){
                        if (row.status == 1) {

                            result+= `<li>
                                    <a > <img src="/cms_lib/img/icons/witing-user.svg" alt="waiting-icon" /></a> 
                                                        </li>`;


                        }
                        else if (row.status == 2){
                            result+=`<li>
                                                             <div class="toggle-Section">
                                                                <label class="switch active input_Switch_Ac"  data-id="${row.id}">
                                                                    <input type="checkbox" data-bs-toggle="modal" data-bs-target="#deactive-user-Modal" />
                                                                    <span class="slider round "></span>
                                                                </label>
                                                            </div>
                                                        </li>`;
                        }
                        else {
                            result+= ` <li>
                                                            <div class="toggle-Section">
                                                                <label class="switch input_Switch_De" data-id="${row.id}"  >
                                                                    <input type="checkbox input_Switch_De" data-bs-toggle="modal" data-bs-target="#active-user-Modal" />
                                                                    <span class="slider round "></span>
                                                                </label>
                                                            </div>
                                                        </li>`;
                        }
                        result+= `</ul></div>`;
                    }
                                                
                        return result;
                },

                "orderable": false
            },
        ]
    });
}


$('#SubmitSearch').on('click', function () {
    
    //GetUser = $('#UserName').val();
    //GetEmail = $('#EmailSerch').val();
    //GetPhone = $('#phoneSearch').val();
    //GetRole = $('#Roles').val();
    //GetStatus = $('#Status').find(":selected").val();
    ValidationFilter()
    /*table.clear().draw();*/

})



function ValidationFilter(){

    GetUser = $('#UserName').val().trim();
    GetEmail = $('#EmailSerch').val().trim();
    GetPhone = $('#phoneSearch').val().trim();
    GetRole = $('#Roles').val();
    GetStatus = $('#Status').find(":selected").val();



    // Check Nasme

    if (GetUser != "") {
        if (GetUser.length > 100) {
            return false;
        }
    }


    //Check Email

    if (GetEmail != "") {

        if (GetEmail.length > 100) {

            return false;
        }

       
    }


    //Check Mobile
    var ExistNumber = $.isNumeric(GetPhone);
    if (GetPhone !="") {

        if (!ExistNumber) {
            return false;

        }
    }

    DataTableFun();

}


$('#RemaovePages').on('click', function () {


    //$('#UserName').val('')
    //$('#EmailSerch').val('');
    //$('#phoneSearch').val('')
    //$("#Roles").val($("#target option:first").val());
    //$("#Status").val($("#target option:first").val());


    //GetUser = $('#UserName').val();
    //GetEmail = $('#EmailSerch').val();
    //GetPhone = $('#phoneSearch').val();
    //GetRole = $('#Roles').val();
    //GetStatus = $('#Status').find(":selected").val();

    //DataTableFun();

    location.reload();

})



$(document).on("click", ".input_Switch_Ac", function () {

    var GetUserId = $(this).attr("data-id");
    $('#DeactiveModal').attr("data-id", GetUserId);
    $('#DeactiveNo').attr("data-id", GetUserId);



});

$(document).on("click", ".input_Switch_De", function () {

    var GetUserId = $(this).attr("data-id");
    $('#ActiveModal').attr("data-id", GetUserId);
    $('#ActiveNo').attr("data-id", GetUserId)
});




$(document).on("click", "#ActiveModal", function () {
    

    var GetUserId = $(this).attr("data-id");

    ReloadDeactive(GetUserId);


});

$(document).on("click", "#DeactiveModal", function () {
 
    var GetUserId = $(this).attr("data-id");
    ReloadActive(GetUserId);
});


function ReloadDeactive(GetVal) {
    
    $.ajax({
        url: "?handler=Acvtive",
        type: "Post",
        contentType: 'application/x-www-form-urlencoded',
        dataType: "json",
        data: { "UserId": GetVal },
        headers:
        {
            "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        success: function (result) {
            
            var IfSucces = result.success;
            if (IfSucces) {
                location.reload(true)

            } else {
                debugger;
                $('#active-user-Modal').modal('hide');
                $("#ActiveDeactiveBlockMessage").html(result.errors[0])

                $('#Active-Warning-Modal').modal('show');
            }
        }
    });
}

function ReloadActive(GetVal) {
    
    $.ajax({
        url: "?handler=Deacvtive",
        type: "Post",
        contentType: 'application/x-www-form-urlencoded',
        dataType: "json",
        data: { "UserId": GetVal },
        headers:
        {
            "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        success: function (result) {
            
            var IfSucces = result.success;

            if (IfSucces) {
                location.reload(true)

            } else {
                debugger;
                $('#deactive-user-Modal').modal('hide');
                $("#ActiveDeactiveBlockMessage").html(result.errors[0])
                $('#Active-Warning-Modal').modal('show');
            }
            //Active - Warning - Moda
        }
    });
}



function GetRoleList() {

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
        
        // create the option and append to Select2


        $.each(data, function (key, val) {
            var option = new Option(val.descriptionAr, val.id, true, false);
            RoleSelect.append(option).trigger('change');
        });

        //// manually trigger the `select2:select` event
        //RoleSelect.trigger({
        //    type: 'select2:select',
        //    params: {
        //        data: data
        //    }
        //});
    });
}

