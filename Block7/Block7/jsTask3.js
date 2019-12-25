selectionMenu.onclick = function (event) {
	//let ul = event.target.closest('ul');
	//if (!ul) return;

	//if (!selectionMenu.contains(ul)) return;

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