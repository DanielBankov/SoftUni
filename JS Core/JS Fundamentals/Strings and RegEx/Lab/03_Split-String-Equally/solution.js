function solve() {
    let word = document.getElementById('text').value;
    let groupSize = +document.getElementById('number').value;

    if (word.length % groupSize > 0) {
        let remainder = word.length % groupSize;
        let charToFill = groupSize - remainder;

        word = word + word.substr(0, charToFill);
    }

    let result = [];

    for (let i = 0; i < word.length; i += groupSize) {
        result.push(word.substr(i, groupSize));
    }

    document.getElementById('result').innerHTML = result.join(' ');
}