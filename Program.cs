using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashier20180416_CMoney
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>();
            items.Add(new Item("鍵盤", 300, 10));
            items.Add(new Item("滑鼠", 100, 25));
            items.Add(new Item("螢幕", 3000, 5));
            int input;
            do
            {
                Console.WriteLine("收銀系統的選單為 1) 購買商品 2)  結帳 -1) 結束 ");
                input = int.Parse(Console.ReadLine());
                while (input == 1)
                {
                    Console.WriteLine("目前有以下商品，請輸入編號與購買數量，或按 -1 返回主選單 ");
                    for (int i = 0; i < items.Count; i++)
                    { Console.WriteLine(items[i].name + ", 單價: " + items[i].price + ", 庫存數量: " + items[i].reserve); }
                    string instruction = Console.ReadLine();
                    if (instruction == "-1")
                    {
                        Console.WriteLine("回到主選單。");
                        break;
                    }
                    string[] inputShopping = instruction.Split(',');
                    int shoppingItem = int.Parse(inputShopping[0]) - 1;
                    int shoppingNum = int.Parse(inputShopping[1]);
                    if (items[shoppingItem].Buying(shoppingNum) == false)
                    { Console.WriteLine("購買失敗，目前庫存不足"); }
                    else
                    { Console.WriteLine("購買成功。"); }
                }
                if (input == 2)
                {
                    Console.WriteLine("選擇結帳方案 1) 一般計價 2) 打8折 3) 滿 1000 送 100   -1) 返回主選單 ");
                    input = int.Parse(Console.ReadLine());
                    int total = 0;
                    for (int i = 0; i < items.Count; i++)
                    {
                        Console.WriteLine($"{items[i].name}, 單價: {items[i].price}, 購買數量 {items[i].amount}");
                        total += items[i].price * items[i].amount;
                    }
                    switch (input)
                    {
                        case 1:
                            Console.WriteLine($"原價{total}，共計{total}元");
                            break;
                        case 2:
                            Console.WriteLine($"原價{total}，折扣後共計{total * 0.8}元");
                            break;
                        case 3:
                            Console.WriteLine($"原價{total}，折扣後共計{total - (total / 1000) * 100}元");
                            break;
                        default:
                            break;
                    }
                }
            } while (input != -1);
            Console.WriteLine("謝謝再次光臨。");
            Console.ReadKey();
        }
    }
}
