$(document).ready(function () {
    console.log("Document ready");
    BindGrid();

    $('#addPackageBtn').click(function () {

    });

    $('#btnMdlSave').click(function () {
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

    // Function to render cards
    function renderCards(data) {
        var cardsContainer = $('#cardsContainer');
        cardsContainer.empty(); // Clear existing cards
        var tr = "";
        $.each(data, function (index, package) {
            tr += `
                <tr>
                    <td class="row">
                        <div>
                            <div class="col-md-12">
                                <div class="card-outline-primary">
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-md-4">

                                                </div>
                                                <div class="col-md-8">
                                                    <div class="d-flex justify-content-end">
                                                        <a href="javascript:void(0)" class="bg-primary rounded-circle p-2 text-white d-inline-flex mb-n3 me-3" style="float: right;" data-bs-toggle="tooltip" data-bs-placement="top" title="Edit" onclick="EditModel('${package.packageId}');">
                                                            <i class="ti ti-pencil fs-4"></i>
                                                        </a>
                                                        <a href="javascript:void(0)" class="bg-primary rounded-circle p-2 text-white d-inline-flex mb-n3 me-3" style="float: right;" data-bs-toggle="tooltip" data-bs-placement="top" title="Delete" onclick="DeleteData('${package.packageId}');">
                                                            <i class="ti ti-trash fs-4"></i>
                                                        </a>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-3"><label class="form-label">Package Name:</label><br>${package.packageName}</div>
                                                <div class="col-md-3"><label class="form-label">Image:</label><br>${package.image}</div>
                                                <div class="col-md-3"><label class="form-label">Package Amountt:</label><br>${package.packageAmt}</div>
                                                <div class="col-md-3"><label class="form-label">Duration:</label><br>${package.noOfDays}D/ ${package.noOfNights}N</div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>`;
        });

        var table = '<table id="tblData"><thead><tr><th></th></tr></thead ><tbody>' + tr + "</tbody></table>";
        cardsContainer.append(table);

        $('#tblData').DataTable({
            "pageLength": 5,
            "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]] // Options for the number of records per page
        });
    }

    // Fetch data and render cards
    function fetchDataAndRenderCards() {
        $.ajax({
            url: '/Package/GetPackageData', // Update with your URL
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response && response.data) {
                    renderCards(response.data);
                }
            },
            error: function (xhr, status, error) {
                console.log('Error:', error);
            }
        });
    }

    // Initial call to fetch data and render cards
    fetchDataAndRenderCards();
}