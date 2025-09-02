using CarVault.Application.DTOs.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.Validatores;
public class CreateOrderRequestValidator:AbstractValidator<CreateOrderRequest>
{
    public CreateOrderRequestValidator()
    {
        RuleFor(o => o.UserId)
            .NotEmpty().WithMessage("UserId is required.");

        RuleFor(o => o.CarId)
            .GreaterThan(0).WithMessage("CarId must be a valid ID.");
    }
}
