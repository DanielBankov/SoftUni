function solve(numbers) {
    let evenNumbers = "";

    for(let number = 0; number < numbers.length; number++){
        if(number % 2 === 0){
            evenNumbers += ' ' + numbers[number];
        }
    }

    return evenNumbers;
}

console.log(solve(['20', '30', '40']));