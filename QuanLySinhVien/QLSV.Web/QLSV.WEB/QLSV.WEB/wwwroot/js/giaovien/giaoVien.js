var giaoVien = giaoVien || {};

giaoVien.drawTable = function () {
    giaoVientable = $("#tbgiaoVien").DataTable({
        "processing": true, // for show progress bar  
        "serverSide": true, // for process server side  
        "filter": true, // this is for disable filter (search box)  
        "orderMulti": false, // for disable multiple column at once  
        "ajax": {
            "url": "/GiaoVien/LayDanhSachGiaoVien",
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            //{
            //    "data": "giaoVienId",
            //    "name": "GiaoVienId",
            //    "autoWidth": true,
            //    "title": "ID"
            //},
            {
                "data": "hoTenGV",
                "name": "HoTenGV",
                "autoWidth": true,
                "title": "Tên Giáo Viên"
            },
            {
                "data": "gioiTinh",
                "name": "GioiTinh",
                "autoWidth": true,
                "title": "Giới Tính"
            },
            {
                "data": "dob",
                "name": "DOB",
                "autoWidth": true,
                "title": "Ngày Sinh"
            },
            {
                "data": "img",
                "name": "Img",
                "autoWidth": true,
                "title": "Ảnh",
                "render": function (data) {

                    return '<img src="' + data + '" style="width:50px;height:50px;" alt="anh"/>';

                    //return "<video>"+
                    //    "<source  type='video/mp4' src='" + data + "' >" +
                    //"</video>"

                }
            },
            {
                "data": "diaChi",
                "name": "DiaChi",
                "autoWidth": true,
                "title": "Địa Chỉ"
            },
            {
                "data": "email",
                "name": "Email",
                "autoWidth": true,
                "title": "Email"
            },
            {
                "data": "tongSoLop",
                "name": "TongSoLop",
                "autoWidth": true,
                "title": "Số Lớp Dạy"
            },
            {
                data: "giaoVienId",
                render: function (data, type, row) {
                    return "<a href='javascript:void(0);' onclick=giaoVien.getDetail('" + data + "')><i class='fa fa-eye'></i></a> " +
                        "<a href='javascript:void(0);' onclick=giaoVien.delete('" + data + "')><i class='fa fa-trash'></i></a> ";
                },
                "sortable": false
            },
        ]

    });
};

giaoVien.openAddEditModal = function () {
    giaoVien.resetForm();
    $('#addEditModel').modal('show');
};

giaoVien.initClasses = function () {
    $.ajax({
        url: '/giaoVien/GetClasses',
        method: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            if (data.status === 1) {
                var response = data.response;
                $.each(response, function (index, value) {
                    $('#ClassName').append(
                        "<option value = '" + value.id + "'>" + value.name + "</option>"
                    );
                });
            }
        }
    });
};

giaoVien.initSex = function () {
    $('#GioiTinh').append(
        "<option value = '1'>Nam</option><option value = '0'>Nữ</option>"
    );
};

giaoVien.save = function () {
    //if ($('#frmAddEditClass').valid()) {
    var giaoVienObj = {};
    giaoVienObj.GiaoVienId = $('#GiaoVienId').val();
    giaoVienObj.HoTenGV = $('#HoTenGV').val();
    $('#GioiTinh').val() == 1 ? giaoVienObj.GioiTinh = true : giaoVienObj.GioiTinh = false;
    giaoVienObj.DOB = $('#DOB').val();
    giaoVienObj.Img = imagebase64;
    giaoVienObj.DiaChi = $('#DiaChi').val();
    giaoVienObj.Email = $('#Email').val();

    $.ajax({
        url: '/GiaoVien/LuuGiaoVien',
        method: 'POST',
        data: JSON.stringify(giaoVienObj),
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            if (data.status === 1) {
                $('#addEditModel').modal('hide');
                giaoVien.reloadTable();
                bootbox.alert(data.message);
            }
            else if (data.status ===0)
            {
                bootbox.alert(data.message);
            }
        }
    });
    //}
};


giaoVien.getDetail = function (id) {
    $.ajax({
        url: '/GiaoVien/LayGiaoVienTheoId/' + id,
        method: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            if (data.status === 1) {
                var response = data.response;

                $('#GiaoVienId').val(response.giaoVienId);
                $('#DOB').val(response.dob);
                $('#HoTenGV').val(response.hoTenGV);
                if (response.gioiTinh === "Nam") {
                    $('#GioiTinh').val('1');
                } else if (response.gioiTinh === "Nữ") {
                    $('#GioiTinh').val('0');
                }
                giaoVien.showImg(response.img);
                $('#DiaChi').val(response.diaChi);
                $('#Email').val(response.email);
                //$('#TongSoLop').val(response.tongSoLop);
                $('#addEditModel').find('.modal-title').text('Cập Nhập Giáo Viên');
                $('#addEditModel').modal('show');
            }
            if (data.status === -1) {
                bootbox.alert(data.message);
            }
           
        }
    });
};

giaoVien.delete = function (id) {
    bootbox.confirm({
        message: "Are you sure to delete?",
        buttons: {
            confirm: {
                label: 'Yes',
                className: 'btn-success'
            },
            cancel: {
                label: 'No',
                className: 'btn-danger'
            }
        },
        callback: function (result) {
            if (result) {
                $.ajax({
                    url: '/GiaoVien/XoaNhanVien/' + id,
                    method: 'DELETE',
                    dataType: 'json',
                    contentType: 'application/json',
                    success: function (data) {
                        if (data.status === 2) {
                            giaoVien.reloadTable();
                            bootbox.alert(data.message);
                            giaoVien.resetForm();
                           var imagebase64 = "";
                            giaoVien.showImg(imagebase64);
                        }
                        else if (data.status === 1) {
                            bootbox.alert(data.message);
                        }
                    }
                });
            }
        }
    });

};

giaoVien.showImg = (imagebase64) => {
    if (imagebase64 == "") {
        //$('#hienAnh').show();
        $('#Img').hide();
    } else {
        //$('#hienAnh').hide();
        $('img[id="Img"]').attr('src', imagebase64);
        //$('#Img').show();

    }
};

var imagebase64 = "";
giaoVien.encodeImageFileAsURL = function (element) {
    var file = element.files[0];
    var reader = new FileReader();
    reader.onloadend = function () {
        imagebase64 = reader.result;
        if (imagebase64 != "") {
            giaoVien.showImg(imagebase64);

        }
    }
    reader.readAsDataURL(file);
};

giaoVien.reloadTable = function () {
    giaoVientable.ajax.reload(null, false);
};

giaoVien.resetForm = function () {
    $('#GiaoVienId').val('0');
    $('#HoTenGV').val('');
    $('#GioiTinh').val('1');
    $('#DOB').val('');
    $('#Img').val(''); 
    $('#IMGFile').val('');
    $('#DiaChi').val('');
    $('#Email').val('');
    $('#addEditModel').find('.modal-title').text('Tạo Giáo Viên');
    //$("#frmAddEditClass").validate().resetForm();
};

giaoVien.init = function () {
    giaoVien.drawTable();
    //giaoVien.initClasses();
    giaoVien.initSex();
    giaoVien.resetForm();
};

$(document).ready(function () {
    giaoVien.init();
});