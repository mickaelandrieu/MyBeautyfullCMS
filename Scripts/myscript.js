/* appel � la cr�ation d'un article */
$("#createForm").click(function () {
    $.ajax({
        type: "GET",
        url: 'http://localhost:11111/article/Create',
    }).done(function (response) {
        $('#Form').append(response);
        $('#Form').css('display', 'block');
    }
    );
});

/* appel de la validation d'un article : cr�ation d'un article */
