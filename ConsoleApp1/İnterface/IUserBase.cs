using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.İnterface
{
    public interface IUserBase
    {
        string UserName { get; set; }
        string Password { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        bool IsActive { get; set; }
        public string IdentityNo { get; set; }
    }


    public abstract class User : IUserBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public string IdentityNo { get; set; }

        public User() { }
        public User(string userName, string password, bool isActive, string identityNo)
        {
            UserName = userName;
            Password = password;
            IsActive = isActive;
            IdentityNo = identityNo;
        }
    }
    public enum UserTypeEnum
    {
        Personal,
        Student,
        Jobber
    }
    public static class UserFactory
    {
        public static IUserBase GetInstance(UserTypeEnum userType)
        {
            if (userType == UserTypeEnum.Personal)
                return new Personal();
            if (userType == UserTypeEnum.Student)
                return new Student();
            return new Jobber();
        }
    }
}
