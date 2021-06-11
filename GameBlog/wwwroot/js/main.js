'use strict';

$(document).ready(function () {

    /*------------------
        Navigation
    --------------------*/
    $('.primary-menu').slicknav({
        appendTo: '.header-warp',
        closedSymbol: '<i class="fa fa-angle-down"></i>',
        openedSymbol: '<i class="fa fa-angle-up"></i>'
    });


    /*------------------
        Hero Slider
    --------------------*/
    $('.hero-slider').owlCarousel({
        loop: true,
        nav: true,
        dots: true,
        navText: ['', '<img src="/img/icons/solid-right-arrow.png" alt="right arrow icon">'],
        mouseDrag: false,
        animateOut: 'fadeOut',
        animateIn: 'fadeIn',
        items: 1,
        autoplay: true,
        autoplayTimeout: 3000,
    });

    let dot = $('.hero-slider .owl-dot');
    dot.each(function () {
        let index = $(this).index() + 1;
        if (index < 10) {
            $(this).html('0').append(index + '.');
        } else {
            $(this).html(index + '.');
        }
    });


})
