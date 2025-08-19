using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.Models.InputModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Win32;
using NuGet.Protocol.Plugins;

namespace BusinessLayer.AuthServices
{
    public interface IAuthService
    {
        Task<IEnumerable<IdentityError>> Register(Register register);

        Task<object> Login(Login login);
    }
}
