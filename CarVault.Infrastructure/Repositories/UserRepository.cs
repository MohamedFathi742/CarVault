using CarVault.Application.DTOs.Requests;
using CarVault.Application.DTOs.Responses;
using CarVault.Application.Interfaces;
using CarVault.Domain.Entities;
using CarVault.Infrastructure.Common;
using CarVault.Infrastructure.Persistence;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarVault.Infrastructure.Repositories;
public class UserRepository(UserManager<ApplicationUser> userManager, ApplicationDbContext context) : IUserRepository
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<UserWithRoleResponse?>> GetAllUseresAsync()
    {
         var users= await _userManager.Users
            .AsNoTracking()
            .ToListAsync();

        var response = new List<UserWithRoleResponse?>();
        foreach (var user in users)
        {
            var role = await _userManager.GetRolesAsync(user);
           var userResponse = user.Adapt<UserWithRoleResponse?>();
         userResponse!.Role= role.FirstOrDefault();
            response.Add(userResponse);
        }
        return response;
    }
    public async Task<ApplicationUser?> GetUserByIdAsync(string userId)
    {
        return await _userManager.Users
           .Where(u => u.Id == userId)
            .AsNoTracking()
           .FirstOrDefaultAsync();

    }
    public async Task<ApplicationUser?> GetUserByEmailAsync(string email)
    {
        return await _userManager.Users
            .Where(u => u.Email == email)
             
            .AsNoTracking()
            .FirstOrDefaultAsync();




    }



    public async Task<ApplicationUser?> GetUserWithOrdersAsync(string userId)
    {
        var user = await _userManager.Users
            .Where(u => u.Id == userId)
            .Include(u => u.Orders)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        return user;

    }

    public async Task<ApplicationUser?> UpdateUserAsync(UpdateUserRequest request, string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user is null)
            return null;

        user.FullName = request.FullName;
        user.Address = request.Address;
        user.ProfileImage = request.ProfileImage;
        await _userManager.UpdateAsync(user);
        await _context.SaveChangesAsync();
        return user;

    }

    public async Task DeleteUserAsync(string userId)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
        await _userManager.DeleteAsync(user!);
        await _context.SaveChangesAsync();

    }

    public async Task<PaginationResponse<ApplicationUser>> GetPagedAsync(UserFilterRequest userFilter)
    {
        IQueryable<ApplicationUser> query = _context.Users.AsNoTracking();
        var users = _userManager.Users.AsQueryable();

        if (!string.IsNullOrEmpty(userFilter.Name))
        {
            query = query.Where(u => u.FullName != null && u.FullName.Contains(userFilter.Name));
        }

        if (!string.IsNullOrEmpty(userFilter.Email))
        {
            query = query.Where(u => u.Email != null && u.Email.Contains(userFilter.Email));
        }

        if (!string.IsNullOrEmpty(userFilter.Role))
        {
            var userRole = await _userManager.GetUsersInRoleAsync(userFilter.Role);

            users = users.Where(u => userRole.Select(r => r.Id).Contains(u.Id));
        }


        return await query.ToPagedResultAsync(
            userFilter,
            searchPredicate: u => u.FullName.ToLower().Contains(userFilter.Search!)


            );

    }
}