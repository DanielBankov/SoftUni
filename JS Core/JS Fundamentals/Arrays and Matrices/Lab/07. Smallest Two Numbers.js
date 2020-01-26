function solve(numbers) {
    for (let currindex = 1; currindex < numbers.length; currindex++) {
        let currElement = numbers[currindex - 1];

        for (let index = currindex; index < numbers.length; index++) {
            let nextElement = numbers[index];

            if (currElement > nextElement) {
                let temp = nextElement;
                numbers[index] = numbers[currindex - 1];
                numbers[currindex - 1] = temp;

                currindex--;
                break;
            }
        }
    }

    let smallestTwoNums = numbers.slice(0, 2);
    console.log(smallestTwoNums.join(" "));
}

solve([30, 15, 50, 5]);
solve([3, 0, 10, 4, 7, 3]);