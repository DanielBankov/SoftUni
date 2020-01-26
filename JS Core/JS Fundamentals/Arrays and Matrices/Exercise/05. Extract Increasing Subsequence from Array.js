function solve(array) {
    let nonDecreasingArr = [array[0]];
    let lastIn = array[0];

    for (let index = 0; index < array.length - 1; index++) {

        if (array[index] < array[index + 1] && lastIn < array[index + 1]) {
            nonDecreasingArr.push(array[index + 1]);
            lastIn = array[index + 1];
        }
    }

    console.log(nonDecreasingArr.join('\n'));
}

solve([1, 3, 8, 4, 10, 12, 3, 2, 24]);
solve([20, 3, 2, 15, 6, 1]);