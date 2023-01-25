const dialog = document.querySelector('.layout__dialog');
//Buttons
const btnFechaModal = document.querySelector('.dialog__close');
const btnConfirm = document.querySelector('.dialog__confirm');

//Message
const message = document.querySelector('.dialog__message');

export class modal {
    OpenModal(text, hideConfirm = true) {
        message.innerHTML = text;
        btnConfirm.ariaHidden = hideConfirm;
        dialog.showModal();
    }
    CloseModal() {
        btnFechaModal.addEventListener('click', (e) => {
           this.DialogClose();            
        })
    }
    DialogClose(){
        message.innerHTML = "";
        dialog.close();
    }
}