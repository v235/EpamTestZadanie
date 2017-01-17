$(document).ready(function() {
    $('#singlelot tbody').on('click', 'tr #LotImageUrl', function() {
        $(".fancybox").attr("href", document.getElementById('LotImageUrl').getAttribute('src'));
        $(".fancybox").fancybox();
    });
});