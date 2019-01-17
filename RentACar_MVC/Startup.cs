using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;

[assembly: OwinStartup(typeof(RentACar_MVC.Startup))]

namespace RentACar_MVC
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                CookieName = "RentACarCookie",
                ExpireTimeSpan = TimeSpan.FromDays(1),
                LoginPath = new PathString("/Account/Login")
            });
        }
    }
}
