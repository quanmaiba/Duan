var candidator = candidator || {};
var dataTable = $('#candidatorDatatable'),
    dataTableOption;


candidator.candidatorDatatable = function () {
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
            url: "candidator/Gets",
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
                title: 'Họ và Tên',
                name: 'HoTen',
                data: 'hoTen'
            },
            {
                title: 'Số điện thoại',
                name: 'SoDienThoai',
                data: 'soDienThoai'
            },
            {
                title: 'Số CMND',
                name: 'SoCMND',
                data: 'soCMND'
            },
            {
                title: 'Tỉnh thành',
                name: 'TinhThanh',
                data: 'tinhThanh'
            },
            {
                title: 'Vị trí ứng tuyển',
                name: 'ViTri',
                data: 'viTri'
            },
            {
                title: 'Ngày đăng ký',
                name: 'NgayDangKy',
                data: 'ngayDangKy'
            }
        ],
    });
};

candidator.reloadDatatable = function () {
    dataTableOption.ajax.reload(null, false);
};

candidator.showInlineLoading = function (e, isShow) {
    var img = $(e).parents(".upload-section").find(".inline-loading");
    if (isShow)
        img.show();
    else {
        img.hide();
    }
};

candidator.init = function () {
    candidator.candidatorDatatable();
};

$(document).ready(function () {
    candidator.init();
});