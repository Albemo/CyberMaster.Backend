using CyberMaster.Backend.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CyberMaster.Backend.Infrastructure.Services.Token
{
    public interface IJWTTokenGeneratorService
    {
        string GenerateToken(User user, IList<string> roles, IList<Claim> claims);
    }
}
