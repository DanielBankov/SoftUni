function solve() {
  let text = document.getElementById('text').value;
  let convention = document.getElementById('naming-convention').value;

  function PascalOrCamel(text, convention) {
    let words = text.split(' ').filter(a => a !== '');
    let output = '';

    if (convention === 'Pascal Case' || convention === 'Camel Case') {
      words.forEach(word => {
        output += word[0].toUpperCase() + word.substr(1, word.length - 1).toLowerCase();
      });

      if (convention === 'Camel Case') {
        output = output[0].toLowerCase() + output.substr(1);
      }
    } else {
      output = "Error!";
    }

    document.getElementById('result').innerHTML = output;
  }

  PascalOrCamel(text, convention);
}