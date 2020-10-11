using Capstone.Classes;
using Capstone.UI_Folder;
using System;

namespace Capstone
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Student\GIT\c-module-1-capstone-team-4\19_Capstone\vendingmachine.txt";
            ProductLoader productLoader = new ProductLoader(filePath);
            Machine machine = new Machine(productLoader.ProductList);
            Menu menu = new Menu(machine);
            menu.Show();
            
        }
    }
}
