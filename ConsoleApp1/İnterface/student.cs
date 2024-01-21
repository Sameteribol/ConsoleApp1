using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.İnterface
{
    public interface IStudent : IUserBase
    {
        int Absenteeism { get; set; }
        byte Marks { get; set; }
        string StudentNo { get; set; }
    }

    public class Student : User, IStudent
    {
        public int Absenteeism { get; set; }
        public byte Marks { get; set; }

        public string StudentNo { get; set; }

        public Student() { }
        public Student(string userName, string password, bool isActive, string identityNo, int absenteeism, byte marks, string studentNo) : base(userName, password, isActive, identityNo)
        {
            Absenteeism = absenteeism;
            Marks = marks;
            StudentNo = studentNo;

        }
    }
}
