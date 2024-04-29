$(function () {
    var $container = $('.seat-map-grid');
    var $flightId = $('.flight-id')
    var $seatIcon = $('.seat.available', $container);
    var $submitBtn = $('.submit', $container);

    $seatIcon.click(function () {
        // clear previously selected seats
        $seatIcon.removeClass('selected');

        // make the clicked seat selected
        $(this).addClass('selected');
    });

    
    $submitBtn.click(function () {
        var seat = $('div').find('.selected');
        if (seat != null) {
            var obj = { seatNum: seat.attr('id'), flightId: $flightId.attr('id') }; // get seat number of selected seat

            // use ajax to post the seat number to the UpdateSeat method of FlightsController
            $.ajax({
                url: '/Flights/UpdateSeat',
                type: "POST",  
                contentType: 'application/x-www-form-urlencoded',
                data: obj,
                success: function (result) {

                    alert("success!");
                },
                error: function (result) {
                    alert("failure");
                }
            });
        }
    }); 

});