function solve() {
    let typesObj = {};

    for (let arg of arguments) {
        let type = typeof arg;

        console.log(`${type}: ${arg}`);

        if (typesObj[type]) {
            typesObj[type]++;
        } else {
            typesObj[type] = 1;
        }
    }

    typesObj = Object.entries(typesObj).sort((a, b) => b[1] - a[1]).forEach(element => {
        console.log(`${element[0]} = ${element[1]}`);
    });
    
}

solve('cat', 42, function () { console.log('Hello world!'); });