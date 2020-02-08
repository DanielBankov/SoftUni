function solution() {
    let string = '';

    function append(str) {
        string += str;
    }

    function removeStart(n) {
        string = string.substr(n);
    }

    function removeEnd(n) {
        string = string.substr(0, string.length - n);
    }

    function print() {
        console.log(string);
    }

    return {
        append,
        removeStart,
        removeEnd,
        print
    };
}

let firstZeroTest = solution();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();

let person = {
    name: 'gosho',
    sayHi: function () {
        console.log(this.name + 'says hi');
    }
};

let secondPerson = {
    name: 'pesho'
};

person.sayHi.call(secondPerson); // calling the secondPerson obj and involke sayHi wit 'pesho'
console.log(Math.max.call(null, 1,2,3,4,5)); // null is context *(so we dont have context)
person.sayHi.apply(secondPerson); // calling the secondPerson obj and involke sayHi wit 'pesho' but with array parameters
console.log(Math.max.apply(null, [1,2,3,4,5])); // null is context *(so we dont have context)
let varr = person.sayHi.bind(secondPerson); // bind dont invoke func but creates a copy in varaiable 