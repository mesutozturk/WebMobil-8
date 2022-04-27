console.log("3.js");

var changeColor = () => {
    var rangeRed = document.getElementById("range-red");
    var rangeGreen = document.getElementById("range-green");
    var rangeBlue = document.getElementById("range-blue");

    var pickerDiv = document.getElementById("picker-div");

    console.log([rangeRed.value, rangeGreen.value, rangeBlue.value]);
    //var color = "rgb(" + rangeRed.value + "," + rangeGreen.value + "," + rangeBlue.value + ")";
    var color = `rgb(${rangeRed.value},${rangeGreen.value},${rangeBlue.value})`;
    var colorRev = `rgb(${255 - rangeRed.value},${255 - rangeGreen.value},${255 - rangeBlue.value})`;
    pickerDiv.innerHTML = color;
    pickerDiv.style.backgroundColor = color;
    pickerDiv.style.color = colorRev;
}

changeColor();