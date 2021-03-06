using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            IP_Repostirory ipr = new IP_Repostirory();
            //ipr.ImportIP("2001:0db8:0000:0000:0000:8a2e:0370:7334");

            DateTime testDate = DateTime.Now;
            Console.WriteLine(testDate.ToString("yyyy-dd-MM HH:mm:ss.fff"));

            Console.ReadKey();
        }
    }
}
