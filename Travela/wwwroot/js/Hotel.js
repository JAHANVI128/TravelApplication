$(document).ready(function () {
    console.log("Document ready");
    BindGrid();
    BindCityData();
    fetchRoomTypes();

    // Validation for numeric fields
    //$('#HotelPhone,#RoomNumber, #Amount').on('input', function () {
    //    var value = $(this).val();
    //    if (/[^0-9]/.test(value)) { // Check for non-numeric characters
    //        alert('Please enter a valid number.');
    //        $(this).val(value.replace(/[^0-9]/g, '')); // Remove non-numeric characters
    //    }
    //});

    $('#RoomNumber, #Amount, #HotelPhone').on('keypress', function (e) {
        if (e.which < 48 || e.which > 57) { // ASCII codes for digits 0-9
            alert('Please enter a valid number.');
            e.preventDefault();
        }
    });

    $('#addHotelBtn').click(function () {
        $('#addHotelModalLabel').text('Add Hotel');
        $('#addHotelModal').modal('show');
        $('#form')[0].reset();
        resetForm();
    });

    $('#btnMdlSave').click(function () {
        var hotelName = $('#HotelName').val();
        var hotelImg = $("#HotelImage").val();
        var hotelPhone = $('#HotelPhone').val();
        var cityId = $('#CityId').val();
        var isValid = true;

        if (!hotelName) {
            $('#hotelError').text('Please enter Hotel Name.');
            isValid = false;
        } else {
            $('#hotelError').text('');
        }

        if (!hotelImg && !$('#currentHotelImage').attr('src')) {
            $('#hotelImgError').text('Please select Hotel Image.');
            isValid = false;
        } else {
            $('#hotelImgError').text('');
        }

        if (!hotelPhone || hotelPhone.length < 10 || hotelPhone.length > 10) {
            $('#hotelPhoneError').text('Please enter Hotel Phone.');
            isValid = false;
        } else {
            $('#hotelPhoneError').text('');
        }

        if (!cityId) {
            $('#cityError').text('Please select a City.');
            isValid = false;
        } else {
            $('#cityError').text('');
        }

        if (isValid) {
            var formdata = new FormData($('#form')[0]);
            var fileInput = $('#HotelImage')[0].files[0];

            var roomList = [];
            $('#roomTable tbody tr').each(function () {
                var roomTypeId = $(this).find('td:eq(1)').data('id');
                var roomNumber = $(this).find('td:eq(2)').text();
                var amount = $(this).find('td:eq(3)').text();

                var room = {
                    RoomTypeId: roomTypeId,
                    RoomNo: roomNumber,
                    Amount: parseFloat(amount)
                };
                roomList.push(room);
            });

            if (fileInput) {
                formdata.append('HotelImage', fileInput);
            }
            formdata.append('RoomList', JSON.stringify(roomList));

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
                    alert("Something went wrong. Please try again.");
                }
            });
        }
    });

    let roomCounter = 1;

    $('#addRoomBtn').click(function () {
        var roomType = $('#RoomType').val();
        var roomTypeText = $('#RoomType option:selected').text();
        var roomNumber = $('#RoomNumber').val();
        var amount = $('#Amount').val();
        var isValid = true;

        if (!roomType) {
            $('#roomTypeError').text('Please select Room Type.');
            isValid = false;
        } else {
            $('#roomTypeError').text('');
        }

        if (!roomNumber) {
            $('#roomNumberError').text('Please enter Room Number.');
            isValid = false;
        } else if (isNaN(roomNumber)) {
            $('#roomNumberError').text('Please enter a valid Room Number.');
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
                    <td data-id="${roomType}">${roomTypeText}</td>
                    <td>${roomNumber}</td>
                    <td>${amount}</td>
                    <td><button type="button" class="btn btn-outline-danger btn-sm delete-room">Delete</button></td>
                </tr>
            `);
            resetForm();
        }
    });

    $('#roomTable tbody').on('click', '.delete-room', function () {
        $(this).closest('tr').remove();
        roomCounter--;
    });
});

function EditModel(hotelId) {
    $.ajax({
        type: "GET",
        url: "/Hotel/EditHotel",
        data: { hotelId: hotelId },
        success: function (data) {
            if (data.isError) {
                alert(data.strMessage);
            } else {
                $('#addHotelModalLabel').text('Edit Hotel');
                var dataList = data.result;

                Object.keys(dataList).forEach(function (key) {
                    var element = $('#' + key.charAt(0).toUpperCase() + key.slice(1));
                    if (element.length) {
                        if (element.attr('type') === 'checkbox') {
                            element.prop('checked', dataList[key]);
                        } else if (element.attr('type') === 'file') {
                            console.log('File input detected, skipping value set for', key);
                        } else {
                            element.val(dataList[key]);
                        }
                    }
                });

                $('#addHotelModal').modal('show');
            }
        },
        error: function (ex) {
            alert("Something went wrong. Please try again.");
        }
    });
}

function BindCityData() {
    $.ajax({
        type: "GET",
        url: "/City/CityList",
        dataType: 'json',
        success: function (data) {
            if (data != null && data.length > 0) {
                $('#CityId').empty();
                $('#CityId').append('<option value="">Select City</option>');
                $.each(data, function (index, city) {
                    $('#CityId').append('<option value="' + city.cityId + '">' + city.cityName + '</option>');
                });
            } else {
                $('#CityId').append('<option value="">No data available</option>');
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.error("Error fetching city data: ", textStatus, errorThrown);
            alert("An error occurred while fetching city data.");
        }
    });
}

function fetchRoomTypes() {
    $.ajax({
        type: 'GET',
        url: '/RoomType/RoomTypeList',
        dataType: 'json',
        success: function (data) {
            if (data != null && Array.isArray(data)) {
                $('#RoomType').html('');
                $('#RoomType').append(new Option("Select Room Type", ""));
                data.forEach(function (item) {
                    if (item.roomTypeId && item.roomTypeName) {
                        $('#RoomType').append(new Option(item.roomTypeName, item.roomTypeId));
                    }
                });
            }
        },
        error: function (xhr, status, error) {
            console.error("AJAX error:", error);
            alert("Failed to load room types: " + error);
        }
    });
}

function DeleteData(hotelId, hotelName) {
    if (confirm('Are you sure you want to delete "' + hotelName + '" as a hotel city?')) {
        $.ajax({
            type: "POST",
            url: "/Hotel/DeleteHotel",
            data: { hotelId: hotelId },
            dataType: "json",
            success: function (result) {
                if (result.isError) {
                    alert(result.Message);
                } else {
                    BindGrid();
                    alert('Hotel deleted successfully.');
                }
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
            "type": "POST",
            "url": "/Hotel/GetHotelData",
            "contentType": "application/x-www-form-urlencoded",
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

function resetForm() {
    $('#hotelError').text('');
    $('#hotelImgError').text('');
    $('#hotelPhoneError').text('');
    $('#cityError').text('');
    $('#RoomType').val('');
    $('#RoomNumber').val('');
    $('#Amount').val('');
}