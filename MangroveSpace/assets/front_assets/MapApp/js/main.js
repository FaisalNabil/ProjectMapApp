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
            


 


    });

    $(window).scroll(function() {
        if ($(this).scrollTop() > 250){  
            $('header').addClass("sticky");
        }
        else{
            $('header').removeClass("sticky");
        }
    });


}(jQuery));
