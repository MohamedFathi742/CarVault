using CarVault.Application.DTOs.Requests;
using CarVault.Application.DTOs.Responses;
using CarVault.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.Interfaces;
public interface IUserRepository
{

    Task<IEnumerable<UserWithRoleResponse?>> GetAllUseresAsync();
    Task<ApplicationUser?> GetUserByIdAsync(string userId);
    Task<ApplicationUser?> GetUserByEmailAsync(string email);
    Task<ApplicationUser?> GetUserWithOrdersAsync(string userId);
    Task<ApplicationUser?> UpdateUserAsync(UpdateUserRequest request,string userId);
   Task DeleteUserAsync(string userId);
    Task<PaginationResponse<ApplicationUser>> GetPagedAsync(UserFilterRequest  userFilter);

}
