function solve() {
   let sendMessage = document.getElementById('send');
   
   sendMessage.addEventListener('click', function(){
      let chatInputElement = document.getElementById('chat_input');
      let chatInputValue = chatInputElement.value;

      if(chatInputValue){
         let newMessage = document.createElement('div');
         newMessage.setAttribute('class', 'message my-message');
         newMessage.textContent = chatInputValue;
         
         let divParent = document.getElementById('chat_messages');
         divParent.appendChild(newMessage); 
      }
      
      chatInputElement.value = '';
   });
}