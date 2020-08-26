using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CEby_Website
{
    public interface IEnrollClassRepository
    {
        EnrollClassModel Add(int userId, int classId);
        bool Remove(int userId, int classId);
        List<EnrollClassModel> GetEnrolledClasses(int userId);
    }

    public class EnrollClassModel
    {
        public int UserId { get; set; }
        public int ClassId { get; set; }
    }

    public class EnrollClassRepository : IEnrollClassRepository
    {
        public EnrollClassModel Add(int userId, int classId)
        {
            
            var newClass = DatabaseAccessor.Instance.UserClass.First(t => t.ClassId == classId);
            var enrollClass = DatabaseAccessor.Instance.User.Where(t => t.UserId == userId).First();

            enrollClass.UserClass.Add(newClass);
            DatabaseAccessor.Instance.SaveChanges();

            return new EnrollClassModel { UserId = newClass.UserId, ClassId = newClass.ClassId };
        }
        public List<EnrollClassModel> GetEnrolledClasses(int userId)
        {
            return DatabaseAccessor.Instance.UserClass
                .Where(t => t.UserId == userId)
                .Select(t => new EnrollClassModel
                {
                    UserId = t.UserId,
                    ClassId = t.ClassId
                })
                .ToList();            
        }

        public bool Remove(int userId, int classId)
        {
            var items = DatabaseAccessor.Instance.UserClass
                .Where(t => t.UserId == userId && t.ClassId == classId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseAccessor.Instance.UserClass.Remove(items.First());
            DatabaseAccessor.Instance.SaveChanges();
            return true;

        }
    }
}