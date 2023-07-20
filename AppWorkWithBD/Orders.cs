using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWorkWithBD
{
    public static class Orders
    {
        public static List<elem_Order> ListOrder { get; set; } = new List<elem_Order>();

        public static void AddElemToList(int id,string name_product,int amount) {
            ListOrder.Add(new elem_Order(id,name_product,amount));
        }

        public static void ClearList() { 
        ListOrder.Clear();
        }

    }

    public  class elem_Order
    {
        public int  id;
        public string name_product;
        public int amount;

        public elem_Order(int id, string name_product, int amount) { 
        this.id = id;
        this.name_product = name_product;
        this.amount = amount;
        }
    }


}
