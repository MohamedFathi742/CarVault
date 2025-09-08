using CarVault.Application.DTOs.Requests;
using FluentValidation;

namespace CarVault.Application.Validatores;
public class CreateCarImageRequestValidator:AbstractValidator<CreateCarImageRequest>
{
    public CreateCarImageRequestValidator()
    {
        RuleFor(x => x.CarId)
           .GreaterThan(0).WithMessage("CarId must be greater than 0.");

        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("Image URL is required.")
           // .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
            .WithMessage("Image URL must be a valid URL.");
    }
}
