using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CEby_RestProject.Models
{
   
    public class Users
    {
        public int UserId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
    }

}
