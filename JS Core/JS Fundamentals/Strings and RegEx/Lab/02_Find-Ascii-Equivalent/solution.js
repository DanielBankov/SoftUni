function solve() {
  let text = document.getElementById('text').value;
  let result = document.getElementById('result');
  let parts = text.split(' ').filter(a => a !== '');
  let numbers = '';
  let p = '';
  
  parts.forEach(part => {
    p = document.createElement('p');
    let words = '';

    if (isNaN(+part)) {
      // This is not a number
      words += [...part].map(ch => ch.charCodeAt()).join(' ');
      words += '\n';
      p.innerHTML = words;
    } else {
      numbers += String.fromCharCode(+part);
    }
    result.appendChild(p);
  });
  p.innerHTML = numbers;
}

document.getElementById('my-button').addEventListener('click', solve, false);