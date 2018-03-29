using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 樂透對獎機
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("樂透對獎, 請輸入六個不重複的1~49的值");
            string input = Console.ReadLine();
            input = input.Trim();                                           //將頭尾空白去除
            while (!InputNumCheck(input))                                   //當不符合輸入規則
            {
                Console.WriteLine("輸入錯誤 請輸入六個不重複的1~49的值");
                input = Console.ReadLine();
            }
            string[] inputNum = input.Split(',');                           //依照,分隔字串
            int[] InputNumArray = new int[6];                               //新增陣列來存放分隔後的字串數字
            int[] lottoNum = GetLottery(6);                                 //產生六個中獎數字
            int[] BingoNum = new int[6];                                    //新增一個存放中獎後的數字
            int bingoCount = 0;                                             //宣告一個計數器來計算中獎的次數
            for (int i = 0; i < 6; i++)
            {
                InputNumArray[i] = int.Parse(inputNum[i]);                  //將分隔後的字串轉為數字存入inputNumArray
                for (int j = 0; j < 6; j++)
                {
                    if (lottoNum[j] == InputNumArray[i])                    //若輸入的數字與中獎數字相同 
                    {
                        BingoNum[bingoCount] = lottoNum[j];                 //將中獎數字存入中獎陣列
                        bingoCount += 1;                                    //中獎數+1
                    }
                }
            }
            Console.Write("您選的號碼是:");
            for (int i = 0; i < 6; i++)
            {
                Console.Write(InputNumArray[i] + ",");
            }
            Console.Write("\n電腦選中的號碼是:");
            for (int i = 0; i < 6; i++)
            {
                Console.Write(lottoNum[i] + ",");
            }
            if (bingoCount != 0)
            {
                Console.Write($"\n總共中了{bingoCount}個數字,中獎的數字是:");
                for (int i = 0; i < bingoCount; i++)
                {
                    Console.Write(BingoNum[i] + ",");
                }
            }
            else { Console.WriteLine("很抱歉你共估了"); }
            Console.ReadKey();
        }
        /// <summary>
        /// 確認是否符合(X,X,X,X,X,X)的規則 若是則回傳true
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool InputNumCheck(string input)
        {
            string[] inputNum = input.Split(',');
            int[] num = new int[6];
            if (inputNum.Length != 6)                                   //當輸入的逗號不是五個
            {
                return false;                                           //回傳false
            }
            for (int i = 0; i < inputNum.Length; i++)
            {
                if (!int.TryParse(inputNum[i], out num[i]))             //當輸入的字串不可被整數化
                {
                    return false;
                }
                if (num[i] > 49 || num[i] < 1)                          //當輸入的數字不在1~49
                {
                    return false;
                }
            }
            for (int i = 0; i < inputNum.Length; i++)                   //輸入的字串重複判定
            {
                for (int j = 1; j > i && j < inputNum.Length; j++)
                {
                    if (inputNum[j] == inputNum[i])                     //若重複
                    {
                        return false;
                    }
                }
            }
            return true;



        }
        /// <summary>
        /// 產生樂透數字
        /// </summary>
        /// <param name="n"></param>
        public static int[] GetLottery(int n)
        {
            Random rnd = new Random();
            int[] LotteryNum = new int[n];
            {
                for (int i = 0; i < LotteryNum.Length; i++)
                {
                    LotteryNum[i] = rnd.Next(1, 50);
                }
                int flag = 1;
                while (flag != 0)
                {
                    for (int i = 1; i < LotteryNum.Length; i++)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            flag = 0;
                            if (LotteryNum[i] == LotteryNum[j])
                            {
                                LotteryNum[i] = rnd.Next(1, 50);
                                flag += 1;
                                break;
                            }
                        }
                        if (flag != 0)
                        { break; }
                    }
                }
                //Array.Sort(LotteryNum);

                return LotteryNum;
            }
        }
    }
}
