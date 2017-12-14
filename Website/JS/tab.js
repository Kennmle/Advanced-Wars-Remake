//Jesus chirst why is all of this hard coded. I'll fix it later
let currentTab = 1;

function tab(x) {
	document.getElementById("tab"+currentTab).className = "hidden";
	document.getElementById("side"+currentTab).className = "inactive";
	document.getElementById("side"+x).className = "active";
	document.getElementById("tab"+x).className = "current";
	currentTab = x;
}

function switchColor(str) {
	document.getElementById("colorScheme").href = "./stylesheets/colors/"+str+".css";
}

function dropDownShow() {
	document.getElementById("dropMenu").className = "dropCurrent";
}
function dropDownHide() {
	document.getElementById("dropMenu").className = "hidden";
}

function getRandomInt(min, max) {
  return Math.floor(Math.random() * (max - min)) + min;
}
