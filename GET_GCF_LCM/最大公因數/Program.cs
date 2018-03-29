using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 最大公因數
{
    class Program
    {
        static void Main(string[] args)
        {
            int x, y, check = 1;
            string input;
            while (check == 1)
            {
                Console.Write("求兩個數字的最大公斤數與最小公倍數\n請輸入第一個數字:");
                x = int.Parse(Console.ReadLine());
                Console.Write("請輸入第二個數字:");
                y = int.Parse(Console.ReadLine());
               int gcd =  GetGcd(x, y);
                Console.WriteLine("gcd = " + gcd);
                Console.WriteLine("lcm = " + x*y/gcd);
                Console.WriteLine("do you want to continue? Yes = 1, No = any key else");

                input = Console.ReadLine();
                if (input == "1")       //當輸入1時繼續       
                {
                    check = 1;
                }
                else                    //輸入其他時結束
                {
                    check = 2;
                }
            }
        }
        /// <summary>
        /// 求最大公因數
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static int GetGcd(int x, int y)
        {
            int a = x;
            int b = y;
            //int a, b;   
            //if (x > y)                  // x,y 排序
            //{
            //    a = x;
            //    b = y;
            //}
            //else
            //{
            //    a = y;
            //    b = x;
            //}
            int remainder = 100;        //重置remainder != 0
            while (remainder != 0)      //當餘數!=0 則繼續取餘數 輾轉相除法
            {
                remainder = a % b;
                Console.WriteLine($"num1 = {a},num2 = {b}, remainder = {remainder}");
                a = b;
                b = remainder;
            }
            return a;
        }
    }
}
