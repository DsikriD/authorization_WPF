using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace AppWorkWithBD
{
    public class Product
    {
        public int id;
        public string name;
        public decimal price;

        public Product(int id,string name, decimal price) { 
        this.id = id;
        this.name = name;
        this.price = price; 
        }

    }

    public static class Products
    {
        public static List<Product> ListProducts { get; set; } = new List<Product>();

        public static void ProductAdd(int id,string name,decimal price) {
            ListProducts.Add(new Product(id,name,price));
        }

        public static void ClearProducts() {ListProducts.Clear();}    
  
    }


}
