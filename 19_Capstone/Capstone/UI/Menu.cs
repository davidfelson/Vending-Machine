using Capstone.Classes;
using MenuFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace Capstone.UI_Folder
{
    public class Menu : ConsoleMenu
    {
        private Machine machine;
        public Menu(Machine machine)
        {
            this.machine = machine;
            AddOption("Display Items", DisplayItems);
            AddOption("Purchase Menu", PurchaseMenu);
            AddOption("Exit", Exit);

            Configure(cfg =>
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                cfg.Title = "Vendo-Matic 800";
                cfg.ItemForegroundColor = ConsoleColor.Cyan;
                cfg.SelectedItemForegroundColor = ConsoleColor.Blue;

            });

        }

        private MenuOptionResult PurchaseMenu()
        {
            SubMenu subMenu = new SubMenu(machine);
            subMenu.Show();
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }


        private MenuOptionResult DisplayItems()
        {

            foreach (Product product in machine.DisplayItems())
            {
                if (product.Quantity == 0)
                {
                    Console.WriteLine($"{product.SlotLocation}\t{product.ProductName,-16}\t{product.Price:C}\tSOLD OUT");
                }
                else
                {
                    Console.WriteLine($"{product.SlotLocation}\t{product.ProductName,-16}\t{product.Price:C}\t{product.Quantity}");
                }

            }
            return MenuOptionResult.WaitAfterMenuSelection;



        }
    }
}
