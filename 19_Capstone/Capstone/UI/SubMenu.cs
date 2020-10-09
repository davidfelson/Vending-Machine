using Capstone.Classes;
using MenuFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.UI_Folder
{
    public class SubMenu : ConsoleMenu
    {
        //TODO Make SubMenu
        private Machine machine;
        public SubMenu(Machine machine)
        {
            this.machine = machine;
            AddOption("Feed Money", FeedMoney);
            AddOption("Select Product", SelectProduct);
        }

        private MenuOptionResult SelectProduct()
        {
            //Todo Display the list of products and locations and price
            string input = GetString("Enter Slot Location");
            try
            {
                Product selectedProduct = machine.DispenseProduct(input);
                Console.WriteLine($"You bought {selectedProduct.ProductName} {selectedProduct.Message}");
                return MenuOptionResult.WaitAfterMenuSelection;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return MenuOptionResult.WaitAfterMenuSelection;
            }
            
            
        }

        private MenuOptionResult FeedMoney()
        {
            //prompt the user for their bill
            int money = GetInteger("How Much", null, new int[] { 1, 2, 5, 10 });
            machine.FeedMoney(money);
            return MenuOptionResult.DoNotWaitAfterMenuSelection;  
        }

        protected override void OnBeforeShow()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Current Balance: {machine.Balance:C}");
            Console.ResetColor();
        }
    }
}
