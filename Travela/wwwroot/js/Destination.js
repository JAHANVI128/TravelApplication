$(document).ready(function () {
    console.log("Document ready");
    BindGrid();

    $('#addDestinationBtn').click(function () {
        $('#addDestinationModal').modal('show');
    });

    $('#btnMdlSave').click(function () {

        var destinationName = $('#DestinationName').val();

        if (!destinationName) {
            $('#destinationError').text('Please enter Destination Name.');
            return;
        }

        var formdata = new FormData($('#form')[0]);

        $.ajax({
            type: "POST",
            url: "/Destination/AddOrUpdateDestination",
            data: formdata,
            processData: false,
            contentType: false,
            dataType: 'json',
            success: function (data) {
                if (data != null && data != undefined) {
                    alert(data.message);
                    $('#addDestinationModal').modal('hide');
                    BindGrid();
                    $('#form')[0].reset();
                }
                else {
                    alert("Record not saved, Try again", "", "error");
                }
            },
            error: function (ex) {
                alert("Something went wrong, Try again!", "", "error");
            }
        });
    });
});

function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}

function EditModel(destinationId) {

    $.ajax({
        type: "GET",
        url: "/Destination/EditDestination",
        data: { destinationId: destinationId }, 

        success: function (data) {
            debugger;
            if (data.isError) {
                alert(data.strMessage);
            } else {
                var dataList = data.result;

                Object.keys(dataList).forEach(function (key) {

                    if ($('#' + capitalizeFirstLetter(key)) != null && $('#' + key) != undefined) {
                        if (key.includes("is")) {
                            $('#' + capitalizeFirstLetter(key)).prop('checked', dataList[key]);
                        }
                        else {
                            $('#' + capitalizeFirstLetter(key)).val(dataList[key]);
                        }
                    }
                });
            }
            $('#addDestinationModal').modal('show');
        },
        error: function (ex) {
            ShowMessage("Something went wrong. Please try again.", "", "error");
        }
    });
}

function DeleteData(destinationId, destinationName) {
    var row = $(this).closest('tr');

    if (confirm('Are you sure you want to delete "' + destinationName + '" as a destination city?')) {
        $.ajax({
            type: "POST",
            url: "/Destination/DeleteDestination",
            data: { destinationId: destinationId },
            success: function (result) {
                BindGrid();
                alert('Destination deleted successfully.');
            },
            error: function () {
                alert("An error occurred while deleting the destination.");
            }
        });
    }
}

function BindGrid() {
    if ($.fn.DataTable.isDataTable("#tbldata")) {
        $('#tbldata').DataTable().clear().destroy();
    }
    var yesBadge = '<td><span class="badge badge-info mt-1">Yes</span></td>';
    var noBadge = '<td><span class="badge badge-secondary mt-1">No</span></td>';

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
            "url": "/Destination/GetDestinationData",
            "contentType": "application/x-www-form-urlencoded",
            "type": "POST",
            "datatype": "json",
            "dataSrc": function (json) {
                console.log(json.data);
                var jsonObj = json.data;
                return jsonObj;
            }
        },
        "columnDefs": [{
            "targets": [0],
            "searchable": false
        }],
        "columns": [
            {
                name: "Sr. No.",
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }, autoWidth: true
            },
            { data: "destinationName", name: "Destination Name", autoWidth: true },
            {
                data: null,
                render: function (data, type, row) {
                    return row.isActive ? yesBadge : noBadge;
                }, autoWidth: true
            },
            {
                data: null,
                render: function (data, type, row) {
                    var editButton = "<button class=\"btn mb-0 btn-outline-success btnedit\" title=\"Edit\" onclick=\"EditModel('" + row.destinationId + "');\">Edit<i class=\"fas fa-pencil-alt\"></i></button>&nbsp;";
                    var deleteButton = "<button class=\"btn mb-0 btn-outline-danger btndelete\" title=\"Delete\" onclick=\"DeleteData('" + row.destinationId + "', '" + row.destinationName + "');\">Delete<i class=\"fas fa-trash-alt\"></i></button>";
                    return editButton + deleteButton;
                }, autoWidth: true
            }
        ]
    });
}

