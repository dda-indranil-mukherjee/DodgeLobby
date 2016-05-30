using Dodge.Lobby.Framework.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace Dodge.Lobby.Framework.SessionManager
{
    public class CookieHelper
    {

        public static void WriteCookie(string userId,string userName,bool isPersistent)
        {
            try
            {
                DateTime cookieTimeOut = (isPersistent) ? DateTime.Now.AddMinutes(ConfigHelper.FormsAuthenticationRememberMeTimeout) : DateTime.Now.AddMinutes(ConfigHelper.FormsAuthenticationTimeout);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userId, DateTime.Now, cookieTimeOut, isPersistent, userName);
                HttpCookie cookie = FormsAuthentication.GetAuthCookie(userId, isPersistent);
                cookie.Value = FormsAuthentication.Encrypt(ticket);
                //cookie.Domain = ConfigHelper.CookieDomain;
                //cookie.Path = "/";
                cookie.Expires = cookieTimeOut;

                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void RemoveCookie()
        {
            try
            {
                // clear authentication cookie
                HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName);
                cookie1.Domain = ConfigHelper.CookieDomain;
                cookie1.Path = "/";
                cookie1.Expires = DateTime.Now.AddYears(-1);
                HttpContext.Current.Response.Cookies.Add(cookie1);

                // clear session cookie
                HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId");
                cookie2.Expires = DateTime.Now.AddYears(-1);
                HttpContext.Current.Response.Cookies.Add(cookie2);

                FormsAuthentication.SignOut();

                // Invalidate the Cache on the Client Side
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                HttpContext.Current.Response.Cache.SetNoStore();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
