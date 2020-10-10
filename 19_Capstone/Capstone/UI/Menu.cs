using Capstone.Classes;
using MenuFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.UI_Folder
{
    public class Menu : ConsoleMenu
    {
        //TODO Add Title, Colors to Display

        private Machine machine;
        public Menu (Machine machine)
        {
            this.machine = machine;
            AddOption("Display Items", DisplayItems);
            AddOption("Purchase Menu", PurchaseMenu);
            AddOption("Exit", Exit);
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
                Console.WriteLine(product.ProductName);
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }
    }
}
