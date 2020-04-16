using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Landlord_project.Models.Validators
{
    public class FileValidator : AbstractValidator<IFormFile>
    {
        public FileValidator()
        {
            RuleFor(x => x.ContentType)
                .Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png") || x.Equals("image/jpeg") || x.Equals("image/tif"))
                .WithMessage("Choose correct file format");
        }
    }
}
