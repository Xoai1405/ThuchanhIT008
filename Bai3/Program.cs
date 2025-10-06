using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Nhập ngày: ");
            int day=0;
                try
                {
                    day = int.Parse(Console.ReadLine());
                    
               
                }
                catch
                {
                Console.WriteLine("Ngày tháng năm KHÔNG hợp lệ!");
                return;
                }

            Console.Write("Nhập tháng: ");
            int month=0;
            try
            {
                month = int.Parse(Console.ReadLine());
                

            }
            catch
            {
                Console.WriteLine("Ngày tháng năm KHÔNG hợp lệ!");
                return;
            }

            Console.Write("Nhập năm: ");
            int year=0;
            try
            {
                year = int.Parse(Console.ReadLine());

            }
            catch
            {
                Console.WriteLine("Ngày tháng năm KHÔNG hợp lệ!");
                return;
            }

            if (IsValidDate(day, month, year))
            {
                Console.WriteLine("Ngày tháng năm hợp lệ!");
            }
            else
            {
                Console.WriteLine("Ngày tháng năm KHÔNG hợp lệ!");
            }
        }

        static bool IsValidDate(int day, int month, int year)
        {
            if (year < 1 || month < 1 || month > 12 || day < 1)
                return false;

            int[] daysInMonth = { 31, LaNamNhuan(year) ? 29 : 28, 31, 30, 31, 30,
                              31, 31, 30, 31, 30, 31 };

            return day <= daysInMonth[month - 1];
        }

        static bool LaNamNhuan(int year)
        {
            return (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
        }
    }
}
