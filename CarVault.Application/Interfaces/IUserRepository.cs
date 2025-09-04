using CarVault.Application.DTOs.Requests;
using CarVault.Application.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.Interfaces;
public interface IUserRepository
{
    Task<UserResponse?> GetUserByIdAsync(string userId);
    Task<UserResponse?> GetUserByEmailAsync(string email);
    Task<UserResponse?> GetUserWithOrdersAsync(string userId);
    Task<UserResponse?> UpdateUserAsync(UpdateUserRequest request,string userId);
   

}
