function solve() {
   let clicks = 0;
   let doc = document.querySelector('button').addEventListener('click', () => {
      let paragraph = document.querySelector('#exercise p');  

      clicks++;
      paragraph.style.fontSize = `${clicks * 2}px`;

      if(clicks % 3 === 1){
         paragraph.style.color = 'blue';
      }
      else if(clicks % 3 === 2){
         paragraph.style.color = 'green';
      }
      else if(clicks % 3 === 0){
         paragraph.style.color = 'red';
      }
      
   });
}