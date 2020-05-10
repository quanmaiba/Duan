var customer = customer || {};
var addEditModal = $("#addEditModal"),
    addEditForm = $('#addEditForm'),
    dataTable = $('#customerDatatable'),
    dataTableOption,
    tuNgay = "null",
    denNgay = "null";


customer.customerDatatable = function () {
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
            url: 'home/Gets',
            type: "POST",
            dataType: 'json'
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
                data: 'hoTen'//,
                //render: function (data, type, row, meta) {

                //    return $("<div>").append('<img style="width:100px" src="'+ row.url +'"/>').html();
                //}
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
                title: 'Điều kiện vay',
                name: 'DieuKienVay',
                data: 'dieuKienVay'
            },
            {
                title: 'Ngày đăng ký',
                name: 'NgayDangKy',
                data: 'ngayDangKy'
            },
            {
                title: 'Đã xuất excel',
                name: 'DaXuatRaExcel',
                data: 'daXuatRaExcel',
                class: "text-center",
                render: function (data, type, row, meta) {
                    var checkBtn = '<i class="fa fa-check poiter"></i>';
                    if (!data)
                        checkBtn = '';
                    return $("<div>").append(checkBtn).html();
                }
            }
        ],
    });
};

customer.Save = function () {
    if (addEditForm.valid()) {
        var data = addEditForm.serializeObjectPro();

        $.ajax({
            url: "home/AddUpdate",
            method: "post",
            data: data,
            success: function (response) {
                helpers.showMessage(response);
                customer.reloadDatatable();
                addEditModal.modal("hide");
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
            }
        });
    }
};

customer.reloadDatatable = function () {
    dataTableOption.ajax.reload(null, true);
}

customer.showAddModel = function () {
    customer.resetForm();

    addEditModal.find(".modal-title").text("Thêm mới banner");
    addEditModal.modal("show");
};

customer.showEditModal = function (id) {
    customer.resetForm();

    $.ajax({
        url: "home/Get/" + id,
        method: "get",
        success: function (response) {
            if (response.code == 1) {
                var data = response.data;
                banner.bindingForm(data);
                addEditModal.find(".modal-title").text("Chỉnh sửa banner");
                addEditModal.modal("show");
            } else
                helpers.showMessage(response);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });
};


customer.showInlineLoading = function (e, isShow) {
    var img = $(e).parents(".upload-section").find(".inline-loading")
    if (isShow)
        img.show();
    else {
        img.hide();
    }
};

customer.xuatExcel = function (daXuatRaExcel) {
    $("#ExportToCSV").remove();

    $('body').append('<form id="ExportToCSV"></form>');
    $('#ExportToCSV')
        .attr("action", "Home/XuatExcel").attr("method", "post")
        .append('<input type="hidden" name="tuNgay" value="' + tuNgay + '">')
        .append('<input type="hidden" name="denNgay" value="' + denNgay + '">')
        .append('<input type="hidden" name="daXuatRaExcel" value="' + daXuatRaExcel + '">')
        .append('<input type="hidden" name="updateExcel" value="' + true + '">');

    $('#ExportToCSV').submit();

    customer.reloadDatatable();
}

customer.init = function () {
    customer.customerDatatable();
    $('#daterange').daterangepicker(
        {
            autoUpdateInput: false,
            locale: {
                cancelLabel: 'Clear'
            }
        });

    $('#daterange').on('apply.daterangepicker', function (ev, picker) {
        tuNgay = picker.startDate.format('YYYY-MM-DD');
        denNgay = picker.endDate.format('YYYY-MM-DD');
        $(this).val(picker.startDate.format('DD/MM/YYYY') + ' - ' + picker.endDate.format('DD/MM/YYYY'));

        dataTableOption.ajax.url('home/Gets?tuNgay=' + tuNgay + "&DenNgay=" + denNgay);
        customer.reloadDatatable();
    });

    $('#daterange').on('cancel.daterangepicker', function (ev, picker) {
        $(this).val('');
    });
};

$(document).ready(function () {
    customer.init();
});