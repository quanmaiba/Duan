var home = home || {};

home.dangKyNgay = function () {
    $("#modalDangKyNgay").modal("show");
    $("#modalTuyenDung").modal("hide");
}

home.vayTienMat = function () {
    $("html, body").animate({ scrollTop: $(".content-tab-1").offset().top - 120 }, "slow");
    return false;
}

home.scrollTop = function () {
    $("html, body").animate({ scrollTop: 0 }, "slow");
    return false;
}

home.yeuCauVay = function () {
    if ($("#modalDangKyNgay").valid()) {
        var data = $("#modalDangKyNgay").serializeObjectPro();

        $.ajax({
            url: "/Home/DangKyVay",
            method: "post",
            data: data,
            success: function (response) {
                helpers.showMessage(response);
                home.vayTienMatResetForm();
                $("#modalDangKyNgay").modal("hide");
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
            }
        });
    }
}


home.vayTienMatResetForm = function () {
    $("#HoTen").val("");
    $("#SoCMND").val("");
    $("#SoDienThoai").val("");
    $("#HoTen").val("");
}

home.tuyenDung = function () {
    $.validator.addMethod('ut_SoCMND', function (value) {
        return /^([1-9]([0-9]){8})$/.test(value) || /^([1-9]([0-9]){11})$/.test(value);
    }, "Số chứng minh không chính xác. Số chứng minh là một dãy số gồm 9 hoặc 12 chữ số.");

    $("#modalTuyenDung").modal("show");
    $("#modalDangKyNgay").modal("hide");
}

home.ungTuyen = function () {
    if ($("#modalTuyenDung").valid()) {
        var data = $("#modalTuyenDung").serializeObjectPro();

        $.ajax({
            url: "/Home/DangKyUngTuyen",
            method: "post",
            data: data,
            success: function (response) {
                helpers.showMessage(response);
                home.ungTuyenResetForm();
                $("#modalTuyenDung").modal("hide");
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
            }
        });
    }
}

home.ungTuyenResetForm = function () {
    $("#ut_HoTen").val("");
    $("#ut_SoCMND").val("");
    $("#ut_SoDienThoai").val("");
    $("#ut_HoTen").val("");
}

home.init = function () {
    $.validator.addMethod('SoCMND', function (value) {
        return /^([1-9]([0-9]){8})$/.test(value) || /^([1-9]([0-9]){11})$/.test(value);
    }, "Số chứng minh không chính xác. Số chứng minh là một dãy số gồm 9 hoặc 12 chữ số.");
}

$(document).ready(function () {
    home.init();
});