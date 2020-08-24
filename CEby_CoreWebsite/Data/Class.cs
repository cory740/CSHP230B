﻿using System;
using System.Collections.Generic;

namespace CEby_CoreWebsite.Data
{
    public partial class Class
    {
        public Class()
        {
            UserClass = new HashSet<UserClass>();
        }

        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public decimal ClassPrice { get; set; }

        public virtual ICollection<UserClass> UserClass { get; set; }
    }
}
