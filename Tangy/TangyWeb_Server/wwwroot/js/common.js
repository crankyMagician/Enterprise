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