$(document).ready(function () {
    console.log("Document ready");
    BindGrid();
    BindCityData();

    $('#addHotelBtn').click(function () {
        $('#addHotelModal').modal('show');
    });

    $('#btnMdlSave').click(function () {

        var hotelName = $('#HotelName').val();

        if (!hotelName) {
            $('#hotelError').text('Please enter Hotel Name.');
            return;
        } else {
            $('#hotelError').text('');
        }

        var hotelImg = $("#HotelImage").val();

        if (!hotelImg) {
            $('#hotelImgError').text('Please select Hotel Image.');
            return;
        } else {
            $('#hotelImgError').text('');
        }

        var formdata = new FormData($('#form')[0]);
        var fileInput = $('#HotelImage')[0].files[0];

        formdata.append('HotelImage', fileInput);

        $.ajax({
            type: "POST",
            url: "/Hotel/AddOrUpdateHotel",
            data: formdata,
            processData: false,
            contentType: false,
            dataType: 'json',
            success: function (data) {
                if (data != null && data != undefined) {
                    alert(data.message);
                    $('#addHotelModal').modal('hide');
                    BindGrid();
                    $('#form')[0].reset();
                } else {
                    alert("Record not saved, Try again", "", "error");
                }
            },
            error: function (ex) {
                alert("Something went wrong, Try again!", "", "error");
            }
        });
    });

    let roomCounter = 1;

    $('#addRoomBtn').click(function () {
        var roomType = $('#RoomType').val();
        var roomNumber = $('#RoomNumber').val();
        var amount = $('#Amount').val();
        var isValid = true;

        if (!roomType) {
            $('#roomTypeError').text('Please enter Room Type.');
            isValid = false;
        } else {
            $('#roomTypeError').text('');
        }

        if (!roomNumber) {
            $('#roomNumberError').text('Please enter Room Number.');
            isValid = false;
        } else {
            $('#roomNumberError').text('');
        }

        if (!amount) {
            $('#amountError').text('Please enter Amount.');
            isValid = false;
        } else if (isNaN(amount)) {
            $('#amountError').text('Please enter a valid Amount.');
            isValid = false;
        } else {
            $('#amountError').text('');
        }

        if (isValid) {
            $('#roomTable tbody').append(`
                <tr>
                    <td>${roomCounter++}</td>
                    <td>${roomType}</td>
                    <td>${roomNumber}</td>
                    <td>${amount}</td>
                </tr>
            `);

            // Clear inputs after adding
            $('#RoomType').val('');
            $('#RoomNumber').val('');
            $('#Amount').val('');
        }
    });
});

function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}

function EditModel(hotelId) {
    $.ajax({
        type: "GET",
        url: "/Hotel/EditHotel",
        data: { hotelId: hotelId },

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
                        } else {
                            $('#' + capitalizeFirstLetter(key)).val(dataList[key]);
                        }
                    }
                });
            }
            $('#addHotelModal').modal('show');
        },
        error: function (ex) {
            ShowMessage("Something went wrong. Please try again.", "", "error");
        }
    });
}

function BindCityData() {
    // Populate city dropdown
    $.ajax({
        type: "GET",
        url: "/City/CityList", // URL to fetch city data
        dataType: 'json',
        success: function (data) {
            if (data != null && data.length > 0) {
                // Clear existing options
                $('#CityId').empty();

                // Add default option
                $('#CityId').append('<option value="">Select City</option>');

                // Iterate over city data and add options to the dropdown
                $.each(data, function (index, city) {
                    console.log(city);
                    $('#CityId').append('<option value="' + city.cityId + '">' + city.cityName + '</option>');
                });
            } else {
                // Handle empty or no data
                $('#CityId').append('<option value="">No data available</option>');
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.error("Error fetching city data: ", textStatus, errorThrown);
            alert("An error occurred while fetching city data.");
        }
    });
}

function DeleteData(hotelId, hotelName) {
    var row = $(this).closest('tr');

    if (confirm('Are you sure you want to delete "' + hotelName + '" as a hotel city?')) {
        $.ajax({
            type: "POST",
            url: "/Hotel/DeleteHotel",
            data: { hotelId: hotelId },
            success: function (result) {
                BindGrid();
                alert('Hotel deleted successfully.');
            },
            error: function () {
                alert("An error occurred while deleting the hotel.");
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
            "url": "/Hotel/GetHotelData",
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
                data: null,
                name: "Sr. No.",
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }, autoWidth: true
            },
            {
                data: "hotelImage",
                name: "Hotel Image",
                autoWidth: true,
                render: function (data, type, row) {
                    return '<img src="' + data + '" alt="Hotel Image"  style="width: 100px; height: 100px; object-fit: cover;"/>';
                }
            },
            { data: "hotelName", name: "Hotel Name", autoWidth: true },
            { data: "hotelPhone", name: "Hotel Phone", autoWidth: true },
            { data: "strcity", name: "City", autoWidth: true },
            {
                data: "isActive",
                render: function (data, type, row) {
                    return data ? yesBadge : noBadge;
                }, autoWidth: true
            },
            {
                data: null,
                render: function (data, type, row) {
                    var editButton = "<button class=\"btn mb-0 btn-outline-success btnedit\" title=\"Edit\" onclick=\"EditModel('" + row.hotelId + "');\">Edit<i class=\"fas fa-pencil-alt\"></i></button>&nbsp;";
                    var deleteButton = "<button class=\"btn mb-0 btn-outline-danger btndelete\" title=\"Delete\" onclick=\"DeleteData('" + row.hotelId + "', '" + row.hotelName + "');\">Delete<i class=\"fas fa-trash-alt\"></i></button>";
                    return editButton + deleteButton;
                }, autoWidth: true
            }
        ]
    });
}