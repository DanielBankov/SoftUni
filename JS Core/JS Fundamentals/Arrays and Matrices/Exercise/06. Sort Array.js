function solve(array) {
    console.log(array.join('\n', array.sort((a, b) => a.length - b.length || a.toLowerCase().localeCompare(b.toLowerCase()))));
}

solve(['alpha', 'beta', 'gamma']);
solve(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']);
solve(['alpha', 'beta', 'gamma']);