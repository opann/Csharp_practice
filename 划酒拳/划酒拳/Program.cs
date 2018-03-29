using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 划酒拳
{
    class Program
    {
        enum Status
        {
            YOU_CONTINUE = 0,
            PC_CONTINUE = 1,
            YOU_WIN = 2,
            PC_WIN = 3,
        }
        static void Main(string[] args)
        {
            int start;
            string you_num = "1 2 3";
            string[] you_num2 = you_num.Split(' ');
            int count = 0;
            int flag = 0, pc_l, pc_r, pc_num;
            Random rnd = new Random();
            start = rnd.Next(2);
            Console.WriteLine("與電腦划酒拳,將隨機選取你或是PC先開始");
            while (flag != 1)
            {
                switch (start)
                {
                    case (int)Status.YOU_CONTINUE:
                        Console.WriteLine("===========玩家回合==========\n請輸入左手 右手 及預測數");
                        you_num = Console.ReadLine();
                        you_num2 = you_num.Split(' ');
                        if (you_num2.Length != 3 || int.Parse(you_num2[0]) % 5 != 0 || int.Parse(you_num2[1]) % 5 != 0 || int.Parse(you_num2[2]) % 5 != 0)
                        {
                            Console.WriteLine("請按照格式輸入");
                            break;
                        }
                        pc_l = rnd.Next(2) * 5;
                        pc_r = rnd.Next(2) * 5;
                        pc_num = rnd.Next(3) * 5 - pc_l - pc_r;
                        if (int.Parse(you_num2[2]) == int.Parse(you_num2[0]) + int.Parse(you_num2[1]) + pc_l + pc_r)
                        {
                            if (count == 1)
                            {
                                start = 2;
                                break;
                            }
                            Console.WriteLine("電腦出:" + pc_l + "    " + pc_r + "\n玩家出:" + you_num2[0] + "    " + you_num2[1] + "\n玩家猜:" + you_num2[2] + "     你贏了 繼續猜");
                            start = 0;
                            count += 1;
                        }
                        else
                        {
                            Console.WriteLine("電腦出:" + pc_l + "    " + pc_r + "\n玩家出:" + you_num2[0] + "    " + you_num2[1] + "\n玩家猜:" + you_num2[2] + "     你輸了 換電腦");
                            start = 1;
                            count = 0;
                        }
                        break;
                    case (int)Status.PC_CONTINUE:
                        Console.WriteLine("==========電腦的回合==========\n請輸入左手 右手");
                        you_num = Console.ReadLine();
                        you_num2 = you_num.Split(' ');
                        if (you_num2.Length != 2 || int.Parse(you_num2[0]) % 5 != 0 || int.Parse(you_num2[1]) % 5 != 0)
                        {
                            Console.WriteLine("請按照格式輸入");
                            break;
                        }
                        pc_l = rnd.Next(2) * 5;
                        pc_r = rnd.Next(2) * 5;
                        pc_num = rnd.Next(3) * 5 + pc_l + pc_r;
                        if (pc_num == int.Parse(you_num2[0]) + int.Parse(you_num2[1]) + pc_r + pc_l)
                        {
                            if (count == 1)
                            {
                                start = 3;
                                break;
                            }
                            Console.WriteLine("電腦出:" + pc_l + "    " + pc_r + "\n玩家出:" + you_num2[0] + "    " + you_num2[1] + "\n電腦猜:" + pc_num + "     電腦猜中了 繼續猜");
                            start = 1;
                            count += 1;
                        }
                        else
                        {
                            Console.WriteLine("電腦出:" + pc_l + "    " + pc_r + "\n玩家出:" + you_num2[0] + "    " + you_num2[1] + "\n電腦猜: " + pc_num + "     電腦輸了 換你");
                            start = 0;
                            count = 0;
                        }
                        break;
                    case (int)Status.YOU_WIN:
                        Console.WriteLine("恭喜你獲勝了");
                        flag = 1;
                        break;
                    case (int)Status.PC_WIN:
                        Console.WriteLine("電腦獲勝了");
                        flag = 1;
                        break;
                    default:
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
