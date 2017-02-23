/*
 *
 *		STYLE-SWITCHER.JS
 *
 */
(function ($) {

    $(document).ready(function () {

        var $styleSwitcher = $('#style-switcher');
        var $colorPickerHolder = $styleSwitcher.find('.ff-color-picker');
        var $colorPickerInput = $styleSwitcher.find('.ff-color-picker-input');
        var $colorPickerOverlay = $styleSwitcher.find('.ff-color-picker-overlay');

        /**********************************************************************************************************************/
        /* FRESHFACE COLOR PICKER REALTIME
        /**********************************************************************************************************************/
        // loading color accent CSS
        var colorAccentUrl = ff_template_url + '/assets/css/colors-accent.css';
        var colorAccentOriginalColor = '#bca480';
        var colorAccentRegExp = new RegExp(colorAccentOriginalColor, 'g');
        var colorAccentContent = null;
        var $colorAccentStyle = null;

        var loadColorAccentContent = function () {
            $.get(colorAccentUrl, function (response) {
                colorAccentContent = response;

                if ($.cookie('hand-picked-color')) {
                    var handPickedColor = $.cookie('hand-picked-color');

                    setInputColor(handPickedColor);
                    setPickerColor(handPickedColor);
                    setWebsiteColor(handPickedColor);
                }
            });
        }
        loadColorAccentContent();

        var $colorPickerHolder = $styleSwitcher.find('.ff-color-picker');
        var $colorPickerReset = $styleSwitcher.find('.ff-reset-picker');


        var setInputColor = function (hex) {
            $colorPickerInput.css('background-color', hex);
        }

        var setPickerColor = function (hex) {
            $colorPickerHolder.ColorPickerSetColor(hex);
        }

        var setWebsiteColor = function (hex) {
            if (colorAccentContent == null) {
                return false;
            }

            var colorAccentReplaced = colorAccentContent.replace(colorAccentRegExp, hex);

            if ($colorAccentStyle == null) {
                var style = '<style id="ff-color-accent-style"></style>';
                $colorAccentStyle = $(style);
                $('body').append($colorAccentStyle);
            }

            $colorAccentStyle.html(colorAccentReplaced);
            $.cookie('hand-picked-color', hex);

        }

        var resetColor = function () {
            $.removeCookie('hand-picked-color');

            setInputColor('#fff');
            setPickerColor('#fff');
            if ($colorAccentStyle != null) {
                $colorAccentStyle.html('');
            }
        }

        $colorPickerReset.click(function (e) {
            resetColor();
            e.stopPropagation();
            return false;

        });

        $colorPickerOverlay.fadeOut(0);

        $colorPickerInput.click(function () {
            $colorPickerHolder.toggle(500);
            $colorPickerOverlay.fadeToggle(0);
        });

        $colorPickerOverlay.click(function () {
            $colorPickerHolder.toggle(500);
            $colorPickerOverlay.fadeToggle(0);
        });


        // COLOR PICKER INITIALISATION
        $colorPickerHolder.ColorPicker({
            flat: true, // flat, directly inserted into the code

            onChange: (function (hsb, hex, rgb) {   // on change callback
                var hexWithSharp = '#' + hex;

                setInputColor(hexWithSharp);
                setWebsiteColor(hexWithSharp);
            })

        });




        /**********************************************************************************************************************/
        /* FRESHFACE COLOR PICKER REALTIME - END
        /**********************************************************************************************************************/

        //$('body').append(style_switch_content);

        $("#style-switcher > a").on("click", function (e) {

            e.preventDefault();
            $("#style-switcher").toggleClass("open");

            if (!$('#style-switcher').hasClass('open')) {
                $colorPickerHolder.hide(500);
            }

        });


        if ($('#ff-accent-css').size() == 0) {
            var linkHTML = '<link rel="stylesheet" id="ff-accent-css"  href="" type="text/css" media="all" />';

            $('body').append(linkHTML);
        }

        var $link = $('#ff-accent-css');

        var colors = 'green',
			layout = $.cookie('layout'),
			menus = $.cookie('menus'),
			pattern = $.cookie('pattern');

        if (($.cookie('colors'))) {

            $.cookie('colors', 'green', 365);
            colors = $.cookie('colors');
            $('#style-switcher .colors a[data-style="' + colors + '"]');

        } else {

            $link.attr('href', ff_template_url + '/assets/css/alternative-styles/' + colors + '.css');
            $('#style-switcher .colors a[data-style="' + colors + '"]').addClass('selected-box');

        };

        if (!($.cookie('layout'))) {

            $.cookie('layout', 'wide', 365);
            layout = $.cookie('layout');
            $("body").addClass(layout);
            $('#style-switcher .layout a[data-style="wide"]');

        } else {

            if (layout == "boxed") {

                $("body").addClass(layout);
                $("body").removeClass("wide");

            } else {

                $("body").addClass(layout);
                $("body").removeClass("boxed pattern-1 pattern-2 pattern-3 pattern-4 pattern-5 pattern-6 pattern-7 pattern-8 pattern-9 pattern-10");

            };

        };

        if ((layout == "boxed") && $.cookie('pattern')) {
            console.log($.cookie('pattern'));

            $styleSwitcher.find('.patterns a').removeClass('selected-box');

            $styleSwitcher.find('.' + $.cookie('pattern')).addClass('selected-box-green');

            $("body").removeClass("pattern-1 pattern-2 pattern-3 pattern-4 pattern-5 pattern-6 pattern-7 pattern-8 pattern-9 pattern-10 wide");
            $("body").addClass(pattern);

        } else {

            if (layout == "boxed") {

                $("body").removeClass("pattern-1 pattern-2 pattern-3 pattern-4 pattern-5 pattern-6 pattern-7 pattern-8 pattern-9 pattern-10");

            } else {

                $("body").removeClass("pattern-1 pattern-2 pattern-3 pattern-4 pattern-5 pattern-6 pattern-7 pattern-8 pattern-9 pattern-10 boxed");

            }

        };

        if (!($.cookie('menus'))) {

            $.cookie('menus', 'light', 365);
            menus = $.cookie('menus');
            $(".menu").addClass(menus);
            $('#style-switcher .menus a[data-style="light"]');

        } else {

            if (menus == "dark") {

                $(".menu").addClass(menus);
                $(".menu").removeClass("light");

            } else {

                $(".menu").addClass(menus);
                $(".menu").removeClass("dark");

            };

        };


        // CHANGE COLOR //
        $('#style-switcher .colors a').on('click', function (e) {

            $(this).siblings().removeClass('selected-box');
            $(this).addClass('selected-box');

            var $this = $(this),
				colors = $this.data('style');

            e.preventDefault();





            $link.attr('href', ff_template_url + '/assets/css/alternative-styles/' + colors + '.css');
            $.cookie('colors', colors, 365);

        });

        // BOXED LAYOUT //
        $('#style-switcher .layout a.boxed').on('click', function (e) {

            e.preventDefault();

            $("body").addClass("boxed");
            $("body").removeClass("wide");
            $.cookie('layout', 'boxed', 365);

            if ($.cookie('pattern')) {

                var pattern = $.cookie('pattern');

                $("body").removeClass("pattern-1 pattern-2 pattern-3 pattern-4 pattern-5 pattern-6 pattern-7 pattern-8 pattern-9 pattern-10");
                $("body").addClass(pattern);

            }

            document.location.reload();

        });

        // WIDE LAYOUT
        $('#style-switcher .layout a.wide').on('click', function (e) {

            e.preventDefault();

            $("body").addClass("wide");
            $("body").removeClass("boxed pattern-1 pattern-2 pattern-3 pattern-4 pattern-5 pattern-6 pattern-7 pattern-8 pattern-9 pattern-10");
            $.cookie('layout', 'wide', 365);

            document.location.reload();

        });

        // CHANGE PATTERNS //
        $('#style-switcher .patterns a').on('click', function (e) {

            $(this).siblings().removeClass('selected-box-green');
            $(this).addClass('selected-box-green');

            var $this = $(this),
				pattern = $this.data('style');

            e.preventDefault();

            $("body").removeClass("pattern-1 pattern-2 pattern-3 pattern-4 pattern-5 pattern-6 pattern-7 pattern-8 pattern-9 pattern-10 wide");
            $("body").addClass(pattern);
            $("#style-switcher select").val("boxed");
            $.cookie('pattern', pattern, 365);

        });

        // DARK MENU //
        $('#style-switcher .menus a.dark').on('click', function (e) {

            e.preventDefault();

            $('.megamenu-container').css('background-image', 'url(http://demo.freshface.net/milo/wp-content/uploads/sites/19/2015/06/bg-megamenu-dark.jpg)');

            $(".menu").addClass("dark");
            $(".menu").removeClass("light");
            $.cookie('menus', 'dark', 365);

        });

        // LIGHT MENU
        $('#style-switcher .menus a.light').on('click', function (e) {

            e.preventDefault();

            $('.megamenu-container').css('background-image', 'url(http://demo.freshface.net/milo/wp-content/uploads/sites/19/2015/05/bg-megamenu.jpg)');

            $(".menu").addClass("light");
            $(".menu").removeClass("dark");
            $.cookie('menus', 'light', 365);

        });

    });

})(jQuery);