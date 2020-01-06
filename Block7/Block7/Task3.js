selectionMenu.onclick = function (event) {
	if (event.target.tagName != "LI") return;

	if (event.ctrlKey || event.metaKey) {
		toggleSelect(event.target);
	} else {
		singleSelect(event.target);
	}
}

selectionMenu.onmousedown = function () {
	return false;
};

function toggleSelect(li) {
	li.classList.toggle('selected');
}

function singleSelect(li) {
	let selected = selectionMenu.querySelectorAll('.selected');

	for (let elem of selected) {
		elem.classList.remove('selected');
	}
	li.classList.add('selected');
}

function moveItems(sourceId, destId, querySelector) {
	let sourceList = document.getElementById(sourceId),
		allItems = sourceList.querySelectorAll(querySelector),
		destList = document.getElementById(destId);

	for (var i = 0; i < allItems.length; i++) {
		destList.appendChild(allItems[i]);
		allItems[i].classList.remove('selected');
	}
}