using CarVault.Application.DTOs.Requests;
using CarVault.Application.DTOs.Responses;
using CarVault.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.Services;
public interface IUserService
{
    Task<PaginationResponse<UserResponse>> GetPagedAsync(UserFilterRequest userFilter);
    Task<IEnumerable<UserResponse?>> GetAllUseresAsync();
    Task<UserResponse?> GetUserByIdAsync(string userId);
    Task<UserResponse?> GetUserByEmailAsync(string email);
    Task<UserResponse?> GetUserWithOrdersAsync(string userId);
    Task<UserResponse?> UpdateUserAsync(UpdateUserRequest request, string userId);
    Task DeleteUserAsync(string userId);



}
