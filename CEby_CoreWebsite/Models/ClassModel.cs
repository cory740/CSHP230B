using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEby_CoreWebsite.Models
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
