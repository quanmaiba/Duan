var loans = loans || {};
var addEditModal = $("#addEditModal"),
    addEditForm = $('#addEditForm'),
    dataTable = $('#loansDatatable'),
    dataTableOption;


loans.loansDatatable = function () {
    dataTableOption = dataTable.DataTable({
        serverSide: true,
        responsive: true,
        order: [[0, "desc"]],
        pageLength: 12,
        lengthMenu: [[12, 25, 50, -1], [12, 25, 50, "Tất cả"]],
        language: {
            "sProcessing": "Đang xử lý...",
            "sLengthMenu": "Xem _MENU_ mục",
            "sZeroRecords": "Không tìm thấy dòng nào phù hợp",
            "sInfo": "Đang xem _START_ đến _END_ trong tổng số _TOTAL_ dòng",
            "sInfoEmpty": "Không có dữ liệu",
            "sInfoFiltered": "(được lọc từ _MAX_ mục)",
            "sInfoPostFix": "",
            "sSearch": "Tìm kiếm nhanh:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "Đầu",
                "sPrevious": "Trước",
                "sNext": "Tiếp",
                "sLast": "Cuối"
            }
        },
        ajax: {
            url: "loans/Gets",
            type: "POST",
        },
        columns: [
            {
                title: '#',
                name: 'Id',
                data: 'id',
                width: 50,
            },
            {
                title: 'Loại hình vay',
                name: 'Ten',
                data: 'ten'
            },
            {
                title: 'Trạng thái',
                name: 'TrangThai',
                data: 'trangThai',

            },
            {
                title: 'Công cụ',
                name: 'id',
                sortable: false,
                searchable: false,
                width: 50,
                render: function (data, type, row, meta) {
                    var editBtn = '<a onclick="loans.showEditModal(\'' + row.id + '\')" href="javascript:;" class="action-buttons" data-toggle="tooltip" data-placement="top" title="Chỉnh sửa banner"><i class="fa fa-pencil poiter"></i></a>';
                    var deleteBtn = '<a onclick="loans.showConfirmDeleteModal(\'' + row.id + '\')" href="javascript:;" class="action-buttons" data-toggle="tooltip" data-placement="top" title="Xóa banner"><i class="fa fa-remove poiter"></i></a>';
                    return $("<div>").append(editBtn + ' ' + deleteBtn).html();
                }
            },
        ],
    });
};

loans.Save = function () {
    if (addEditForm.valid()) {
        var data = addEditForm.serializeObjectPro();

        $.ajax({
            url: "loans/AddUpdate",
            method: "post",
            data: data,
            success: function (response) {
                helpers.showMessage(response);
                loans.reloadDatatable();
                addEditModal.modal("hide");
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
            }
        });
    }
};

loans.showAddModel = function () {
    loans.resetForm();

    addEditModal.find(".modal-title").text("Thêm mới điều kiện vay");
    addEditModal.modal("show");
};

loans.resetForm = function () {
    $("#hiddenId").val("");
    $("#Ten").val("");
};

loans.reloadDatatable = function () {
    dataTableOption.ajax.reload(null, false);
};

loans.showConfirmDeleteModal = function (id) {
    BootstrapDialog.show({
        title: "Xác nhận",
        message: 'Bạn có muốn xóa điều kiện vay không?',
        type: BootstrapDialog.TYPE_WARNING,
        buttons: [{
            label: 'Hủy',
            action: function (dialogItself) {
                dialogItself.close();
            }
        }, {
            label: 'Đồng ý',
            cssClass: 'btn-primary',
            action: function (dialogItself) {
                loans.delete(id);
                dialogItself.close();
            }
        }]
    });
};

loans.showEditModal = function (id) {
    loans.resetForm();

    $.ajax({
        url: "loans/Get/" + id,
        method: "get",
        success: function (response) {
            if (response.code === 1) {
                var data = response.data;
                loans.bindingForm(data);
                addEditModal.find(".modal-title").text("Chỉnh sửa điều kiện vay");
                addEditModal.modal("show");
            } else
                helpers.showMessage(response);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });
};

loans.bindingForm = function (data) {
    if (data != undefined && data != null) {
        $("#hiddenId").val(data.Id);
        $("#Ten").val(data.Ten);
    }
};

loans.delete = function (id) {
    $.ajax({
        url: "loans/Active",
        method: "post",
        data: { id },
        success: function (response) {
            helpers.showMessage(response);
            loans.reloadDatatable();
            addEditModal.modal("hide");
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });
};


loans.showInlineLoading = function (e, isShow) {
    var img = $(e).parents(".upload-section").find(".inline-loading");
    if (isShow)
        img.show();
    else {
        img.hide();
    }
};

loans.init = function () {
    loans.loansDatatable();
};

$(document).ready(function () {
    loans.init();
});