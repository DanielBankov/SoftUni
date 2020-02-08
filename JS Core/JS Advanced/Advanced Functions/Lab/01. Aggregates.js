function aggregate(arr) {
    console.log('Sum = ', reducer(arr, (a, b) => a + b, 0));
    console.log('Min = ', reducer(arr, (a, b) => Math.min(a, b), Number.MAX_SAFE_INTEGER));
    console.log('Max = ', reducer(arr, (a, b) => a > b ? a : b, Number.MIN_SAFE_INTEGER));
    console.log('Product = ', reducer(arr, (a, b) => a * b, 1));
    console.log('Join = ', reducer(arr, (a, b) => a.toString() + b.toString(), ''));
}

function reducer(arr, operator, initial) {
    let result = initial;

    for(let elem of arr){
        result = operator(result, elem);
    }

    return result;
}

aggregate([5, -3, 20, 7, 0.5]);