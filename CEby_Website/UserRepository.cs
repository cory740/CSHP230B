using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CEby_Website
{
    public interface IUserRepository
    {
        UserModel Login(String email, string password);
        UserModel Register(string email, string password);
    }

    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UserRepository : IUserRepository
    {
        public UserModel Login(string email, string password)
        {
            var user = DatabaseAccessor.Instance.User
                .FirstOrDefault(t => t.UserEmail.ToLower() == email.ToLower() && t.UserPassword == password);

            if (user == null)
            {
                return null;
            }
            return new UserModel { Id = user.UserId, Name = user.UserEmail };
        }

        public UserModel Register(string email, string password)
        {
            var user = DatabaseAccessor.Instance.User
                .Add(new Data.User
                {
                    UserEmail = email,
                    UserPassword = password
                });

            if (user == null)
            {
                return null;
            }

            DatabaseAccessor.Instance.SaveChanges();

            return new UserModel { Id = user.Entity.UserId, Name = user.Entity.UserEmail };
        }
    }
}
