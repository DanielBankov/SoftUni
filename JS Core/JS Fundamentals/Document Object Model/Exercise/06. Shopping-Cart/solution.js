function solve() {
   let addBtns = Array.from(document.getElementsByClassName('add-product'));
   let checkoutBtn = document.getElementsByClassName('checkout')[0];
   let textArea = document.getElementsByTagName('textarea')[0];
   let totalPrice = 0;
   let cartProducts = [];

   for (let productAddBtn of addBtns) {
      productAddBtn.addEventListener('click', addClick);
   }

   checkoutBtn.addEventListener('click', checkout);

   function checkout() {
      textArea.textContent += `You bought ${cartProducts.join(', ')} for ${totalPrice.toFixed(2)}.`;

      for (let productAddBtn of addBtns){
         productAddBtn.disabled = true;
      }
      checkoutBtn.disabled = true;
   }

   function addClick() {
      let productName = this.parentElement.parentElement.getElementsByClassName('product-title')[0].textContent;
      let productPrice = this.parentElement.parentElement.getElementsByClassName('product-line-price')[0].textContent;
      totalPrice += +productPrice;

      if (!cartProducts.includes(productName)) {
         cartProducts.push(productName);
      }

      textArea.textContent += `Added ${productName} for ${productPrice} to the cart.\n`;
      console.log(textArea.textContent);
   }
}