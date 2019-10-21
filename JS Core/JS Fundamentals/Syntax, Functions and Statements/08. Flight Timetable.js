function solve(inputArr){
    let flightInfo = inputArr[0];
    let town = inputArr[1];
    let time = inputArr[2];
    let flightNumber = inputArr[3];
    let gateNumber = inputArr[4];

    console.log(`${flightInfo}: Destination - ${town}, Flight - ${flightNumber}, Time - ${time}, Gate - ${gateNumber}`);
}

solve(['Departures', 'London', '22:45', 'BR117', '42']);