var lop = lop || {};

lop.drawTable = function () {
    loptable = $("#tbLop").DataTable({
        "processing": true, // for show progress bar  
        "serverSide": true, // for process server side  
        "filter": true, // this is for disable filter (search box)  
        "orderMulti": false, // for disable multiple column at once  
        "ajax": {
            "url": "/Lop/LayDanhSachLop",
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "lopId",
                "name": "LopId",
                "autoWidth": true,
                "title": "ID"
            },
            {
                "data": "tenLop",
                "name": "TenLop",
                "autoWidth": true,
                "title": "Tên Lớp"
            },
            {
                data: "lopId",
                render: function (data, type, row) {
                    return "<a href='javascript:void(0);' onclick=lop.getDetail('" + data + "')><i class='fa fa-eye'></i></a> " +
                        "<a href='javascript:void(0);' onclick=lop.delete('" + data + "')><i class='fa fa-trash'></i></a> ";
                },
                "sortable": false
            },
        ]

    });
};

lop.openAddEditModal = function () {
    lop.resetForm();
    $('#addEditModel').modal('show');
};

lop.initClasses = function () {
    $.ajax({
        url: '/lop/GetClasses',
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

lop.initSex = function () {
    $('#Sex').append(
        "<option value = '1'>Male</option><option value = '0'>Female</option>"
    );
};

lop.save = function () {
    if ($('#frmAddEditClass').valid()) {
        var lopObj = {};
        lopObj.TenLop = $('#TenLop').val();
        lopObj.LopId = $('#LopId').val();

        $.ajax({
            url: '/lop/LuuLop',
            method: 'POST',
            data: JSON.stringify(lopObj),
            dataType: 'json',
            contentType: 'application/json',
            success: function (data) {
                if (data.status === 1) {
                    $('#addEditModel').modal('hide');
                    //lop.reloadTable();
                    bootbox.alert(data.message);
                }
            }
        });
    }
};


lop.getDetail = function (id) {
    $.ajax({
        url: '/lop/Get/' + id,
        method: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            if (data.status === 1) {
                var response = data.response;

                $('#Fullname').val(response.fullName);
                $('#DOB').val(response.dob);
                $('#Sex').val(response.sex);
                $('#ClassName').val(response.classRoomId);
                $('#StudentId').val(response.lopId);
            }
            $('#addEditModel').find('.modal-title').text('Update Student');
            $('#addEditModel').modal('show');
        }
    });
};

lop.delete = function (id) {
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
                    url: '/lop/DeleteStudent/' + id,
                    method: 'GET',
                    dataType: 'json',
                    contentType: 'application/json',
                    success: function (data) {
                        if (data.status === 1) {
                            lop.reloadTable();
                        }
                    }
                });
            }
        }
    });

};

lop.reloadTable = function () {
    loptable.ajax.reload(null, false);
};

lop.resetForm = function () {
    $('#TenLop').val('');
    $('#addEditModel').find('.modal-title').text('Tạo Lớp');
    $("#frmAddEditClass").validate().resetForm();
};

lop.init = function () {
    lop.drawTable();
    //lop.initClasses();
    //lop.initSex();
    lop.resetForm();
};

$(document).ready(function () {
    lop.init();
});