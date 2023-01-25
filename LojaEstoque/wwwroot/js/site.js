const Theme = {
    body: document.querySelector('body'),
    button: document.querySelector(".btn-theme"),
    spans: Array.from(document.querySelector(".theme-mode").querySelectorAll("span")),
    Select() {
        this.button.addEventListener("click", (e) => {
            let active = this.button.ariaChecked === "true";
            this.ChangeTheme(active);
        })
        this.spans.forEach((span) => {
            span.addEventListener("click", (e) => {
                let active = this.button.ariaChecked === "true";
                this.ChangeTheme(active);
            })
        })
    },
    ChangeTheme(active) {
        if (!active) {
            this.button.ariaChecked = true;
            this.body.id = "dark";
            localStorage.setItem("theme", this.body.id);
            localStorage.setItem("btnStatus", this.button.ariaChecked);
        }
        else {
            this.button.ariaChecked = false;
            this.body.id = "light";
            localStorage.setItem("theme", this.body.id);
            localStorage.setItem("btnStatus", this.button.ariaChecked);
        }

    },
    SetTheme() {
        let theme = localStorage.getItem("theme");
        let btnStatus = localStorage.getItem("btnStatus");
        if (theme == null || btnStatus == null) return;

        this.body.id = theme;
        this.button.ariaChecked = btnStatus;
    }
}

Theme.Select();

window.addEventListener("load", (e) => {
    Theme.SetTheme();
})