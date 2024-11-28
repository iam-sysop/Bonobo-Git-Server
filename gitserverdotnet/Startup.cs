using System;
using System.Web.Mvc;

using Microsoft.Owin;

using Owin;
using gitserverdotnet.Security;

[assembly: OwinStartup(typeof(gitserverdotnet.Startup))]

namespace gitserverdotnet
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            DependencyResolver.Current.GetService<IAuthenticationProvider>().Configure(app);
        }
    }
}
