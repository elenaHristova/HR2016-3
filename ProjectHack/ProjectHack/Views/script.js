var elements = document.querySelectorAll("#home-toggles a");

for (var i = 0; i < elements.length; i++) {
    elements[i].onclick = function (element) {
        console.log(element);
        element.srcElement.classList.add("login");
        for (var j = 0; j < elements.length; j++) {
            if (element.srcElement !== elements[j]) {
                elements[j].classList.remove("login");
            }
        }
    }
}
