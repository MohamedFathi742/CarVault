using CarVault.Application.DTOs.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.Validatores;
public class LoginUserRequestValidator:AbstractValidator<LoginUserRequest>
{
    public LoginUserRequestValidator()
    {

        RuleFor(u => u.Email).NotEmpty().EmailAddress();
        RuleFor(u => u.Password).NotEmpty().MinimumLength(8);
    }
}

