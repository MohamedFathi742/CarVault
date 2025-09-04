using CarVault.Application.DTOs.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.Validatores;
public class UpdateCarRequestValidator:AbstractValidator<UpdateCarRequest>
{
    public UpdateCarRequestValidator()
    {
        RuleFor(c => c.Model)
            .NotEmpty().WithMessage("Model is required.")
            .MaximumLength(100).WithMessage("Model must not exceed 100 characters.");

        RuleFor(c => c.Brand)
            .NotEmpty().WithMessage("Brand is required.")
            .MaximumLength(100).WithMessage("Brand must not exceed 100 characters.");

        RuleFor(c => c.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");

        //RuleFor(c => c.CategoryId)
        //    .GreaterThan(0).WithMessage("CategoryId must be a valid ID.");

        //RuleForEach(c => c.CarImages)
        //    .NotEmpty().WithMessage("Image URL cannot be empty.")
        //    .MaximumLength(500).WithMessage("Image URL must not exceed 500 characters.");
    }
}
