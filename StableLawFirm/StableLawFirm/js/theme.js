"use strict";




// Prealoder
 function prealoader () {
   if ($('#loader').length) {
     $('#loader').fadeOut(); // will first fade out the loading animation
     $('#loader-wrapper').delay(350).fadeOut('slow'); // will fade out the white DIV that covers the website.
     $('body').delay(350).css({'overflow':'visible'});
  };
 }


// Home Page One Banner
function vegasBanner () {
  if($("#banner").length) {
    $("#banner").vegas({
        slides: [
            //{ src: "images/home/slide-1.jpg" },
            //{ src: "images/home/slide-2.jpg" },
            { src: "images/home/slide-3.jpg" }
        ],

        transition: [ 'fade', 'zoomOut', 'swirlLeft' ]
    });

    $('button#previous').on('click', function () {
          $("#banner").vegas('options', 'transition', 'zoomOut').vegas('previous');
      });

      $('button#next').on('click', function () {
          $("#banner").vegas('options', 'transition', 'slideLeft2').vegas('next');
      });

  }
}



// Accordion panel
function themeAccrodion () {
  if ($('.theme-accordion > .panel').length) {
    $('.theme-accordion > .panel').on('show.bs.collapse', function (e) {
          var heading = $(this).find('.panel-heading');
          heading.addClass("active-panel");
          
    });
    
    $('.theme-accordion > .panel').on('hidden.bs.collapse', function (e) {
        var heading = $(this).find('.panel-heading');
          heading.removeClass("active-panel");
          //setProgressBar(heading.get(0).id);
    });

  };
}



// Testimonial Slider 
function testimonialSlider () {
  if($('.testimonial-slider').length) {
    $('.testimonial-slider').owlCarousel({
        loop:true,
        margin:30,
        nav:false,
        dots:true,
        autoplay:true,
        autoplayTimeout:1500,
        autoplaySpeed:1000,
        lazyLoad:true,
        singleItem:true,
        items:1,
    })
  }
}




// placeholder remove
function removePlaceholder () {
  if ($("input,textarea").length) {
    $("input,textarea").each(
            function(){
                $(this).data('holder',$(this).attr('placeholder'));
                $(this).on('focusin', function() {
                    $(this).attr('placeholder','');
                });
                $(this).on('focusout', function() {
                    $(this).attr('placeholder',$(this).data('holder'));
                });
                
        });
  }
}



// Scroll to top
function scrollToTop () {
  if ($('.scroll-top').length) {

    //Check to see if the window is top if not then display button
    $(window).on('scroll', function (){
      if ($(this).scrollTop() > 200) {
        $('.scroll-top').fadeIn();
      } else {
        $('.scroll-top').fadeOut();
      }
    });
    
    //Click event to scroll to top
    $('.scroll-top').on('click', function() {
      $('html, body').animate({scrollTop : 0},1500);
      return false;
    });
  }
}




function gMapHome () {
  if ($('.google-map').length) {
    $('.google-map').each(function () {
      // getting options from html 
      var Self = $(this);
      var mapName = Self.attr('id');
      var mapLat = Self.data('map-lat');
      var mapLng = Self.data('map-lng');
      var iconPath = Self.data('icon-path');
      var mapZoom = Self.data('map-zoom');
      var mapTitle = Self.data('map-title');


      var styles = [
                  {
                      "featureType": "administrative",
                      "elementType": "labels.text.fill",
                      "stylers": [
                          {
                              "color": "#444444"
                          }
                      ]
                  },
                  {
                      "featureType": "landscape",
                      "elementType": "all",
                      "stylers": [
                          {
                              "color": "#f2f2f2"
                          }
                      ]
                  },
                  {
                      "featureType": "poi",
                      "elementType": "all",
                      "stylers": [
                          {
                              "visibility": "off"
                          }
                      ]
                  },
                  {
                      "featureType": "road",
                      "elementType": "all",
                      "stylers": [
                          {
                              "saturation": -100
                          },
                          {
                              "lightness": 45
                          }
                      ]
                  },
                  {
                      "featureType": "road",
                      "elementType": "geometry",
                      "stylers": [
                          {
                              "hue": "#ff0000"
                          }
                      ]
                  },
                  {
                      "featureType": "road.highway",
                      "elementType": "all",
                      "stylers": [
                          {
                              "visibility": "simplified"
                          }
                      ]
                  },
                  {
                      "featureType": "road.arterial",
                      "elementType": "labels.icon",
                      "stylers": [
                          {
                              "visibility": "off"
                          }
                      ]
                  },
                  {
                      "featureType": "transit",
                      "elementType": "all",
                      "stylers": [
                          {
                              "visibility": "off"
                          }
                      ]
                  },
                  {
                      "featureType": "water",
                      "elementType": "all",
                      "stylers": [
                          {
                              "color": "#16C3D1"
                          },
                          {
                              "visibility": "on"
                          }
                      ]
                  }
              ]


      // if zoom not defined the zoom value will be 15;
      if (!mapZoom) {
        var mapZoom = 12;
      };
      // init map
      var map;
      map = new GMaps({
          div: '#'+mapName,
          scrollwheel: false,
          lat: mapLat,
          lng: mapLng,
          styles: styles,
          zoom: mapZoom
      });
      // if icon path setted then show marker
      if(iconPath) {
        
        map.addMarker({
            icon: 'images/logo/map.png',
            lat: 40.925372,
              lng: -74.276544,
              title: 'Legal Station Main Office',
              infoWindow: {
            content: '<h6>North Parchrtome Steet</h6> <p>Gazipur,Dhaka</p>'
          }
        });
        map.addMarker({
            icon: 'images/logo/map.png',
            lat: 40.929399,
              lng: -74.430091,
              title: 'Legal Station Tongi Branch',
              infoWindow: {
            content: '<h6>Raibow Manor California</h6> <p>Tongi,Dhaka</p>'
          }
        });
        map.addMarker({
            icon: 'images/logo/map.png',
            lat: 40.892321,
              lng: -74.477377,
              title: 'Legal Station Nikunjo Branch',
              infoWindow: {
            content: '<h6>17 Thorpe Close Notting</h6> <p>Nikunjo,Dhaka</p>'
          }
        });
        map.addMarker({
            icon: 'images/logo/map.png',
            lat: 40.935654,
              lng: -74.186256,
              title: 'Office Under Construction',
              infoWindow: {
            content: '<h6>Longkloof Studio</h6> <p>Banani,Dhaka</p>'
          }
        });
      }
    });  
  };
}



// Sticky header
function stickyHeader () {
  if ($('header').length) {
    var sticky = $('header'),
        scroll = $(window).scrollTop();

    if (scroll >= 190) sticky.addClass('fixed');
    else sticky.removeClass('fixed');
    
  };
}


// toggle menu for mobile
function mobileDropdown () {
  if($('.main-menu').length) {
    $('.main-menu nav ul li.dropdown_menu').append(function () {
      return '<i class="fa fa-bars"></i>';
    });
    $('.main-menu nav ul li.dropdown_menu .fa').on('click', function () {
      $(this).parent('li').children('ul').slideToggle();
    }); 
  }
}




//Contact Form Validation
function contactFormValidation () {
  if($('.form-validation').length){
    $('.form-validation').validate({ // initialize the plugin
      rules: {
        name: {
          required: true
        },
        email: {
          required: true,
          email: true
        },
        phone: {
          required: true
        },
        message: {
          required: true
        }
      },
      submitHandler: function(form) {
                $(form).ajaxSubmit({
                    success: function() {
                        $('.form-validation :input').attr('disabled', 'disabled');
                        $('.form-validation').fadeTo( "slow", 1, function() {
                            $(this).find(':input').attr('disabled', 'disabled');
                            $(this).find('label').css('cursor','default');
                            $('#alert_success').fadeIn();
                        });
                    },
                    error: function() {
                        $('.form-validation').fadeTo( "slow", 1, function() {
                            $('#alert_error').fadeIn();
                        });
                    }
                });
            }
        });
  }
}

// Close suddess Alret
function closeSuccessAlert () {
  if($('.closeAlert').length) {
    $(".closeAlert").on('click', function(){
      $(".alert_wrapper").fadeOut();
    });
    $(".closeAlert").on('click', function(){
      $(".alert_wrapper").fadeOut();
    })
  }
}




// DOM ready function
jQuery(document).on('ready', function() {
	(function ($) {
	 vegasBanner ();
     themeAccrodion ();
     testimonialSlider ();
     removePlaceholder ();
     scrollToTop ();
     gMapHome ();
     mobileDropdown ();
     contactFormValidation ();
     closeSuccessAlert ()
  })(jQuery);
});


// Window load function
jQuery(window).on('load', function () {
   (function ($) {
		  prealoader ()
  })(jQuery);
 });

// Window scroll function
jQuery(window).on('scroll', function () {
  (function ($) {
    stickyHeader ()
  })(jQuery);
});
