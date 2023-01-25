const dialog = document.querySelector('.layout__dialog');
//Buttons
const btnFechaModal = document.querySelector('.dialog__close');
const btnConfirm = document.querySelector('.dialog__confirm');

//Message
const message = document.querySelector('.dialog__message');

export class modal {
    //Abre dialog Modal
    OpenModal(text, hideConfirm = true) {
        message.innerHTML = text;
        btnConfirm.ariaHidden = hideConfirm;
        dialog.showModal();
    }
    //Aguarda click no botão de fechar
    CloseModal() {
        btnFechaModal.addEventListener('click', (e) => {
           this.DialogClose();            
        })
    }
    //Fecha modal
    DialogClose(){
        message.innerHTML = "";
        dialog.close();
    }
}