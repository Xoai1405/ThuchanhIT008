using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    class Program
    {
        static int TongLe(int[] a, int n)
        {
            int Tong = 0;
            for(int i=0;i<n;i++)
            {
                if (a[i] % 2 != 0) Tong += a[i];
            }
            return Tong;
        }
        static bool CheckNT(int n)
        {
            if (n < 2) return false;
            for(int i=2;i<=Math.Sqrt(n);i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        static int CountSoNT(int[] a, int n)
        {
            int cnt = 0;
            foreach (int i in a)
                if (CheckNT(i)) cnt++;
            return cnt;
        }
        static int SoChinhPhuongMin(int[] a, int n)
        {
            int res = -1;
            for (int i= 0;i < n;i++ )
            {
                if ((int)Math.Sqrt(a[i]) * (int)Math.Sqrt(a[i]) == a[i])
                {
                    if (res == -1) res = a[i];
                    else res = Math.Min(res, a[i]);
                }
            }
            return res;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap kich thuoc mang (so nguyen duong): ");
            int n;
            while(true)
            {
                try
                {
                    n = int.Parse(Console.ReadLine());
                    if (n> 0) break;
                    Console.WriteLine("Du lieu nhap khong hop le. Vui long nhap lai");
                }
                catch
                {
                    Console.WriteLine("Du lieu nhap khong hop le. Vui long nhap lai");
                    
                }
            }
            
            int[] a = new int[n];
            Random rd = new Random();
            for (int i=0;i<a.Length;i++)
            {
                a[i] = rd.Next(-100, 100);
            }
            Console.WriteLine("Mang da tao la: ");
            foreach(int i in a)
            {
                Console.Write(i);
                Console.Write(" ");
            }
            Console.WriteLine();
            Console.WriteLine("Tong cua cac so le: {0}", TongLe(a, n));
            Console.WriteLine("So luong so nguyen to trong mang: {0}", CountSoNT(a, n));
            Console.WriteLine("So chinh phuong nho nhat: {0}", SoChinhPhuongMin(a, n));

        }
    }
}
