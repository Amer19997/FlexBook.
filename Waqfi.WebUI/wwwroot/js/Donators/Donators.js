//var table;
//var Data = {};

var GetDonatorName = $('#Donatorname').val();
var GetEmail = $("#emailserch").val().trim();


var GetPhone = $('#Phone').val();


//$('#Donatorname').on("cut copy paste", function (e) {
//    e.preventDefault();
//});

//$('#Phone').on("cut copy paste", function (e) {
//    e.preventDefault();
//});

$(document).ready(function () {
    RenderTable();
});

// Ajax Form
function RenderTable() {
   

    table = $('#Donator').DataTable({
        ajax: {
            url: "/Donator/Donators?handler=GetAjax",
            type: "Post",
            contentType: 'application/x-www-form-urlencoded',
            dataType: "json",
            data: { "Donatorname": GetDonatorName, "Email": GetEmail, "Phone": GetPhone },
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
        destroy: true,
        dom: '<"toolbar">frtip',
        processing: false,
        serverSide: true,
        filter: false,
        ordering: false,
        lengthChange: false,
        pageLength: 10,
        drawCallback: function (data, type, row, counter) {
            var Total = data._iRecordsTotal;

            var page_min = 10;
            var $api = this.api();
            var pages = $api.page.info().pages;
            var rows = $api.data().length;

            if ((rows < page_min && Total <= 10) || Total <= 10 ) {
              

                $('.dataTables_paginate').css('display', 'none')


            } 
            else {
                // SHow everything
                $('#Donator')
                    .next('.dataTables_info').css('display', 'block')
                    .next('.dataTables_paginate').css('display', 'block');
            }
            
        },
        info: false,
        language: {
            emptyTable: "(لا يوجد نتائج للبحث)",
            paginate: {
                next: '&#8592;', // or '→'
                previous: '&#8594;' // or '←'
            },
            
        },
        columns: [
            //{ data: "id", name: "ID" },
            {
                "render": function (data, type, row, counter) {
                    return row.counterPage + counter.row + 1;
                },
                "orderable": false
            },
            { data: "fullName", name: "FullName" },
            { data: "mobileNumber", name: "MobileNumber" },
            { data: "email", name: "Email" },
            
            { data: "creationDate", name: "CreationDate" },
            //{ data: "DateOfBirth", name: "DateOfBirth" }
        ]
    });




    //$('.pagination').hide();

    //$('div.toolbar').html(`
    //                    `);

}


// search Table
function Search() {
    

    GetDonatorName = $('#Donatorname').val();
    GetEmail = $('#emailserch').val();
    GetPhone = $('#Phone').val();
    //table.ajax.url("/Donator/Donators?handler=GetAjax&Donator=1").load();


    RenderTable();
}
function Closebtn() {

    
    $("#Donatorname").val('');
    $("#emailserch").val('');
    $("#Phone").val('');

    

}