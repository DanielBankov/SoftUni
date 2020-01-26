function solve(array) {  
    let rotation = array.pop();

    for (let index = 0; index < rotation % array.length; index++) {
        array.unshift(array.pop());
    }
    
    console.log(array.join(" "));
}

solve(['1', '2', '3', '4', '2']);
solve(['Banana', 'Orange', 'Coconut', 'Apple', '15']);