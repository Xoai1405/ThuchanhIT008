using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai4
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Nhập tháng: ");
            int month = 0;
            while(true)
            {
                try
                {
                    month = int.Parse(Console.ReadLine());
                    if (month > 0 && month < 13) break;
                    Console.WriteLine("Thang khong hop le. Vui long nhap lai: ");
                }
                catch
                {
                    Console.WriteLine("Thang khong hop le. Vui long nhap lai: ");
                    
                }


            }
            Console.Write("Nhập năm: ");
            int year = 0;
            while (true)
            {
                try
                {
                    year = int.Parse(Console.ReadLine());
                    if (year>0) break;
                    Console.WriteLine("Nam khong hop le. Vui long nhap lai: ");
                }
                catch
                {
                    Console.WriteLine("Nam khong hop le. Vui long nhap lai: ");

                }
            }

            bool LaNamNhuan(int n)
            {
                return (n % 400 == 0) || (n % 4 == 0 && n % 100 != 0);
            }
            int[] day = { 31, LaNamNhuan(year) ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            Console.WriteLine("So ngay trong thang la: {0}", day[month - 1]);
        }
    }
}