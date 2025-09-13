using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.DTOs.Responses;
public class UserWithRoleResponse 
{

  public  string Id { get; set; }
    public string FullName{ get; set; }
    public string Email { get; set; }
    public string? Address { get; set; }
    public string? ProfileImage { get; set; }
    public string? Role { get; set; }




}


