using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 英檢成績
{
    struct TEST             //struct英檢成績
    {
        public int ID;
        public int HEAR;
        public int READ;
        public int SUM;
    }
    enum Menu               //列舉Menu
    {
        Enter_grade = 1,
        List_grade = 2,
        Edit_grade = 3,
        End = -1,

    }
    class Program
    {
        static void Main(string[] args)
        {
            TEST[] GRADE = new TEST[1];         //建立成績陣列來存成績
            TEST grade;                         //建立一個暫存成績的變數
            grade.ID = 0;                       //建立初始值
            grade.HEAR = 0;
            grade.READ = 0;
            grade.SUM = 0;
            int menu = 0, count = 0, id = 0;    //menu為選單控制,count為資料筆數, id為修改成績時的暫存
            string fixGrade = " ";              //fixGrade為修改成績時的輸入暫存
            string[] FixGrade = fixGrade.Split(' '); //FixGrade為將fixGrade處理為兩個成績
            while (menu != -1)                  //當menu!=-1 則無限迴圈, -1則結束
            {
                Console.WriteLine("主選項: 1)輸入成績 2)統計資料 3)修改成績 -1)結束");
                menu = int.Parse(Console.ReadLine());   //輸入選單編號

                switch (menu)
                {
                    case (int)Menu.Enter_grade:
                        Console.Write("聽力測驗:");
                        grade.HEAR = int.Parse(Console.ReadLine()); //輸入成績
                        while (grade.HEAR < 0 || grade.HEAR > 120)  //若成績不在範圍內防呆
                        {
                            Console.Write("成績輸入錯誤,須為0~120\n聽力測驗:");
                            grade.HEAR = int.Parse(Console.ReadLine());
                        }
                        Console.Write("閱讀測驗:");
                        grade.READ = int.Parse(Console.ReadLine());
                        while (grade.READ < 0 || grade.READ > 120)   //防呆
                        {
                            Console.Write("成績輸入錯誤,須為0~120\n閱讀測驗:");
                            grade.READ = int.Parse(Console.ReadLine());
                        }
                        grade.SUM = grade.READ + grade.HEAR;        //成績加總
                        Console.WriteLine("總分為:" + grade.SUM + "\n\n");
                        grade.ID = ++count;                         
                        GRADE[count - 1] = grade;                   //將暫存資料寫數GRADE
                        Array.Resize(ref GRADE, GRADE.Length + 1);  //成績陣列長度+1
                        break;
                    case (int)Menu.List_grade:
                        Console.WriteLine("編號  聽力測驗 閱讀測驗 總分");
                        Console.WriteLine("============================");
                        for (int i = 0; i < GRADE.Length - 1; i++)
                        {
                            Console.WriteLine(GRADE[i].ID + "\t" + GRADE[i].HEAR + "\t" + GRADE[i].READ + "\t" + GRADE[i].SUM + "\n");
                        }
                        break;
                    case (int)Menu.Edit_grade:
                        Console.Write("編號:");
                        id = int.Parse(Console.ReadLine()) - 1;     //讀取要修改的編號,陣列初始值0所以要-1
                        while (id > GRADE.Length - 2)               //由於輸入資料後陣列長度會+1 所以這邊Grade.Length要多-1
                        {
                            Console.Write("超出索引範圍!!\n編號:"); //防呆
                            id = int.Parse(Console.ReadLine()) - 1;
                        }
                        Console.Write("請輸入要修改的成績,以空白鍵區隔(ex:70 80):");
                        fixGrade = Console.ReadLine();              //輸入暫存
                        FixGrade = fixGrade.Split(' ');             //暫存依照空白拆解成兩個部分
                        while (FixGrade.Length != 2)                //若拆解不成功(空白數量!=1)
                        {
                            Console.Write("請輸入正確格式:(聽力成績 閱讀成績):");  //防呆 重新輸入
                            fixGrade = Console.ReadLine();
                            FixGrade = fixGrade.Split(' ');
                        }
                        GRADE[id].HEAR = int.Parse(FixGrade[0]);            //重新將資料寫入GRADE陣列
                        GRADE[id].READ = int.Parse(FixGrade[1]);
                        GRADE[id].SUM = GRADE[id].READ + GRADE[id].HEAR;    //重新計算總合寫入
                        break;
                    case (int)Menu.End:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
