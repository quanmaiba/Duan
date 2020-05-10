var register = register || {};

register.delete = function (id) {
    $.ajax({
        url: "/register/Delete",
        method: "post",
        data: { id },
        success: function (response) {
            helpers.showMessage(response);
            register.reloadDatatable();
            addEditModal.modal("hide");
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });
};

register.TinhThanhChange = function (quanHuyenId = 0) {
    $.ajax({
        url: "/account/QuanHuyenGets?id=" + $("#TinhThanhId").val(),
        method: "Get",
        success: function (response) {
            $("#QuanHuyenId").empty();

            $.each(response, function (i, v) {
                var op = '<option ' + (quanHuyenId != 0 && quanHuyenId == v.id ? 'selected="selected"' : i == 0 ? 'selected="selected"' : '') + ' value="' + v.id + '">' + v.text + '</option>';
                $("#QuanHuyenId").append(op);
            });

            $("#QuanHuyenId").trigger("change");
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });
}


register.QuanHuyenChange = function (phuongXaId = 0) {
    $.ajax({
        url: "/account/PhuongXaGets?id=" + $("#QuanHuyenId").val(),
        method: "Get",
        success: function (response) {
            $("#PhuongXaId").empty();

            $.each(response, function (i, v) {
                var op = '<option ' + (phuongXaId != 0 && phuongXaId == v.id ? 'selected="selected"' :i == 0 ? 'selected="selected"' : '') + ' value="' + v.id + '">' + v.text + '</option>';
                $("#PhuongXaId").append(op);
            });

            $("#PhuongXaId").trigger("change");
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });
}

register.TaoThanhVien = function () {
    if ($("#frmRegister").valid() && $("#QuanHuyenId").val() != null && $("#PhuongXaId").val() != null) {
        var data = $("#frmRegister").serializeObjectPro();

        $.ajax({
            url: "/account/Register",
            method: "Post",
            data: data,
            success: function (response) {
                helpers.showMessage(response);

                if (response.code) {
                    setTimeout(function () { window.location = "/Account/Login?ReturnURL=" + response.returnURL }, 2000);
                }
                    
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
            }
        });
    }
}

register.init = function () {
}

$(document).ready(function () {
    register.init();
});