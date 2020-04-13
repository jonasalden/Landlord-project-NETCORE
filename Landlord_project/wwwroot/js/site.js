function LoadingScreen(show) {
    if (show === true) {
        $('body').append('<div id="landlord-backdrop"><img id="landlord-backdrop-spinner" src="~/wwwroot/images/spinner.gif" /></div>');
    }
    else {
        $('#landlord-backdrop').remove();
    }
}