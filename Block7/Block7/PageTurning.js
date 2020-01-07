function appendElements() {
	let container = document.createElement('div'),
		previousPage = document.createElement('a'),
		timerButton = document.createElement('button'),
		timer = document.createElement('span');

	previousPage.setAttribute('href', document.referrer);
	previousPage.innerHTML = "Go to previous page";
	previousPage.setAttribute('class', 'button');
	timer.setAttribute('id', 'timer');

	container.appendChild(previousPage);
	container.appendChild(timerButton);
	container.appendChild(timer);

	document.body.appendChild(container);

	setInterval(function () {
		let timer = 5000;

		if (timer < 0) {
			window.location.href = '../Task2/Task2.html';
			document.getElementById("timer").innerHTML = timer;
		}
	}, timer);
}