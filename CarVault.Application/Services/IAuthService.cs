using CarVault.Application.DTOs.Requests;
using CarVault.Application.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.Services;
public interface IAuthService
{
    Task<AuthResponse> RegisterUserAsync(RegisterUserRequest request, string role);
    Task<AuthResponse> LoginUserAsync(LoginUserRequest request);
    

}
