var changePassword = changePassword || {};

changePassword.Submit = function () {
    if ($("#frmChangePassword").valid()) {
        var data = $("#frmChangePassword").serializeObjectPro();

        $.ajax({
            url: "account/ChangePassword",
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

changePassword.init = function () {
}

$(document).ready(function () {
    changePassword.init();
});