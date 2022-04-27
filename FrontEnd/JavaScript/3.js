var changeColor = () => {
    var rangeRed = document.getElementById("range-red");
    var rangeGreen = document.getElementById("range-green");
    var rangeBlue = document.getElementById("range-blue");
    var pickerDiv = document.getElementById("picker-div");

    //console.log([rangeRed.value, rangeGreen.value, rangeBlue.value]);
    //var color = "rgb(" + rangeRed.value + "," + rangeGreen.value + "," + rangeBlue.value + ")";
    var color = `rgb(${rangeRed.value},${rangeGreen.value},${rangeBlue.value})`;
    var colorRev = `rgb(${255 - rangeRed.value},${255 - rangeGreen.value},${255 - rangeBlue.value})`;
    pickerDiv.innerHTML = color;
    pickerDiv.style.backgroundColor = color;
    pickerDiv.style.color = colorRev;
}
var copyClipboard = () => { //arrow function

    Swal.fire({
        icon: 'question',
        title: 'Kopyalansın mı?',
        showCancelButton: true,
        confirmButtonText: 'Kopyala',
        cancelButtonText: `İptal`,
    }).then((result) => {
        /* Read more about isConfirmed, isDenied below */
        //console.log(result);
        if (result.isConfirmed) {
            var pickerDiv = document.getElementById("picker-div");
            navigator.clipboard.writeText(pickerDiv.innerHTML);
            Swal.fire('Kopyalandı!', pickerDiv.innerHTML, 'success')
        } else if (result.isDenied) {
            Swal.fire('İptal', 'Kopyalama işlemi iptal edildi', 'info')
        }
    })
}
changeColor();