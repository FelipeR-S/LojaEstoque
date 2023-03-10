const inputValor = document.querySelector('.produto--valor');
const form = document.querySelector('.form-cadastro');

//Previne que valores sejam enviador incorretamente
form.addEventListener('submit', (e) => {
    e.preventDefault();
    let regex = new RegExp("^[0-9]{1,3},[0-9]{1,2}$");
    if (!regex.test(inputValor.value)){
        return;
    }

    inputValor.value = inputValor.value.replace(',', '.');
    form.submit();
})

//Previne que caracteres incorretos sejam inseridos
inputValor.addEventListener('keypress', (e) => {
    let regex = new RegExp("[0-9]");

    if(!regex.test(e.key) && e.key != ","){
        e.preventDefault()
    } 
})
