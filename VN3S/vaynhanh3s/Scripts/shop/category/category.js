var category = category || {};
var page = 0;

category.ThuocGets = function () {
    var pageSize = 12;
    var data = {
        DanhMucId: $("#hiddenCategoryId").val(),
        StartIndex: page * pageSize,
        NumRowEachPage: pageSize,
        SearchValue: ""
    };

    $.ajax({
        url: "category/ThuocTheoDanhMucPartial",
        method: "post",
        data: data,
        success: function (response) {
            if (response.indexOf("có sản phẩm") > 0 && page > 0) {
                page = page - 1;
            }
            else {
                $(".list-product").html(response);
                $("#grid-view").trigger("click");
            }
            
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });
};

category.prePage = function () {
    page = page - 1;
    if (page < 0)
        page = 0;

    category.ThuocGets();
}

category.nextPage = function () {
    page = page + 1;
    category.ThuocGets();
}

category.init = function () {
    category.ThuocGets();
}

$(document).ready(function () {
    category.init();
});