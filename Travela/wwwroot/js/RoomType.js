$(document).ready(function () {
    console.log("Document ready");
    BindGrid();

    $('#addRoomTypeBtn').click(function () {
        $("#RoomTypeId").val("0")
        $('#addRoomTypeLabel').text('Add Room Type');
        $('#addRoomTypeModal').modal('show');
        resetForm();
    });

    $('#btnMdlSave').click(function (e) {
        e.preventDefault();

        var roomTypeName = $('#RoomTypeName').val().trim();

        if (!roomTypeName) {
            $('#roomTypeError').text('Please enter Room Type Name.');
            return;
        } else {
            $('#roomTypeError').text('');
        }

        var formdata = new FormData($('#form')[0]);

        $.ajax({
            type: "POST",
            url: "/RoomType/AddOrUpdateRoomType",
            data: formdata,
            processData: false,
            contentType: false,
            dataType: 'json',
            success: function (data) {
                if (data != null && data != undefined) {
                    alert(data.message);
                    $('#addRoomTypeModal').modal('hide');
                    BindGrid();
                } else {
                    alert("Record not saved, Try again", "", "error");
                }
            },
            error: function (ex) {
                alert("Something went wrong, Try again!", "", "error");
            }
        });
    });

    $('#RoomTypeName').on('input', function () {
        if ($(this).val().trim() !== '') {
            $('#roomTypeError').text('');
        }
    });
});

function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}

function EditModel(roomTypeId) {
    $.ajax({
        type: "GET",
        url: "/RoomType/EditRoomType",
        data: { roomTypeId: roomTypeId },
        success: function (data) {
            if (data.isError) {
                alert(data.strMessage);
            } else {
                $('#addRoomTypeLabel').text('Edit Room Type');
                var dataList = data.result;

                Object.keys(dataList).forEach(function (key) {
                    if ($('#' + capitalizeFirstLetter(key)) != null && $('#' + key) != undefined) {
                        if (key.includes("is")) {
                            $('#' + capitalizeFirstLetter(key)).prop('checked', dataList[key]);
                        } else {
                            $('#' + capitalizeFirstLetter(key)).val(dataList[key]);
                        }
                    }
                });
            }
            $('#addRoomTypeModal').modal('show');
        },
        error: function (ex) {
            ShowMessage("Something went wrong. Please try again.", "", "error");
        }
    });
}

function DeleteData(roomTypeId, roomTypeName) {
    if (confirm('Are you sure you want to delete "' + roomTypeName + '" room?')) {
        $.ajax({
            type: "POST",
            url: "/RoomType/DeleteRoomType",
            data: { roomTypeId: roomTypeId },
            success: function (result) {
                BindGrid();
                alert('Room Type deleted successfully.');
            },
            error: function () {
                alert("An error occurred while deleting the Room Type.");
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
        "processing": true,
        "serverSide": false,
        "filter": true,
        "orderMulti": false,
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
            "url": "/RoomType/GetRoomTypeData",
            "contentType": "application/x-www-form-urlencoded",
            "type": "POST",
            "datatype": "json",
            "dataSrc": function (json) {
                console.log(json.data);
                return json.data;
            }
        },
        "columnDefs": [{
            "targets": [0],
            "searchable": false
        }],
        "columns": [
            {
                name: "Sr. No. ",
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                },
                autoWidth: true
            },
            { data: "roomTypeName", name: "Room Type Name", autoWidth: true },
            {
                data: null,
                render: function (data, type, row) {
                    return row.isActive ? yesBadge : noBadge;
                },
                autoWidth: true
            },
            {
                data: null,
                render: function (data, type, row) {
                    var editButton = "<button class=\"btn mb-0 btn-outline-success btnedit\" title=\"Edit\" onclick=\"EditModel('" + row.roomTypeId + "');\">Edit<i class=\"fas fa-pencil-alt\"></i></button>&nbsp;";
                    var deleteButton = "<button class=\"btn mb-0 btn-outline-danger btndelete\" title=\"Delete\" onclick=\"DeleteData('" + row.roomTypeId + "', '" + row.roomTypeName + "');\">Delete<i class=\"fas fa-trash-alt\"></i></button>";
                    return editButton + deleteButton;
                },
                autoWidth: true
            }
        ]
    });
}

function resetForm() {
    $('#form')[0].reset();
    $('#RoomTypeName').val('');
    $('#roomTypeError').val('');
}