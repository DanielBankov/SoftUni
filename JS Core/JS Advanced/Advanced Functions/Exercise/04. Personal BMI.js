function bmi(name, age, weight, height) {
    let obj = {
        name,
        personalInfo: {
            age,
            weight,
            height
        },
        BMI: (weight / Math.pow(height / 100, 2)).toFixed(0),
        status: ''
    };

    if(obj.BMI < 1.85){
        obj.status = 'underweight'; 
    } else if (obj.BMI < 25){
        obj.status = 'normal';
    } else if (obj.BMI < 30){
        obj.status = 'overweight';
    } else if (obj.BMI > 29){
        obj.status = 'obese';
        obj.recommendation = 'admission required';
    }

    return obj;
}

console.log(bmi('Peter', 29, 75, 182));