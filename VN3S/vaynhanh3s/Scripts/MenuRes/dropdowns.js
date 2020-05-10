(function($){
	$.fn.dropdowns = function (options) {
		
		var defaults = {
			toggleWidth: 999
		}
		
		var options = $.extend(defaults, options);
		
		var ww = document.body.clientWidth;
		
		var addParents = function() {
			$(".ul-nav-mobile li a").each(function() {
				if ($(this).next().length > 0) {
					$(this).addClass("parent");
				}
			});
		}
		
		//var adjustMenu = function() {
		//	if (ww < options.toggleWidth) {
		//		$(".toggleMenu").css("display", "inline-block");
		//		if (!$(".toggleMenu").hasClass("active")) {
		//			$(".ul-nav-mobile").slideUp();
		//		} else {
		//			$(".ul-nav-mobile").slideDown();
		//		}
		//		$(".ul-nav-mobile li").unbind('mouseenter mouseleave');
		//		$(".ul-nav-mobile li a.parent").unbind('click').bind('click', function(e) {
		//		    // must be attached to anchor element to prevent bubbling
		//		    e.preventDefault();
		//		    $(".ul-nav-mobile li").removeClass("hover");
		//		    $(this).parent("li").toggleClass("hover");
				    
		//		});
		//	} 
		//	else if (ww >= options.toggleWidth) {
		//		$(".toggleMenu").css("display", "none");
		//		$(".ul-nav-mobile").slideDown();
		//		$(".ul-nav-mobile li").removeClass("hover");
				
		//		//alert("123");
		//		//$(".ul-nav-mobile li a").unbind('click');
		//		$(".ul-nav-mobile li").unbind('mouseenter mouseleave').bind('mouseenter mouseleave', function() {
		//			// must be attached to li so that mouseleave is not triggered when hover over submenu
		//			$(this).toggleClass('hover');
		//		});
		//	}
		//}
		
		var adjustMenu = function () {
		    if (ww < 967) {
		        $(".toggleMenu").css("display", "inline-block");
		        if (!$(".toggleMenu").hasClass("active")) {
		            $(".ul-nav-mobile").slideUp();
		        } else {
		            $(".ul-nav-mobile").slideDown();
		        }
		        $(".ul-nav-mobile li").unbind('mouseenter mouseleave');
		        $(".ul-nav-mobile li a.parent").unbind('click').bind('click', function (e) {
		            // must be attached to anchor element to prevent bubbling
		            e.preventDefault();
		            $(".ul-nav-mobile li").addClass('abc');
		            var abc = $(this).parent("li");
		            $(abc).toggleClass("hover").removeClass('abc');
		            $(".ul-nav-mobile li.abc").removeClass('hover');
		        });
		    }
		    else if (ww >= 967) {
		        $(".toggleMenu").css("display", "none");
		        $(".ul-nav-mobile").show();
		        $(".ul-nav-mobile li").removeClass("hover");
		        $(".ul-nav-mobile li a").unbind('click');
		        $(".ul-nav-mobile li").unbind('mouseenter mouseleave').bind('mouseenter mouseleave', function () {
		            // must be attached to li so that mouseleave is not triggered when hover over submenu
		            $(this).toggleClass('hover');
		        });
		    }
		}

		return this.each(function () {
		    $(".toggleMenu").click(function (e) {
				e.preventDefault();
				$(this).toggleClass("active");
				$(this).next(".ul-nav-mobile").toggle();
				adjustMenu();
				//alert("sadasd");
			});
			adjustMenu();
			addParents();
			$(window).bind('resize orientationchange', function() {
				ww = document.body.clientWidth;
				adjustMenu();
			});
			
		});
	}
})(jQuery)

