function solve(numbers) {
    let length = numbers[0];
    let additionElements = numbers[1];
    let newArr = [1];
    
    for (let index = 1; index < length ; index++) {
        let buffer = index - additionElements;
        let sum = 0;
        
        if(buffer < 0)
        {
            for (let sumIndex = 0; sumIndex < index; sumIndex++) {
                sum += newArr[sumIndex];
            }
        }
        else{
           for (let summIndex = index - 1; summIndex >= buffer; summIndex--) {
               sum += newArr[summIndex];
           }
        }
        
        newArr.push(sum);
    }

    console.log(newArr.join(' '));
}

solve([8, 2]);
solve([6, 3]);
solve([9, 5]);