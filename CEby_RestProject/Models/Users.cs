using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEby_RestProject.Models
{
   
    public class Users
    {
        public int UserId 
        { 
            get
            {
                return newId;
            }
            set
            {
                string newId = DateTime.Now.Ticks.ToString("x");
            }
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
    }

}
