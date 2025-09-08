using CarVault.Application.DTOs.Requests;
using CarVault.Application.DTOs.Responses;
using CarVault.Application.Interfaces.Security;
using CarVault.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace CarVault.Application.Services;
public class AuthService(IJwtService jwtService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : IAuthService
{
    private readonly IJwtService _jwtService = jwtService;
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
    public async Task<AuthResponse> RegisterUserAsync(RegisterUserRequest request, string role)
    {
        var user = request.Adapt<ApplicationUser>();

        user.UserName = request.Email;

        var createUser = await _userManager.CreateAsync(user, request.Password);
        if (!createUser.Succeeded)
            throw new Exception(string.Join(",", createUser.Errors.Select(e => e.Description)));

        await _userManager.AddToRoleAsync(user, role);

        var roles = await _userManager.GetRolesAsync(user);

        var token = _jwtService.GenerateToken(user.Id, user.Email!, roles);

        var result = user.Adapt<AuthResponse>() with
        {
            Role = roles.FirstOrDefault(),
            Token = token

        };
        return result;
    }
    public async Task<AuthResponse> LoginUserAsync(LoginUserRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
               throw new UnauthorizedAccessException("Invalid Credentails");

        var check = await _signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: false);
        if (!check.Succeeded)
        {
            throw new UnauthorizedAccessException("Invalid Credentails");
        }
        
                var roles = await _userManager.GetRolesAsync(user);
        var token = _jwtService.GenerateToken(user.Id, user.Email!, roles);

        return new AuthResponse
        (
          user.Id,
            user.FullName,
            user.Email!,
          user.Address,
            user.ProfileImage,
            roles.FirstOrDefault() ?? string.Empty,
             token

         );



    }

}
