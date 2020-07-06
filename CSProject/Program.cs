
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSProject
{
 
    class Program
    {
        static void Main(string[] args)
        {
            List<Staff> myStaff = new List<Staff>();
            
            int month = 0, year = 0;

            while (year == 0)
            {
                Console.Write("\nPlease enter the year: ");
                string sene = Console.ReadLine();
                try
                {
                    year = Convert.ToInt32(sene);
                }
                catch (FormatException)
                {
                    Console.WriteLine("You have entered non-numeric characters");
                    year = 0;
                }
            }

            while (month == 0)
            {
                Console.Write("\nPlease enter the month: ");
                string ay = Console.ReadLine();
                try
                {
                    month = Convert.ToInt32(ay);
                    if (month < 1 || month > 12)
                    {
                        Console.WriteLine("You have entered an invalid value");
                        month = 0;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("You have entered non-numeric characters");
                    month = 0;
                }
            }

            FileReader fr = new FileReader();
            myStaff = fr.ReadFile();

            for (int i = 0; i < myStaff.Count; i++)
            {
                Console.WriteLine("Enter hours worked for {0}:", myStaff[i].NameOfStaff);
                string hours = Console.ReadLine();
                try
                {
                    myStaff[i].HoursWorked = Convert.ToInt32(hours);
                    myStaff[i].CalculatePay();
                    Console.WriteLine(myStaff[i].ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
            }

            PaySlip ps = new PaySlip(month, year);
            ps.GeneratePaySlip(myStaff);
            ps.GenerateSummary(myStaff);


            Console.Read();
        }
    }
}
