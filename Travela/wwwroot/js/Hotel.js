$(document).ready(function () {
    console.log("Document ready");
    BindGrid();
    BindCityData();
    //BindRoomTypeData(); // Add this line to fetch and populate room types

    $('#addHotelBtn').click(function () {

        $('#addHotelModalLabel').text('Add Hotel');
        //$('#currentHotelImage').hide();
        $('#addHotelModal').modal('show');
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

        if (!hotelPhone) {
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
                var roomTypeId = $(this).find('td:eq(1)').data('roomtypeid');
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

        resetForm();

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
                    <td><button type="button" class="btn btn-outline-danger btn-sm delete-room">Delete</button></td>
                </tr>
            `);
        }
    });

     //Event delegation to handle dynamically added delete buttons
    $('#roomTable tbody').on('click', '.delete-room', function () {
        $(this).closest('tr').remove();
        roomCounter--; // Decrement room counter
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

                // Call to bind room types before populating form
                //BindRoomTypeData();

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

                //if (dataList.hotelImage) {
                //    $('#currentHotelImage').attr('src', dataList.hotelImage).show();
                //} else {
                //    $('#currentHotelImage').hide();
                //}

                $('#addHotelModal').modal('show');
            }
        },
        error: function (ex) {
            alert("Something went wrong. Please try again.");
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

        //success: function (data) {
        //    if (!data.isError) {
        //        var citySelect = $('#CityId');
        //        citySelect.empty();
        //        citySelect.append('<option value="">Select City</option>');
        //        data.result.forEach(function (city) {
        //            citySelect.append('<option value="' + city.cityId + '">' + city.cityName + '</option>');
        //        });
        //    }
        //},
        //error: function (ex) {
        //    alert("Something went wrong while fetching cities. Please try again.");
        //}

    });
}

function DeleteData(hotelId, hotelName) {
    if (confirm('Are you sure you want to delete "' + hotelName + '" as a hotel city?')) {
        $.ajax({
            type: "POST",
            url: "/Hotel/DeleteHotel",
            data: { hotelId: hotelId },
            dataType: "json", // Expecting JSON response
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
    $('#form')[0].reset();
    $('#hotelError').text('');
    $('#hotelImgError').text('');
    $('#hotelPhoneError').text('');
    $('#cityError').text('');
    $('#RoomType').val('');
    $('#RoomNumber').val('');
    $('#Amount').val('');
}