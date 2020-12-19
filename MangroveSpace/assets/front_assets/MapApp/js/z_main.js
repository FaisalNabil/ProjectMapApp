/************* Main Js File ************************
    Template Name: 
    Author: 
    Version: 1.0
    Copyright 2018
*************************************************************/


/*------------------------------------------------------------------------------------
    
JS INDEX
=============

01 - Banner-Slider Setup

-------------------------------------------------------------------------------------*/


(function ($) {
    "use strict";

    jQuery(document).ready(function ($) {



        /* 
		=================================================================
		01 - Main Slider JS
		=================================================================	
		*/

        $(".briffs-slide").owlCarousel({
            animateOut: 'fadeOutLeft',
            animateIn: 'fadeIn',
            items: 2,
            nav: true,
            dots: false,
            autoplayTimeout: 7000,
            autoplaySpeed: 2000,
            autoplay: true,
            loop: true,
            navText: ["<i class='fa fa-long-arrow-left'><i>", "<i class='fa fa-long-arrow-right'><i>"],
            mouseDrag: true,
            touchDrag: true,
            responsive: {
                0: {
                    items: 1
                },
                480: {
                    items: 1
                },
                600: {
                    items: 1
                },
                750: {
                    items: 1
                },
                1000: {
                    items: 1
                },
                1200: {
                    items: 1
                }
            }
        });

        $(".briffs-slide").on("translate.owl.carousel", function () {
            $(".briffs-main-slide h2").removeClass("animated fadeInUp").css("opacity", "0");
            $(".briffs-main-slide h4").removeClass("animated fadeInUp").css("opacity", "0");
            $(".briffs-main-slide a").removeClass("animated fadeInDown").css("opacity", "0");
        });
        $(".briffs-slide").on("translated.owl.carousel", function () {
            $(".briffs-main-slide h2, .briffs-main-slide h4").addClass("animated fadeInUp").css("opacity", "1");
            $(".briffs-main-slide a").addClass("animated fadeInDown").css("opacity", "1");
        });


        /* 
		=================================================================
		05 - Testimonial Slider JS
		=================================================================	
		*/

        $(".testimonial-slide").owlCarousel({
            autoplay: true,
            loop: true,
            margin: 20,
            touchDrag: true,
            mouseDrag: true,
            items: 1,
            nav: false,
            dots: true,
            autoplayTimeout: 6000,
            autoplaySpeed: 1200,
            navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
            responsive: {
                0: {
                    items: 1
                },
                480: {
                    items: 1
                },
                600: {
                    items: 1
                },
                1000: {
                    items: 2
                },
                1200: {
                    items: 2
                }
            }
        });



        $(".verticalCarousel").verticalCarousel({

            // current item to display on start
            currentItem: 1,

            // number of items to display at a time
            showItems: 4,

        });


        //var isNS = (navigator.appName == "Netscape") ? 1 : 0;

        //if (navigator.appName == "Netscape") document.captureEvents(Event.MOUSEDOWN || Event.MOUSEUP);

        //function mischandler() {
        //    return false;
        //}

        //function mousehandler(e) {
        //    var myevent = (isNS) ? e : event;
        //    var eventbutton = (isNS) ? myevent.which : myevent.button;
        //    if ((eventbutton == 2) || (eventbutton == 3)) return false;
        //}
        //document.oncontextmenu = mischandler;
        //document.onmousedown = mousehandler;
        //document.onmouseup = mousehandler;

        //function disableselect(e) {
        //    return false
        //}

        //function reEnable() {
        //    return true
        //}
        ////if IE4+
        //document.onselectstart = new Function("return false")
        ////if NS6
        //if (window.sidebar) {
        //    document.onmousedown = disableselect
        //    document.onclick = reEnable
        //}
        //document.onkeydown = function (e) {
        //    if (e.ctrlKey &&
        //        (e.keyCode === 85)) {
        //        return false;
        //    }
        //};

        /* 
		=================================================================
		06 - Counter JS
		=================================================================	
		*/



        /* 
		=================================================================
		06 - Counter JS
		=================================================================	
		*/


        $('.counter').counterUp({
            delay: 10,
            time: 1000
        });


        /* 
		=================================================================
		03 - Team Slider JS
		=================================================================	
		*/







        $('.popup-youtube').magnificPopup({
            disableOn: 700,
            type: 'iframe',
            mainClass: 'mfp-fade',
            removalDelay: 160,
            preloader: false,
            fixedContentPos: false
        });




        /* 
		=================================================================
		03 - Team Slider JS
		=================================================================	
		*/


        $(".team-slider").owlCarousel({
            autoplay: true,
            loop: true,
            margin: 20,
            touchDrag: true,
            mouseDrag: true,
            items: 1,
            nav: false,
            dots: true,
            autoplayTimeout: 6000,
            autoplaySpeed: 1200,
            navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
            responsive: {
                0: {
                    items: 1
                },
                480: {
                    items: 1
                },
                600: {
                    items: 2
                },
                1000: {
                    items: 4
                },
                1200: {
                    items: 4
                }
            }
        });








    });

    $(window).on('scroll', function () {
        var scroll = $(window).scrollTop();
        if (scroll >= 50) {
            $(".forsticky").addClass("sticky");
        } else {
            $(".forsticky").removeClass("sticky");
            $(".forsticky").addClass("");
        }
    });


}(jQuery));
