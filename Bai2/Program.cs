using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    class Program
    {
        static bool CheckNT(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap n (so nguyen duong): ");
            int n;
            while(true)
            {
                try
                {
                    n = int.Parse(Console.ReadLine());
                    if (n > 0) break;
                    Console.WriteLine("Du lieu nhap khong hop le. Vui long nhap lai: ");
                }
                catch
                {
                    Console.WriteLine("Du lieu nhap khong hop le. Vui long nhap lai: ");

                }
            }
            
            int res = 0;
            for (int i = 2; i < n; i++)
            {
                if (CheckNT(i)) res += i;
            }
            Console.WriteLine("Tong cac so nguyen to <n: {0}", res);
        }
    }
}
