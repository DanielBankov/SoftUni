function solve() {
	let input = document.getElementById('input').value;
	var sum = GetSingleSumNumber(input);

	function GetSingleSumNumber(input) {
		let result = input;	
		sum = 0;
		
		while (result.length > 1) {
			for (let i = 0; i < result.length; i++) {
				sum += +result[i];
			}
			
			result = sum.toString();
			sum = 0;
		}
		return result;
	}

	let splicedInput = input.slice(sum, input.length - sum);
	
	function fromBinaryToChar(binary) { 
		let decimal = parseInt(binary, 2);
		let char = String.fromCharCode(decimal);
		return char;
	 }

	 let output = splicedInput.split(/([\d]{8})/g)
							  .filter(a => a !== '')
							  .map(ch => fromBinaryToChar(ch))
							  .filter(el => /[a-zA-Z ]+/g.test(el))
							  .join('');

	 document.getElementById('resultOutput').textContent = output;
}