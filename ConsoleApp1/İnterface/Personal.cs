using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.İnterface
{
    public interface IPersonal : IUserBase
    {
        string SSN { get; set; }
        decimal Salary { get; set; }
        void CalculateSalary(short workingHours);
    }

    public class Personal : User, IPersonal
    {
        public string SSN { get; set; }
        public decimal Salary { get; set; }
        public Personal() { }
        public Personal(string userName, string password, bool isActive, string ssn, decimal salary, string identityNo) : base(userName, password, isActive, identityNo)
        {
            SSN = ssn;
            Salary = salary;
        }
        public void CalculateSalary(short workingHours)
        {
            Console.WriteLine(@$"Calculated salary: {Salary * workingHours} ₺");
        }
    }
}