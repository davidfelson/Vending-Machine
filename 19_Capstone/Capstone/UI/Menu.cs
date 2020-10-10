using Capstone.Classes;
using MenuFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.UI_Folder
{
    public class Menu : ConsoleMenu
    {
        private Machine machine;
        public Menu (Machine machine)
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
                Console.WriteLine($"{product.SlotLocation} {product.ProductName} {product.Price:C}");
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }
    }
}
