
    $('.nav-tabs li a').on('click', function () {
        $(this).parent().find('.active').removeClass('active');
        $(this).addClass('active');
    });

$('.text-new-line').trunk8({
    lines: 6
});