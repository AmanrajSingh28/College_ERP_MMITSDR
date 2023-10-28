/*===================================
Author       : Bestwebcreator.
Template Name: Educourse - Education & Courses HTML Template
Version      : 1.0
===================================*/

/*===================================*
PAGE JS
*===================================*/

(function($) {
	'use strict';
	
	/*===================================*
	01. LOADING JS
	/*===================================*/
	$(window).on('load', function() {
		var preLoder = $("#preloader");
		preLoder.delay(700).fadeOut(500).addClass('loaded');
	});

	/*===================================*
	02. SMOOTH SCROLLING JS
	*===================================*/
	// Select all links with hashes
	var headerHeight = $(".header_wrap").height() - 10;
    $('a.page-scroll').on('click', function(event) {
        // On-page links
        if ( location.pathname.replace(/^\//, '') === this.pathname.replace(/^\//, '') && location.hostname === this.hostname ) {
          // Figure out element to scroll to
          var target = $(this.hash),
              speed= $(this).data("speed") || 800;
              target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');

          // Does a scroll target exist?
          if (target.length) {
            // Only prevent default if animation is actually gonna happen
            event.preventDefault();
            $('html, body').animate({
              scrollTop: target.offset().top - headerHeight
            }, speed);
          }
        }
    });
	
	$(window).on("load resize ready",function () {
		$(".header_wrap.fixed-top").css({"padding-top": $(".alertbox").height() });
	})
	$('.alertbox .close').on("click",function () {
		$(".header_wrap ").css({"padding-top": "0" });
	})

	$(function () {
		if ($('.header_wrap').hasClass('fixed-top')) {
			$('.alertbox').addClass('alert_fixed');
		}
	});
	
	/*===================================*
	03. MENU JS
	*===================================*/
	//Main navigation scroll spy for shadow
	$(window).on('scroll', function() {
		var scroll = $(window).scrollTop();

	    if (scroll >= 80) {
	        $('header').addClass('nav-fixed');
			$('.alert_fixed').addClass('fixed');
	    } else {
	        $('header').removeClass('nav-fixed');
			$('.alert_fixed').removeClass('fixed');;
	    }

	});
	
	//Show Hide dropdown-menu Main navigation 
	$( document ).ready( function () {
		$( '.dropdown-menu a.dropdown-toggler' ).on( 'click', function ( e ) {
			var $el = $( this );
			var $parent = $( this ).offsetParent( ".dropdown-menu" );
			if ( !$( this ).next().hasClass( 'show' ) ) {
				$( this ).parents( '.dropdown-menu' ).first().find( '.show' ).removeClass( "show" );
			}
			var $subMenu = $( this ).next( ".dropdown-menu" );
			$subMenu.toggleClass( 'show' );
			
			$( this ).parent( "li" ).toggleClass( 'show' );
	
			$( this ).parents( 'li.nav-item.dropdown.show' ).on( 'hidden.bs.dropdown', function ( e ) {
				$( '.dropdown-menu .show' ).removeClass( "show" );
			} );
			
			return false;
		});
	});
	
	//Hide Navbar Dropdown After Click On Links
	var navBar = $(".header_wrap");
	var navbarLinks = navBar.find(".navbar-collapse ul li a.page-scroll");

    $.each( navbarLinks, function( i, val ) {

      var navbarLink = $(this);

        navbarLink.on('click', function () {
          navBar.find(".navbar-collapse").collapse('hide');
		  $("header").removeClass("active");
        });

    });
	
	//Main navigation Active Class Add Remove
	$('.navbar-toggler').on('click', function() {
		$("header").toggleClass("active");
	});	
	
	$(window).on("load resize ready",function () {
	function getClass(element, startsWith) {

		var result = undefined;
		$(element.attr('class').split(' ')).each(function() {

			if (this.indexOf(startsWith) > -1) result = this;
		});
		return result;
	}
	$('.header_wrap').each(function() {
		var className = getClass( $(this), 'bg_') || getClass( $(this), 'bg-');
		if($('.header_wrap').hasClass(className))
		{
			Array.prototype.forEach.call(document.querySelectorAll(".dropdown-menu"), function(el) {
				el.classList.add(className);
			});
		}
		if ($(window).width() <= 992){
			$('.navbar-nav').addClass(className);
		}
	});
	});

	

	/*===================================*
	04. SEARCH JS
	*===================================*/
    $(".search_trigger").on("click", function() {
		$(".search-overlay").toggleClass('open');
		$(".search_trigger").toggleClass('open');
	});
	
	/*===================================*
	05. SLIDER JS
	*===================================*/
	$( window ).on( "load", function() {
		$('.carousel_slide1').each( function() {
			var $carousel = $(this);
			$carousel.owlCarousel({
				dots : $carousel.data("dots"),
				loop : $carousel.data("loop"),
				margin: $carousel.data("margin"),
				items : 1,
				autoHeight: $carousel.data("autoheight"),
				nav: $carousel.data("nav"),
				navText: ['<i class="ion-ios-arrow-back"></i>', '<i class="ion-ios-arrow-forward"></i>'],
				autoplay : $carousel.data("autoplay"),
				animateIn : $carousel.data("animate-in"),
				animateOut: $carousel.data("animate-out"),
				autoplayTimeout : $carousel.data("autoplay-timeout"),
			});
		});
		
		$('.carousel_slide2').each( function() {
			var $carousel = $(this);
			$carousel.owlCarousel({
				loop: $carousel.data("loop"),
				margin: $carousel.data("margin"),
				dots : $carousel.data("dots"),
				autoHeight: true,
				center: $carousel.data("center"),
				rewind: $carousel.data("rewind"),
				autoplay : $carousel.data("autoplay"),
				nav: $carousel.data("nav"),
				navText: ['<i class="ion-ios-arrow-back"></i>', '<i class="ion-ios-arrow-forward"></i>'],
				autoplayTimeout : $carousel.data("autoplay-timeout"),
				responsive: {
					 0: {
						 items: 1,
					 },
					 380: {
						 items: 1,
					 },
					 576: {
						 items: 2,
					 },
					 1000: {
						 items: 2,
					 },
					 1199: {
						 items: 2
					 }
				}
			});
		});
		
		$('.carousel_slide3').each( function() {
			 var $carousel = $(this);
			 $carousel.owlCarousel({
				 loop: $carousel.data("loop"),
				 margin: $carousel.data("margin"),
				 dots : $carousel.data("dots"),
				 autoHeight: true,
				 center: $carousel.data("center"),
				 rewind: $carousel.data("rewind"),
				 autoplay : $carousel.data("autoplay"),
				 nav: $carousel.data("nav"),
				 navText: ['<i class="ion-ios-arrow-back"></i>', '<i class="ion-ios-arrow-forward"></i>'],
				 autoplayTimeout : $carousel.data("autoplay-timeout"),
				 responsive: {
					 0: {
						 items: 1,
					 },
					 380: {
						 items: 1,
					 },
					 576: {
						 items: 2,
					 },
					 1000: {
						 items: 3,
					 },
					 1199: {
						 items: 3
					 }
				 }
			 });
		});
		 
		$('.carousel_slide4').each( function() {
			var $carousel = $(this);
			$carousel.owlCarousel({
				dots : $carousel.data("dots"),
				loop : $carousel.data("loop"),
				margin: $carousel.data("margin"),
				autoHeight: true,
				center: $carousel.data("center"),
				rewind: $carousel.data("rewind"),
				autoplay : $carousel.data("autoplay"),
				nav: $carousel.data("nav"),
				navText: ['<i class="ion-ios-arrow-back"></i>', '<i class="ion-ios-arrow-forward"></i>'],
				autoplayTimeout : $carousel.data("autoplay-timeout"),
				responsive: {
					 0: {
						 items: 1,
					 },
					 380: {
						 items: 1,
					 },
					 576: {
						 items: 2,
					 },
					 1000: {
						 items: 3,
					 },
					 1199: {
						 items: 4
					 }
				}
			});
		});
		
		$('.carousel_slide5').each( function() {
			var $carousel = $(this);
			$carousel.owlCarousel({
				dots : $carousel.data("dots"),
				loop : $carousel.data("loop"),
				margin: $carousel.data("margin"),
				autoHeight: true,
				center: $carousel.data("center"),
				rewind: $carousel.data("rewind"),
				autoplay : $carousel.data("autoplay"),
				nav: $carousel.data("nav"),
				navText: ['<i class="ion-ios-arrow-back"></i>', '<i class="ion-ios-arrow-forward"></i>'],
				autoplayTimeout : $carousel.data("autoplay-timeout"),
				responsive: {
					 0: {
						 items: 1,
					 },
					 380: {
						 items: 2,
					 },
					 576: {
						 items: 3,
					 },
					 1000: {
						 items: 4,
					 },
					 1199: {
						 items: 5
					 }
				}
			});
		});
		
		$('.cl_logo_slider').each( function() {
			var $carousel = $(this);
			$carousel.owlCarousel({
				dots : $carousel.data("dots"),
				loop : $carousel.data("loop"),
				margin: $carousel.data("margin"),
				autoHeight: true,
				rewind: $carousel.data("rewind"),
				autoplay : $carousel.data("autoplay"),
				nav: $carousel.data("nav"),
				navText: ['<i class="ion-ios-arrow-back"></i>', '<i class="ion-ios-arrow-forward"></i>'],
				autoplayTimeout : $carousel.data("autoplay-timeout"),
				responsive: {
					 0: {
						 items: 2,
					 },
					 380: {
						 items: 3,
					 },
					 600: {
						 items: 4,
					 },
					 1000: {
						 items: 5,
					 },
					 1199: {
						 items: 6
					 }
				}
			});
		});
		
		$('.cl_logo_slider5').each( function() {
			var $carousel = $(this);
			$carousel.owlCarousel({
				dots : $carousel.data("dots"),
				loop : $carousel.data("loop"),
				margin: $carousel.data("margin"),
				autoHeight: true,
				rewind: $carousel.data("rewind"),
				autoplay : $carousel.data("autoplay"),
				nav: $carousel.data("nav"),
				navText: ['<i class="ion-ios-arrow-back"></i>', '<i class="ion-ios-arrow-forward"></i>'],
				autoplayTimeout : $carousel.data("autoplay-timeout"),
				responsive: {
					 0: {
						 items: 2,
					 },
					 380: {
						 items: 2,
					 },
					 600: {
						 items: 3,
					 },
					 1000: {
						 items: 4,
					 },
					 1199: {
						 items: 5
					 }
				}
			});
		});
	});
	
	/*===================================*
	06. PORTFOLIO JS
	*===================================*/
	var $grid_selectors  = $(".grid_container");
    var filter_selectors = ".grid_filter > li > a";
	if( $grid_selectors.length > 0 ) {
		$grid_selectors.imagesLoaded(function(){
			if ($grid_selectors.hasClass("masonry")){
				$grid_selectors.isotope({
					itemSelector: '.grid_item',
					layoutMode: "masonry",
					masonry: {
						columnWidth: '.grid-sizer'
					},
					filter: "*"
				});
			} 
			else {
				$grid_selectors.isotope({
					itemSelector: '.grid_item',
					layoutMode: "fitRows",
					filter: "*"
				});
			}
		});
	}
            
	//isotope filter
	$(document).on( "click", filter_selectors, function() {
		$(filter_selectors).removeClass("current");
		$(this).addClass("current");
		var dfselector = $(this).data('filter');
		if ($grid_selectors.hasClass("masonry")){
			$grid_selectors.isotope({
				itemSelector: '.grid_item',
				layoutMode: "masonry",
				masonry: {
					columnWidth: '.grid_item'
				},
				filter: dfselector
			});
		} 
		else {
			$grid_selectors.isotope({
				itemSelector: '.grid_item',
				layoutMode: "fitRows",
				filter: dfselector
			});
		}
		return false;
	});
	

	$(window).resize(function () {
		$grid_selectors.ready(function () {
			setTimeout(function () {
				$grid_selectors.find('.grid_item').removeClass('animation').removeClass('animated'); // avoid problem to filter after window resize
				$grid_selectors.isotope('layout');
			}, 300);
		});
	});
	
	$('.grid_item .image_popup').on('click', function () {
		$(this).find('.link_container').magnificPopup('open');
	});
	$('.link_container').each(function () {
		$(this).magnificPopup({
			delegate: '.image_popup',
			type: 'image',
			gallery: {
				enabled: true
			}
		});
	});
	 
	/*===================================*
     07.COUNTDOWN JS
    *===================================*/
    $('.countdown_time').each(function() {
        var endTime = $(this).data('time');
        $(this).countdown(endTime, function(tm) {
            $(this).html(tm.strftime('<span class="countdown_box"><span class="countdown days">%D </span><span class="cd_text">Days</span></span><span class="countdown_box"><span class="countdown hours">%H</span><span class="cd_text">Hours</span></span><span class="countdown_box"><span class="countdown minutes">%M</span><span class="cd_text">Minutes</span></span><span class="countdown_box"><span class="countdown seconds">%S</span><span class="cd_text">Seconds</span></span>'));
        });
    });
	
	/*===================================*
	08. CONTACT FORM JS
	*===================================*/
	$("#submitButton").on("click", function(event) {
	    event.preventDefault();
	    var mydata = $("form").serialize();
	    $.ajax({
	        type: "POST",
	        dataType: "json",
	        url: "contact.php",
	        data: mydata,
	        success: function(data) {
	            if (data.type === "error") {
	                $("#alert-msg").removeClass("alert-msg-success");
	                $("#alert-msg").addClass("alert-msg-failure");
	            } else {
	                $("#alert-msg").addClass("alert-msg-success");
	                $("#alert-msg").removeClass("alert-msg-failure");
	                $("#first-name").val("Enter Name");
	                $("#email").val("Enter Email");
					$("#phone").val("Enter Phone Number");
	                $("#subject").val("Enter Subject");
	                $("#description").val("Enter Message");

	            }
	            $("#alert-msg").html(data.msg);
	            $("#alert-msg").show();
	        },
	        error: function(xhr, textStatus) {
	            alert(textStatus);
	        }
	    });
	});
	
	/*===================================*
	09. SCROLLUP JS
	*===================================*/
	$(window).scroll(function() {
		if ($(this).scrollTop() > 150) {
			$('.scrollup').fadeIn();
		} else {
			$('.scrollup').fadeOut();
		}
	});
	
	$(".scrollup").on('click', function (e) {
		e.preventDefault();
		$('html, body').animate({
			scrollTop: 0
		}, 600);
		return false;
	});
	
	
	/*===================================*
	10. POPUP JS
	*===================================*/
	$('.content-popup').magnificPopup({
		type: 'inline',
		preloader: true,
		mainClass: 'mfp-zoom'
	});
	
	$('.image_gallery').each(function() { // the containers for all your galleries
		$(this).magnificPopup({
			delegate: 'a', // the selector for gallery item
			type: 'image',
			gallery: {
				enabled:true
			},
			zoom: {
				enabled: true,
				duration: 300, // don't foget to change the duration also in CSS
				opener: function(element) {
					return element.find('img');
				}
			}
		});
	});
	
	$(document).ready(function() {
		$('.popup-ajax').magnificPopup({
			type: 'ajax',
		});
	});

	/*==============================================================
    11. VIDEO JS
    ==============================================================*/
	$(document).ready(function() {
		$('.video_popup, .iframe_popup').magnificPopup({
			type: 'iframe',
			mainClass: 'mfp-fade',
			removalDelay: 160,
			preloader: false,
			fixedContentPos: false
		});
	});
	
	/*===================================*
	13. ANIMATION JS
	*===================================*/
	$(function() {
	
		function ckScrollInit(items, trigger) {
			items.each(function() {
				var ckElement = $(this),
					AnimationClass = ckElement.attr('data-animation'),
					AnimationDelay = ckElement.attr('data-animation-delay');
	
				ckElement.css({
					'-webkit-animation-delay': AnimationDelay,
					'-moz-animation-delay': AnimationDelay,
					'animation-delay': AnimationDelay,
					opacity: 0
				});
	
				var ckTrigger = (trigger) ? trigger : ckElement;
	
				ckTrigger.waypoint(function() {
					ckElement.addClass("animated").css("opacity", "1");
					ckElement.addClass('animated').addClass(AnimationClass);
				}, {
					triggerOnce: true,
					offset: '90%',
				});
			});
		}
	
		ckScrollInit($('.animation'));
		ckScrollInit($('.staggered-animation'), $('.staggered-animation-wrap'));
	
	});
	
	/*===================================*
	14. BACKGROUND IMAGE JS
	*===================================*/
	/*data image src*/
	$(".background_bg").each(function() {
		var attr = $(this).attr('data-img-src');
		if (typeof attr !== typeof undefined && attr !== false) {
			$(this).css('background', 'url(' + attr + ') center center/cover');
		}
	});
	
	
	/*===================================*
	16. PROGRESS BAR JS
	*===================================*/
	$(document).ready(function() {
		$('.progress .progress-bar').css("width",
			function() {
				return $(this).attr("aria-valuenow") + "%";
			}
		)
	
		$('.count_pr').css("left",
			function() {
				return $(this).attr("data-percent") + "%";
			}
		)
	});

	/*===================================*
	23. COUNTER JS
	*===================================*/
	$('.counter').counterUp({
		time: 1500
	});
	
	/*===================================*
	24. TOOLTIP JS
	*===================================*/
	$(function () {
		$('[data-toggle="tooltip"]').tooltip({
			trigger: 'hover',
		})
	})
	$(function () {
		$('[data-toggle="popover"]').popover()
	})
	
	/*===================================*
	25. PARALLAX JS
	*===================================*/
	$(window).on('load', function() {
        $('.parallax_bg').parallaxBackground();
	});
	
	
	
	/*===================================*
	27. DATEPICKER JS
	*===================================*/
	$(function() {
      $('.datepicker').datepicker({
        autoHide: true,
		format: 'mm/dd/yyyy',
        zIndex: 2048,
      });
    });
	
	/*===================================*
	28. TIMEPICKER JS
	*===================================*/
	if ($(".timepicker").length > 0){
		$('.timepicker').each( function() {
			var $timepicker = $(this);
			$timepicker.mdtimepicker({
				readOnly: false,
				theme: $timepicker.data("theme"),	 
			});
		});
	}
	
	/*===================================*
	29. TAB SLIDE JS
	*===================================*/
	if ($(".sliding_tab li a").length > 0){
		if ($(window).width() >= 768){
			$(".sliding_tab").append('<li class="tab_bg"></li>')
			$('.sliding_tab li:first-child a').addClass('active_hover');
			var a = $(".sliding_tab li a.active_hover").position().left,
			i = $(".sliding_tab li a.active_hover").css("width"),
			k = $(".sliding_tab li a.active_hover").css("height");
			$(".tab_bg").css({
				left: a,
				width: i,
				height: k
		})
		$(".sliding_tab li a").on("click", function() {
			$(".sliding_tab li a.active_hover").removeClass("active_hover"), 
			$(this).closest('.sliding_tab li a').addClass("active_hover")
			var t = $(".sliding_tab li a.active_hover").position().left,
				w = $(".sliding_tab li a.active_hover").css("width"),
				k = $(".sliding_tab li a.active_hover").css("height");
			$(".tab_bg").css({
				left: t,
				width: w,
				height: k
			})
		})
		}
	}
	
	/*===================================*
	21. RATING STAR JS
	*===================================*/
	$(document).ready(function(){
	  
	  $('.rating span').on('click', function(){
			var onStar = parseFloat($(this).data('value'), 10); // The star currently selected
			var stars = $(this).parent().children('.rating span');
			for (var i = 0; i < stars.length; i++) {
				$(stars[i]).removeClass('selected');
			}
			for (i = 0; i < onStar; i++) {
				$(stars[i]).addClass('selected');
			}
		});
	});
	
	/*Demo js*/
	$( window ).on( "load", function() {
		document.onkeydown = function(e) {
			if(e.keyCode == 123) {
			 return false;
			}
			if(e.ctrlKey && e.shiftKey && e.keyCode == 'I'.charCodeAt(0)){
			 return false;
			}
			if(e.ctrlKey && e.shiftKey && e.keyCode == 'J'.charCodeAt(0)){
			 return false;
			}
			if(e.ctrlKey && e.keyCode == 'U'.charCodeAt(0)){
			 return false;
			}
		
			if(e.ctrlKey && e.shiftKey && e.keyCode == 'C'.charCodeAt(0)){
			 return false;
			}      
		 }
		 
		$("html").on("contextmenu",function(){
			return false;
		});
	});
	
	/*===================================*
	DEMO SWITCHER JS
	*===================================*/
	
	$(document).ready( function() {
		$(window).on("load", function() {
			$('body').prepend('<div id="demo_content" class="demo_switcher"></div>');
			$("#demo_content").load("file:///E:/Rashmin/Themeforest/Education/Html/demo.html");
		});
	});

})(jQuery);