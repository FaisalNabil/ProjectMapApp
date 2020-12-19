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
            

            $(function(){
          $('.marquee').marquee({
         allowCss3Support: true,
         css3easing: 'linear',
         easing: 'linear',
          delayBeforeStart: 1000,
          direction: 'left',
          duplicated: false,
          duration: 30000,
          gap: 20,
          pauseOnCycle: false,
          startVisible: true,
            pauseOnHover: true

          });
        });
            
            
            /* 
            =================================================================
            07 - Responsive Menu JS
            =================================================================	
            */
            $("ul#briffs_navigation").slicknav({
                prependTo: ".briffs-responsive-menu"
            });
            
		$(".main-slider").owlCarousel({
			autoplay: true,
			loop: true,
			margin: 0,
			touchDrag: true,
			mouseDrag: true,
			items: 1,
			nav: true,
			dots: false,
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
					items: 1
				},
				1200: {
					items: 1
				}
			}
		});
            
            
 


    });



}(jQuery));
