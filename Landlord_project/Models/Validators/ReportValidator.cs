using FluentValidation;

namespace Landlord_project.Models.Validators
{
	public class ReportValidator : AbstractValidator<ReportModel>
	{
		public ReportValidator()
		{
			RuleFor(rm => rm.FirstName)
				.Matches("^[^0-9]+$").WithMessage("Inga siffror i förnamet")
				.NotEmpty().WithMessage("Du måste ange ett förnamn")
				.Length(1, 75).WithMessage("Ange förnamn i korrekt format");

			RuleFor(rm => rm.LastName)
				.Matches("^[^0-9]+$").WithMessage("Inga siffror i förnamet")
				.NotEmpty().WithMessage("Du måste ange ett efternamn")
				.Length(1, 75).WithMessage("Ange efternamn i korrekt format");

			RuleFor(rm => rm.Phone)
				.NotEmpty().WithMessage("Du måste ange ett telefonnummer")
				.Matches("^[0-9,-]*$").WithMessage("Ange telefonnummer i korrekt format")
				.Length(8, 15).WithMessage("Ange ett nummer i korrekt längd");
			
			RuleFor(rm => rm.Email)
				.EmailAddress().WithMessage("Ange giltig epostadress")
				.NotEmpty().WithMessage("Email får inte vara tomt")
				.Length(4, 100).WithMessage("Ange korrekt längd på epostadress");

			RuleFor(rm => rm.Description)
				.NotEmpty().WithMessage("Beskrivning får inte vara tomt")
				.Length(5, 2000).WithMessage("Ange en välformulerad beskrivning");

			RuleFor(rm => rm.HousingNumber)
				.NotEmpty().WithMessage("Fastighetsnummer får inte vara tomt")
				.Length(1, 15).WithMessage("Ange giltigt fastighetsnummer");
			// Börjat med FLUENT VALIDATION.
			//RuleFor(x => x.Age).InclusiveBetween(18, 60);

			RuleFor(x => x.Image).SetValidator(new FileValidator());
		}
	}
}
