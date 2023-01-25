import { modal } from './modal.js';
const modalClass = new modal();
modalClass.CloseModal();

//Controla elementos da busca de produtos
const Search = {
    input: document.querySelector('.header__busca--input'),
    autocomplete: document.querySelector('.autocomplete'),
    autocompleteOptions: Array.from(document.querySelector('.autocomplete').querySelectorAll('li')),
    searchButton: document.querySelector('.header__busca--button'),
    produtos: Array.from(document.querySelectorAll('.itens--item')),
    show: document.querySelector('.exibe--btn'),
    InputListener(){
        //Exibe resultados equivalentes de acordo com o digitado
        this.input.addEventListener('keyup', (e) => {
            this.autocompleteOptions.forEach((item) =>{
                //Compara valor de input com lista
                if(!item.innerText.toLowerCase().startsWith(this.input.value.toLowerCase() || this.input.value != "")){
                    item.ariaHidden = true;
                }
                else
                    item.ariaHidden = false;
            })
        })
    },
    //Retorna produto de acordo com a busca
    GetProduto(){
        this.searchButton.addEventListener('click', (e) => {
            this.produtos.forEach((item) => item.ariaHidden = false);
            if (this.input.value == "") return; //Retorna caso valor for vazio
            var item = null;
            //Busca na lista de produtos se há algum equivalente com a busca
            var item = this.produtos.find(i => i.querySelector(".item__nome").innerText.toLowerCase() == this.input.value.toLowerCase())
            if (item == null){
                //Exibe mensagem caso busca não gerar nenhum resultado
                modalClass.OpenModal("Produto não encontrado!");
                return;
            }
            //Mostra produto encontrado
            this.produtos.forEach((item) => item.ariaHidden = true);
            item.ariaHidden = false;
        })
    },
    //Seleciona item do autocomplete
    AutoComplete(){
        this.autocompleteOptions.forEach((item) => {
            item.addEventListener('click', (e) => {
                this.input.value = item.innerText;
                item.ariaHidden = true;
            })
        })
    },
    //Mostra todos os produtos
    ShowAll(){
        this.show.addEventListener('click', (e) => {
            this.produtos.forEach((item) => item.ariaHidden = false);
        })
    }
}

//Controla algumas ações relativo aos produtos
const Produto = {
    confirmDelete: document.querySelectorAll('.item__actions--confirm'),
    delete: document.querySelector('.dialog__confirm'),
    element: "",
    //Exibe aviso antes de deletar produto
    DeleteWarning(){
        this.confirmDelete.forEach((btn) => {
            let parent = btn.parentElement.parentElement;
            let id = parent.querySelector('.item__id').innerText;
            let nome = parent.querySelector('.item__nome').innerText;
            //Aguarda click no botão de excluir
            btn.addEventListener('click', (e) => {
                modalClass.OpenModal(`Deseja realmente excluír o produto abaixo:<br>ID: ${id} | ${nome}.`, false);
                this.element = parent;
            });
        })
    },
    //Metodo para chamar action que deleta produto
    ConfirmDelete(){
        this.delete.addEventListener('click', (e) =>{
            modalClass.DialogClose();
            let link = this.element.querySelector('.item__actions--delete');
            link.click();
        })        
    }
}

window.addEventListener("load", (e) => {
    //Verifica se há alguma mensagem para ser exibida após o load
    if (mensagemServer != null && mensagemServer != "") 
        modalClass.OpenModal(mensagemServer);
})

Search.InputListener();
Search.GetProduto();
Search.AutoComplete();
Search.ShowAll();

Produto.DeleteWarning();
Produto.ConfirmDelete();