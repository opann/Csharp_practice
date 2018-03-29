using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            //pm為質數判斷子
            bool pm = true;
            int j = 0;
            Console.WriteLine("請輸入一個數字");
            int input = int.Parse(Console.ReadLine());
            Console.Write($"{input}以下的質數有:");
            //從1開始判定是否為i質數
            for (int i = 1; i <= input; i++)
            {
                //質數判定子重置為true
                pm = true;
                //質數判定法為:若i不能被2~(i-1)整除 則為質數
                for (j = i - 1; j > 1; j--)
                {
                    //質數判定子pm: 若i不能被j整除 則&&後回寫到pm
                    pm = (i % j != 0);
                    if (!pm) { break; }//若被整除 則跳出迴圈
                }
                //若pm為true(i都未被j整除) 則輸出i
                if (pm && (i != 1)) { Console.Write($"{i}, "); }
            }
            Console.Write($"\n{input}的因數有");
            for (int i = 1; i <= input; i++)
            {
                //若input被i整除 則輸出i
                if (input % i == 0) { Console.Write($"{i}, "); }
            }
            Console.Write($"\n{input}的質因數有");
            for (int i = 1; i <= input; i++)
            {
                pm = true;
                for (j = i - 1; j > 1; j--)
                {
                    pm = (i % j != 0);
                    if (!pm) { break; }
                }
                //質因數多一個判斷子 &&當input能被i整除
                if (pm && (i != 1) && (input % i) == 0) { Console.Write($"{i}, "); }
            }
            Console.ReadKey();

        }
    }
}
