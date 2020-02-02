function solve() {
    const users = JSON.parse(document.getElementById('arr').value);
    let result = document.getElementById('result');

    const extractName = (user) => {
        const pattern = /^[A-Z][a-z]* [A-Z][a-z]* /;
        const match = user.match(pattern);
        return match && match[0];
    };

    const extractPhoneNumber = (user) => {
        const pattern = /(\+359 [\d]{1} [\d]{3} [\d]{3})|(\+359-[\d]{1}-[\d]{3}-[\d]{3})/;
        const match = user.match(pattern);
        return match && match[0];
    };

    const extractEmail = (user) => {
        const pattern = / [a-z0-9]+@[a-z]+\.[a-z]{2,3}$/;
        const match = user.match(pattern);
        return match && match[0];
    };

    users.forEach(user => {
        let name = extractName(user);
        let phoneNumber = extractPhoneNumber(user);
        let email = extractEmail(user);

        if (!name || !phoneNumber || !email) {
            let pInvalid = document.createElement('p');
            result.appendChild(pInvalid);
            pInvalid.textContent = 'Invalid data';
        } else {
            let pName = document.createElement('p');
            let pPhoneNumber = document.createElement('p');
            let pEmail = document.createElement('p');

            pName.textContent = 'Name: ' + name;
            pPhoneNumber.textContent = 'Phone Number: ' + phoneNumber;
            pEmail.textContent = 'Email: ' + email;

            result.appendChild(pName);
            result.appendChild(pPhoneNumber);
            result.appendChild(pEmail);
        }

        let pDashes = document.createElement('p');
        pDashes.textContent = '---';
        result.appendChild(pDashes);
    });

}