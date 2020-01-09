let timer = false;

function appendElements() {
	let container = document.createElement('div'),
		previousPage = document.createElement('button'),
		timerButton = document.createElement('button'),
		icon = document.createElement('i');

	previousPage.addEventListener('click', back);
	previousPage.innerHTML = "Go to previous page";
	previousPage.setAttribute('class', "back");

	icon.classList.add("fas");
	icon.classList.add("fa-stop-circle");

	timerButton.setAttribute('id', "timerBtn");
	timerButton.addEventListener('click', timerControl);
	timerButton.addEventListener('click', timerButtonStyle)
	timerButton.appendChild(icon);

	container.appendChild(previousPage);
	container.appendChild(timerButton);

	document.body.appendChild(container);

	timerControl();
}

function timerControl() {
	let ref = document.getElementById('path');

	if (timer === false) {
		timer = setInterval(function () {
			window.location.href = ref.href;
		}, 5000);
	} else {
		clearInterval(timer);
		timer = false;
	}
}

function timerButtonStyle(event) {
	let timerbutton = event.target,
		icon = document.getElementsByTagName('i');

	if (icon[0].className === "fas fa-stop-circle") {
		timerbutton.classList.remove("fa-stop-circle");
		timerbutton.classList.add("fa-play-circle");
	} else {
		timerbutton.classList.remove("fa-play-circle");
		timerbutton.classList.add("fa-stop-circle");
	}
}

function back() {
	window.history.back()
}