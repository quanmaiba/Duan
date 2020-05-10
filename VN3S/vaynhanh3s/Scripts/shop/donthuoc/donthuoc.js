var donthuoc = donthuoc || {};
var addEditForm = $('#frmUploadDonThuoc');

donthuoc.Save = function () {
    if ($(".DonThuocUrl").length < 1) {
        BootstrapDialog.show({
            title: "Xác nhận",
            message: 'Bạn chưa tải đơn thuốc lên',
            type: BootstrapDialog.TYPE_WARNING,
            buttons: [{
                label: 'Đồng ý',
                cssClass: 'btn-primary',
                action: function (dialogItself) {
                    dialogItself.close();
                }
            }]
        });
    }
    else {
        if (addEditForm.valid()) {
            var data = addEditForm.serializeObjectPro();

            var url = "";

            $(".DonThuocUrl").each(function (i, v) {
                url += $(v).attr("src") + ";"
            })
            data.url = url;

            $.ajax({
                url: "UpLoadDonThuoc/Save",
                method: "post",
                data: data,
                success: function (response) {
                    helpers.showMessage(response);
                    setTimeout(function () {
                        window.location.href = "/";
                    }, 1500);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    console.log(textStatus, errorThrown);
                }
            });
        }
    }
}

donthuoc.donThuocUploader = function () {
    $('#DonThuocUploader').fileupload({
        dataType: 'json',
        maxFileSize: 5242880,//5MB
        acceptFileTypes: /(\.|\/)(gif|jpg|png)$/i,
        maxNumberOfFiles: 1,
        autoUpload: true,
        disableImageResize: false,
        imageMaxWidth: 1024,
        imageCrop: false,
        done: function (e, data) {
            $.each(data.result.files, function (index, file) {
                $("#DonThuocPreview").append('<div class="DonThuocPreview" style="float:left; margin-right:10px; margin-top:10px;"><a class="btn btn-sm btn-warning pointer" onclick="donthuoc.Remove(this)">x</a><br/><image class="DonThuocUrl" src="' + file.fullpath + '" style="width:100px;"/></div>');
                donthuoc.showInlineLoading("#DonThuocUploader", false);
            });
        },
        add: function (e, data) {
            donthuoc.showInlineLoading("#DonThuocUploader", true);
            data.submit();
        }
    });
}

donthuoc.Remove = function (e) {
    $(e).parents(".DonThuocPreview").remove();
}

donthuoc.showInlineLoading = function (e, isShow) {
    var img = $(e).parents(".upload-section").find(".inline-loading")
    if (isShow)
        img.show();
    else {
        img.hide();
    }
}

donthuoc.init = function () {
    donthuoc.donThuocUploader();
}

$(document).ready(function () {
    donthuoc.init();
});