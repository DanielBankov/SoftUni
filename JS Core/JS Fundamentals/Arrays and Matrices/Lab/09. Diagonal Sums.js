function solve(matrix) {
    let firstDiagonal = 0;
    let secondDiagonal = 0;

    for (let row = 0; row < matrix.length; row++) {


        firstDiagonal += matrix[row][row];
        secondDiagonal += matrix[row][matrix[row].length - row - 1];
    }

    console.log(firstDiagonal + " " + secondDiagonal);
}

solve([
    [20, 40],
    [10, 60]
]);

solve([
    [3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]
]);