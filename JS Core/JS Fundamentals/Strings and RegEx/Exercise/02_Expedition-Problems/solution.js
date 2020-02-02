function solve() {
    let resultElement = document.getElementById('result');
    let separator = document.getElementById('string').value;
    let text = document.getElementById('text').value;

    let regexMessage = new RegExp(`${separator}.+${separator}`);
    let patternDegrees = /(north|east).*?([\d]{2})[^,]*?,[^,]*?([\d]{6})/gmi;
    let eastMatch;
    let northMatch;

    let match = patternDegrees.exec(text);
    let message = text.match(regexMessage);
    message = message[0].slice(separator.length, message.length - separator.length - 1);

    while (match !== null) {
        if (match[1].toLowerCase() === 'north') {
            northMatch = match;
        } else {
            eastMatch = match;
        }
        match = patternDegrees.exec(text);
    }
    
    let p1 = document.createElement('p');
    p1.innerHTML = `${northMatch[2]}.${northMatch[3]} N`;

    let p2 = document.createElement('p');
    p2.innerHTML = `${eastMatch[2]}.${eastMatch[3]} E`;

    let p3 = document.createElement('p');
    p3.innerHTML = `Message: ${message}`;

    resultElement.appendChild(p1);
    resultElement.appendChild(p2);
    resultElement.appendChild(p3);
}