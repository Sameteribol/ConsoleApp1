using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.İnterface
{
    public interface IJobber : IUserBase
    {
        string WorkArea { get; set; }
        string LicensePlate { get; set; }
    }

    public class Jobber : User, IJobber
    {
        public string WorkArea { get; set; }
        public string LicensePlate { get; set; }
        public Jobber() { }
        public Jobber(string userName, string password, bool isActive, string identityNo, string workArea, string licensePlate) : base(userName, password, isActive, identityNo)
        {
            WorkArea = workArea;
            LicensePlate = licensePlate;
        }
    }

}
