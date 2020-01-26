function solve(array) {
    var delimer = array.pop(array[array.length - 1]);
    
    console.log(array.join(delimer));
}

solve(['One', 'Two', 'Three', 'Four', 'Five', '-']);
solve(['How about no?', 'I', 'will', 'not', 'do', 'it!', '_']);