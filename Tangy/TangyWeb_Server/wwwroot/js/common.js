window.ShowToastr = (type, message) => {
    console.log("JS Called");
    if (type === "success") {
        // Override global options
        toastr.success(message, 'Operation succesful',  { timeOut: 5000 })
    }
    if (type === "error") {
        // Override global options
        toastr.error(message, 'Operation failed', { timeOut: 5000 })
    }
}


window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire(
            'Success Notification!',
            message,
            'success'
        )
    }
    if (type === "error") {
        Swal.fire(
            'Error Notification!',
            message,
            'error'
        )
    }
}





function ShowDeleteConfirmationModal() {
   $('#deleteConfirmationModal').modal('show');
}

function HideDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('hide');
}

//ksa army icon
const ksaArmyIcon = L.icon({
    iconUrl: '../images/KSA_Flag.png',
    // ...
    iconSize: [60, 45],
    iconAnchor: [15, 30],
    popupAnchor: [0, -30]
});


let map;
function createMap() {
    console.log("Create map");
    map = L.map('map').setView([24.7136, 46.6753], 10);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors'
    }).addTo(map);
   
   
}


function addMarker(lat, lng) {
    L.marker([lat, lng], { icon: ksaArmyIcon }).addTo(map);
    
    console.log("Marker added");
}


function placePolygon(points) {
    console.log("points sent from c#:" + JSON.stringify(points));
    L.polygon(points).addTo(map);
    console.log("Polyggon added");
}


