using FluentValidation;
using Landlord_project.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landlord_project.Models.Validators
{
    public class ResidenceApplicationValidator : AbstractValidator<ResidenceApplication>
    {
        public ResidenceApplicationValidator()
        {
            RuleFor(rm => rm.Tenant.FirstName)
                .Matches("^[^0-9]+$").WithMessage("Inga siffror i förnamet")
                .NotEmpty().WithMessage("Du måste ange ett förnamn")
                .Length(1, 75).WithMessage("Ange förnamn i korrekt format");

            RuleFor(rm => rm.Tenant.LastName)
                .Matches("^[^0-9]+$").WithMessage("Inga siffror i förnamet")
                .NotEmpty().WithMessage("Du måste ange ett efternamn")
                .Length(1, 75).WithMessage("Ange efternamn i korrekt format");

            RuleFor(rm => rm.Tenant.Phone)
                .NotEmpty().WithMessage("Du måste ange ett telefonnummer")
                .Matches("^[0-9,-]*$").WithMessage("Ange telefonnummer i korrekt format")
                .Length(8, 15).WithMessage("Ange ett nummer i korrekt längd");

            RuleFor(rm => rm.Tenant.Email)
        .EmailAddress().WithMessage("Ange giltig epostadress")
        .NotEmpty().WithMessage("Email får inte vara tomt")
        .Length(4, 100).WithMessage("Ange korrekt längd på epostadress");

            RuleFor(rm => rm.Tenant.SocialSecurityNumber)
                .NotEmpty().WithMessage("Ange giltigt personnummer")
                .Matches("^[0-9,-]*$").WithMessage("Ange personnummer i korrekt format")
                 .Length(10, 25).WithMessage("Ange korrekt längd på personnummret");

            RuleFor(rm => rm.Tenant.Age)
            .NotEmpty().WithMessage("Ange en ålder");
        }
    }
}
