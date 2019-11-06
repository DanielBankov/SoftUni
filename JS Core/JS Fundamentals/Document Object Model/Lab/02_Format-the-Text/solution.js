function solve(){
  let inputParagraphValue = document.getElementById('input').textContent;
  let inputSentences = inputParagraphValue.split('.');

  let newParagraph;
  let output = document.getElementById('output');

  for(let i = 0; i < inputSentences.length - 1; i++){
    if(i % 3 == 0){
       newParagraph = document.createElement('p');
       output.appendChild(newParagraph);
      }
      
      newParagraph.textContent += inputSentences[i] + '.';
    }
}