using CarVault.Application.DTOs.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.Validatores;
public class UpdateOrderRequestValidator:AbstractValidator<UpdateOrderRequest>
{
    private readonly string[] allowedStatuses = { "Pending", "Completed", "Cancelled" };
    public UpdateOrderRequestValidator()
    {
        RuleFor(o => o.Status)
              .Must(status => allowedStatuses.Contains(status))
              .WithMessage($"Status must be one of the following: {string.Join(", ", allowedStatuses)}")
              .When(o => !string.IsNullOrEmpty(o.Status)); 
    }
}
