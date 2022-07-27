function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.watchPosition(showPosition);
    } else {
        x.innerHTML = "Geolocation is not supported by this browser.";
    }
}

function showPosition(position) {
    debugger
    var userLatt = position.coords.latitude;
    var userLong = position.coords.longitude;
    var marker = L.marker([userLatt, userLong]).addTo(myMap);

}