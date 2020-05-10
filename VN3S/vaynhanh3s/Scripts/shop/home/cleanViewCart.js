var cleanViewCart = cleanViewCart || {};

cleanViewCart.clearViewCart = function () {
    cart.GetCurrentCart();
    if (currentCart != null && currentCart.IsView) {
        currentCart = {
            Id: -1,
            GhiChu: "",
            TongTien: 0,
            DonHangChiTiets: [

            ]
        };
        localStorage.setItem('myCart', JSON.stringify(currentCart));
    }
}


$(document).ready(function () {
    cleanViewCart.clearViewCart();
});