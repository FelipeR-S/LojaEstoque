import { modal } from './modal.js';
const modalClass = new modal();
modalClass.CloseModal();
modalClass.Confirm();

const Search = {
    input: document.querySelector('.header__busca--input'),
    autocomplete: document.querySelector('.autocomplete'),
    autocompleteOptions: Array.from(document.querySelector('.autocomplete').querySelectorAll('li')),
    searchButton: document.querySelector('.header__busca--button'),
    produtos: Array.from(document.querySelectorAll('.itens--item')),
    InputListener(){
        this.input.addEventListener('keyup', (e) => {
            this.autocompleteOptions.forEach((item) =>{
                if(!item.innerText.toLowerCase().startsWith(this.input.value.toLowerCase() || this.input.value != "")){
                    item.ariaHidden = true;
                }
                else
                    item.ariaHidden = false;
            })
        })
    },
    GetProduto(){
        this.searchButton.addEventListener('click', (e) => {
            if (this.input.value == "") return;
            var item = this.produtos.find(i => i.querySelector(".item__nome").innerText.toLowerCase() == this.input.value.toLowerCase())
            if (item == null){
                alert("Produto não encontrado!")
                this.produtos.forEach((item) => item.ariaHidden = false);
                return;
            } 
            this.produtos.forEach((item) => item.ariaHidden = true);
            item.ariaHidden = false;
        })
    },
    AutoComplete(){
        this.autocompleteOptions.forEach((item) => {
            item.addEventListener('click', (e) => {
                this.input.value = item.innerText;
                console.log(this.input)
            })
        })
    }
}

const Produto = {
    produtos: Array.from(document.querySelectorAll('.itens--item')),
    Excluir(){
        this.produtos.forEach((produto) => {
            let btn = produto.querySelector(".item__actions--delete");
            btn.addEventListener('click', (e) => {
                let id = produto.querySelector('.item__id');
                let nome = produto.querySelector('.item__nome');
                modalClass.OpenModal(`Deseja realmente excluír o produto abaixo? <br> ID: ${id.innerText} | Nome: ${nome.innerText}`);
            })
        })
    }
}

window.addEventListener("load", (e) => {
    if (mensagemServer != null && mensagemServer != "") modalClass.OpenModal(mensagemServer, true);
})

Produto.Excluir();
Search.InputListener();
Search.GetProduto();
Search.AutoComplete();