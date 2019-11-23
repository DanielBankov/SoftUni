function solve() {
   let searchField = document.getElementById('searchField');
   let searchBtn = document.getElementById('searchBtn');
   let table = document.getElementsByTagName('tbody')[0].getElementsByTagName('tr');

   searchBtn.addEventListener('click', function() {
      let searchString = searchField.value;

      for(let cell of table){
         if(cell.textContent.includes(searchString)){
            cell.className = 'select';
         }
      }

      searchField.value = '';
   });
}