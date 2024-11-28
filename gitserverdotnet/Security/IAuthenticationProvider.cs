using System.Collections.Generic;
using System.Security.Claims;

using Owin;

namespace gitserverdotnet.Security
{
    public interface IAuthenticationProvider
    {
        void Configure(IAppBuilder app);
        void SignIn(string username, string returnUrl, bool rememberMe);
        void SignOut();
        IEnumerable<Claim> GetClaimsForUser(string username);
    }
}