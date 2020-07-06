// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(window).scroll(function () {
    /* affix after scrolling 95px */
    if ($(document).scrollTop() > 95) {
        //se elemento form-default existir => alinha o header do form para debaixo da navbar
        //adiciona a classe show-bar-always ao card-header do elemento
        if ($("#form-default").length) {
            this.console.log("Existe");
            $("#form-default .card-header").addClass('show-bar-always');
            $("#contect-default-header").addClass('container');
            $('.navbar').css("display", "none");
        }

        $('.navbar').addClass('affix');
        $('.navbar').addClass('box-shadow');
        $('.navbar').css("opacity", "0.95");  
    }
    else {
        $('.navbar').removeClass('affix');
        $('.navbar').removeClass('box-shadow');

        if ($("#form-default").length) {
            this.console.log("Existe");
            $("#form-default .card-header").removeClass('show-bar-always');
            $("#contect-default-header").removeClass('container');
            $('.navbar').css("display", "block");
        }
    }
});