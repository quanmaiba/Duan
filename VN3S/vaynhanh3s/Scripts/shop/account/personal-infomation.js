var personalInfomation = personalInfomation || {};

personalInfomation.Submit = function () {
    if ($("#persional").valid()) {
        var data = $("#persional").serializeObjectPro();

        $.ajax({
            url: "account/ChangePersonalInfomation",
            method: "Post",
            data: data,
            success: function (response) {
                helpers.showMessage(response);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
            }
        });
    }
}

personalInfomation.init = function () {
    $("TinhThanhId").trigger("change");
}

$(document).ready(function () {
    personalInfomation.init();
});