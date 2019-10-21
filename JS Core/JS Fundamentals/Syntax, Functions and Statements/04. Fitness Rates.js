function solve(day, service, time) {
    if (service === 'Fitness') {
        if (time <= 15.00) {
            switch (day) {
                case 'Monday':
                    console.log(5.00);
                    break;
                case 'Tuesday':
                    console.log(5.00);
                    break;
                case 'Wednesday':
                    console.log(5.00);
                    break;
                case 'Thurstday':
                    console.log(5.00);
                    break;
                case 'Friday':
                    console.log(5.00);
                    break;
                case 'Saturday':
                    console.log(8.00);
                    break;
                case 'Sunday':
                    console.log(8.00);
                    break;
            }
        } else {
            switch (day) {
                case 'Monday':
                    console.log(7.50);
                    break;
                case 'Tuesday':
                    console.log(7.50);
                    break;
                case 'WednesDay':
                    console.log(7.50);
                    break;
                case 'Thurstday':
                    console.log(7.50);
                    break;
                case 'Friday':
                    console.log(7.50);
                    break;
                case 'Saturday':
                    console.log(8.00);
                    break;
                case 'Sunday':
                    console.log(8.00);
                    break;
            }
        }
    } else if (service === 'Sauna') {
        if (time <= 15.00) {
            switch (day) {
                case 'Monday':
                    console.log(4.00);
                    break;
                case 'Tuesday':
                    console.log(4.00);
                    break;
                case 'WednesDay':
                    console.log(4.00);
                    break;
                case 'Thurstday':
                    console.log(4.00);
                    break;
                case 'Friday':
                    console.log(4.00);
                    break;
                case 'Saturday':
                    console.log(7.00);
                    break;
                case 'Sunday':
                    console.log(7.00);
                    break;
            }
        } else {
            switch (day) {
                case 'Monday':
                    console.log(6.50);
                    break;
                case 'Tuesday':
                    console.log(6.50);
                    break;
                case 'WednesDay':
                    console.log(6.50);
                    break;
                case 'Thurstday':
                    console.log(6.50);
                    break;
                case 'Friday':
                    console.log(6.50);
                    break;
                case 'Saturday':
                    console.log(7.00);
                    break;
                case 'Sunday':
                    console.log(7.00);
                    break;
            }
        }
    } else if (service === 'Instructor') {
        if (time <= 15.00) {
            switch (day) {
                case 'Monday':
                    console.log(10.00);
                    break;
                case 'Tuesday':
                    console.log(10.00);
                    break;
                case 'WednesDay':
                    console.log(10.00);
                    break;
                case 'Thurstday':
                    console.log(10.00);
                    break;
                case 'Friday':
                    console.log(10.00);
                    break;
                case 'Saturday':
                    console.log(15.00);
                    break;
                case 'Sunday':
                    console.log(15.00);
                    break;
            }
        } else {
            switch (day) {
                case 'Monday':
                    console.log(12.50);
                    break;
                case 'Tuesday':
                    console.log(12.50);
                    break;
                case 'WednesDay':
                    console.log(12.50);
                    break;
                case 'Thurstday':
                    console.log(12.50);
                    break;
                case 'Friday':
                    console.log(12.50);
                    break;
                case 'Saturday':
                    console.log(15.00);
                    break;
                case 'Sunday':
                    console.log(15.00);
                    break;
            }
        }
    }
}

//better way solution
function solve2(day, ServiceType, time) {
    let daysArr = function (day) {
        return ['Monday', 'Tuesday', 'Wednesday', 'Thurstday', 'Friday', 'Saturday', 'Sunday'].indexOf(day);
    };

    let weekdaysServicePrices = {
        'Fitness': 5,
        'Sauna': 4,
        'Instructor': 10
    };

    let weekendsServicePrices = {
        'Fitness': 8,
        'Sauna': 7,
        'Instructor': 15
    };

    if (daysArr(day) <= 4) {
        if (time <= 15.00) {
            return weekdaysServicePrices[ServiceType];
        } else {
            return weekdaysServicePrices[ServiceType] + 2.5;
        }
    } else {
        return weekendsServicePrices[ServiceType];
    }
}


solve('Monday', 'Sauna', 15.30);
console.log(solve2('Monday', 'Sauna', 15.30));