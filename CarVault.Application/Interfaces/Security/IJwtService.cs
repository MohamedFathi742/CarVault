using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.Interfaces.Security;
public interface IJwtService
{
    string GenerateToken(string userId, string email, IList<string> roles);
}
