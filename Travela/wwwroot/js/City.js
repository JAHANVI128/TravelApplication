
$(document).ready(function () {
    BindGrid();
    $('#btnMdlSave').click(function () {

        // Validation
        var cityName = $('#CityName').val();
        // Reset previous errors
        $('.text-danger').text('');

        // Custom validations
        if (!cityName) {
            $('#cityError').text('Please enter City Name.');
            return;
        }

        var formdata = new FormData($('#form')[0]);

        $.ajax({
            type: "POST",
            url: "/City/AddOrUpdate",
            data: formdata,
            processData: false,
            contentType: false,
            dataType: 'json',
            success: function (data) {
                if (data != null && data != undefined) {
                    ShowMessage(data.strMessage, "", data.type);
                    BindGrid();
                    $('#addCityModal').modal('show');
                    if (typeof data.isError != 'undefined' && data.isError == false) {
                        $('#addCityModal').modal('hide');
                        ClearForm();
                    }
                }
                else {
                    ShowMessage("Record not saved, Try again", "", "error");
                }
            },
            error: function (ex) {
                ShowMessage("Something went wrong, Try again!", "", "error");
            }
        });

    });
});



function EditModel(cityid) {

    debugger;
    // Prepare form data
    var formdata = new FormData($('#form')[0]);
    var token = $('input[name="AntiforgeryFieldname"]').val();

    // Make AJAX request to get qualification details
    $.ajax({
        type: "POST",
        contentType: false,
        url: "/Qualification/GetQualificationDetails",
        data: { QuaId: cityid }, // Pass QuaId to the server
        success: function (data) {
            $('#addQualificationModal').modal('show')
            if (data.isError) {
                ShowMessage(data.strMessage, "", "error");
            } else {
                var qualification = data.result;

                // Loop through qualification data and populate form fields
                Object.keys(qualification).forEach(function (key) {
                    var field = $('#' + key);

                    if (field.length > 0) {
                        if (key === "description") {
                            CKEDITOR.instances['Description'].setData(qualification[key]);
                        } else {
                            field.val(qualification[key]);
                        }
                    }
                });
            }
        },
        error: function (ex) {
            ShowMessage("Something went wrong, Try again!", "", "error");

        }
    });
}


// Handle delete button click
$('.delete-btn').click(function () {
    var qualificationId = $(this).data('qualification-id');
    var row = $(this).closest('tr');

    // Confirm deletion with user
    if (confirm('Are you sure you want to delete this Qualification Name?')) {
        // Send AJAX request to delete employee
        $.ajax({
            type: "POST",
            url: ResolveUrl("/Qualification/DeleteQualificationData"),
            data: { qualificationId: qualificationId },
            success: function (result) {
                // Remove the corresponding row from the table upon successful deletion
                row.remove();
                alert('Department deleted successfully.');
            },
            error: function () {
                alert("An error occurred while deleting the Qualification.");
            }
        });
    }
});

function BindGrid() {
    debugger;
    if ($.fn.DataTable.isDataTable("#tbldata")) {
        $('#tbldata').DataTable().clear().destroy();
    }

    var yesBadge = '<td><span class="badge badge-info mt-1">Yes</span></td>';
    var noBadge = '<td><span class="badge badge-secondary mt-1">No</span></td>';

    var form = $('#frmAddEdit');
    var token = $('input[name="AntiforgeryFieldname"]', form).val();

    $("#tbldata").DataTable({
        "processing": true, // for show progress bar
        "serverSide": false, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "initComplete": function () {
            var api = this.api();
            var searchInput = $('.dataTables_filter input');

            searchInput.on('keyup change', function () {
                if (searchInput.val() === '') {
                    api.search('').draw();
                }
            });
        },
        "ajax": {
            "url": "/City/",
            "contentType": "application/x-www-form-urlencoded",
            "type": "POST",
            'data': {
                "AntiforgeryFieldname": token
                // etc..
            },
            "datatype": "json",
            "dataSrc": function (json) {

                // Settings.
                var jsonObj = json.data;
                // Data
                return jsonObj;
            }
        },
        "columnDefs": [{
            "targets": [0],
            //"visible": false,
            "searchable": false
        }],
        "columns": [

            {
                name: "City Id",
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }, autoWidth: true
            },
            { data: "cityname", name: "City Name", autoWidth: true },
            {
                data: null,
                render: function (data, type, row) {
                    return row.isActive ? yesBadge : noBadge;
                }, autoWidth: true
            },
            {
                data: null,
                render: function (data, type, row) {
                    var strEdit = "<button class=\"btn mb-0 btn-outline-success btnedit\" title=\"Edit\" onclick=\"EditModel('" + row.id + "','" + 1 + "');\" ><i class=\"fas fa-pencil-alt\"></i>Edit</button>&nbsp;";
                    var strRemove = "<button class=\"btn mb-0 btn-outline-danger btndelete\" title=\"Delete\" onclick=\"DeleteData('" + row.id + "', '" + row.title + "');\"><i class=\"fas fa-trash-alt\"></i>Delete</button>";
                    var strMain = strEdit + strRemove;
                    return strMain;
                }, autoWidth: true
            },
        ]

    });
}