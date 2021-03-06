﻿using System;
using System.Collections.Generic;

namespace CEby_CoreWebsite.Data
{
    public partial class User
    {
        public User()
        {
            UserClass = new HashSet<UserClass>();
        }

        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public bool UserIsAdmin { get; set; }

        public virtual ICollection<UserClass> UserClass { get; set; }
    }
}
