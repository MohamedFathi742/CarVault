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

    public async Task<IEnumerable<UserResponse?>> GetAllUseresAsync()
    {
        return await _userManager.Users
            .ProjectToType<UserResponse>()
            .AsNoTracking()
            .ToListAsync();
    }
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
        var user = await _userManager.FindByIdAsync(userId);
        if (user is null)
            return null;

        user.FullName = request.FullName;
        user.Address = request.Address;
        user.ProfileImage = request.ProfileImage;
        await _userManager.UpdateAsync(user);
        await _context.SaveChangesAsync();
        return user.Adapt<UserResponse>();

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
      var users=  _userManager.Users.AsQueryable();

        if (!string.IsNullOrEmpty(userFilter.Name))
        {
            query = query.Where(u => u.FullName!=null&&u.FullName.Contains(userFilter.Name));
        }

        if (!string.IsNullOrEmpty(userFilter.Email))
        {
            query = query.Where(u => u.Email!=null&&u.Email.Contains(userFilter.Email));
        }

        if (!string.IsNullOrEmpty(userFilter.Role))
        {
            var userRole=await _userManager.GetUsersInRoleAsync(userFilter.Role);

            users = users.Where(u => userRole.Select(r=>r.Id).Contains(u.Id));
        }


        return await query.ToPagedResultAsync(
            userFilter,
            searchPredicate:u=>u.FullName.ToLower().Contains(userFilter.Name!)


            );

    }
}