using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.DTOs.Requests;
public record class RegisterUserRequest
(
 string FullName ,
 string Email ,
 string Password ,
 string? Address,
 IFormFile? ProfileImage 
    
 );