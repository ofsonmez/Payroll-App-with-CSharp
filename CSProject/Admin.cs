using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject
{
    class Admin : Staff
    {
        // Fields
        private const float overtimeRate = 15.5f;
        private const float adminHourlyRate = 30;

        // Properties
        public float Overtime { get; private set; }

        // Constructor
        public Admin(string name) : base(name, adminHourlyRate) {}

        // Methods
        public override void CalculatePay()
        {
            base.CalculatePay();
            if (HoursWorked > 160)
                Overtime = overtimeRate * (HoursWorked - 160);
        }

        public override string ToString()
        {
            return "\nNameOfStaff = " + NameOfStaff + "\nadminHourlyRate = "
                + adminHourlyRate + "\nHoursWorked = " + HoursWorked
                + "\nBasicPay = " + BasicPay + "\nOvertime = " + Overtime
                + "\n\nTotalPay = " + TotalPay;
        }
    }
}
