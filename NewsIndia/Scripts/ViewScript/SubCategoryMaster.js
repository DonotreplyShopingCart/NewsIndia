var categorytable;
$(document).ready(function () {

    DataTableLoad();

});
function DataTableLoad() {
    $('#tblSubCategoryGrid').dataTable({
        "bLengthChange": false, 'iDisplayLength': 7
    });
    $("#tblSubCategoryGrid_filter").hide();

    oTable = $('#tblSubCategoryGrid').DataTable();

    $('#txtSearchSubCategory').on('keyup', function () {
        oTable.search(this.value).draw();
    });
}
var IsNewEnrty;
var SubCategoryId;
$(document).ready(function () {
    $("#txtSubCategoryName").popover({ trigger: 'manual' });
    $("#ddlCategory").popover({ trigger: 'manual' });

    $("#txtSubCategoryName").change(function () {
        $("#txtSubCategoryName").popover('hide');
    });

    $("#ddlCategory").change(function () {
        $("#ddlCategory").popover('hide');
    });

    $("#btnSaveChanges").click(function () {
        $("#txtSubCategoryName").attr("data-content", "Looks like this Subcategory is already Present!!!");
        if ($("#txtSubCategoryName").val() == "") {
            $("#txtSubCategoryName").attr("data-content", "Please Enter Subcategory!!!");
            $("#txtSubCategoryName").popover('show');
        } else {
            if ($("#ddlCategory").val() == "0") {

                $("#ddlCategory").popover('show');
            } else {
                CheckSubCategoryName();

            }
        }
    });

});

function RemoveSubCategory(subCategoryId) {
    if (confirm('Are you sure you want to delete this Sub-Category.')) {
        $.ajax({
            url: '/SubCategoryManager/RemoveSubCategory',
            type: "POST",
            data: { subCategoryId: subCategoryId },
            success: function (data) {

                if (data.IsSubCategoryRemoved) {
                    showNotification("Sub-Category has been Removed.", "success");
                    $("#divLoading").show();
                    $("#divSubCategoryTable").load("/SubCategoryManager/ShowSubCategoryTable", function () {
                        $("#divLoading").hide();
                        DataTableLoad();
                        ReloadMenuDashboard();
                    });

                } else {
                    showNotification("Error while processing your request.", "warning");
                }

            },
            error: function (data) {
                showNotification("Error while Communicating with server.", "warning");
            }
        });
    }

}

function SaveSubCategory() {
    $.ajax({
        url: '/SubCategoryManager/SaveSubCategoryInfo',
        type: "POST",
        data: { subCategoryId: SubCategoryId, subCategoryName: $("#txtSubCategoryName").val(), isVisible: $('#chkIsVisible').prop('checked'), categoryId: $("#ddlCategory").val() },
        success: function (data) {
            debugger;
            var subCategorySaved = data.SubCategorySaved;
            if (subCategorySaved) {
                showNotification("Sub-Category has been saved.", "success");
                $('#popup').modal('toggle');
                $("#divLoading").show();
                $("#divSubCategoryTable").load("/SubCategoryManager/ShowSubCategoryTable", function () {
                    $("#divLoading").hide();
                    DataTableLoad();
                    ReloadMenuDashboard();
                });

            } else {
                showNotification("Error while processing your request.", "warning");
            }

        },
        error: function (data) {
            showNotification("Error while Communicating with server.", "warning");
        }
    });
}

function CheckSubCategoryName() {
    $.ajax({
        url: '/SubCategoryManager/CheckSubCategoryName',
        type: "POST",
        data: { subCategoryName: $("#txtSubCategoryName").val(), subCategoryId: SubCategoryId, categoryId: $("#ddlCategory").val() },
        success: function (data) {
            debugger;
            var isSubCategoryPresent = data.IsSubCategoryPresent;
            if (isSubCategoryPresent) {

                $("#txtSubCategoryName").popover('show');
            } else {
                SaveSubCategory();
            }

        },
        error: function (data) {
            showNotification("Error while Communicating with server.", "warning");
        }
    });
}


function loadSubCategoryInfo() {
    $.ajax({
        url: '/SubCategoryManager/GetSubCategoryInfo',
        type: "POST",
        data: { subCategoryId: SubCategoryId },
        success: function (data) {
            var subCategoryInfo = data.SubCategoryInformation;
            if (subCategoryInfo.SubCategoryName != null) {
                $("#txtSubCategoryName").val(subCategoryInfo.SubCategoryName);
                $('#chkIsVisible').prop('checked', subCategoryInfo.IsVisible);
                SetCategoryDropDown(subCategoryInfo.CategoryId);
            } else {
                showNotification("Error while processing your request.", "warning");
            }

        },
        error: function (data) {

            showNotification("Error while Communicating with server.", "warning");
            $('#popup').modal('toggle');
        }
    });

}


$('#popup').on('show.bs.modal', function (event) {
    var modal = $(this);
    ResetPopUp(modal);

    var eventObject = $(event.relatedTarget);
    var subCategoryId = eventObject.data('subcategoryid');

    SubCategoryId = subCategoryId;

    if (SubCategoryId == 0)
        NewEntryPopUp(modal);
    else
        EditEntryPopUp(modal);
});
//model Close event
$('#popup').on('hidden.bs.modal', function () {
    $("#txtSubCategoryName").popover('hide');
    $("#ddlCategory").popover('hide');

});

function EditEntryPopUp(modal) {
    modal.find('.modal-title').text("Edit Sub-Category");
    loadSubCategoryInfo();
}

function NewEntryPopUp(modal) {
    modal.find('.modal-title').text("Add Sub-Category");

}
function SetCategoryDropDown(value) {
    $("#ddlCategory").val(value).attr("selected", "selected");
}

function ResetPopUp(modal) {
    modal.find('.modal-title').text('');
    $("#txtSubCategoryName").val("");
    SetCategoryDropDown(0);
    $('#chkIsVisible').prop('checked', false);

}
