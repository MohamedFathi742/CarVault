using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.DTOs.Responses;
public record class UserResponse
(


 string Id ,
 string FullName ,
 string Email ,
 string? Address ,
 string? ProfileImage ,
 string? Role ,
 List<OrderResponse>? Orders 
    
 );