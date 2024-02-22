$(function () {
    var $container = $('.seat-map-grid');
    var $seatIcon = $('.seat.available', $container);
    var $submitBtn = $('.submit', $container);

    $seatIcon.click(function () {
        // clear previously selected seats
        $seatIcon.removeClass('selected');

        // make the clicked seat selected
        $(this).addClass('selected');
    });

    /*
    $submitBtn.click(function () {
        var seat = $('div').find('.selected');
        if (seat != null) {
            var obj = seat.data(seatNum);  // get data attribute of selected seat

            // use ajax to post the seat number to the UpdateSeat method of FlightsController
            $.ajax({
                url: '@Url.Action("UpdateSeat")',
                type: "POST",  
                data: JSON.stringify(obj),
                success: function (result) {

                    alert("success! (maybe)");
                },
                error: function (result) {
                    alert("failure");
                }
            });
        }
    }); */

});