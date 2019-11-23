function solve() {
  let furnitureListJson = document.getElementsByTagName('textarea')[0];
  let resultTextBox = document.getElementsByTagName('textarea')[1];
  let generateBtn = document.getElementsByTagName('button')[0].addEventListener('click', generate);
  let buyBtn = document.getElementsByTagName('button')[1].addEventListener('click', buy);
  let table = document.getElementsByTagName('tbody')[0];
  document.getElementsByTagName("input")[0].disabled = false;

  function generate() {
    let furnitureList = JSON.parse(furnitureListJson.value); 

    for (let i = 0; i < furnitureList.length; i++) {
      let child = table.appendChild(document.getElementsByTagName("tr")[1].cloneNode(true));
      
      child.getElementsByTagName('td')[0].innerHTML = `<img src=${furnitureList[i]["img"]}>`;
      child.getElementsByTagName('td')[1].innerHTML = `<p>${furnitureList[i]["name"]}</p>`;
      child.getElementsByTagName('td')[2].innerHTML = `<p>${furnitureList[i]["price"]}</p>`;
      child.getElementsByTagName('td')[3].innerHTML = `<p>${furnitureList[i]["decFactor"]}</p>`;
      child.getElementsByTagName('td')[4].innerHTML = `<input type="checkbox">`;
    }
  }

  function buy() {
    let productNames = [];
    let totalPrice = 0;
    let averageDecFactor = 0;
    let trElementsCount = table.children.length;
    
    for (let index = 0; index < trElementsCount; index++) {
      let trElement = table.children[index];
      let tdLastElement = trElement.children.length;      
      let checkBox = Array.from(trElement.getElementsByTagName('td'))[tdLastElement - 1].children[0];

      let productName = trElement.getElementsByTagName('p')[0].textContent;
      let productPrice = trElement.getElementsByTagName('p')[1].textContent;
      let decorationFactor = trElement.getElementsByTagName('p')[2].textContent;

      if(checkBox.checked){
          productNames.push(productName);
          totalPrice += +productPrice;
          averageDecFactor += +decorationFactor;
      }
    }

    resultTextBox.textContent += `Bought furniture: ${productNames.join(', ')}\n`;
    resultTextBox.textContent += `Total price: ${totalPrice.toFixed(2)}\n`;
    resultTextBox.textContent += `Average decoration factor: ${averageDecFactor / productNames.length}`;

  }
}