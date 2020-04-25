$(document).ready(function () {
    $('#intresseanmalan').on('click', function () {
        $.ajax({
            url: "/Home/RentalApplication/",
            type: "GET",
            data: { residenceId: $('#Id').val() },
            success: function (data) {
                $('#rental-application-container').toggleClass('active');

                if ($('#rental-application-container').hasClass('active')) {
                    $('#rental-application-container').html(data);
                    $('#rental-application-container').removeAttr('hidden');
                }
                else {
                    $('#rental-application-container').attr('hidden', 'hidden');
                    $('#rental-application-container').empty();
                }
            }
        });
    });

    var activateForm = $('#ActivateRegisterForm').val();
    if (activateForm === 'True') {
        $('#intresseanmalan').click();
    }
});