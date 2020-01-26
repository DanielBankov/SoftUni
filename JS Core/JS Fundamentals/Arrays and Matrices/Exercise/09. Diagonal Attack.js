function solve(matrix) {
    let firstDiagonal = 0;
    let secondDiagonal = 0;

    let numberMatrix = matrix.map(row => row.split(' ').map(Number));

    for (let row = 0; row < numberMatrix.length; row++) {
        firstDiagonal += numberMatrix[row][row];
        secondDiagonal += numberMatrix[row][numberMatrix[row].length - row - 1];
    }

    if (firstDiagonal === secondDiagonal) {
        for (let row = 0; row < numberMatrix.length; row++) {
            for (let col = 0; col < numberMatrix[row].length; col++) {
                if (row !== col && numberMatrix[row].length - 1 - row !== col) {
                    numberMatrix[row][col] = firstDiagonal;
                }
            }
        }

        numberMatrix.forEach(element => {
            console.log(element.join(' '));
        });
    } else {
        matrix.forEach(element => {
            console.log(element);
        });
    }
}


solve(['5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1']);

solve(['1 1 1',
        '1 1 1',
        '1 1 0']);