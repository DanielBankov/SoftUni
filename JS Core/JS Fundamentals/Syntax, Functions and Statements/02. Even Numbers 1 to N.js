function solve(number) {
    let num = +number; // with this '+' in front of 'number' cast string to number

    for (let i = 1; i <= number; i++){
        if(i % 2 == 0){
            console.log(i);
        }
    }
  }

solve(5);