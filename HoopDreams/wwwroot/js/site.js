// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', function () {
    var navbarToggler = document.querySelector('.navbar-toggler');
    var navbarClose = document.querySelector('.navbar-close');
    var navbarCollapse = document.querySelector('.navbar-collapse');

    if (navbarClose && navbarToggler && navbarCollapse) {
        navbarClose.addEventListener('click', function () {
            if (navbarCollapse.classList.contains('show')) {
                navbarToggler.click();
            }
        });
    }
});