using CarVault.Application.DTOs.Requests;
using CarVault.Application.DTOs.Responses;
using CarVault.Application.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.Services;
public class UserService(IUserRepository repository):IUserService
{
    private readonly IUserRepository _repository = repository;

    public async Task<IEnumerable<UserWithRoleResponse?>> GetAllUseresAsync()
    {
       var users= await _repository.GetAllUseresAsync();
        return users.Adapt<IEnumerable<UserWithRoleResponse?>>();
    }
    public async Task<UserResponse?> GetUserByIdAsync(string userId)
    {
      var user=await _repository.GetUserByIdAsync(userId) ?? throw new Exception("Not Found");
        return user.Adapt<UserResponse?>();
    }


    public async Task<UserResponse?> GetUserByEmailAsync(string email)
    {
        var user= await _repository.GetUserByEmailAsync(email) ?? throw new Exception("Not Found");
        
        return user.Adapt<UserResponse?>();
    }


    public async Task<UserWithOrderResponse?> GetUserWithOrdersAsync(string userId)
    {
       var user= await _repository.GetUserWithOrdersAsync(userId) ?? throw new Exception("Not Found");
        return user.Adapt<UserWithOrderResponse?>();
     
    }



    public async Task<UserResponse?> UpdateUserAsync(UpdateUserRequest request, string userId)
    {
        var user = await _repository.UpdateUserAsync(request, userId) ?? throw new Exception("Not Found");
        return user.Adapt<UserResponse?>();
    }
    public async Task DeleteUserAsync(string userId)
    {
      await _repository.DeleteUserAsync(userId);
    }

    public async Task<PaginationResponse<UserResponse>> GetPagedAsync(UserFilterRequest userFilter)
    {
       var result=await _repository.GetPagedAsync(userFilter);
        return result.Adapt<PaginationResponse<UserResponse>>();
    }
}
