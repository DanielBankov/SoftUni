function solve(numbers) {
    var newArr = [];

    for (let index = numbers.length; index > 0; index--) {
        if (index % 2 === 1) {
            newArr.push(numbers[index] * 2);
        }
    }

    console.log(newArr.join(' '));
}

solve([10, 15, 20, 25]);
solve([3, 0, 10, 4, 7, 3]);