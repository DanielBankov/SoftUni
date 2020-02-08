function solution() {
    let obj = {
        carbohydrate: 0,
        protein: 0,
        fat: 0,
        flavour: 0
    };

    let errorObj = {
        carbohydrate: 'Error: not enough carbohydrate in stock',
        protein: 'Error: not enough protein in stock',
        fat: 'Error: not enough fat in stock',
        flavour: 'Error: not enough flavour in stock'
    };

    return function (args) {
        let command = args.split(' ')[0];
        let element = args.split(' ')[1];
        let qty = +args.split(' ')[2];

        if (command === 'restock') {
            obj[element] += qty;
            console.log('Success');
        } else if (command === 'prepare') {

            if (element === 'apple') {

                if (obj.carbohydrate < qty) {
                    console.log(errorObj.carbohydrate);
                    return;
                }
                if (obj.flavour < (qty * 2)) {
                    console.log(errorObj.flavour);
                    return;
                }

                obj.carbohydrate -= qty;
                obj.flavour -= (qty * 2);
                console.log('Success');

            } else if (element === 'lemonade') {

                if (obj.carbohydrate < (qty * 10)) {
                    console.log(errorObj.carbohydrate);
                    return;
                }
                if (obj.flavour < (qty * 20)) {
                    console.log(errorObj.flavour);
                    return;
                }

                obj.carbohydrate -= (qty * 10);
                obj.flavour -= (qty * 20);
                console.log('Success');

            } else if (element === 'burger') {

                if (obj.carbohydrate < (qty * 5)) {
                    console.log(errorObj.carbohydrate);
                    return;
                }
                if (obj.fat < (qty * 7)) {
                    console.log(errorObj.fat);
                    return;
                }
                if (obj.flavour < (qty * 3)) {
                    console.log(errorObj.flavour);
                    return;
                }

                obj.carbohydrate -= (qty * 5);
                obj.fat -= (qty * 7);
                obj.flavour -= (qty * 3);
                console.log('Success');

            } else if (element === 'eggs') {

                if (obj.protein < (qty * 5)) {
                    console.log(errorObj.protein);
                    return;
                }
                if (obj.fat < qty) {
                    console.log(errorObj.fat);
                    return;
                }
                if (obj.flavour < qty) {
                    console.log(errorObj.flavour);
                    return;
                }

                obj.carbohydrate -= (qty * 5);
                obj.fat -= qty;
                obj.flavour -= qty;
                console.log('Success');

            } else if (element === 'turkey') {
                if (obj.carbohydrate < (qty * 10)) {
                    console.log(errorObj.carbohydrate);
                    return;
                }
                if (obj.fat < (qty * 10)) {
                    console.log(errorObj.fat);
                    return;
                }
                if (obj.flavour < (qty * 10)) {
                    console.log(errorObj.flavour);
                    return;
                }
                if (obj.protein < (qty * 10)) {
                    console.log(errorObj.carbohydrate);
                    return;
                }

                obj.carbohydrate -= (qty * 10);
                obj.fat -= (qty * 10);
                obj.flavour -= (qty * 10);
                obj.protein -= (qty * 10);
                console.log('Success');
            }
        } else if(command === 'report'){
            console.log(`protein=${obj.protein} carbohydrate=${obj.carbohydrate} fat=${obj.fat} flavour=${obj.flavour}`);
        }
    };
}

let manager = solution();
manager('restock carbohydrate 10');
manager('restock flavour 10');
manager('prepare apple 1');
manager('restock fat 10');
manager('prepare burger 1');
manager('report');
