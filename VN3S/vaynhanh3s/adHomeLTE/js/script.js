$(function(){
	

	$('.nav li').hover(function(){
	    $('ul:first', this).stop().slideDown();
	},function(){
		$('ul',this).hide();
		
	});


	$('.nav li ul li').hover(function () {
	    var position = $(this).offset();
	    var rightpos = $(window).width() - position.left;
	    if (rightpos < 500)
	        $('ul:first', this).css("left", "-100%");
	    $('ul:first', this).stop().slideDown();
	}, function () {
	    $('ul', this).hide();
	});
	
	$('.c-border-shadow').hover(function(){
		$(this).addClass('c-border-shadow-hover');	
	},function(){
		$(this).removeClass('c-border-shadow-hover');
	});
	

	

	
    $(window).scroll(function (event) {
        if ($("html").width() > 500) {
            if ($(this).scrollTop() > 10) {
                $('#button-btt').fadeIn();
            } else {
                $('#button-btt').fadeOut();
            }
        }
        else {
            $('#button-btt').hide();
        }
	    
	});

	$("#button-btt").click(function () {
	    $("html, body").animate({ scrollTop: 0 }, "slow");
	    return false;
	});
});


function callSlide(min_money, max_money) {
    $("#slider").slider({
        orientation: "horizontal",
        range: "min",
        min: min_money,
        max: max_money,
        value: min_money,
        step: 500000,
        slide: getValueSlide,
        change: getValueSlide
    });
}


function validateEmail(email) {
   // var re = /^(([^<>()\[\]\\.,;:\s@@"]+(\.[^<>()\[\]\\.,;:\s@@"]+)*)|(".+"))@@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
   // return re.test(email);
   return true;
}

function callSlide1(min_month, max_month) {
    $("#slider1").slider({
        orientation: "horizontal",
        range: "min",
        min: min_month,
        max: max_month,
        value: min_month,
        step: 3,
        slide: getValueSlide1,
        change: getValueSlide1
    });
}


function getValueSlide() {
    var tienvay = $("#slider").slider("value");

    $('#money_valslider').val(Comma(tienvay));
    $('#slider .ui-slider-handle').html('<div class="valueAbsolute">' + Comma(tienvay) + '</div>');
    tinhtragop();
}
function getValueSlide1() {
    var value = $("#slider1").slider("value");
    $('#month_valslider').val(value);
    $('#slider1 .ui-slider-handle').html('<div class="valueAbsolute">' + value + ' </div>');
    tinhtragop();
}




$.fn.digits = function () {
    return this.each(function () {
        $(this).text($(this).text().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1."));
    })
}


function Comma(Num) { //function to add commas to textboxes
    
    Num += '';
    Num = Num.replace('.', ''); Num = Num.replace('.', ''); Num = Num.replace('.', '');
    Num = Num.replace('.', ''); Num = Num.replace('.', ''); Num = Num.replace('.', '');
    x = Num.split('.');
    x1 = x[0];
    x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1))
        x1 = x1.replace(rgx, '$1' + '.' + '$2');
    return x1 + x2;
    

    //alert(Num);
    //num2 = Num.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".");

    return num2;




}

function findAndReplace(string, target, replacement) {
    var i = 0, length = string.length;
    for (i; i < length; i++) {
        string = string.replace(target, replacement);
    }
    return parseInt(string);
}


$(window).scroll(function () {
    if ($(this).scrollTop() > 40) {
        $('.header').addClass("sticky");
        $('.line-menu').hide();
        $('.logo img').fadeIn();
        $('.nav').addClass("stickynav");

    }
    else {
        $('.header').removeClass("sticky");
        $('.line-menu').show();
        $('.nav').removeClass("stickynav");
        //$('.logo img').removeClass("imglogo");
    }
});

//var mywindow = $(window);
//var mypos = mywindow.scrollTop() + 40;
//var up = false;
//var newscroll;
//mywindow.scroll(function () {
//    newscroll = mywindow.scrollTop();
//    if (newscroll > mypos && !up) {
//        $('.header').stop().slideToggle('slow');
//        up = !up;
//        console.log(up);
//    } else if(newscroll < mypos && up) {
//        $('.header').stop().slideToggle('slow');
//        up = !up;
//    }
//    mypos = newscroll;
//});


