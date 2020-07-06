using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace CSProject
{
    class PaySlip
    {
        // Fields
        private int month, year;

        enum MonthsOfYear
        {
            January = 1, February = 2, March = 3, April = 4, May = 5,
            June = 6, July = 7, August = 8, September = 9,
            October = 10, November = 11, December = 12
        }

        // Constructor
        public PaySlip(int payMounth, int payYear)
        {
            month = payMounth;
            year = payYear;
        }

        // Methods
        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;

            foreach (Staff f in myStaff)
            {
                path = f.NameOfStaff + ".txt";
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine("PaySlip For {0} {1}", (MonthsOfYear)month, year);
                    sw.WriteLine("==========================");
                    sw.WriteLine("Name of Staff: " + f.NameOfStaff);
                    sw.WriteLine("Hours Worked: " + f.HoursWorked + "\n");
                    sw.WriteLine("Basic Pay: " + "$" + f.BasicPay);
                    if (f.GetType() == typeof(Manager))
                        sw.WriteLine("Allowance: " + "$" + ((Manager)f).Allowance);
                    else
                        sw.WriteLine("Overtime Pay: " + "$" + ((Admin)f).Overtime);
                    sw.WriteLine("");
                    sw.WriteLine("==========================");
                    sw.WriteLine("Total Pay: " + "$" + f.TotalPay);
                    sw.WriteLine("==========================");
                    sw.Close();
                }
            }
        }

        public void GenerateSummary(List<Staff> myStaff1)
        {
            var result = from f in myStaff1
                         where f.HoursWorked < 10
                         orderby f.NameOfStaff ascending
                         select new { f.NameOfStaff, f.HoursWorked };

            string path = "summary.txt";
            using (StreamWriter sf = new StreamWriter(path))
            {
                sf.WriteLine("Staff with less than 10 working hours\n");
                foreach (var f in result)
                {
                    sf.WriteLine("Name of Staff: {0}, Hours Worked: {1}", f.NameOfStaff, f.HoursWorked);
                }
                sf.Close();
            }
        }
        public override string ToString()
        {
            return "month = " + month + "year = " + year;
        }
    }
}
