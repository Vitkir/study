calculate.onclick = function () {
	let input = document.getElementById('inputExpression').value + "",
		pattern = /([/+-/*/]?)([ ]?)(([0-9]+\.[0-9]+)|[0-9]+)/g,
		exp = input.match(pattern),
		result = 0;
	for (var i = 0; i < exp.length; i++) {
		switch (exp[i][0]) {
			case "+":
				result = result + +exp[i].substring(1);
				break;
			case "-":
				result -= +exp[i].substring(1);
				break;
			case "*":
				result *= +exp[i].substring(1);
				break;
			case "/":
				result /= +exp[i].substring(1);
				break;
			default:
				result += +exp[i];
				break;
		}
	}
	document.getElementById('expressionResult').innerHTML = "result: " + result.toFixed(2);
}