$(function () {
    $('ssButton').click(function (event) {
        alert('ss works');
        var PlaceholderElement = $('Placeholder');
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            PlaceholderElement.html(data);
            PlaceholderElement.find('.modal').show();
        })
    })
})
