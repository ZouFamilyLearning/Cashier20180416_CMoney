using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashier20180416_CMoney
{
    public class Item
    {
        public string name;
        public int price;
        public int reserve;
        public int amount;

        public Item(string name, int price, int reserve)
        {
            this.name = name;
            this.price = price;
            this.reserve = reserve;
            amount = 0;
        }

        public bool Buying(int shoppingNum)
        {

            if (shoppingNum <= reserve)
            {
                reserve -= shoppingNum;
                amount += shoppingNum;
                return true;
            }
            return false;
        }
    }

}
