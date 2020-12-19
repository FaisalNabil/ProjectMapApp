$(document).ready(function() {

    "use strict";

    //Nice Scroll

    $("html").niceScroll();


    $(".carousel").carousel({
        interval: 6000
    });

    // Show color option div when click the Gear

    $(".gear-check").click(function() {
        $(".color-option").fadeToggle();
    });


    //Change Theme Color On Click

    var colorLi = $(".color-option ul li");

    colorLi
        .eq(0).css("backgroundColor", "#E41B17").end()
        .eq(1).css("backgroundColor", "#E426D5").end()
        .eq(2).css("backgroundColor", "#009AFF").end()
        .eq(3).css("backgroundColor", "#FFD500");

    colorLi.click(function() {
        $("link[href*='theme']").attr("href", $(this).attr("data-value"));
    });

    //Caching The Scroll To Top Element

    var scrollButton = $("#scroll-top");

    $(window).scroll(function() {


        if ($(this).scrollTop() >= 700) {
            scrollButton.show();
        } else {
            scrollButton.hide();
        }

    });


    //Click on Button to scroll top

    scrollButton.click(function() {
        $("html, body").animate({ scrollTop: 0 }, 600);
    });
});

// Loading Screen

$(window).load(function() {

    //Show The Scroll

    $("body").css("overflow", "auto");

    // Loading Elements

    $(".loading-overlay .sk-folding-cube").fadeOut(2000, function() {
        $(this).parent().fadeOut(2000, function() {
            $(this).remove();
        });
    });
});