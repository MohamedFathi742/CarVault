using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.DTOs.Responses;
public record AuthResponse
(

 string Id,
 string FullName,
 string Email,
 string? Address,
 string? ProfileImage,
 string? Role,
 string? Token




 );
