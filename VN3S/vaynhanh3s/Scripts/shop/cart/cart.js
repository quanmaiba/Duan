var cart = cart || {};


var currentCart,
    cartItem = {
        Id: -1,
        GhiChu: "",
        TongTien: 0,
        DonHangChiTiets: [
            //{
            //    ThuoId: 0,
            //    TenThuoc: "",
            //    DonViId: 0,
            //    TenDonVi: "",
            //    SoLuongLon: 0,
            //    DonGiaLe: 0,
            //    ThanhTienLon: 0
            //}
        ]
    };

cart.Add = function (id, sll = 1, sln = 0) {
    if (sll == null || sll == undefined || sll == "")
        sll = 0;
    if (sln == null || sln == undefined || sln == "")
        sln = 0;

    $.ajax({
        url: "/product/Details?id=" + id,
        method: "post",
        success: function (response) {
            if (response.code == 1) {

                cart.GetCurrentCart();
                var matchItems = _.find(currentCart.DonHangChiTiets, function (o) { return o.ThuocId == response.data.Id; });
                if (matchItems == null || matchItems.length == 0) {
                    currentCart.DonHangChiTiets.push({ ThuocId: response.data.Id, TenThuoc: response.data.Ten, SoLuongLon: sll, SoLuongNho: sln, DonGiaLe: response.data.DonGiaLe, DonGiaLeQuyDoi: response.data.DonGiaLeQuyDoi, LogoThuoc: response.data.LogoThuoc, TenDonViLon: response.data.TenDonViLon, TenDonViNho: response.data.TenDonViNho });
                }
                else {
                    matchItems.SoLuongLon = parseInt(matchItems.SoLuongLon) + parseInt(sll);
                    matchItems.SoLuongNho = parseInt(matchItems.SoLuongNho) + parseInt(sln);
                }

                cart.Refresh(currentCart);
                cart.Display();
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });
}

cart.Edit = function (id) {
    cart.Remove(id);
    cart.Add(id, $("#thuocsll_" + id).val(), $("#thuocsln_" + id).val());

    cart.Refresh(currentCart);
    cart.Display();
}

cart.Remove = function (id) {
    cart.GetCurrentCart();

    _.remove(currentCart.DonHangChiTiets, function (o) { return o.ThuocId == id });

    cart.Refresh(currentCart);
    cart.Display();
}

cart.Clear = function () {
    currentCart = null;
    cart.AlwayInitCart();

    cart.Refresh(currentCart);
    cart.Display();
}

cart.GetCurrentCart = function () {
    currentCart = JSON.parse(localStorage.getItem('myCart'));
}

cart.AlwayInitCart = function () {
    //just init when current cart is null
    if (currentCart == null || currentCart == undefined) {
        currentCart = cartItem;

        localStorage.setItem('myCart', JSON.stringify(currentCart));
    }
}

cart.Refresh = function (cart) {
    var TongTien = 0;

    $.each(cart.DonHangChiTiets, function (i, v) {
        v.ThanhTienLon = v.SoLuongLon * v.DonGiaLe;
        v.ThanhTienNho = v.SoLuongNho * v.DonGiaLeQuyDoi;
        v.TongTien = v.ThanhTienLon + v.ThanhTienNho;

        TongTien += v.TongTien;
    });

    cart.TongTien = TongTien;
    localStorage.setItem('myCart', JSON.stringify(cart));
}

cart.Checkout = function () {
    cart.GetCurrentCart();
    if (currentCart.TongTien > 0) {
        window.location.href = "/Cart";
    }
}

cart.Submit = function () {
    if (isRequestAuthenticated == 'false') {
        BootstrapDialog.show({
            title: "Đăng nhập để mua hàng",
            message: 'Bạn cần phải đăng nhập trước khi thanh toán giỏ hàng!',
            type: BootstrapDialog.TYPE_WARNING,
            buttons: [{
                label: 'Đăng nhập',
                cssClass: 'btn-primary',
                action: function (dialogItself) {
                    window.location.href = "Account/Login?ReturnURL=%2FCart";
                }
            },
            {
                label: 'Đăng ký',
                cssClass: 'btn-success',
                action: function (dialogItself) {
                    window.location.href = "Account/Register?ReturnURL=%2FCart";
                }
            }
            ]
        });
    }
    else {
        cart.GetCurrentCart();
        if (currentCart.DonHangChiTiets == null || currentCart.DonHangChiTiets.length == 0) {
            helpers.showMessage({ code: 0, msg: "Bạn chưa chọn sản phẩm vào giỏ hàng" });
        }
        else {
            if ($("#frmCart").valid()) {
                var data = $("#frmCart").serializeObjectPro();
                console.log(data);
                $.ajax({
                    url: "/cart/MuaHang",
                    data: data,
                    method: "post",
                    success: function (response) {
                        helpers.showMessage(response);
                        if (response.code == 1) {

                            cartDetails.Display();
                            var pathname = window.location.pathname.toLowerCase();;
                            if (pathname.indexOf("quantri") < 0) {
                                cart.Clear();
                                cart.Display();

                                window.location.href = "Cart/Tracking";
                            }
                            else {
                                setTimeout(function () {
                                    cart.Clear();
                                    cart.Display();

                                    window.location.href = "/QuanTri";
                                }, 800);
                            }
                        }
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        console.log(textStatus, errorThrown);
                    }
                });
            }
        }
    }

}

cart.Display = function () {
    var soMatHang = currentCart.DonHangChiTiets.length;
    if (soMatHang == null || soMatHang == undefined || soMatHang == 0) {
        $("#cart-total").text("Giỏ hàng trống");
        $("#cart-total-mobile").text("Giỏ hàng trống");
    }
    else {
        $("#cart-total").html(soMatHang + " sản phẩm - " + "<span class='vnd'>" + currentCart.TongTien + "</span>");
        $("#cart-total-mobile").html(soMatHang + " sản phẩm - " + "<span class='vnd'>" + currentCart.TongTien + "</span>");
    }

    helpers.vndFormat();
}

cart.init = function () {
    cart.GetCurrentCart();
    cart.AlwayInitCart();
    cart.Display();
    $("#TinhThanhId").trigger("change");
}

$(document).ready(function () {
    cart.init();
});