import { modal } from './modal.js';
const modalClass = new modal();
modalClass.CloseModal();

const Search = {
    input: document.querySelector('.header__busca--input'),
    autocomplete: document.querySelector('.autocomplete'),
    autocompleteOptions: Array.from(document.querySelector('.autocomplete').querySelectorAll('li')),
    searchButton: document.querySelector('.header__busca--button'),
    produtos: Array.from(document.querySelectorAll('.itens--item')),
    show: document.querySelector('.exibe--btn'),
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
            this.produtos.forEach((item) => item.ariaHidden = false);
            if (this.input.value == "") return;
            var item = null;
            var item = this.produtos.find(i => i.querySelector(".item__nome").innerText.toLowerCase() == this.input.value.toLowerCase())
            if (item == null){
                modalClass.OpenModal("Produto não encontrado!");
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
                item.ariaHidden = true;
            })
        })
    },
    ShowAll(){
        this.show.addEventListener('click', (e) => {
            this.produtos.forEach((item) => item.ariaHidden = false);
        })
    }
}

const Produto = {
    confirmDelete: document.querySelectorAll('.item__actions--confirm'),
    delete: document.querySelector('.dialog__confirm'),
    element: "",
    DeleteWarning(){
        this.confirmDelete.forEach((btn) => {
            let parent = btn.parentElement.parentElement;
            let id = parent.querySelector('.item__id').innerText;
            let nome = parent.querySelector('.item__nome').innerText;
            btn.addEventListener('click', (e) => {
                modalClass.OpenModal(`Deseja realmente excluír o produto abaixo:<br>ID: ${id} | ${nome}.`, false);
                this.element = parent;
            });
        })
    },
    ConfirmDelete(){
        this.delete.addEventListener('click', (e) =>{
            modalClass.DialogClose();
            let link = this.element.querySelector('.item__actions--delete');
            link.click();
        })        
    }
}

window.addEventListener("load", (e) => {
    if (mensagemServer != null && mensagemServer != "") 
        modalClass.OpenModal(mensagemServer);
})

Search.InputListener();
Search.GetProduto();
Search.AutoComplete();
Search.ShowAll();

Produto.DeleteWarning();
Produto.ConfirmDelete();