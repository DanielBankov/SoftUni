function solve(array) {
    let steps = array.pop(array[array.length - 1]);

    for (let index = 0; index < array.length; index += +steps) {
        console.log(array[index]);
    }
}

solve(['5', '20', '31', '4', '20', '2']);
solve(['dsa', 'asd', 'test', 'tset', '2']);
solve(['1', '2', '3', '4', '5', '6']);