using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bai6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap so dong (so nguyen duong): ");
            int n;
            int m;
            while(true)
            {
                try
                {
                    n = int.Parse(Console.ReadLine());
                    if (n > 0) break;
                    Console.WriteLine("Du lieu nhap khong hop le. Vui long nhap lai so dong: ");
                }
                catch
                {
                    Console.WriteLine("Du lieu nhap khong hop le. Vui long nhap lai so dong: ");
                }
            }
            Console.WriteLine("Nhap so cot (so nguyen duong): ");
            while (true)
            {
                try
                {
                    m = int.Parse(Console.ReadLine());
                    if (m > 0) break;
                    Console.WriteLine("Du lieu nhap khong hop le. Vui long nhap lai so cot: ");
                }
                catch
                {
                    Console.WriteLine("Du lieu nhap khong hop le. Vui long nhap lai so cot: ");
                }
            }

            int[,] MaTran = new int[n, m];
            Random rd = new Random();

            for(int i=0;i<n;i++)
            {
                for(int j=0;j<m;j++)
                {
                    MaTran[i, j] = rd.Next(-100, 100);
                }
            }
            while (true)
            {
                Console.WriteLine("============Menu============");
                Console.WriteLine("1. Xuat ma tran");
                Console.WriteLine("2. Tim phan tu nho nhat cua mang");
                Console.WriteLine("3. Tim phan tu lon nhat cua mang");
                Console.WriteLine("4. Tim dong co tong lon nhat trong mang");
                Console.WriteLine("5. Tinh tong cac so khong phai la so nguyen to");
                Console.WriteLine("6. Xoa dong thu k trong ma tran");
                Console.WriteLine("7. Xoa cot chua phan tu lon nhat trong ma tran");
                Console.WriteLine("8. Thoat");
                Console.WriteLine("Moi chon chuc nang: ");
                int cn = int.Parse(Console.ReadLine());
                    switch (cn)
                    {
                        case 1:
                            Console.WriteLine("Ma tran: ");
                            Xuat(MaTran, n, m);
                            break;
                        case 2:
                            Console.WriteLine("Phan tu nho nhat trong mang la: {0}", MinVal(MaTran, n, m));
                            break;
                        case 3:
                            Console.WriteLine("Phan tu lon nhat trong mang la: {0}", MaxVal(MaTran, n, m));
                            break;
                        case 4:
                            Console.WriteLine("Dong co tong lon nhat la: {0}", MaxRow(MaTran, n, m));
                            break;
                        case 5:
                            Console.WriteLine("Tong cac so khong phai so nguyen to: {0}", TongSoKhongLaNT(MaTran, n, m));
                            break;
                        case 6:
                            RemoveRowK(MaTran, ref n, ref m);
                            Console.WriteLine("Ma tran sau khi xoa dong k la: ");
                            Xuat(MaTran, n, m);
                            break;
                        case 7:
                            RemoveColOfMaxVal(MaTran, ref n, ref m);
                            Console.WriteLine("Ma tran sau khi xoa la: ");
                            Xuat(MaTran, n, m);
                            break;
                        case 8:
                            goto Lable;
                            break;
                    }

            }
        Lable:;

        }
        static void Xuat(int[,] a, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0} ",a[i, j]);
                }
                Console.Write('\n');
            }
        }
        static int MaxVal(int[,] a, int n, int m)
        {
            int res = a[0, 0];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    res = Math.Max(res, a[i, j]);
                }
                
            }
            return res;
        }
        static int MinVal(int[,] a, int n, int m)
        {
            int res = a[0, 0];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    res = Math.Min(res, a[i, j]);
                }

            }
            return res;
        }
        static int MaxRow(int[,] a, int n, int m)
        {
            int res=1;
            int maxsum = int.MinValue;
            for(int i=0;i<n;i++)
            {
                int sum = 0;
                for(int j=0;j<m;j++)
                {
                    sum += a[i, j];
                }
                if(sum>=maxsum)
                {
                    res = i+1;
                    maxsum = sum;
                }
            }
            return res;
        }
        static bool CheckNT(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        
        static int TongSoKhongLaNT(int[,] a, int n, int m)
        {
            int res = 0;
            for(int i=0;i<n;i++)
            {
                for(int j=0;j<m;j++)
                {
                    if (!CheckNT(a[i, j])) res += a[i, j];
                }
            }
            return res;
        }
        static void RemoveRowK(int[,] a,  ref int n, ref int m )
        {
            Console.Write("Nhap dong can xoa (so nguyen duong): ");
            int k;
            while (true)
            {
                try
                {
                    k = int.Parse(Console.ReadLine());
                    if (k > 0 && k<=n) break;
                    Console.WriteLine("Dong can xoa nam ngoai pham vi cua mang. Nhap dong can xoa khac: ");

                }
                catch
                {
                    Console.WriteLine("Du lieu nhap khong hop le. Vui long nhap lai: ");
                }
            }
            k--;
            if (n == k+1) { n--; return; }
            for (int i = k; i < n-1; i++)
            {
                
                for(int j=0;j<m;j++)
                {
                    a[i, j] = a[i + 1, j];
                }
            }
            n--;
        }
        
        static void RemoveColOfMaxVal(int[,] a,  ref int n,ref int m)
        {
            int MaxvalofMatrix = MaxVal(a, n, m);
        LABLE:  while (true)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (a[i, j] == MaxvalofMatrix)
                        {
                            if (j == m-1) { m--; return; }
                            for (int p = 0; p < n; p++)
                            {
                                for (int q = j; q < m - 1; q++)
                                {
                                    a[p, q] = a[p, q + 1];
                                }
                            }
                            m--;
                            goto LABLE;
                        }
                        return;
                    }

                }

            }
        }
    }
}
