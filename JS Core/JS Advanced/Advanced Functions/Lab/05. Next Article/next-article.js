function getArticleGenerator(input) {
    let content = document.getElementById('content');
    let i = 0;

    function getArticle() {
        if(i >= input.length) return;

        let p = document.createElement('p');
        let article = document.createElement('article');
        p.textContent = input[i++];
        article.appendChild(p);
        content.appendChild(article);
    }

    return getArticle;
}