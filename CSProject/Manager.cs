using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject
{
    class Manager: Staff
    {
        // Fields
        private const float managerHourlyRate = 50;

        // Properties
        public int Allowance { get; private set; }

        // Constructor
        public Manager(string name): base (name, managerHourlyRate)
        {
        }

        // Methods
        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 1000;
            if (HoursWorked > 160)
                TotalPay = BasicPay + Allowance;
        }

        public override string ToString()
        {
            return "\nNameOfStaff = " + NameOfStaff + "\nmanagerHourlyRate = "
                + managerHourlyRate + "\nHoursWorked = " + HoursWorked + "\nBasicPay = "
                + BasicPay + "\nAllowance = " + Allowance + "\n\nTotalPay = " + TotalPay;
        }
    }
}
