using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Dodge.Lobby.Data;

namespace Dodge.Lobby.Web.Models
{
    public class UserLoginInfo
    {
        [Required]
        [Display(Name = "User Name")]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool Remember { get; set; }

        public long UserId { get; set; }
        public string UserName{get;set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public bool IsValid(string username, string password)
        {
            try
            {
                Login myLogin = new Login();
                dynamic res = myLogin.Authenticate(username + ":" + password);

                if (res != null)
                {
                    this.UserId = Convert.ToInt64(res["user-profile"]["@user-id"].Value);
                    this.UserName = res["user-profile"]["@user-name"].Value;
                    this.FirstName = res["user-profile"]["@first-name"].Value;
                    this.LastName = res["user-profile"]["@last-name"].Value;
                    this.MiddleName = res["user-profile"]["@middle-name"]==null ? "" : res["user-profile"]["@middle-name"].Value;

                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }           
        }
    }
}