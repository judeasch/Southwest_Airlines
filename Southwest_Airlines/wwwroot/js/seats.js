$(function () {
    var $container = $('.seat-map-grid');
    var $seatIcon = $('.seat.available', $container);

    $seatIcon.click(function () {
        // clear previously selected seats
        $seatIcon.removeClass('selected');

        // make the clicked seat selected
        $(this).addClass('selected');
    });

});