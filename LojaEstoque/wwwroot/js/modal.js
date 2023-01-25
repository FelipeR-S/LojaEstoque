const dialog = document.querySelector('.layout__dialog');
//Buttons
const btnFechaModal = document.querySelector('.dialog__close');
const btnConfirma = document.querySelector('.dialog__confirm');

//Message
const message = document.querySelector('.dialog__message');

export class modal {
    OpenModal(text, hideConfirma = false) {
        message.innerHTML = text;
        btnConfirma.ariaHidden = hideConfirma;
        dialog.showModal();
    }
    CloseModal() {
        btnFechaModal.addEventListener('click', (e) => {
            message.innerHTML = "";
            dialog.close();
        })
    }
    Confirm() {
        btnConfirma.addEventListener('click', (e) => {
            console.log(location.href)
        })
    }
}