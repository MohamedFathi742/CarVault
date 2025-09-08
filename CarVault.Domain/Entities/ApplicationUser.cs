using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Domain.Entities;
public sealed class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? ProfileImage { get; set; }

    public ICollection<Car> Cars { get; set; } = [];
    public ICollection<Order> Orders { get; set; } = [];
}
