using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ProFinalEstudiantes
{
    public static class AuthManager
    {
        public static void Login(string userId, HttpContextBase context)
        {
            var ticket = new FormsAuthenticationTicket(
                1,
                userId,
                DateTime.Now,
                DateTime.Now.AddMinutes(30),
                false,
                userId
            );

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            context.Response.Cookies.Add(cookie);
        }
    }
}