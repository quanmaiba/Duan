var product = product || {};

product.Add = function (id) {
    var sll = $("#thuoc_sll").val();
    var sln = $("#thuoc_sln").val();
    cart.Add(id, sll, sln);
    helpers.showMessage({ code: 1, msg: "Đã thêm sản phẩm vào giỏ hàng" });
}

product.init = function () {

}

$(document).ready(function () {
    product.init();
});