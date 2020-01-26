function solve(array) {  
    let outputArr = [];

    for (let index = 0; index < array.length; index++) {
        
        if(array[index] === 'add'){
            outputArr.push(index + 1);
        }
        else {
            outputArr.pop(outputArr[index - 1]);
        }
    }

    outputArr.length == 0 ? console.log("Empty") : console.log(outputArr.join("\n"));
}

solve(['add', 'add', 'add', 'add']);
solve(['add', 'add', 'remove', 'add', 'add']);
solve(['remove', 'remove', 'remove']);