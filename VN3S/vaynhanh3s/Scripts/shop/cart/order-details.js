var orderDetails = orderDetails || {};


orderDetails.init = function () {

};

orderDetails.HuyDonHang = function (id) {
    var html = '<div>Bạn muốn hủy đơn hàng? Xin nhập lý do: </div><div><textarea rows="3" id="LyDoHuy" placeholder="Nhập lý do hủy đơn hàng" class="form-control" styke="width:100%"/></div>';
    BootstrapDialog.show({
        title: "Hủy đơn hàng",
        message: html,
        type: BootstrapDialog.TYPE_WARNING,
        buttons: [
            {
                label: 'Hoàn tác',
                cssClass: 'btn-primary',
                action: function (dialogItself) {
                    dialogItself.close();
                }
            }, {
                label: 'Đồng ý',
                cssClass: 'btn-warning',
                action: function (dialogItself) {
                    if ($("#LyDoHuy").val() == "") {
                        BootstrapDialog.show({
                            title: "Lỗi",
                            message: "Bạn chưa nhập lý do hủy đơn",
                            type: BootstrapDialog.TYPE_DANGER,
                        });
                    }
                    else {
                        $.ajax({
                            url: "cart/HuyDonHang",
                            data: { DonHangKey: id, GhiChu: $("#LyDoHuy").val() },
                            method: "post",
                            success: function (response) {
                                dialogItself.close();
                                helpers.showMessage(response);
                                if (response.code) {
                                    setTimeout(function () { window.location = "/Cart/Tracking" }, 2000);
                                }

                            },
                            error: function (jqXHR, textStatus, errorThrown) {
                                console.log(textStatus, errorThrown);
                            }
                        });
                    }
                }
            }
        ]
    });
};

$(document).ready(function () {
    orderDetails.init();
});