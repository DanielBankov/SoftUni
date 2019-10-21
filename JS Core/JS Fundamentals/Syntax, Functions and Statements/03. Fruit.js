function solve(fruit, totalWeight, priceForKg) {
    let totalPrice = totalWeight * priceForKg;

    console.log(`I need ${totalPrice} leva to buy ${totalWeight} kilograms ${fruit}.`);
  }

solve('orange', 2500, 1.80);