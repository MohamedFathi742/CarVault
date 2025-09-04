using CarVault.Application.DTOs.Requests;
using CarVault.Application.DTOs.Responses;
using CarVault.Application.Interfaces;
using CarVault.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarVault.Infrastructure.Repositories;
public class UserRepository (UserManager<ApplicationUser> userManager ): IUserRepository
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public async Task<UserResponse?> GetUserByIdAsync(string userId)
    {
        return await _userManager.Users
           .Where(u => u.Id == userId)
           .ProjectToType<UserResponse>()
           .AsNoTracking()
           .FirstOrDefaultAsync();

    }
    public async Task<UserResponse?> GetUserByEmailAsync(string email)
    {
        return await _userManager.Users
            .Where(u => u.Email == email)
            .ProjectToType<UserResponse>()
            .AsNoTracking()
            .FirstOrDefaultAsync();
      



    }

  

    public async Task<UserResponse?> GetUserWithOrdersAsync(string userId)
    {
        var user = await _userManager.Users
            .Where(u => u.Id == userId)
            .Include(u => u.Orders)
            .ProjectToType<UserResponse>()
            .AsNoTracking()
            .FirstOrDefaultAsync();
        return user;

    }

    public async Task<UserResponse?> UpdateUserAsync(UpdateUserRequest request, string userId)
    {
  var user=await _userManager.FindByIdAsync(userId);
        if (user is null)
            return null;

        user.FullName=request.FullName;
        user.Address=request.Address;
        user.ProfileImage=request.ProfileImage;
        await _userManager.UpdateAsync(user);
        return user.Adapt<UserResponse>();

    }
}
