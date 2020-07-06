using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSProject
{
    class FileReader
    {
        // Method
        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string path = "staff.txt";
            string[] separator = { ", " };

            // file read
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        Console.WriteLine(sr.ReadLine());
                        result = sr.ReadLine().Split(separator, StringSplitOptions.None);
                        if (result[1] == "Manager")
                            myStaff.Add(new Manager(result[0]));
                        else
                            myStaff.Add(new Admin(result[0]));
                    }
                    sr.Close();
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            return myStaff;
        }
    }
}
