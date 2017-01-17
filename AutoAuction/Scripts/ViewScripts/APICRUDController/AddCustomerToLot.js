$(document).ready(function() {
    $('#singlelot tbody').on('click', 'tr #LotImageUrl', function() {
        $(".fancybox").attr("href", document.getElementById('LotImageUrl').getAttribute('src'));
        $(".fancybox").fancybox();
    });
    $("#AddNewCustomer").click(function() {
        var addCL =
        {
            LotId: $("#LotId").val(),
            CustomerBet: $("#addPrice").val(),
            CurrentPrice: $("#LotCurrentPrice").val(),
            LotMaker: false
        };
        $.ajax({
            url: '/api/APICRUD/',
            type: 'POST',
            data: JSON.stringify(addCL),
            contentType: "application/json;charset=utf-8",
            success: function(data, status) {
                window.location = '/Customer';
            },
            error:
                function(jxqr, error, status) {
                    //
                    var response = jQuery.parseJSON(jxqr.responseText);
                    $('#errors').empty();
                    $('#errors').append("<h2>" + "Неправильно введены данные" + "</h2>");
                    // CustomerBet error
                    if (response['ModelState']['CustomerBet']) {

                        $.each(response['ModelState']['CustomerBet'], function(index, item) {
                            $('#errors').append("<p>" + item + "</p>");
                        });
                    }
                    //Customer error
                    if (response['ModelState']['Customer']) {

                        $.each(response['ModelState']['Customer'], function(index, item) {
                            $('#errors').append("<p>" + item + "</p>");
                        });
                    }
                }
        });
    });
});