function solve(number) {
    number = number.toString();
    let firstElement = number[0];
    let sum = +firstElement;
    let trueOrFalse = true;

    for (let i = 1; i < number.length; i++) {
        
        if (firstElement !== number[i]){
            trueOrFalse = false;
        }
        sum += +number[i];
    }
    console.log(trueOrFalse);
    console.log(sum);
}

solve(22222);
solve(1234);