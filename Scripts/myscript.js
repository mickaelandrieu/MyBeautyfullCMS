/* appel à la création d'un article */
$("#createForm").click(function () {
    $.ajax({
        type: "GET",
        url: 'http://localhost:11111/article/Create',
    }).done(function (response) {
        $('#createArticleForm').append(response);
    }
    );
});

/* appel de la validation d'un article : création d'un article */
