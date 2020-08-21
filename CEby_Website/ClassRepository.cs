using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CEby_Website.Data;
using Microsoft.Data.SqlClient.Server;

namespace CEby_Website
{
    public class DatabaseAccessor
    {

        static DatabaseAccessor()
        {
            Instance = new minicstructorContext();
        }

        public static minicstructorContext Instance { get; private set; }
    }

    public interface IClassRepository
    {
        ClassModel[] ForClass(int classId);
    }

    public class ClassModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public decimal ClassPrice { get; set; }
    }

    public class ClassRepository : IClassRepository
    {

        public ClassModel[] ForClass(int classId)
        {
            return DatabaseAccessor.Instance.Class
                    .Where(t => t.ClassId == classId)
                    .Select(t => new ClassModel
                    {
                        ClassId = t.ClassId,
                        ClassName = t.ClassName,
                        ClassDescription = t.ClassDescription,
                        ClassPrice = t.ClassPrice
                    })
                    .ToArray();
        }
    }

}