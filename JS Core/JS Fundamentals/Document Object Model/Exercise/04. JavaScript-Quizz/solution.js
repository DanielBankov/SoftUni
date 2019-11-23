function solve() {
  let sectionsElemet = document.getElementsByTagName('section');
  let answersElement = Array.from(document.getElementsByClassName('answer-text'));
  let resultElement = document.getElementById('results');
  let indexSection = 0;
  let points = 0;

  let correctAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];

  for (let answer of answersElement) {
    answer.addEventListener("click", onClick);
  }

  function onClick() {
    if (this.textContent === correctAnswers[0]) {
      points++;
    } else if (this.textContent === correctAnswers[1]) {
      points++;
    } else if (this.textContent === correctAnswers[2]) {
      points++;
    }

    let resultMessageElement = document.getElementsByClassName('results-inner')[0];
    let resultMessage = resultMessageElement.children[0];
    indexSection++;

    if (indexSection === 3) {
      sectionsElemet[indexSection - 1].style.display = 'none';
      resultElement.style.display = 'block';

      if (points === 3) {
        resultMessage.textContent = 'You are recognized as top JavaScript fan!';
      } else {
        resultMessage.textContent = `You have ${points} right answers`;
      }

    } else {
      sectionsElemet[indexSection - 1].style.display = 'none';
      sectionsElemet[indexSection].style.display = 'block';
    }
  }
}