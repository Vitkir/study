let timer = false,
	delay = 3000,
	pages = [],
	currentPageIndex = 0;

$(document).ready(function appendElements() {
	let container = $('<div></div>'),
		previousPage = $('<button></button>'),
		timerButton = $('<button></button>'),
		showsTimer = $('<div></div>'),
		iconBack = $('<i></i>'),
		iconStop = $('<i></i>');

	iconBack.addClass("btn fa fa-backward");

	previousPage.append(iconBack);
	previousPage.on('click', back);

	iconStop.addClass("btn fa fa-stop");

	timerButton.attr('id', "timerBtn");
	timerButton.append(iconStop);
	timerButton.on('click', timerControl);
	timerButton.on('click', timerButtonStyle);

	showsTimer.attr('id', 'showTimer');

	container.append(previousPage, timerButton, showsTimer);

	$('body').append(container);

	createPagesList();
	getPageData(pages[0]);
	timerControl();
})

function timerControl() {
	let showTimer = $('#showTimer'),
		count;
	if (timer === false) {
		count = delay / 1000;
		changeTimerPresentation(showTimer, count);
		timer = setInterval(function () {
			if (count === 0) {
				currentPageIndex++;
				if (pages[currentPageIndex] == null) {
					//clearInterval(timer);
					//timer = false;
					if (confirm('press "OK" to go to first page')) {
						currentPageIndex = 0;
						getPageData(pages[currentPageIndex]);
						count = delay / 1000;
					} else {
						//todo close window
					}
				} else {
					getPageData(pages[currentPageIndex]);
					count = delay / 1000;
				}
			} else {
				count = count - 1;
				changeTimerPresentation(showTimer, count);
			}
		}, 1000);
	} else {
		clearInterval(timer);
		timer = false;
	}
}

function timerButtonStyle(event) {
	let timerbutton = event.target,
		icon = $('#timerBtn').first();

	if (icon.className === "btn fa fa-stop") {
		timerbutton.classList.remove("fa-stop");
		timerbutton.classList.add("fa-play");
	} else {
		timerbutton.classList.remove("fa-play");
		timerbutton.classList.add("fa-stop");
	}
}

function changeTimerPresentation(showTimer, count) {
	showTimer.html(count + ' seconds until next page');
}

function createPagesList() {
	pages.push("DeleteDoubleLetters.html");
	pages.push("Calculate.html");
	pages.push("SelectionMenu.html");
}

function back() {
	currentPageIndex--;
	getPageData(pages[currentPageIndex]);
}

function getPageData(url) {
	let data = url + " #content,script";
	$('#content').load(data);
}