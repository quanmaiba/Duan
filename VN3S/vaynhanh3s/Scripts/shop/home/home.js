var home = home || {};
var owl;

home.blogCarousel = function () {
    $("#blog-carousel").owlCarousel({
        margin: 10,
        autoWidth: true,
        items: 3,
    });
}


home.init = function () {
    home.blogCarousel();
    owl = $("#blog-carousel").data('owlCarousel');
}

$(document).ready(function () {
    home.init();
});