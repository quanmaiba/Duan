var helpers = helpers || {};

var apis = [
    {
        url: "{OrgPath}/Account/ForgotPassword",
        method: "POST",
        name: "forgot"
    },
];

helpers.api_login = function (apiName) {

    api_login = "/Account/Login";
}

$.fn.extend({
    serializeObjectPro: function () {
        var o = {};
        var a = this.serializeArray();
        $.each(a, function () {
            if (this.name.indexOf("[") > 0) {

                var d = this.name.split("["),
                    objectName = d[0].replace(']', ''),
                    index = d[1].replace("]", ""),
                    key = d[2].replace(']', '');

                //var objectName = this.name.substring(0, this.name.indexOf("["));
                //var key = this.name.substring(this.name.indexOf("].") + 2, this.name.length);

                if (typeof o[objectName] == 'undefined')
                    o[objectName] = {};

                if (typeof o[objectName][index] == 'undefined')
                    o[objectName][index] = {}

                if (key == "StartDate" || key == "EndDate")
                    o[objectName][index][key] = parseDatetime(this.value) || '';
                else
                    o[objectName][index][key] = this.value || '';

                //o[objectName][key] = this.value || '';
            }
            else {
                if (o[this.name]) {
                    if (!o[this.name].push) {
                        o[this.name] = [o[this.name]];
                    }
                    o[this.name].push(this.value || '');
                } else {
                    o[this.name] = this.value || '';
                }
            }
        });
        return o;
    }
})


toastr.options = {
    "closeButton": false,
    "debug": false,
    "newestOnTop": true,
    "progressBar": true,
    "positionClass": "toast-top-center",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "300",
    "timeOut": "2000",
    "extendedTimeOut": "800",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
};

helpers.showMessage = function (obj) {
    toastr[obj.code == 1 ? "success" : "error"](obj.msg);
};

helpers.vndFormat = function ()
{
    $(".vnd").each(function (i, v) {
        var x = parseInt($(v).text());
        x = x.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
        $(v).text(x);
        $(v).removeClass("vnd");
    });
}

helpers.showForgotPasswordModal = function () {
    $("#forgotPasswordModal").modal("show");
}

helpers.requestNewPassword = function () {
    if ($("#frmForgotPassword").valid()) {
        var data = $("#frmForgotPassword").serializeObjectPro();

        $.ajax({
            url: "account/QuenMatKhau",
            method: "post",
            data: data,
            success: function (response) {
                helpers.showMessage(response);
                $("#forgotPasswordModal").modal("hide");
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
            }
        });
    }
}

helpers.expainMobileMenu = function (e) {
    $(e).parents(".dropdown").find(".dropdown-hitarea").trigger("click");
}

$(document).ready(function () {
    helpers.vndFormat();

    var videos = document.querySelectorAll('.ql-video')
    for (let i = 0; i < videos.length; i++) {
        var embedContainer = document.createElement('div')
        embedContainer.setAttribute('class', 'embed-container')
        var parent = videos[i].parentNode
        parent.insertBefore(embedContainer, videos[i])
        embedContainer.appendChild(videos[i])
    }
});