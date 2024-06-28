//$.each(data, function (index, job) {
//    tr += `
//         <tr>
//             <td class="row">
//                 <div>
//                     <div class="col-md-12">
//                         <div class="card-outline-primary">
//                             <div class="card">
//                                 <div class="card-body">
//                                     <div class="row">
//                                         <div class="col-md-4">
//                                             <h4 class="card-title">${job.title} &nbsp;<span class="ti ti-info-circle fs-6" onclick="DetailModel('${job.job_id}');" style="display: inline;"></span></h4>
//                                             <div>${job.createddate}</div><br>
//                                         </div>
//                                         <div class="col-md-8">
//                                             <div class="d-flex justify-content-end">
//                                                 <a href="/ListofCandidate/Index?jobId=${job.job_id}" class="btn mb-0 btn-outline-success btnedit d-inline-flex mb-n3 me-3" title="Apply" id="addCandidateBtn">
//                                                     Apply Now
//                                                 </a>
//                                                 <a href="javascript:void(0)" class="bg-primary rounded-circle p-2 text-white d-inline-flex mb-n3 me-3" style="float: right;" data-bs-toggle="tooltip" data-bs-placement="top" title="Edit" onclick="EditModel('${job.job_id}');">
//                                                     <i class="ti ti-pencil fs-4"></i>
//                                                 </a>
//                                                 <a href="javascript:void(0)" class="bg-primary rounded-circle p-2 text-white d-inline-flex mb-n3 me-3" style="float: right;" data-bs-toggle="tooltip" data-bs-placement="top" title="Delete" onclick="DeleteData('${job.job_id}');">
//                                                     <i class="ti ti-trash fs-4"></i>
//                                                 </a>
//                                             </div>
//                                         </div>
//                                     </div>
//                                     <div class="row">
//                                         <div class="col-md-3"><label class="form-label">Vacancies:</label><br>${job.vacancies}</div>
//                                         <div class="col-md-3"><label class="form-label">Experience:</label><br>${job.strexperience}</div>
//                                         <div class="col-md-3"><label class="form-label">Qualification:</label><br>${job.strqualification}</div>
//                                         <div class="col-md-3"><label class="form-label">Valid Upto:</label><br>${new Date(job.validupto).toLocaleDateString()}</div>
//                                     </div>
//                                 </div>
//                             </div>
//                         </div>
//                     </div>
//                 </div>
//             </td>
//         </tr>`;
//});


$(document).ready(function () {
    console.log("Document ready");
    BindGrid();
    BindPackageData();

    $('#addPackageBtn').click(function () {

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

            $.ajax({
                type: "POST",
                url: "/Package/AddOrUpdatePackage",
                data: formdata,
                processData: false,
                contentType: false,
                dataType: 'json',
                success: function (data) {
                    if (data != null && data != undefined) {
                        alert(data.message);
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
});

function EditModel(packageId) {
    $.ajax({
        type: "GET",
        url: "/Package/EditPackage",
        data: { packageId: packageId },
        success: function (data) {
            if (data.isError) {
                alert(data.strMessage);
            } else {
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
            }
        },
        error: function (ex) {
            alert("Something went wrong. Please try again.");
        }
    });
}

function BindPackageData() {
    $.ajax({
        type: "GET",
        url: "/Package/PackageList",
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

function DeleteData(packageId, packageName) {
    if (confirm('Are you sure you want to delete "' + packageName + '?')) {
        $.ajax({
            type: "POST",
            url: "/Package/DeletePackage",
            data: { packageId: packageId },
            dataType: "json",
            success: function (result) {
                if (result.isError) {
                    alert(result.Message);
                } else {
                    BindGrid();
                    alert('Package deleted successfully.');
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