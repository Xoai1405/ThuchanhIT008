using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai5
{
    class Program
    {
        

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Nhập ngày: ");
            int day = 0;
            while (true)
            {
                try
                {
                    day = int.Parse(Console.ReadLine());
                    if (day > 0 && day < 32) break;
                    Console.WriteLine("Ngay khong hop le. Vui long nhap lai: ");
                }
                catch
                {
                    Console.WriteLine("Ngay khong hop le. Vui long nhap lai: ");

                }


            }
            Console.Write("Nhập tháng: ");
            int month = 0;
            while (true)
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
                    if (year > 0) break;
                    Console.WriteLine("Nam khong hop le. Vui long nhap lai: ");
                }
                catch
                {
                    Console.WriteLine("Nam khong hop le. Vui long nhap lai: ");

                }
            }

            try
            {
                DateTime date = new DateTime(year, month, day);

               
                DayOfWeek thu = date.DayOfWeek;

                string[] thuVN = { "Chủ nhật", "Thứ hai", "Thứ ba", "Thứ tư", "Thứ năm", "Thứ sáu", "Thứ bảy" };

                Console.WriteLine($"Ngày {day}/{month}/{year} là {thuVN[(int)thu]}");
            }
            catch (Exception)
            {
                Console.WriteLine("Ngày tháng năm không hợp lệ!");
            }
        }
    }
}