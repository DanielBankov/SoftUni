function solve() {
    let word = document.getElementById('word').value;
    let text = document.getElementById('text').value;
    let result = document.getElementById('result');
    let parts = JSON.parse(text);

    const replaceWord = parts[0].split(' ')[2];
    const pattern = new RegExp(replaceWord, 'gi');
    parts = parts.map(elem => elem.replace(pattern, word));

    parts.forEach(elem => {
        let p = document.createElement('p');
        p.innerHTML = elem;
        result.appendChild(p);
    });
}