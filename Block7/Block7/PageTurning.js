let timer = false;

function appendElements() {
	let container = document.createElement('div'),
		previousPage = document.createElement('button'),
		timerButton = document.createElement('button'),
		icon1 = document.createElement('i'),
		icon2 = document.createElement('i');

	icon1.classList.add("btn");
	icon1.classList.add("fa");
	icon1.classList.add("fa-backward");

	previousPage.addEventListener('click', back);
	previousPage.appendChild(icon1);

	icon2.classList.add("btn");
	icon2.classList.add("fa");
	icon2.classList.add("fa-stop");

	timerButton.setAttribute('id', "timerBtn");
	timerButton.addEventListener('click', timerControl);
	timerButton.addEventListener('click', timerButtonStyle)
	timerButton.appendChild(icon2);

	container.appendChild(previousPage);
	container.appendChild(timerButton);

	document.body.appendChild(container);

	timerControl();
}

function timerControl() {
	let ref = document.getElementById('path');

	if (ref === null) {
		clearInterval(timer);
		timer = false;
		if (confirm('press "OK" to go to first page')) {
			window.history.go(-2);
		} else {
			self.close();
		}
	} else if (timer === false) {
		timer = setInterval(function () {
			//todo close window
			window.location.href = ref.href;
		}, 3000);
	} else {
		clearInterval(timer);
		timer = false;
	}
}

function timerButtonStyle(event) {
	let timerbutton = event.target,
		icon = document.getElementById('timerBtn').firstChild;


	if (icon.className === "btn fa fa-stop") {
		timerbutton.classList.remove("fa-stop");
		timerbutton.classList.add("fa-play");
	} else {
		timerbutton.classList.remove("fa-play");
		timerbutton.classList.add("fa-stop");
	}
}

function back() {
	window.history.back()
}