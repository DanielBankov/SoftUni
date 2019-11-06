function solve() {
    let selectConvertTo = document.getElementById('selectMenuTo');

    let binaryOption = document.createElement("option");
    binaryOption.textContent = 'Binary';

    let hexadecimalOption = document.createElement("option");
    hexadecimalOption.textContent = 'Hexadecimal';

    selectConvertTo.appendChild(binaryOption);
    selectConvertTo.appendChild(hexadecimalOption);

    let convertButton = document.getElementsByTagName('button')[0];

    convertButton.addEventListener('click', function () {
        let selectedValue = selectConvertTo.value;
        let decimalNumber = document.getElementById('input').value;
        let resultElement = document.getElementById('result');
        let result;

        if (selectedValue == 'Binary') {
            result = decimalToBinary(Number(decimalNumber));
            resultElement.setAttribute('value', result.toString());
        }
        else if (selectedValue == 'Hexadecimal') {
            result = decimalToHexadecimal(Number(decimalNumber));
            resultElement.setAttribute('value', result.toString());
        }

        function decimalToBinary(number) {
            return (number >>> 0).toString(2);
        }

        function decimalToHexadecimal(number) {
            return number.toString(16);
        }

        document.querySelector('#result').value = result;
    });
}