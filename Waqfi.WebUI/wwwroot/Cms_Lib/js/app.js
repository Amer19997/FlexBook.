window.onload = function () {
    setTimeout(() => {
        document.getElementById('preloader').style.display = 'none';
    }, 500);
    window.scrollTo(0, 0)
}


var PublicId = '';

// sidenav
let arrow = document.querySelectorAll(".dropdown-arrow");
for (var i = 0; i < arrow.length; i++) {
    arrow[i].addEventListener("click", (e) => {
        e.preventDefault();
        let arrowParent = e.target.parentElement.parentElement;//selecting main parent of arrow
        arrowParent.classList.toggle("showMenu");
    });
}
let sidebar = document.querySelector(".sidebar-nav");
let sidebarBtn = document.querySelector(".bx-menu");
let appContent = document.querySelector(".app-content");
sidebarBtn.addEventListener("click", () => {
    sidebar.classList.toggle("close");
    appContent.classList.toggle("expanded");
});


// =========================select 2 ===================
//$(document).ready(function () {
//    $('.js-example-basic-multiple').select2({
//        closeOnSelect: true,
//        placeholder: "اختر",
//        allowHtml: false,
//        allowClear: true,

//    });
//});

//////////////////////////////////////////////////////////////////////////////////////////////////////

////  table scripts 
//var table;
//var Data = {};
//var GetQuestion = $('#Question').val();
//$(document).ready(function () {
//    RenderTable();
//    RenderTable2();

//});

//function RenderTable2() {
//    

//    table = $('#Donatordatatable').DataTable({
//        ajax: {
//            url: "/Donator/Donators?handler=GetAjax",
//            type: "Post",
//            contentType: 'application/x-www-form-urlencoded',
//            dataType: "json",
//            data: { "Donator": GetDonator, "Email": GetEmail, "Phone": GetPhone },
//            headers:
//            {
//                "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
//            }
//        },
//        destroy: true,
//        dom: '<"toolbar">frtip',
//        processing: false,
//        serverSide: true,
//        filter: false,
//        ordering: false,
//        lengthChange: false,
//        pageLength: 10,
//        drawCallback: function () {
//            
//            var page_min = 10;
//            var $api = this.api();
//            var pages = $api.page.info().pages;
//            var rows = $api.data().length;

//            // Tailor the settings based on the row count
//            if (rows < page_min) {
//                $('#Donator').next('.dataTables_paginate').css('display', 'none');
//            } else {
//                $('#Donator').next('.dataTables_paginate').css('display', 'block');
//            }
//        },
//        info: false,
//        language: {
//            paginate: {
//                next: '&#8592;', // or '→'
//                previous: '&#8594;' // or '←'
//            }
//        },
//        columns: [
//            //{ data: "id", name: "ID" },
//            {
//                "render": function (data, type, row, counter) {
//                    return counter.row + 1;
//                },
//                "orderable": false
//            },
//            { data: "firstName", name: "FirstName" },
//            { data: "lastName", name: "LastName" },
//            { data: "contact", name: "Mobile" },
//            { data: "email", name: "Email" },
//            {
//                "render": function (data, type, row) { return '<a href="#" class="btn btn-danger" onclick=DeleteCustomer("' + row.id + '"); > Delete </a>' },
//                "orderable": false
//            },
//            //{ data: "DateOfBirth", name: "DateOfBirth" }
//        ]
//    });


//    //$('.pagination').hide();

//    //$('div.toolbar').html(`
//    //                    `);

//}


// Ajax Form
//function RenderTable() {
//    table = $('#Questiontable').DataTable({
//        ajax: {
//            url: "/Question/QuestionList?handler=GetAjax",
//            type: "POST",
//            contentType: 'application/x-www-form-urlencoded',
//            dataType: "json",
//            data: { "QuestionSearch": GetQuestion },
//            headers:
//            {
//                "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
//            }
//        },
//        destroy:true,
//        dom: '<"">frtip',
//        processing: false,
//        serverSide: true,
//        filter: false,
//        lengthChange: false,
//        drawCallback: function () {
            
//            var page_min = 10;
//            var $api = this.api();
//            var pages = $api.page.info().pages;
//            var rows = $api.data().length;
//            console.log(rows);
//            // Tailor the settings based on the row count
//            //if (rows < page_min) {
//            //    $('#Questiontable').next('.dataTables_paginate').css('display', 'none');
//            //} else {
//            //    $('#Questiontable').next('.dataTables_paginate').css('display', 'block');
//            //}
//        },
//        pageLength: 10,
//        info: true,
//        language: {
//            paginate: {
//                next: '&#8592;', // or '→'
//                previous: '&#8594;' // or '←'
//            },
            
//            emptyTable: "(لا يوجد نتائج للبحث)"

//        },


//        columns: [
//            //{ data: "id", name: "ID" },
//            {
//                "render": function (data, type, row, counter) {
//                    return counter.row + 1;
//                },
//                "orderable": false
//            },

//            { data: "question", name: "Question" },
//            { data: "answer", name: "Answer" },
//            { data: "priorityNumber", name: "priorityNumber" },
//            { data: "questionStatue", name: "questionStatue" },
//            { data: "questionCreate", name: "questionCreate" },

//            {
//                "render": function (data, type, row) {
//                    return `  <div class="controls">
//                                                    <ul>
//                                                        <li>
//                                       <a href="/Question/UpdateQuestion?Id=${row.questionId }">
//                                        <img src="/cms_lib/img/icons/Edit.svg"  alt="users-icon" />
//                                        </a>
//                                                        </li>
//                                                        <li>
//                                                            <a class="del" data-id="${row.questionId}" href="#">
//                                                        <img  src="/cms_lib/img/icons/Delete.svg" alt="users-icon" /></a>
//                                                        </li>

//                                                    </ul>
//                                                </div>`},
//                "orderable": false
//            },
//            //{ data: "DateOfBirth", name: "DateOfBirth" }
//        ]
//    });

//}
//// search Table
//function Search() {
    
//     GetQuestion = $('#Question').val();

//    //Data = { "Donator": GetDonator, "Email": GetEmail, "Phone": GetPhone };

//    RenderTable();
//    //RenderTable();
//}



//////////////////////////////////////////////////////////////////////////////////////////////////////
//function Search() {
//    debugger
//    var GetDonator = $('#donator').val();
//    var GetEmail = $('#EmailSerch').val();
//    var GetPhone = $('#phoneSearch').val();
//    Data = { "Donator": GetDonator, "Email": GetEmail, "Phone": GetPhone };

//    table.ajax.url("/?handler=GetAjax").load();
//    //RenderTable();
//}
//select 2 script
        
$(".js-select2").select2({
    closeOnSelect: false,
    placeholder : "اختر",
    allowHtml: true,
    allowClear: true,


});

//$(".js-select2-single").select2({
//    closeOnSelect: true,
//});

    //$('.icons_select2').select2({
    //    width: "100%",
    //    templateSelection: iformat,
    //    templateResult: iformat,
    //    allowHtml: true,
    //    placeholder: "Placeholder",
    //    dropdownParent: $( '.select-icon' ),//обавили класс
    //    allowClear: true,
    //    multiple: false
    //});


        function iformat(icon, badge,) {
            var originalOption = icon.element;
            var originalOptionBadge = $(originalOption).data('badge');
         
            return $('<span><i class="fa ' + $(originalOption).data('icon') + '"></i> ' + icon.text + '<span class="badge">' + originalOptionBadge + '</span></span>');
        }

///////////////////////////////////////////////////////////////


//function CreateUser() {

//    debugger

//    var Question = $("#Question").val();
//    var Answer = $("#Answer").val();
//    var Statues = $("#Statues").val();
//    var Prority = $("#Prority").val();


//    //if (Question == "" || Answer == "" || Statues == "" || Prority == 0) {
//    //    return false
//    //}




//    //$.ajax({
//    //    url: "/Question/CreateNewQuestion?handler=CreateQuestion",
//    //    type: "Post",
//    //    contentType: 'application/x-www-form-urlencoded',
//    //    dataType: "json",
//    //    data: { "question": Question, "answer": Answer, "statues": Statues, "prority": Prority },
//    //    headers:
//    //    {
//    //        "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
//    //    },
//    //    success: function (html) {
//    //        debugger
//    //        $("#Question").val('');
//    //        $("#Answer").val('');
//    //        $("#Statues").val('');
//    //        /*$("#Roles").select2('val', '');*/
//    //        $("#Prority").val("");

//    //        //$("#results").append(html);
//    //       // $('#add-user-Modal').modal('show');
//    //    }
//    //});
//}



//////////////////////////////////////////////

//function CreateQuestion() {

//    var form = document.getElementById("form-id");



//        form.submit();
//    };


//$(document).on("click", ".del", function () {

//    var QuestionID = $(this).attr("data-id");
//    console.log(QuestionID);

//    $("#YesValue").attr("href", "/Question/DeleteQuestion?id="+QuestionID)
//    $('#deleteModal').modal('show');

//});


//function UpdateQuestion() {


//    var form = document.getElementById("form-id");

//    form.submit();
//};



/***higripicker */
/* */

$(function () {

    initDefault();

});

function initDefault() {
    $(".hijri-picker").hijriDatePicker({
        hijri: true,
        showSwitcher: false,
        // dateFormat: "dd-mm-yy",
        format: 'LT',
        language: "ar",
        showClose: true,
        showClear: true,
        showTodayButton: true,
        autoclose: true,


    });
}

/**custom datepicker***/
$('.datepickerCustom').datepicker({
    weekStart: 0,
    todayBtn: "linked",
    language: "en",
    orientation: "bottom auto",
    todayHighlight: true,
    keyboardNavigation: false,
    autoclose: true,
    showSwitcher: false,
    useCurrent: false,
    format: 'mm/dd/yyyy',
    showClose: true,
    showClear: true,
    showTodayButton: true,
});

$('.datepickerCustoms').datepicker({
    weekStart: 0,
    todayBtn: "linked",
    language: "en",
    orientation: "bottom auto",
    todayHighlight: true,
    keyboardNavigation: false,
    autoclose: true,
    showSwitcher: false,
    useCurrent: false,
    format: 'dd/mm/yyyy',
    showClose: true,
    showClear: true,
    showTodayButton: true,
});


/*timepicker**/
$(".timepicker").datetimepicker({
    format: "LT",
    icons: {
        up: "fa fa-chevron-up",
        down: "fa fa-chevron-down"
    }
});

$('form').on('submit', function (e) {
    $(":input").each(function () {
        $(this).val($.trim($(this).val()));
    });
});

/* */

$(document).ajaxError(function (event, jqxhr, settings, exception) {
    if (jqxhr.status == 401) {
        window.location.replace("/Admin/Login");
    }
});

$('#preloader').hide();

$(document).ajaxStart(function () {
    $('#preloader').show();
})

$(document).ajaxStop(function () {
    $('#preloader').hide();
});
$('#preloader').hide();

$(document).ajaxStart(function ()
{
    $('#preloader').show();
})

$(document).ajaxStop(function () {
    $('#preloader').hide();
});