function solve(params, sortType) {
    return sortType === 'asc' ? params.sort((a, b) => {
        return a - b;
    }) : params.sort((a, b) => {
        return b - a;
    });
}

console.log(solve([14, 7, 17, 6, 8], 'asc'));
console.log(solve([14, 7, 17, 6, 8], 'desc'));