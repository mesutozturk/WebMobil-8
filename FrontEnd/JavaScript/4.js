console.log("4.js dosyası çalıştı.");

//GeoLocation

var getLocation = () => {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition);
    } else {
        console.log("Geolocation is not supported by this browser.");
    }
}

var showPosition = (position) => {
    console.log(position);
}

// latitude: 41.044008982786345
// longitude: 29.007230753851537

//https://www.google.com/maps/@41.04400551057116,29.007235110826237,20z

//latitude: 41.04400551057116
//longitude: 29.007235110826237