function deleteDoubleLetters() {
	let inputText = document.getElementById('inputText').value + "",
		words = inputText.split("?").join(" ").
			split("!").join(" ").
			split(":").join(" ").
			split(";").join(" ").
			split(",").join(" ").
			split(".").join(" ").
			split("\n").join(" ").split(" "),
		repeatChars = [],
		outputText = "";

	repeatChars = words.map(getRepeatLetters);
	let i = repeatChars.length - 1;
	for (i; i >= 0; i--) {
		if (repeatChars[i].length == 0) {
			repeatChars.splice(i, 1);
		}
	}
	for (let i = 0; i < inputText.length; i++) {
		if (!repeatChars.includes(inputText[i])) {
			let char = inputText.substring(i, i + 1);
			outputText = outputText + char;
		}
	}
	document.getElementById('TextResult').innerHTML = "result: " + outputText;
}

function getRepeatLetters(text) {
	let countRepeatChars = [],
		returnStr = "";
	for (let i = 0; i < text.length; i++) {
		if (countRepeatChars[text[i]] === undefined) {
			countRepeatChars[text[i]] = 0;
		}
		countRepeatChars[text[i]]++;
	}
	for (const char in countRepeatChars) {
		if (countRepeatChars[char] > 1) {
			returnStr += char;
		}
	}
	return returnStr;
}