using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;

namespace CEby_Website.Models
{
    public class ClassModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public decimal ClassPrice { get; set; }

        public ClassModel(int classId, string name, string description, decimal price)
        {
            ClassId = classId;
            ClassName = name;
            ClassDescription = description;
            ClassPrice = price;
        }
    }
}