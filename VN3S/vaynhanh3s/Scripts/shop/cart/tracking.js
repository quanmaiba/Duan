var tracking = tracking || {};
var noiDungQEditor,
    addEditModal = $("#addEditModal"),
    addEditForm = $('#addEditForm'),
    dataTable = $('#donhangDatatable'),
    dataTableOption;


tracking.tintucDatatable = function () {
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
            url: "cart/LayDonHang",
            data: { TrangThaiId: "" },
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
                title: 'Ngày mua',
                name: 'NgayTao',
                data: 'ngayTao',
                render: function (data, type, row, meta) {
                    return moment(data).format("HH:mm DD/MM/YYYY");
                }
            },
            {
                title: 'Người nhận',
                name: 'NguoiNhan',
                data: 'nguoiNhan',
            },
            {
                title: 'Tổng tiền',
                name: 'TongTien',
                data: 'tongTien',
                render: function (data, type, row, meta) {
                    return $("<div>").append("<span class='vnd'>"+ data +"</span>").html();
                }
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
                    var viewBtn = '<a href="Cart/OrderDetails/'+ row.key +'" class="action-buttons" data-toggle="tooltip" data-placement="top" title="Xem chi tiết"><i class="fa fa-eye poiter"></i></a>';
                    //var deleteBtn = '<a onclick="tracking.showConfirmDeleteModal(\'' + row.id + '\')" href="javascript:;" class="action-buttons" data-toggle="tooltip" data-placement="top" title="Xóa tin tức"><i class="fa fa-remove poiter"></i></a>';
                    return $("<div>").append(viewBtn).html();
                }
            },
        ],
        "drawCallback": function (settings) {
            helpers.vndFormat();
        }
    });
};
tracking.reloadDatatable = function () {
    dataTableOption.ajax.reload(null, false);
}

tracking.showConfirmDeleteModal = function (id) {
    BootstrapDialog.show({
        title: "Xác nhận",
        message: 'Bạn có muốn xóa tin tức?',
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
                tracking.delete(id);
                dialogItself.close();
            }
        }]
    });
};

tracking.delete = function (id) {
    $.ajax({
        url: "cart/Delete",
        method: "post",
        data: { id },
        success: function (response) {
            helpers.showMessage(response);
            tracking.reloadDatatable();
            addEditModal.modal("hide");
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });
};

tracking.init = function () {
    tracking.tintucDatatable();
}

$(document).ready(function () {
    tracking.init();
});