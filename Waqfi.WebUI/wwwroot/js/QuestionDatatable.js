
//  table scripts

function checkOnChange() {
    if ($('#name').val() != 'undefinded' && $('#name').val().length > 0) {
        if ($('#name').val().length == 200) {
            $('#nameValidation').html('اسم السؤال غير صحيح' + "<br />");
            $('#name').prop("disabled", true);
        } else {
            $('#name').prop("disabled", false);
            $('#nameValidation').html("");
        }

    }
    else {
        $('#nameValidation').html('هذا الحقل إلزامي' + "<br />");

    }
}



var table;
var Data = {};
var GetQuestion = $('#Question').val();
$(document).ready(function () {
    RenderTable();



    $('#Questiontable tbody').on('click', 'button.dt-control', function () {

        var GetData = $(this).attr("data-answer");


        var tr = $(this).closest('tr');
        var row = table.row(tr);

        if (row.child.isShown()) {
            // This row is already open - close it
            row.child.hide();
            tr.removeClass('shown');
        } else {
            // Open this row
            row.child(format(GetData)).show();
            tr.addClass('shown');
        }
    });
});

//$('#Question').on("cut copy paste", function (e) {
//    e.preventDefault();
//});


function RenderTable() {
    table = $('#Questiontable').DataTable({
        ajax: {
            url: "/Question/QuestionList?handler=GetAjax",
            type: "POST",
            contentType: 'application/x-www-form-urlencoded',
            dataType: "json",
            data: { "questionSearch": GetQuestion },
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
        dom: '<"">frtip',
        processing: true,
        serverSide: true,
        filter: false,
        lengthChange: false,

        drawCallback: function (data, type, row, counter) {
            /*   debugger;*/
            var Total = data._iRecordsTotal;
            var page_min = 10;
            var $api = this.api();
            var pages = $api.page.info().pages;
            var rows = $api.data().length;

            // Tailor the settings based on the row count
            if ((rows < page_min && Total <= 10) || Total <= 10) {


                $('.dataTables_paginate').css('display', 'none')

            } else {
                // SHow everything
                $('#Questiontable')
                    .next('.dataTables_info').css('display', 'block')
                    .next('.dataTables_paginate').css('display', 'block');
            }
        },
        pageLength: 10,
        info: false,
        language: {

            paginate: {
                next: '&#8592;', // or '→'
                previous: '&#8594;' // or '←'
            },

            emptyTable: "(لا يوجد نتائج للبحث)"

        },


        columns: [
            //{ data: "id", name: "ID" },

            {
                "render": function (data, type, row, counter) {

                    return row.counterPage + counter.row + 1;
                },
                "orderable": false,
                data: null,
                defaultContent: '',
            },

            //{ data: "question", name: "Question" ,HTMLButtonElement },
            {

                "render": function (data, type, row) {

                    return `  <div class="d-flex align-items-center">
                                                    <button data-Answer="${row.answer}"  class="dt-control px-3">
                                                        <img src="/cms_lib/img/icons/Arrow - Down Circle.svg" alt="">
                                                    </button>
                                                    <span class="mb-0">
                                                      ${row.question}
                                                    </span>
                                                </div>`},
                "orderable": false
            },
            { data: "priorityNumber", name: "priorityNumber" },
            { data: "questionStatue", name: "questionStatue" },
            { data: "questionCreate", name: "questionCreate" },

            {

                "render": function (data, type, row) {
                    return `  <div class="controls">
                                                    <ul>
       <li>
                                              <a class="Detalies" data-id="${row.questionId}" href="#"">
                                                        <img src="/cms_lib/img/icons/Document.svg"  alt="users-icon" />
                                                     </a>
                                                        </li>

                                                        <li>
                                       <a href="/Question/UpdateQuestion?Id=${row.questionId}">
                                        <img src="/cms_lib/img/icons/Edit.svg"  alt="users-icon" />
                                        </a>
                                                        </li>
                                                        <li>
                                                            <a class="del" data-id="${row.questionId}" href="#">
                                                        <img  src="/cms_lib/img/icons/Delete.svg" alt="users-icon" /></a>
                                                        </li>
                                                        
                                                     
                                                    </ul>
                                                </div>`},
                "orderable": false
            },
            //{ data: "DateOfBirth", name: "DateOfBirth" }

        ],
        // Add event listener for opening and closing details

    });


}




function format(d) {
    // `d` is the original data object for the row
    console.log(d);

    return (
        `<span class="data-details" style="width: 100%;
    background-color: transparent !important;
    text-align: start;
    display: inline-block;
    margin-inline-start: 60px;
    text-align: start;
    max-width: 95%">
                     
                      <td colspan="5">${d}</td>
         </span>`
    );

    //return (
    //    '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">' +
    //    '<tr>' +
    //    '<td>Full name:</td>' +
    //    '<td>' +
    //   'test' +
    //    '</td>' +
    //    '</tr>' +
    //    '<tr>' +
    //    '<td>Extension number:</td>' +
    //    '<td>' +
    //    'test' +
    //    '</td>' +
    //    '</tr>' +
    //    '<tr>' +
    //    '<td>Extra info:</td>' +
    //    '<td>And any further details here (images etc)...</td>' +
    //    '</tr>' +
    //    '</table>'
    //);
}
// search Table
function Search() {

    GetQuestion = $('#Question').val();

    //Data = { "Donator": GetDonator, "Email": GetEmail, "Phone": GetPhone };

    RenderTable();
    //RenderTable();
}



function CreateQuestion() {

    var form = document.getElementById("form-id");



    form.submit();
};


$(document).on("click", ".del", function () {

    var QuestionID = $(this).attr("data-id");
    console.log(QuestionID);

    $("#YesValue").attr("href", "/Question/DeleteQuestion?id=" + QuestionID)
    $('#deleteModal').modal('show');

});


function UpdateQuestion() {


    var form = document.getElementById("form-id");

    form.submit();
};

function Closebtn() {


    $("#Question").val('');

}



$(document).on("click", ".del", function () {

    var QuestionID = $(this).attr("data-id");
    console.log(QuestionID);

    $("#YesValue").attr("href", "/Question/DeleteQuestion?id=" + QuestionID)
    $('#deleteModal').modal('show');

});


$(document).on("click", ".cancelupdate", function () {


    $('#deleteModal').modal('show');

});

$(document).on("click", ".ShowDetalies", function () {

    var QuestionID = $(this).attr("data-itemid");

    Reloaddata(QuestionID);
    

});

function Reloaddata(QuestionID)
{
    

    $.ajax({    
        url: "/Question/UpdateQuestion?handler=DataModal",
        type: "Get",
        contentType: 'application/x-www-form-urlencoded',
        data: { "QuestionId": QuestionID },
        headers:
        {
            "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        success: function (result) {

            var data = result;
            $('#QuestionArModel').val(data.questionAr);
            var model = $('#detailsModal');
            model.find('#QuestionArModel').text(data.questionAr)
            model.find('#AnswerArModel').text(data.answerAr)
            model.find('#QuestionENModel').text(data.questionEn)
            model.find('#AnswerENModel').text(data.answerEN)
            model.find('#QuestionStatues').text(data.questionStatue == 1 ? "غير فعال" : "فعال")
            model.find('#QuestionProirty').text(data.priorityNumber)
            model.find('#QuestionCreation').text('تاريخ الاضافة   :'+data.questionCreate)

            //Question = result.questionAr;

            model.modal('show');

           
        }
    });
}


$(document).on("click", ".Detalies", function () {

    var QuestionID = $(this).attr('data-id');
    console.log(QuestionID);
    Reloaddata(QuestionID)

    

});

