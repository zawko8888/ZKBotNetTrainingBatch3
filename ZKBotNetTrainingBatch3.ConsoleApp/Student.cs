using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZKBotNetTrainingBatch3.ConsoleApp
{
    internal class Student
    {

        public Student()
        {
            StudentName = "--Test--";
        }

        public Student(int studentNo, string studentName, DateTime dateOfBirth)
        {
            studentName = "--Test--";
        }

       public string StudentNo { get; set; }
        public string StudentName { get; set; }


        public DateTime DateofBithd { get; set; }

    }

    public class Employee
    {

    }

    public class Wallet
    {
        public string Name { get; set; }
        public string MobileNo {  get; set; }
        private decimal Balance { get; set; }
        public decimal ShowBalance()
        {
            return Balance;
        }
    }
}
