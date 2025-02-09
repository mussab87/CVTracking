(function ($) {
    "use strict";

    $('.odometer').counterUp({
        delay: 10,
        time: 1000
    });

    // mobile-drop-down
    jQuery('.dropdown-icon').on('click', function () {
        // alert()
        // $(this).next('.mob-submenu').slideToggle();
        jQuery(this).toggleClass('active').next('ul').slideToggle();
        jQuery(this).parent().siblings().children('ul').slideUp();
        jQuery(this).parent().siblings().children('.active').removeClass('active');
    });

    // sticky header

    window.addEventListener('scroll', function () {
        const header = document.querySelector('header.style-1, header.style-2, header.style-3, header.style-4, header.style-5, header.style-6, header.style-7');
        header.classList.toggle("sticky", window.scrollY > 0);
    });

    // Sidebar Sticky




    $('.sidebar-button').on("click", function () {
        $('.main-menu').addClass('show-menu');
    });

    $('.menu-close-btn').on("click", function () {
        $('.main-menu').removeClass('show-menu');
    });
    // mobile-search-area

    $('.search-btn').on("click", function () {
        $('.mobile-search').addClass('slide');
    });

    $('.search-cross-btn').on("click", function () {
        $('.mobile-search').removeClass('slide');
    });




    /* ---------------------------------------------
         NiceSelect
    --------------------------------------------- */

    $('.select1').niceSelect();
    /*$('.select4').niceSelect();*/



    // password-hide and show

    const togglePassword = document.querySelector('#togglePassword');

    const password = document.querySelector('#Password');

    if (togglePassword) {
        togglePassword.addEventListener('click', function (e) {
            // toggle the type attribute
            const type = password.getAttribute('type') === 'password' ? 'text' : 'password';
            password.setAttribute('type', type);
            // toggle the eye / eye slash icon
            this.classList.toggle('bi-eye');
        });
    }
    // company password-hide and show

    const togglePassword3 = document.querySelector('#togglePassword3');

    const password3 = document.querySelector('#Password');

    if (togglePassword3) {
        togglePassword3.addEventListener('click', function (e) {
            // toggle the type attribute
            const type = password3.getAttribute('type') === 'password' ? 'text' : 'password';
            password3.setAttribute('type', type);
            // toggle the eye / eye slash icon
            this.classList.toggle('bi-eye');
        });
    }



    // confirm-password
    const togglePassword2 = document.getElementById('togglePassword2');

    const password2 = document.querySelector('#password2');

    if (togglePassword2) {
        togglePassword2.addEventListener('click', function (e) {
            // toggle the type attribute
            const type = password2.getAttribute('type') === 'password' ? 'text' : 'password';
            password2.setAttribute('type', type);
            // toggle the eye / eye slash icon
            this.classList.toggle('bi-eye');
        });
    }
    //company confirm-password
    const togglePassword4 = document.getElementById('togglePassword4');

    const password4 = document.querySelector('#ConfirmPassword');

    if (togglePassword4) {
        togglePassword4.addEventListener('click', function (e) {
            // toggle the type attribute
            const type = password4.getAttribute('type') === 'password' ? 'text' : 'password';
            password4.setAttribute('type', type);
            // toggle the eye / eye slash icon
            this.classList.toggle('bi-eye');
        });
    }


    // select2
    //
    //if ($("#skills").val() != undefined) {
    //    var skills = JSON.parse($("#candidateSkills").val());
    //    $("#states[]").val(skills);
    //}


    $(".select2").select2({
        //placeholder: "Select Skils",
        width: '100%'
        //allowClear: true
    });
    $('.js-example-basic-single').select2({
        width: '100%',
        tags: true,
    });
    $('.js-example-basic-multiple').select2({
        width: '100%',
        multiple: true,
        tags: true,
    });


    // fancybox
    // $("a.portfolio-img").fancybox();

    $('[data-fancybox="gallery"]').fancybox({
        buttons: [
            "slideShow",
            "thumbs",
            "zoom",
            "fullScreen",
            "share",
            "close"
        ],
        loop: false,
        protect: true
    });


    // Odometer Counter


    jQuery('#cv_DateOfBirth').datepicker({
        changeMonth: true,
        changeYear: true,
        format: 'dd/mm/yyyy',
        startDate: '+1d',
        yearRange: "-90:+00"
    });
    jQuery('#cv_PassportDateOfIssue').datepicker({
        changeMonth: true,
        changeYear: true,
        format: 'dd/mm/yyyy',
        startDate: '+1d',
        yearRange: "-90:+00"
    });
    jQuery('#cv_PassportDateOfExpiry').datepicker({
        changeMonth: true,
        changeYear: true,
        format: 'dd/mm/yyyy',
        startDate: '+1d',
        yearRange: "-90:+00"
    });
    jQuery('#sponsorDateOfBirth').datepicker({
        changeMonth: true,
        changeYear: true,
        format: 'dd/mm/yyyy',
        startDate: '+1d',
        yearRange: "-90:+00"
    });
    jQuery('#datepicker5').datepicker({
        changeMonth: true,
        changeYear: true,
        format: 'dd/mm/yyyy',
        startDate: '+1d',
        yearRange: "-90:+00"
    });
    jQuery('#datepicker6').datepicker({
        changeMonth: true,
        changeYear: true,
        format: 'dd/mm/yyyy',
        startDate: '+1d',
        yearRange: "-90:+00"
    });
    jQuery('#datepicker7').datepicker({
        changeMonth: true,
        changeYear: true,
        format: 'dd/mm/yyyy',
        startDate: '+1d',
        yearRange: "-90:+00"
    });
    jQuery('#datepicker9').datepicker({
        changeMonth: true,
        changeYear: true,
        format: 'dd/mm/yyyy',
        startDate: '+1d',
        yearRange: "-90:+00"
    });
    jQuery('#datepicker10').datepicker({
        changeMonth: true,
        changeYear: true,
        format: 'dd/mm/yyyy',
        startDate: '+1d',
        yearRange: "-90:+00"
    });
    jQuery('#datepicker11').datepicker({
        changeMonth: true,
        changeYear: true,
        format: 'dd/mm/yyyy',
        startDate: '+1d',
        yearRange: "-90:+00"
    });





    // Home One Location
    var swiper = new Swiper(".location-slider", {
        slidesPerView: 4,
        spaceBetween: 24,
        // centeredSlides: true,
        loop: true,
        speed: 1500,
        autoplay: {
            delay: 2000,
        },
        navigation: {
            nextEl: ".next-1",
            prevEl: ".prev-1",
        },
        breakpoints: {
            280: {
                slidesPerView: 1,
                spaceBetween: 15
            },
            480: {
                slidesPerView: 2
            },
            768: {
                slidesPerView: 2
            },
            992: {
                slidesPerView: 3
            },
            1200: {
                slidesPerView: 4
            },
            1400: {
                slidesPerView: 4
            },
            1600: {
                slidesPerView: 4
            },
        }
    });
    // Home One Testimonial
    var swiper = new Swiper(".testimonial-slider1", {
        slidesPerView: 4,
        spaceBetween: 40,
        loop: true,
        speed: 1500,
        autoplay: {
            delay: 2000,
        },
        navigation: {
            nextEl: ".next-2",
            prevEl: ".prev-2",
        },
        breakpoints: {
            280: {
                slidesPerView: 1,
                spaceBetween: 15
            },
            480: {
                slidesPerView: 1
            },
            768: {
                slidesPerView: 1
            },
            992: {
                slidesPerView: 1
            },
            1200: {
                slidesPerView: 2
            },
            1400: {
                slidesPerView: 2
            },
            1600: {
                slidesPerView: 2
            },
        }
    });

    // Home One Location
    var swiper = new Swiper(".trusted-company-slider", {
        slidesPerView: 4,
        spaceBetween: 24,
        loop: true,
        speed: 1500,
        autoplay: {
            delay: 2000,
        },
        breakpoints: {
            280: {
                slidesPerView: 2,
                spaceBetween: 15
            },
            480: {
                slidesPerView: 3
            },
            768: {
                slidesPerView: 4
            },
            992: {
                slidesPerView: 5
            },
            1200: {
                slidesPerView: 6
            },
            1400: {
                slidesPerView: 6
            },
            1600: {
                slidesPerView: 6
            },
        }
    });
    // Home One Location
    var swiper = new Swiper(".recruters-slider", {
        slidesPerView: 4,
        spaceBetween: 20,
        loop: true,
        speed: 1500,
        autoplay: {
            delay: 2000,
        },
        navigation: {
            nextEl: ".next-3",
            prevEl: ".prev-3",
        },
        breakpoints: {
            280: {
                slidesPerView: 1,
                spaceBetween: 30
            },
            480: {
                slidesPerView: 1
            },
            768: {
                slidesPerView: 2
            },
            992: {
                slidesPerView: 3
            },
            1200: {
                slidesPerView: 3
            },
            1400: {
                slidesPerView: 4
            },
            1600: {
                slidesPerView: 4
            },
        }
    });
    // Home Feature slider 2
    var swiper = new Swiper(".feature-slider2", {
        slidesPerView: 2,
        spaceBetween: 20,
        loop: true,
        speed: 1500,
        autoplay: {
            delay: 2000,
        },
        navigation: {
            nextEl: ".next-3",
            prevEl: ".prev-3",
        },
        breakpoints: {
            280: {
                slidesPerView: 1,
                spaceBetween: 30
            },
            480: {
                slidesPerView: 1
            },
            768: {
                slidesPerView: 1.2
            },
            992: {
                slidesPerView: 1.5
            },
            1200: {
                slidesPerView: 2
            },
            1400: {
                slidesPerView: 2.5
            },
            1600: {
                slidesPerView: 2.5
            },
        }
    });

    // Company Gallery Slider
    var swiper = new Swiper(".company-gallery-slider", {
        slidesPerView: 5,
        spaceBetween: 30,
        loop: true,
        speed: 1500,
        autoplay: {
            delay: 2000,
        },
        navigation: {
            nextEl: ".next-3",
            prevEl: ".prev-3",
        },
        breakpoints: {
            280: {
                slidesPerView: 1,
            },
            480: {
                slidesPerView: 2
            },
            768: {
                slidesPerView: 3
            },
            992: {
                slidesPerView: 4
            },
            1200: {
                slidesPerView: 5
            },
            1400: {
                slidesPerView: 5
            },
            1600: {
                slidesPerView: 5
            },
        }
    });

    // Related Job Slider
    var swiper = new Swiper(".related-job-slider", {
        slidesPerView: 3,
        spaceBetween: 30,
        loop: true,
        speed: 1500,
        autoplay: {
            delay: 2000,
        },
        navigation: {
            nextEl: ".next-4",
            prevEl: ".prev-4",
        },
        breakpoints: {
            280: {
                slidesPerView: 1,
            },
            480: {
                slidesPerView: 1
            },
            768: {
                slidesPerView: 2
            },
            992: {
                slidesPerView: 2
            },
            1200: {
                slidesPerView: 3
            },
            1400: {
                slidesPerView: 3
            },
            1600: {
                slidesPerView: 3
            },
        }
    });

    // Category Three Slider
    var swiper = new Swiper(".category3-slider", {
        slidesPerView: 4,
        spaceBetween: 20,
        loop: true,
        speed: 1700,
        autoplay: {
            delay: 2200,
        },
        navigation: {
            nextEl: ".next-5",
            prevEl: ".prev-5",
        },
        breakpoints: {
            280: {
                slidesPerView: 1,
            },
            480: {
                slidesPerView: 2
            },
            768: {
                slidesPerView: 3
            },
            992: {
                slidesPerView: 3
            },
            1200: {
                slidesPerView: 4
            },
            1400: {
                slidesPerView: 4
            },
            1600: {
                slidesPerView: 4
            },
        }
    });
    // Home Four Feedback Slider

    var swiper = new Swiper(".home4-feedback-slider2", {
        slidesPerView: 3,
        spaceBetween: 20,
        centeredSlides: true,
        loop: true,
        navigation: {
            nextEl: ".next-10",
            prevEl: ".prev-10",
        },

    });
    var swiper = new Swiper(".home4-feedback-slider", {
        slidesPerView: 4,
        spaceBetween: 20,
        centeredSlides: true,
        loop: true,
        navigation: {
            nextEl: ".next-10",
            prevEl: ".prev-10",
        },

        breakpoints: {
            280: {
                slidesPerView: 1,
                centeredSlides: false
            },
            480: {
                slidesPerView: 1,
                centeredSlides: false
            },
            768: {
                slidesPerView: 1,
                centeredSlides: false
            },
            992: {
                slidesPerView: 3
            },
            1200: {
                slidesPerView: 3
            },
            1400: {
                slidesPerView: 3
            },
            1600: {
                slidesPerView: 3
            },
        },
        thumbs: {
            swiper: swiper,
        },
    });
    // Home2 Recruiters

    $('#slick1').slick({
        rows: 2,
        dots: false,
        arrows: true,
        infinite: true,
        autoplay: true,
        autoplaySpeed: 2000,
        speed: 2000,
        slidesToShow: 3,
        slidesToScroll: 1,
        responsive: [{
            breakpoint: 1200,
            settings: {
                arrows: false,
                slidesToShow: 2
            }
        }, {
            breakpoint: 991,
            settings: {
                arrows: false,
                slidesToShow: 2
            }
        }, {
            breakpoint: 768,
            settings: {
                arrows: false,
                slidesToShow: 1
            }
        }, {
            breakpoint: 576,
            settings: {
                arrows: false,
                slidesToShow: 1
            }
        }, {
            breakpoint: 480,
            settings: {
                arrows: false,
                slidesToShow: 1
            }
        }, {
            breakpoint: 350,
            settings: {
                arrows: false,
                slidesToShow: 1
            }
        }]
    });
    // Home3 User Feedback
    var swiper = new Swiper(".user-feedback-slider3", {
        spaceBetween: 20,
        loop: true,
        slidesPerView: 1,
        speed: 2000,
        effect: 'fade',
        autoplay: {
            delay: 1500,
        },
        navigation: {
            nextEl: ".next-6",
            prevEl: ".prev-6",
        },
        pagination: {
            el: ".swiper-pagination-g",
            type: "fraction",
        },
    });
    // Home2 User Feedback
    var swiper = new Swiper(".home2-feedback-slider", {
        spaceBetween: 20,
        loop: true,
        slidesPerView: 1,
        speed: 2000,
        // effect: 'fade',
        autoplay: {
            delay: 1500,
        },
        navigation: {
            nextEl: ".next-6",
            prevEl: ".prev-6",
        },
    });

    // Home6 Category
    $('#slick2').slick({
        rows: 2,
        dots: false,
        arrows: true,
        infinite: true,
        autoplay: true,
        autoplaySpeed: 1500,
        speed: 2000,
        slidesToShow: 6,
        slidesToScroll: 1,
        responsive: [{
            breakpoint: 1500,
            settings: {
                slidesToShow: 5
            }
        },
        {
            breakpoint: 1400,
            settings: {
                slidesToShow: 4
            }
        }, {
            breakpoint: 1100,
            settings: {
                // arrows: false,
                slidesToShow: 3
            }
        }, {
            breakpoint: 768,
            settings: {
                arrows: false,
                slidesToShow: 2
            }
        }, {
            breakpoint: 576,
            settings: {
                arrows: false,
                slidesToShow: 1
            }
        }, {
            breakpoint: 480,
            settings: {
                arrows: false,
                slidesToShow: 1
            }
        }, {
            breakpoint: 350,
            settings: {
                arrows: false,
                slidesToShow: 1
            }
        }]
    });
    // Home6 Feedback Slider

    var swiper = new Swiper(".home6-feedback-slider", {
        slidesPerView: 3,
        spaceBetween: 20,
        loop: true,
        speed: 1700,
        autoplay: {
            delay: 2200,
        },
        navigation: {
            nextEl: ".next-12",
            prevEl: ".prev-12",
        },
        breakpoints: {
            280: {
                slidesPerView: 1,
            },
            480: {
                slidesPerView: 1
            },
            768: {
                slidesPerView: 2
            },
            992: {
                slidesPerView: 2
            },
            1200: {
                slidesPerView: 3
            },
            1400: {
                slidesPerView: 3
            },
            1600: {
                slidesPerView: 3
            },
        }
    });

    // Home6 Top Recruiters
    $('#slick3').slick({
        rows: 2,
        dots: false,
        arrows: true,
        infinite: true,
        autoplay: true,
        autoplaySpeed: 1500,
        speed: 2000,
        slidesToShow: 4,
        slidesToScroll: 1,
        responsive: [{
            breakpoint: 1750,
            settings: {
                slidesToShow: 3
            }
        },
        {
            breakpoint: 1400,
            settings: {
                slidesToShow: 3
            }
        }, {
            breakpoint: 1100,
            settings: {
                // arrows: false,
                slidesToShow: 2
            }
        }, {
            breakpoint: 768,
            settings: {
                arrows: false,
                slidesToShow: 1
            }
        }, {
            breakpoint: 576,
            settings: {
                arrows: false,
                slidesToShow: 1
            }
        }, {
            breakpoint: 480,
            settings: {
                arrows: false,
                slidesToShow: 1
            }
        }, {
            breakpoint: 350,
            settings: {
                arrows: false,
                slidesToShow: 1
            }
        }]
    });

    // Home5 Recruiters

    $('#slick4').slick({
        rows: 2,
        dots: false,
        arrows: true,
        infinite: true,
        autoplay: true,
        autoplaySpeed: 2000,
        speed: 2000,
        slidesToShow: 4,
        slidesToScroll: 1,
        responsive: [{
            breakpoint: 1400,
            settings: {
                arrows: false,
                slidesToShow: 3
            }
        }, {
            breakpoint: 1200,
            settings: {
                arrows: false,
                slidesToShow: 3
            }
        },
        {
            breakpoint: 991,
            settings: {
                arrows: false,
                slidesToShow: 2
            }
        }, {
            breakpoint: 768,
            settings: {
                arrows: false,
                slidesToShow: 1
            }
        }, {
            breakpoint: 576,
            settings: {
                arrows: false,
                slidesToShow: 1
            }
        }, {
            breakpoint: 480,
            settings: {
                arrows: false,
                slidesToShow: 1
            }
        }, {
            breakpoint: 350,
            settings: {
                arrows: false,
                slidesToShow: 1
            }
        }]
    });

    // Home5 Trusted Company

    $('#slick5').slick({
        rows: 2,
        dots: false,
        arrows: true,
        infinite: true,
        autoplay: true,
        autoplaySpeed: 2000,
        speed: 2000,
        slidesToShow: 5,
        slidesToScroll: 1,
        responsive: [{
            breakpoint: 1400,
            settings: {
                arrows: false,
                slidesToShow: 5
            }
        }, {
            breakpoint: 1200,
            settings: {
                arrows: false,
                slidesToShow: 4
            }
        },
        {
            breakpoint: 991,
            settings: {
                arrows: false,
                slidesToShow: 3
            }
        }, {
            breakpoint: 768,
            settings: {
                arrows: false,
                slidesToShow: 2
            }
        }, {
            breakpoint: 576,
            settings: {
                arrows: false,
                slidesToShow: 2
            }
        }, {
            breakpoint: 480,
            settings: {
                arrows: false,
                slidesToShow: 1
            }
        }, {
            breakpoint: 350,
            settings: {
                arrows: false,
                slidesToShow: 1
            }
        }]
    });

    // Home5 Feedback Slider

    var swiper = new Swiper(".home5-feedback-slider", {
        slidesPerView: 2,
        spaceBetween: 20,
        loop: true,
        speed: 1700,
        autoplay: {
            delay: 2200,
        },
        navigation: {
            nextEl: ".next-13",
            prevEl: ".prev-13",
        },
        breakpoints: {
            280: {
                slidesPerView: 1,
            },
            480: {
                slidesPerView: 1
            },
            768: {
                slidesPerView: 1
            },
            992: {
                slidesPerView: 1
            },
            1200: {
                slidesPerView: 2
            },
            1400: {
                slidesPerView: 2
            },
            1600: {
                slidesPerView: 2
            },
        }
    });





    $('body').on('click', '.add-education-row', function () {
        var newRow = '';
        newRow += '<div class="row addEducation">';
        newRow += '<div class="col-lg-12">';
        newRow += '<div class="info-title">';
        newRow += '<h6>Academic Information:</h6>';
        newRow += '<div class="dash"></div>';
        newRow += '</div>';
        newRow += '</div>';
        newRow += '<div class="col-md-6">';
        newRow += '<div class="form-inner mb-25">';
        newRow += '<label for="educationalLavel">Education Level*</label>';
        newRow += '<div class="input-area">';
        newRow += '<img src="assets/images/icon/qualification-2.svg" alt="">';
        newRow += '<select class="select1">';
        newRow += '<option value="0">Bachelor Degree in CSE</option>';
        newRow += '<option value="1">IGCSE</option>';
        newRow += '<option value="2">AS</option>';
        newRow += '</select>';
        newRow += '</div>';
        newRow += '</div>';
        newRow += '</div>';
        newRow += '<div class="col-md-6">';
        newRow += '<div class="form-inner mb-25">';
        newRow += '<label for="major">My Major*</label>';
        newRow += '<div class="input-area">';
        newRow += '<img src="assets/images/icon/major.svg" alt="">';
        newRow += '<select class="select1">';
        newRow += '<option value="0">Science</option>';
        newRow += '<option value="1">Arts</option>';
        newRow += '<option value="2">Commerce</option>';
        newRow += '</select>';
        newRow += '</div>';
        newRow += '</div>';
        newRow += '</div>';
        newRow += '<div class="col-md-6">';
        newRow += '<div class="form-inner mb-25">';
        newRow += '<label for="institute">Institute/University*</label>';
        newRow += '<div class="input-area">';
        newRow += '<img src="assets/images/icon/univercity.svg" alt="">';
        newRow += '<input type="text" id="institute" name="institute" placeholder="Type Your Institute Name...">';
        newRow += '</div>';
        newRow += '</div>';
        newRow += '</div>';
        newRow += '<div class="col-md-6">';
        newRow += '<div class="form-inner mb-30">';
        newRow += '<label for="gpa">Result/GPA**</label>';
        newRow += '<div class="input-area">';
        newRow += '<img src="assets/images/icon/gpa-2.svg" alt="">';
        newRow += '<input type="text" id="gpa" name="gpa" placeholder="4.75/5">';
        newRow += '</div>';
        newRow += '</div>';
        newRow += '</div>';
        newRow += '<div class="col-md-6">';
        newRow += '<div class="form-inner mb-25">';
        newRow += '<label for="datepicker10">Starting Period*</label>';
        newRow += '<div class="input-area">';
        newRow += '<img src="assets/images/icon/calender2.svg" alt="">';
        newRow += '<input type="text" id="datepicker10" name="stp" placeholder="DD/MM/YY">';
        newRow += '</div>';
        newRow += '</div>';
        newRow += '</div>';
        newRow += '<div class="col-md-6">';
        newRow += '<div class="form-inner mb-30">';
        newRow += '<label for="datepicker11">Ending Period*</label>';
        newRow += '<div class="input-area">';
        newRow += '<img src="assets/images/icon/calender2.svg" alt="">';
        newRow += '<input type="text" id="datepicker11" name="ep" placeholder="DD/MM/YY">';
        newRow += '</div>';
        newRow += '</div>';
        newRow += '</div>';
        newRow += '<div class="add-row">';
        newRow += '<button type="button" class="remove-education-row remove">Remove Education Area</button>'
        newRow += "</div>";
        newRow += '</div>';
        $('.education-row').append(newRow);
        $('.select1').niceSelect();

    });
    // Workingarea Row
    var count = 0;
    var existCount = $("#countExpList").val();
    if (existCount != undefined) {
        count = parseInt(existCount) - 1;
    }
    $('body').on('click', '.add-experiences-row', function () {
        count = count + 1;

        var newRow = '';
        newRow += '<div class="row addexperiences">';
        newRow += '<div class="col-lg-12">';
        newRow += '<div class="info-title">';
        newRow += '<h6>Add Candidate Previous Employment:</h6>';
        newRow += '<div class="dash"></div>';
        newRow += '</div>';
        newRow += '</div>';
        newRow += '<div class="col-md-6">';
        newRow += '<div class="form-inner mb-25">';
        newRow += '<label>Period</label>';
        newRow += '<div class="input-area">';
        newRow += '<img src="../../assets/images/icon/hight.svg" alt="">';
        newRow += '<input id="previousEmployment_' + count.toString() + '__Period" name="previousEmployment[' + count.toString() + '].Period" placeholder="Period">';
        newRow += '</div>';
        newRow += '</div>';
        newRow += '</div>';
        newRow += '<div class="col-md-6">';
        newRow += '<div class="form-inner mb-25">';
        newRow += '<label>Country Of Employment</label>';
        newRow += '<div class="input-area">';
        newRow += '<img src="../../assets/images/icon/nid.svg" alt="">';
        newRow += '<select class="select4" id="previousEmployment_' + count.toString() + '__.CountryOfEmploymentId" name="previousEmployment[' + count.toString() + '].CountryOfEmploymentId">';
        newRow += '<option value="0">Select Country of Employment</option>';
        newRow += '</select>';
        newRow += '</div>';
        newRow += '</div>';
        newRow += '</div>';
        newRow += '<div class="col-md-6">';
        newRow += '<div class="form-inner mb-25">';
        newRow += '<label>Position</label>';
        newRow += '<div class="input-area">';
        newRow += '<img src="../../assets/images/icon/designation-2.svg" alt="">';
        newRow += '<select class="select5" id="previousEmployment_' + count.toString() + '__.PositionId" name="previousEmployment[' + count.toString() + '].PositionId">';
        newRow += '<option value="0">Select Position</option>';
        newRow += '</select>';
        newRow += '</div>';
        newRow += '</div>';
        newRow += '</div>';
        newRow += '<div class="add-row">';
        newRow += '<button type="button" class="remove-experiences-row remove">Remove Experiences Area</button>'
        newRow += "</div>";
        newRow += '</div>';
        newRow += '</div>';
        $('.experiences-row').append(newRow);


        debugger;
        var country = JSON.parse($("#countrylist").val());
        var position = JSON.parse($("#positionlist").val());

        var element = 'previousEmployment_' + count.toString() + '__.CountryOfEmploymentId';

        var select = document.getElementById(element);

        $.each(country, function (index, i) {
            const option = new Option(i.country, i.Id);
            select.add(option, undefined);
        });

        var elementPosition = 'previousEmployment_' + count.toString() + '__.PositionId';

        var selectPosion = document.getElementById(elementPosition);

        $.each(position, function (index, i) {
            const option = new Option(i.DesignationEnglish, i.Id);
            selectPosion.add(option, undefined);
        });

        $('.select4').niceSelect();
        $('.select5').niceSelect();
    });

    // Experiences Row
    $('body').on('click', '.addwork-area-row', function () {
        var newRow = '';
        newRow += '<div class="row addworkarea">';
        newRow += '<div class="col-md-6">';
        newRow += '<div class="form-inner mb-25">';
        newRow += '<label for="working-field">Working Field*</label>';
        newRow += '<div class="input-area">';
        newRow += '<img src="assets/images/icon/company-2.svg" alt="">';
        newRow += '<input type="text" id="working-field" name="working-field" placeholder="Frontend Developer">';
        newRow += '</div>';
        newRow += '</div>';
        newRow += '</div>';
        newRow += '<div class="col-md-6">';
        newRow += '<div class="form-inner mb-25">';
        newRow += '<label for="icon">Add Icon*</label>';
        newRow += '<div class="input-area">';
        newRow += '<img src="assets/images/icon/company-2.svg" alt="">';
        newRow += '<input type="file">';
        newRow += '</div>';
        newRow += '</div>';
        newRow += '</div>';
        newRow += '<div class="col-md-12">';
        newRow += '<div class="form-inner mb-40">';
        newRow += '<label for="description">Short Description*</label>';
        newRow += '<textarea name="description" id="description" placeholder="Company Details*"></textarea>';
        newRow += '</div>';
        newRow += '</div>';
        newRow += '<div class="add-row">';
        newRow += '<button type="button" class="remove-work-area-row remove">Remove Work Area</button>'
        newRow += "</div>";
        newRow += '</div>';
        $('.work-area-row').append(newRow);
        $('.select1').niceSelect();
    });



    // row remove JS
    $('body').on('click', '.remove-education-row', function () {
        $(this).parents('.addEducation').remove();
    })
    $('body').on('click', '.remove-experiences-row', function () {
        $(this).parents('.addexperiences').remove();
        count = count - 1;
    })
    $('body').on('click', '.remove-work-area-row', function () {
        $(this).parents('.addworkarea').remove();
    })
    $('body').on('click', '.remove-skills-row', function () {
        $(this).parents('.addskills').remove();
    })

    // });


    //===== Salary ranges
    $(function () {
        $('input[name="showInputBox"]').on('click', function () {
            if ($(this).val() === 'fixedPrice') {
                $('#fixedPrice').show();
                $('#rangePrice').hide();
            }
            else if ($(this).val() === 'rangePrice') {
                $('#fixedPrice').hide();
                $('#rangePrice').show();
            } else {
                $('#fixedPrice').hide();
                $('#rangePrice').hide();
            }
        });
        $(".js-example-templating").select2({
            tags: true,
            placeholder: "Type Your Tag",
        });
    });
    //===== Summernote js
    $(function () {
        $("#summernote1").summernote();
        $("button#btnToggleStyle").on("click", function (e) {
            e.preventDefault();
            var styleEle = $("style#fixed");
            if (styleEle.length == 0)
                $("<style id=\"fixed\">.note-editor .dropdown-toggle::after { all: unset; } .note-editor .note-dropdown-menu { box-sizing: content-box; } .note-editor .note-modal-footer { box-sizing: content-box; }</style>")
                    .prependTo("body");
            else
                styleEle.remove();
        })
    })
    //===== Nice number js


    if ($('input[type="number').length) {
        $('input[type="number"]').niceNumber({
            buttonDecrement: '<i class="bi bi-dash"></i>',
            buttonIncrement: '<i class="bi bi-plus"></i>',
        });
    }



    // Preloader
    jQuery(window).on('load', function () {
        $(".eg-preloder").fadeOut("100");
    });

}(jQuery));


function calculateAge() {
    var dateofbirth = $("#cv_DateOfBirth").val();

    // Convert the birthdate string to a Date object
    const birthdate = new Date(dateofbirth);

    // Calculate the difference between the birthdate and today's date
    const ageDiffMs = Date.now() - birthdate.getTime();

    // Convert the age difference from milliseconds to years (using an average of 365.25 days per year)
    const age = Math.floor(ageDiffMs / (1000 * 60 * 60 * 24 * 365.25));

    $("#cv_Age").val(age)
}

function checkUncheckEnglish() {
    var checkbox = document.getElementById("EnglishLanguage");

    if (checkbox.checked) {
        $("#cv_EnglishLanguage").val("true");
    } else {
        $("#cv_EnglishLanguage").val("false");
    }
}

function checkUncheckRootSelected() {
    var checkbox = document.getElementById("rootSelected");

    if (checkbox.checked) {
        $("#cv_RootSelected").val("true");
    } else {
        $("#cv_EnglishLanguage").val("false");
    }
}

function checkUncheckLocalHome() {
    //var checkbox = document.getElementById("LocalHomefilterCheckbox" + foreignId);

    const filterCheckbox = document.querySelectorAll('#LocalHomefilterCheckbox');
    const colMd6Elements = document.querySelectorAll('.col-md-6');

    var chlength = filterCheckbox.length;
    var selected = 0;
    for (var i = 0; i < filterCheckbox.length; i++) {
        if (filterCheckbox[i].checked) {
            selected++;
            colMd6Elements.forEach(element => {
                const selectedVal = parseInt(filterCheckbox[i].dataset.value);
                const elementVal = parseInt(element.dataset.price);
                const shouldDisplay = selectedVal === elementVal;
                if (shouldDisplay) {
                    element.style.display = 'block';
                }
                else {
                    element.style.display = 'none';
                }
                //element.style.display = shouldDisplay ? 'block' : 'none';
            });
        }
    }

    if (selected == 0) {
        colMd6Elements.forEach(element => element.style.display = 'block');
    }
    //const price = parseInt(element.dataset.price);
    //const shouldDisplay = parseInt(price) === parseInt(foreignId);
    //element.style.display = shouldDisplay ? 'block' : 'none';


    //if (checkbox.checked) {
    //    colMd6Elements.forEach(element => {
    //        const price = parseInt(element.dataset.price);
    //        const shouldDisplay = parseInt(price) === parseInt(foreignId);
    //        element.style.display = shouldDisplay ? 'block' : 'none';
    //    });
    //} else {
    //    colMd6Elements.forEach(element => element.style.display = 'block');
    //}
}

function checkUncheckArabic() {
    var checkbox = document.getElementById("ArabicLanguage");

    if (checkbox.checked) {
        $("#cv_ArabicLanguage").val("true");
    } else {
        $("#cv_ArabicLanguage").val("false");
    }
}

function confirmPostToAdmin(cvid) {
    swal({
        title: 'Are you sure?',
        /*html: '<label>Enter Back Forward Comments</label><textarea id="txtcomment" class="form-control input-lg"></textarea>',*/
        input: 'text',
        showCancelButton: true,
        confirmButtonText: 'Yes, Post to Admin',
        type: 'warning'
    },
        function (resolve) {
            if (resolve) {
                $.ajax({
                    url: "/ForeignAgent/PostToAdmin?cvid=" + cvid,
                    method: "GET",
                    success: function (data) {
                        //alert(data);
                        alert("CV has been posted to admin successfully");
                        location.reload();
                    }
                });
            }
            return;
        });
}

var hrpoolId;
var cvId;
var foreignId;
var lan;
function confirmSelectedcv(hrpoolIdd, cvIdd, foreignIdd, lann) {
    hrpoolId = hrpoolIdd;
    cvId = cvIdd;
    foreignId = foreignIdd;
    lan = lann;
    debugger
    $('#confirmSelectedCv').modal('show');


    //swal({
    //    title: 'Are you sure want to select this CV?',
    //    /*html: '<label>Enter Back Forward Comments</label><textarea id="txtcomment" class="form-control input-lg"></textarea>',*/
    //    input: 'text',
    //    showCancelButton: true,
    //    confirmButtonText: 'Yes, Select CV',
    //    type: 'warning'
    //},
    //    function (resolve) {
    //        if (resolve) {
    //            $.ajax({
    //                url: "/LocalAgent/LocalAgentSelectCV?id=" + hrpoolId + "&cvId=" + cvId + "&foreignId=" + foreignId,
    //                method: "GET",
    //                success: function (data) {
    //                    //alert(data);
    //                    alert("CV has been selected successfully");
    //                    location.reload();
    //                }
    //            });
    //        }
    //        return;
    //    });
}

function saveSelectedCv() {
    debugger;
    $.ajax({
        url: "/LocalAgent/LocalAgentSelectCV?id=" + hrpoolId + "&cvId=" + cvId + "&foreignId=" + foreignId,
        method: "GET",
        success: function (data) {
            //alert(data);
            if (lan == 'True') {
                alert("�� ������ ������ ������� �����");
            }
            else {
                alert("CV has been selected successfully");
            }
            location.reload();
        }
    });
}

function confirmUnSelectcv(hrpoolIdd, cvIdd, foreignIdd, lann) {
    hrpoolId = hrpoolIdd;
    cvId = cvIdd;
    foreignId = foreignIdd;
    lan = lann;
    debugger
    $('#confirmUnSelectedCv').modal('show');

    //swal({
    //    title: 'Are you sure want to Unselect this CV?',
    //    /*html: '<label>Enter Back Forward Comments</label><textarea id="txtcomment" class="form-control input-lg"></textarea>',*/
    //    input: 'text',
    //    showCancelButton: true,
    //    confirmButtonText: 'Yes, UnSelect CV',
    //    type: 'warning'
    //},
    //    function (resolve) {
    //        if (resolve) {
    //            $.ajax({
    //                url: "/LocalAgent/LocalAgentUnSelectCV?id=" + hrpoolId + "&cvId=" + cvId + "&foreignId=" + foreignId,
    //                method: "GET",
    //                success: function (data) {
    //                    //alert(data);
    //                    alert("CV has been selected successfully");
    //                    location.reload();
    //                }
    //            });
    //        }
    //        return;
    //    });
}

function saveUnSelectedCv() {
    debugger;
    $.ajax({
        url: "/LocalAgent/LocalAgentUnSelectCV?id=" + hrpoolId + "&cvId=" + cvId + "&foreignId=" + foreignId,
        method: "GET",
        success: function (data) {
            //alert(data);
            if (lan == 'True') {
                alert("�� ������� �� ������ ������ ������� �����");
            }
            else {
                alert("CV has been UnSelected successfully");
            }

            location.reload();
        }
    });
}

//function sponsorData(hrpoolId, cvId, foreignId) {
//    swal({
//        title: 'Enter Sponsor Information:',
//        html: '<label>Sponsor Name:</label><input type="text" id="txtsponsorname" class="form-control input-lg" />'
//            + '<label>Sponsor ID No:</label><input type="text" id="txtsponsorId" class="form-control input-lg" />'
//            + '<label>Sponsor Visa No:</label><input type="text" id="txtsponsorvisaNo" class="form-control input-lg" />'
//            + '<label>Sponsor Telephone No:</label><input type="text" id="txtsponsorContactNo" class="form-control input-lg" />'
//            + '<label>Sponsor Date of Birth:</label><input type="text" id="sponsorDateOfBirth" name="sponsorDateOfBirth" class="form-control input-lg" onclick="showHijriDatePicker()" />',
//        input: 'text',
//        showCancelButton: true,
//        confirmButtonText: 'Save Changes',
//        type: 'warning'
//    },
//        function (resolve) {
//            if (resolve) {
//                sponsorname = $('#txtsponsorname').val();
//                idnumber = $('#txtsponsorId').val();
//                visano = $('#txtsponsorvisaNo').val();
//                contact = $('#txtsponsorContactNo').val();
//                sponsordateofbirth = $('#sponsorDateOfBirth').val();

//                $.ajax({
//                    url: "/LocalAgent/LocalAgentProcessSponsorData?id=" + hrpoolId + "&cvId=" + cvId
//                        + "&sponsorname=" + sponsorname
//                        + "&idnumber=" + idnumber
//                        + "&visano=" + visano
//                        + "&contact=" + contact
//                        + "&sponsordateofbirth=" + sponsordateofbirth,
//                    method: "GET",
//                    success: function (data) {
//                        //alert(data);
//                        alert("CV has been updated successfully");
//                        location.reload();
//                    }
//                });
//            }
//            return;
//        });
//}

function UploadMusanedContract(hrpoolId, cvId, foreignId, selectedCvId, localId, foreignAgentName) {

    var nowDate = new Date().toLocaleDateString();
    swal({
        title: 'Enter Musaned Contract Details:',
        html: '<label>Foreign Agent:</label><b>' + foreignAgentName + '</b>'
            + '<label>Musaned Contract Number:</label><input type="number" id="txtmusanednumber" class="form-control input-lg" />'
            + '<label>Musaned Contract Date:</label><input type="date" id="txtcontractDate" value="' + nowDate + '" >',
        input: 'text',
        showCancelButton: true,
        confirmButtonText: 'Save Changes',
        type: 'warning'
    },
        function (resolve) {
            if (resolve) {
                musanednumber = $('#txtmusanednumber').val();
                contractdate = $('#txtcontractDate').val();


                $.ajax({
                    url: "/RootCompany/UploadMusanedContract?id=" + hrpoolId
                        + "&cvId=" + cvId
                        + "&foreignId=" + foreignId
                        + "&selectedCvId=" + selectedCvId
                        + "&localId=" + localId
                        + "&musanednumber=" + musanednumber
                        + "&contractdate=" + contractdate,

                    method: "GET",
                    success: function (data) {
                        //alert(data);
                        alert("CV status has been updated successfully");
                        location.reload();
                    }
                });
            }
            return;
        });
}


function getDateHijri() {
    var calendar = $.calendars.instance('ummalqura', 'ar');
    //$('.date').calendarsPicker({ calendar: calendar });
    $('#sponsordateofbirth').calendarsPicker({ calendar: calendar });
}

function sponsorData(hrpoolIdd, cvIdd, foreignIdd) {
    debugger;
    hrpoolId = hrpoolIdd;
    cvId = cvIdd;
    foreignId = foreignIdd;

    $('#sponsorData').modal('show');
    getDateHijri();
    //swal({
    //    title: 'Enter Sponsor Information:',
    //    html: '<label>Sponsor Name:</label><input type="text" id="txtsponsorname" class="form-control input-lg" />'
    //        + '<label>Sponsor ID No:</label><input type="text" id="txtsponsorId" class="form-control input-lg" />'
    //        + '<label>Sponsor Visa No:</label><input type="text" id="txtsponsorvisaNo" class="form-control input-lg" />'
    //        + '<label>Sponsor Telephone No:</label><input type="text" id="txtsponsorContactNo" class="form-control input-lg" />'
    //        + '<label>Sponsor Date of Birth:</label><input type="text" onclick="getDateHijri()" class="form-control" id="sponsordateofbirth" name="sponsordateofbirth" placeholder="Select Date of Birth">',
    //    input: 'text',
    //    showCancelButton: true,
    //    confirmButtonText: 'Save Changes',
    //    //type: 'warning'
    //},
    //    function (resolve) {
    //        if (resolve) {

    //            sponsorname = $('#txtsponsorname').val();
    //            idnumber = $('#txtsponsorId').val();
    //            visano = $('#txtsponsorvisaNo').val();
    //            contact = $('#txtsponsorContactNo').val();
    //            sponsordateofbirth = $('#sponsordateofbirth').val();

    //            $.ajax({
    //                url: "/LocalAgent/LocalAgentProcessSponsorData?id=" + hrpoolId + "&cvId=" + cvId
    //                    + "&sponsorname=" + sponsorname
    //                    + "&idnumber=" + idnumber
    //                    + "&visano=" + visano
    //                    + "&contact=" + contact
    //                    + "&sponsordateofbirth=" + sponsordateofbirth,
    //                method: "GET",
    //                success: function (data) {
    //                    //alert(data);
    //                    alert("CV has been updated successfully");
    //                    location.reload();
    //                }
    //            });
    //        }
    //        return;
    //    });
}

function saveSponsorData() {
    debugger;
    sponsorname = $('#txtsponsorname').val();
    idnumber = $('#txtsponsorId').val();
    visano = $('#txtsponsorvisaNo').val();
    contact = $('#txtsponsorContactNo').val();
    sponsordateofbirth = $('#sponsordateofbirth').val();

    $.ajax({
        url: "/LocalAgent/LocalAgentProcessSponsorData?id=" + hrpoolId + "&cvId=" + cvId
            + "&sponsorname=" + sponsorname
            + "&idnumber=" + idnumber
            + "&visano=" + visano
            + "&contact=" + contact
            + "&sponsordateofbirth=" + sponsordateofbirth,
        method: "GET",
        success: function (data) {
            //alert(data);
            alert("CV has been updated successfully");
            location.reload();
        }
    });
}

function showSponsor(name, visanumber, idnumber, contact, dateofbirthhijri, dateofbirth) {

    debugger;
    document.getElementById('SponsorName').innerHTML = name;
    document.getElementById('SponsorId').innerHTML = idnumber;
    document.getElementById('SponsorVisaNo').innerHTML = visanumber;
    document.getElementById('SponsorTelephoneNo').innerHTML = contact;
    document.getElementById('SponsorDOB').innerHTML = dateofbirth;

    $('#showSponsor').modal('show');
    //swal({
    //    title: 'Sponsor Information:',
    //    html: '<label><b>Sponsor Name:</b></label>' + " " + name
    //        + '<br /><label><b>Sponsor ID No:</b></label>' + " " + idnumber
    //        + '<br /><label><b>Sponsor Visa No:</b></label>' + " " + visanumber
    //        + '<br /><label><b>Sponsor Telephone No:</b></label>' + " " + contact
    //        + '<br /><label><b>Date of Birth Hijri:</b></label>' + " " + dateofbirthhijri
    //        + '<br /><label><b>Date of Birth:</b></label>' + " " + dateofbirth,
    //    input: 'text',
    //    showCancelButton: true,
    //    confirmButtonText: 'Close',
    //    //type: 'warning'
    //},
    //    function (resolve) {
    //        if (resolve) {
    //        }
    //        return;
    //    });
}

function showCancelReason(cancelby, reason, canceldate, notes, culture) {

    document.getElementById('CanceledBy').innerHTML = cancelby;
    document.getElementById('CanceledReason').innerHTML = reason;
    document.getElementById('CanceledDate').innerHTML = canceldate;
    document.getElementById('Notes').innerHTML = notes;

    $('#rejectReason').modal('show');
    //swal({
    //    title: 'Cancel Reason Details:',
    //    html: '<label><b>Canceled By:</b></label>' + " " + cancelby
    //        + '<br /><label><b>Canceled Reason:</b></label>' + " " + reason
    //        + '<br /><label><b>Canceled Date:</b></label>' + " " + canceldate
    //        + '<br /><label><b>Notes:</b></label>' + " " + notes,
    //    input: 'text',
    //    showCancelButton: true,
    //    confirmButtonText: 'Close',
    //    //type: 'warning'
    //},
    //    function (resolve) {
    //        if (resolve) {
    //        }
    //        return;
    //    });    
}

function sharewhatsapp(hrpoolId, cvId, foreignId, sendByWhatsApp) {
    //update send bywhatsapp status
    if (sendByWhatsApp == '' || sendByWhatsApp == '0' || sendByWhatsApp == "False") {
        $.ajax({
            url: "/LocalAgent/SendCVByWhatsApp?id=" + hrpoolId,
            method: "GET",
            success: function (data) {
                if (data == "done") {
                    console.log("Send WhatsApp Updated");
                }
            }
        });
    }
    var link = window.location.origin + "/CV/ViewCV/" + hrpoolId + "?cvId=" + cvId + "&foreignId=" + foreignId;
    debugger;
    var url = "https://web.whatsapp.com/send?text=" + encodeURIComponent(link);
    window.open(url, "_blank");
}

function returnbacksharewhatsapp(hrpoolId, cvId, foreignId, sendByWhatsApp) {

    swal({
        title: 'Are you sure you want to return the status into Abailable?',
        input: 'text',
        showCancelButton: true,
        confirmButtonText: 'Yes',
        type: 'warning'
    },
        function (resolve) {
            if (resolve) {

                $.ajax({
                    url: "/LocalAgent/UnSendCVByWhatsApp?id=" + hrpoolId,
                    method: "GET",
                    success: function (data) {
                        if (data == "done") {
                            alert("CV status has been changed into Abailable");
                            location.reload();
                        }
                    }
                });
            }
            return;
        });


}

function cancelCv(hrpoolId, cvId) {
    swal({
        title: 'Enter Cancelation Reason',
        html: '<label style="color: black;font- size: larger;">Cancelation Reason:</label><select id="cancelReasonDrop" class="form-control" onclick="getCancelReason()"><option value="0">Please select Cancel Reason</option></select> <br />'
            + '<label style="color: black;font- size: larger;">Cancelation Notes:</label><input type="text" id="txtnotes" class="form-control input-lg" /> <br />',
        input: 'text',
        showCancelButton: true,
        confirmButtonText: 'Save Changes',
        //onOpen: function () {
        //    console.log('test');
        //    getCancelReason();
        //},
        type: 'warning'
    },
        function (resolve) {
            if (resolve) {
                debugger;
                var e = document.getElementById("cancelReasonDrop");
                var value = e.options[e.selectedIndex].value;

                cancelReason = value;
                notes = $('#txtnotes').val();

                $.ajax({
                    url: "/ForeignAgent/CancelCV?hrpoolid=" + hrpoolId + "&cvId=" + cvId
                        + "&cancelreason=" + cancelReason
                        + "&notes=" + notes,
                    method: "GET",
                    success: function (data) {
                        //alert(data);
                        alert("CV has been canceled successfully");
                        location.reload();
                    }
                });
            }
            return;
        });
}

function getCancelReason() {
    debugger;
    var cancelReason = document.querySelector("#cancelReasonDrop").length; //$('#cancelReasonDrop').size(); //document.getElementById("MainCategoryId").value;
    if (cancelReason == 1) {
        $.post("/ForeignAgent/GetCancelReason",
            function (data, status) {
                //alert("Data: " + data + "\nStatus: " + status);

                if (data !== false) {
                    $("#cancelReasonDrop").empty();

                    $('#cancelReasonDrop').append($('<option>', {
                        value: 0,
                        text: 'Please select Cancel Reason'
                    }));

                    $.each(data, function (index, i) {

                        $('#cancelReasonDrop').append($('<option>', {
                            value: i.id,
                            text: i.cancelReasonEnglish
                        }));
                    });
                }

            });
    }


}

function showLocalCancelDetails(cancelReason, SponsorName, contact, visanumber, dateofbirthhijri, idnumber) {
    debugger;
    document.getElementById('SponsorName2').innerHTML = SponsorName;
    document.getElementById('SponsorId2').innerHTML = idnumber;
    document.getElementById('SponsorVisaNo2').innerHTML = visanumber;
    document.getElementById('SponsorTelephoneNo2').innerHTML = contact;
    document.getElementById('SponsorDOB2').innerHTML = dateofbirthhijri;
    document.getElementById('CanceledReason2').innerHTML = cancelReason;


    $('#LocalCancelDetails').modal('show');
    //swal({
    //    title: 'Sponsor Information:',
    //    html: '<label><b>Sponsor Name:</b></label>' + " " + SponsorName
    //        + '<br /><label><b>Sponsor ID No:</b></label>' + " " + idnumber
    //        + '<br /><label><b>Sponsor Visa No:</b></label>' + " " + visanumber
    //        + '<br /><label><b>Sponsor Telephone No:</b></label>' + " " + contact
    //        + '<br /><label><b>Date of Birth Hijri:</b></label>' + " " + dateofbirthhijri
    //        + '<br /><label><b>Cancellation Reason:</b></label>' + " " + cancelReason,
    //    input: 'text',
    //    showCancelButton: true,
    //    confirmButtonText: 'Close',
    //    //type: 'warning'
    //},
    //    function (resolve) {
    //        if (resolve) {
    //        }
    //        return;
    //    });
}