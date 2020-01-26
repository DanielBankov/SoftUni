function solve(numbers) {
    let newArray = [];

    for (let i = 0; i < numbers.length; i++) {
        numbers[i] < 0 ? newArray.unshift(numbers[i]) : newArray.push(numbers[i]);
    }

    console.log(newArray.join('\n'));
}

solve([3, -2, 0, -1]);