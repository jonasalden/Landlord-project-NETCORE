$(document).ready(function ()
{
    var rentalContainer = $('#rental-application-container');
    var stepOneInput = $('#application-stepOne input');
    var stepTwoInput = $('#application-stepTwo input');
    var stepTwo = $('#application-stepTwo');
    var stepThree = $('#application-stepThree');

    $('#intresseanmalan').on('click', function () {
        $.ajax({
            url: "/Home/RentalApplication/",
            type: "GET",
            data: { residenceId: $('#Id').val() },
            success: function (data)
            {
                rentalContainer.toggleClass('active');

                if (rentalContainer.hasClass('active')) {
                    rentalContainer.html(data);
                    rentalContainer.removeAttr('hidden');
                }
                else {
                    rentalContainer.attr('hidden', 'hidden');
                    rentalContainer.empty();
                }

                $('#residenceApplication-form a').click(function () {
                    if ($(this).hasClass('disabled')) {
                        return false;
                    }
                });

                var count = 0;

                stepOneInput.on('blur', function () {
                    count = 0;

                    stepOneInput.each(function () {
                        if (!$(this).val()) {
                            stepTwo.parent('.form-group').find('a').addClass('disabled');
                            stepTwo.collapse("hide");
                            stepTwo.parent('.form-group').find('svg').removeClass('fa-lock-open').addClass('fa-lock');

                            stepThree.parent('.form-group').find('a').addClass('disabled');
                            stepThree.collapse("hide");
                            stepThree.parent('.form-group').find('svg').removeClass('fa-lock-open').addClass('fa-lock');

                            return false;
                        }
                        else { count++; }
                        if (count >= 5)
                        {
                            stepTwo.parent('.form-group').find('a').removeClass('disabled');
                            stepTwo.parent('.form-group').find('svg').removeClass('fa-lock').addClass('fa-lock-open');
                            stepTwo.collapse("show");
                        }
                    });
                });

                stepTwoInput.on('blur', function () {
                    count = 0;

                    stepTwoInput.each(function () {
                        if (!$(this).val()) {
                            stepThree.parent('.form-group').find('a').addClass('disabled');
                            stepThree.collapse("hide");
                            stepThree.parent('.form-group').find('svg').removeClass('fa-lock-open').addClass('fa-lock');

                            return false;
                        }
                        else { count++; }
                        if (count >= 5) {
                            stepThree.parent('.form-group').find('a').removeClass('disabled');
                            stepThree.parent('.form-group').find('svg').removeClass('fa-lock').addClass('fa-lock-open');
                            stepThree.collapse("show");
                        }
                    });
                })
            }
        });
    });

    var activateForm = $('#ActivateRegisterForm').val();
    if (activateForm === 'True') {
        $('#intresseanmalan').click();
    }
});

