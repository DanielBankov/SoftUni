function solve() {
    let divKeys = Array.from(document.getElementsByClassName('keys'));
    let expressionOutput = document.getElementById('expressionOutput');
    let resultOutput = document.getElementById('resultOutput');
    let clearBtn = document.getElementsByClassName('clear')[0].addEventListener('click', clear);
    let currentClicked;

    for (let index = 0; index < divKeys.length; index++) {
        divKeys[index].addEventListener('click', clickBtn);
    }

    function clickBtn(e) {
        let targetValue = e.target.value;

        if(targetValue === '*' || targetValue === '/' || targetValue === '+' || targetValue === '-'){
            expressionOutput.textContent += ' ' + targetValue + ' ';
        }
        else{
            if(targetValue === '='){
                calculate();
                return;
            }
            currentClicked = targetValue;
            expressionOutput.textContent += currentClicked;
        }

        function calculate() {
            let splitedContent = expressionOutput.textContent;
            let numbers = splitedContent.match(/\d*\.*\d+/g);
            let operation = splitedContent.match(/[\+\*\-\/]/g)[0];
            let firstNum = +numbers[0];
            let secondNum = +numbers[1];
            let result;

            switch (operation) {
                case '+':
                    result = firstNum + secondNum;
                    break;
                case '-':
                    result = firstNum - secondNum;
                    break;
                case '*':
                    result = firstNum * secondNum;
                    break;
                case '/':
                    result = firstNum / secondNum;
                    break;
            }

            resultOutput.textContent = result;
            return;
        }
    }

    function clear() {
        expressionOutput.textContent = '';
        resultOutput.textContent = '';
    }

}