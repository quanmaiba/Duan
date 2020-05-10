var cartDetails = cartDetails || {};

cartDetails.Display = function () {
    setTimeout(function () {
        $(".shopping-cart tbody").empty();
        cart.GetCurrentCart();
        var tongcongDonHang = 0;
        $.each(_.sortBy(currentCart.DonHangChiTiets, o => o.ThuocId), function (i, v) {
            var rowspan = 1;
            if (v.TenDonViLon != v.TenDonViNho)
                rowspan = 2;

            var td = '<tr><td class="text-center vertical-center" rowspan="' + rowspan + '"><a href="/Product/Index/' + v.ThuocId + '"><img style="max-width:50px" src="' + v.LogoThuoc + '"/></a><span class="input-group-btn"> <button type="button" data-toggle="tooltip" title="Remove" class="btn btn-danger btn-sm" onclick="cart.Remove(' + v.ThuocId + ',true' + ');cartDetails.Display();"><i class="fa fa-times-circle"></i></button> </span></td>';
            td += '<td class="vertical-center" rowspan="' + rowspan + '">' + v.TenThuoc + '</td>';
            td += '<td><div class="input-group btn-block"><div class="input-group"> <input style="min-width:50px" onfocusout="cart.Edit(' + v.ThuocId + ');cartDetails.Display();" type="text" id="thuocsll_' + v.ThuocId + '"  value="' + v.SoLuongLon + '" class="form-control"> <span class="input-group-btn"><button style="min-width:50px" type="button" class="btn btn-info btn-flat">' + v.TenDonViLon + '</button></span> </div></div></td>';
            td += '<td class=" text-right"><span class="vnd">' + v.DonGiaLe + '</span></td>';
            td += '<td class=" text-right"><span class="vnd">' + v.ThanhTienLon + '</span></td>';
            td += '<td class="vertical-center text-right" rowspan="' + rowspan + '"><span class="vnd">' + v.TongTien + '</span></td></tr>';

            if (v.TenDonViLon != v.TenDonViNho) {
                td += '<tr><td><div class="input-group btn-block"><div class="input-group"> <input style="min-width:50px" onfocusout="cart.Edit(' + v.ThuocId + ');cartDetails.Display();" type="text" id="thuocsln_' + v.ThuocId + '"  value="' + v.SoLuongNho + '" class="form-control"> <span class="input-group-btn"><button style="min-width:50px" type="button" class="btn btn-info btn-flat">' + v.TenDonViNho + '</button></span> </div></div></td>';
                td += '<td class=" text-right"><span class="vnd">' + v.DonGiaLeQuyDoi + '</span></td>';
                td += '<td class=" text-right"><span class="vnd">' + v.ThanhTienNho + '</span></td></tr>';
            }

            var hiddens = '<input type="hidden" name="DonHangChiTiets[' + i + '][ThuocId]" id="ThuocId" value="' + v.ThuocId + '"/>';
            hiddens += '<input type="hidden" name="DonHangChiTiets[' + i + '][SoLuongLon]" id="SoLuongLon" value="' + v.SoLuongLon + '"/>';
            hiddens += '<input type="hidden" name="DonHangChiTiets[' + i + '][SoLuongNho]" id="SoLuongNho" value="' + v.SoLuongNho + '"/>';
            hiddens += '<input type="hidden" name="DonHangChiTiets[' + i + '][GiaBanLon]" id="GiaBanLon" value="' + v.DonGiaLe + '"/>';
            hiddens += '<input type="hidden" name="DonHangChiTiets[' + i + '][GiaBanNho]" id="GiaBanNho" value="' + v.DonGiaLeQuyDoi + '"/>';
            hiddens += '<input type="hidden" name="DonHangChiTiets[' + i + '][ThanhTienLon]" id="ThanhTienLon" value="' + v.ThanhTienLon + '"/>';
            hiddens += '<input type="hidden" name="DonHangChiTiets[' + i + '][ThanhTienNho]" id="ThanhTienNho" value="' + v.ThanhTienNho + '"/>';
            hiddens += '<input type="hidden" name="DonHangChiTiets[' + i + '][TongTien]" id="TongTien" value="' + v.TongTien + '"/>';

            $(".shopping-cart tbody").append(td).append(hiddens);

            tongcongDonHang += v.TongTien;
        });
        var hiddens = '<input type="hidden" name="TongTien" id="TongTien" value="' + tongcongDonHang + '"/>';
        var tfooter = '<tfoot style="font-weight:600"><tr><td colspan="5" class="text-right">Tổng cộng:</td><td><span class="vnd">' + tongcongDonHang + '</span></td></tr><input type="hidden" name="TongTien"/></tfoot>'
        $(".shopping-cart tfoot").empty();
        $(".shopping-cart").append(tfooter).append(hiddens);
        helpers.vndFormat();
    }, 800);

}

cartDetails.init = function () {
    cartDetails.Display();
}

$(document).ready(function () {
    cartDetails.init();
});