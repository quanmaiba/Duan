var banner = banner || {};
var addEditModal = $("#addEditModal"),
    addEditForm = $('#addEditForm'),
    dataTable = $('#bannerDatatable'),
    dataTableOption;


banner.bannerDatatable = function () {
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
            url: "banner/Gets",
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
                title: 'Hình ảnh',
                name: 'Id',
                data: 'id',
                render: function (data, type, row, meta) {
                    
                    return $("<div>").append('<img style="width:100px" src="'+ row.url +'"/>').html();
                }
            },
            {
                title: 'Mô tả',
                name: 'Description',
                data: 'description'
            },
            {
                title: 'Công cụ',
                name: 'id',
                sortable: false,
                searchable: false,
                width: 50,
                render: function (data, type, row, meta) {
                    var editBtn = '<a onclick="banner.showEditModal(\'' + row.id + '\')" href="javascript:;" class="action-buttons" data-toggle="tooltip" data-placement="top" title="Chỉnh sửa banner"><i class="fa fa-pencil poiter"></i></a>';
                    var deleteBtn = '<a onclick="banner.showConfirmDeleteModal(\'' + row.id + '\')" href="javascript:;" class="action-buttons" data-toggle="tooltip" data-placement="top" title="Xóa banner"><i class="fa fa-remove poiter"></i></a>';
                    return $("<div>").append(editBtn + ' ' + deleteBtn).html();
                }
            },
        ],
    });
};

banner.Save = function () {
    if (addEditForm.valid()) {
        var data = addEditForm.serializeObjectPro();

        $.ajax({
            url: "banner/AddUpdate",
            method: "post",
            data: data,
            success: function (response) {
                helpers.showMessage(response);
                banner.reloadDatatable();
                addEditModal.modal("hide");
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
            }
        });
    }
};

banner.reloadDatatable = function () {
    dataTableOption.ajax.reload(null, false);
}

banner.showAddModel = function () {
    banner.resetForm();

    addEditModal.find(".modal-title").text("Thêm mới banner");
    addEditModal.modal("show");
};

banner.showEditModal = function (id) {
    banner.resetForm();

    $.ajax({
        url: "banner/Get/" + id,
        method: "get",
        success: function (response) {
            if (response.code == 1) {
                var data = response.data;
                banner.bindingForm(data);
                addEditModal.find(".modal-title").text("Chỉnh sửa banner");
                addEditModal.modal("show");
            } else
                helpers.showMessage(response)
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });
};

banner.showConfirmDeleteModal = function (id) {
    BootstrapDialog.show({
        title: "Xác nhận",
        message: 'Bạn có muốn xóa banner?',
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
                banner.delete(id);
                dialogItself.close();
            }
        }]
    });
};

banner.delete = function (id) {
    $.ajax({
        url: "banner/Active",
        method: "post",
        data: { id },
        success: function (response) {
            helpers.showMessage(response);
            banner.reloadDatatable();
            addEditModal.modal("hide");
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });
};

banner.bindingForm = function (data) {
    if (data != undefined && data != null) {
        $("#hiddenId").val(data.Id);
        $("#Description").val(data.Description);
        $("#URL").val(data.Url);
        $("#URLPreview").attr("src", data.Url);
    }
};

banner.resetForm = function () {
    $("#hiddenId").val("");
    $("#Description").val("");
    $("#URL").val("");
    $("#URLPreview").attr("src", "");
};

banner.URLUploader = function () {
    $('#URLUploader').fileupload({
        dataType: 'json',
        maxFileSize: 5242880,//5MB
        acceptFileTypes: /(\.|\/)(gif|jpg|png)$/i,
        maxNumberOfFiles: 1,
        autoUpload: true,
        disableImageResize: false,
        imageMaxWidth: 1024,
        imageCrop: false,
        done: function (e, data) {
            $.each(data.result.files, function (index, file) {
                $("#URL").val(file.fullpath);
                $("#URLPreview").attr("src", file.fullpath);
                banner.showInlineLoading("#URLUploader", false);
            });
        },
        add: function (e, data) {
            window.NotShowLoading = true;
            banner.showInlineLoading("#URLUploader", true);
            data.submit();
        }
    });
}

banner.showInlineLoading = function (e, isShow) {
    var img = $(e).parents(".upload-section").find(".inline-loading")
    if (isShow)
        img.show();
    else {
        img.hide();
    }
}

banner.init = function () {
    banner.bannerDatatable();
    banner.URLUploader();
}

$(document).ready(function () {
    banner.init();
});