function solve(numbers) {
    let count = numbers.shift();
    let firstNumbersK = numbers.slice(0, count);
    let lastNumbersK = numbers.slice(numbers.length - count, numbers.length);

    console.log(firstNumbersK.join(' '));
    console.log(lastNumbersK.join(' '));
}

solve([3, 6, 7, 8, 9]);