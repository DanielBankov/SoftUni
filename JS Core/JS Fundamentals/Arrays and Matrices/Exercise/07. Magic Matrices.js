function solve(matrix) {
    let sum = 0;
    let arr = [];

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            sum += matrix[row][col];
        }

        arr.push(sum);
        sum = 0;
    }

    if (arr.every(sum => sum === arr[0])) {
        console.log(true);
    } else {
        console.log(false);
    }
}

solve([
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]
]);

solve([
    [11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]
]);

solve([
    [1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]
]);