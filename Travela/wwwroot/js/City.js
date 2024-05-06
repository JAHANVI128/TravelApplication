$(document).ready(function () {
    console.log("Document ready");
    BindGrid();

    $('#addCityBtn').click(function () {
        $('#addCityModal').modal('show');
    });

    $('#btnMdlSave').click(function () {

        var cityName = $('#CityName').val();
        //$('.text-danger').text('');

        if (!cityName) {
            $('#cityError').text('Please enter City Name.');
            return;
        }

        var formdata = new FormData($('#form')[0]);

        $.ajax({
            type: "POST",
            url: "/City/AddOrUpdateCity",
            data: formdata,
            processData: false,
            contentType: false,
            dataType: 'json',
            success: function (data) {
                if (data != null && data != undefined) {  
                    alert(data.message);
                    $('#addCityModal').modal('hide');                    
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

    function EditModel(cityid) {
        debugger;
        var formdata = new FormData($('#form')[0]);
        var token = $('input[name="AntiforgeryFieldname"]').val();

        $.ajax({
            type: "POST",
            contentType: false,
            url: "/City/EditCity",
            data: { cityid: cityid }, 
            success: function (data) {
                $('#addCityModal').modal('show')
                if (data.isError) {
                    ShowMessage(data.strMessage, "", "error");
                } else {
                    var city = data.result;

                    Object.keys(city).forEach(function (key) {
                        var field = $('#' + key);

                        if (field.length > 0) {
                            if (key === "description") {
                                CKEDITOR.instances['Description'].setData(city[key]);
                            } else {
                                field.val(city[key]);
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

    $('.delete-btn').click(function () {
        var cityId = $(this).data('cityid');
        var row = $(this).closest('tr');

        if (confirm('Are you sure you want to delete this City Name?')) {
            $.ajax({
                type: "POST",
                url: ResolveUrl("/City/DeleteCity"),
                data: { cityId: cityId },
                success: function (result) {
                    row.remove();
                    alert('City deleted successfully.');
                },
                error: function () {
                    alert("An error occurred while deleting the City.");
                }
            });
        }
    });
});

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
            "url": "/City/GetCityData",
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
            { data: "cityName", name: "City Name", autoWidth: true },
            {
                data: null,
                render: function (data, type, row) {
                    return row.isActive ? yesBadge : noBadge;
                }, autoWidth: true
            },
            {
                data: null,
                render: function (data, type, row) {
                    var strEdit = "<a class=\"btn mb-0 btn-outline-success btnedit\" title=\"Edit\" onclick=\"EditModel('" + row.id + "','" + 1 + "');\" >Edit<i class=\"fas fa-pencil-alt\"></i></a>&nbsp;";
                    var strRemove = "<a class=\"btn mb-0 btn-outline-danger btndelete\" title=\"Delete\" onclick=\"DeleteData('" + row.id + "', '" + row.title + "');\">Delete<i class=\"fas fa-trash-alt\"></i></a>";
                    var strMain = strEdit + strRemove ;

                    return strMain;
                }, autoWidth: true
            }          
            
        ]


    });
}
