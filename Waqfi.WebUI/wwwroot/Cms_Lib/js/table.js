// data table 
var table;
var Data = {};
$(document).ready(function () {
    RenderTable();
});

// Ajax Form
function RenderTable() {
    table = $('#Donator').DataTable({
        ajax: {
            url: "/?handler=GetAjax",
            type: "POST",
            contentType: 'application/x-www-form-urlencoded',
            dataType: "json",
            data: Data,
            headers:
            {
                "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
            }
        },
        dom: '<"">frtip',
        processing: false,
        serverSide: true,
        filter: false,
        lengthChange: false,
        pageLength: 10,
        info: false,
        language: {
            paginate: {
                next: '&#8592;', // or '→'
                previous: '&#8594;' // or '←'
            }
        },


        columns: [
            //{ data: "id", name: "ID" },
            {
                "render": function (data, type, row, counter) {
                    return counter.row + 1;
                },
                "orderable": false
            },
            { data: "firstName", name: "FirstName" },
            { data: "lastName", name: "LastName" },
            { data: "contact", name: "Mobile" },
            { data: "email", name: "Email" },
            {
                "render": function (data, type, row) { return '<a href="#" class="btn btn-danger" onclick=DeleteCustomer("' + row.id + '"); > Delete </a>' },
                "orderable": false
            },
            //{ data: "DateOfBirth", name: "DateOfBirth" }
        ]
    });

}
// search Table
function Search() {
    debugger
    var GetDonator = $('#donator').val();
    var GetEmail = $('#EmailSerch').val();
    var GetPhone = $('#phoneSearch').val();
    Data = { "Donator": GetDonator, "Email": GetEmail, "Phone": GetPhone };

    table.ajax.url("/?handler=GetAjax").load();
    //RenderTable();


}
