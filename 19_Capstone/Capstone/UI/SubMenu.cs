using Capstone.Classes;
using MenuFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.UI_Folder
{
    public class SubMenu : ConsoleMenu
    {
        private Machine machine;


        public SubMenu(Machine machine)
        {
            this.machine = machine;
            AddOption("Feed Money", FeedMoney);
            AddOption("Select Product", SelectProduct);
            AddOption("Finish Transaction", FinishTransaction);
            
            Configure(cfg =>
            {
                cfg.ItemForegroundColor = ConsoleColor.Cyan;
                cfg.SelectedItemForegroundColor = ConsoleColor.Blue;

            });

        }
        private MenuOptionResult FinishTransaction()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Your Balance is {machine.Balance:C}. Dispensing Change...");
            string logTextChange = $"{DateTime.UtcNow} MAKE CHANGE: {machine.Balance:C} $0.00";
            machine.AuditLog(logTextChange);
            int[] changeGiven = machine.MakeChange();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Your change is {changeGiven[0]} quarter(s), {changeGiven[1]} dime(s), {changeGiven[2]} nickle(s).");
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult SelectProduct()
        {
            foreach (Product product in machine.DisplayItems())
            {
                Console.WriteLine($"{product.SlotLocation}\t{product.ProductName,-16}\t{product.Price:C}\t{product.Quantity}");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            string input = GetString("Enter Selection");
            Console.ResetColor();

            try
            {
                Product selectedProduct = machine.DispenseProduct(input);
                string logTextProduct = $"{DateTime.UtcNow} {selectedProduct.ProductName} {selectedProduct.SlotLocation} {(machine.Balance + selectedProduct.Price):C} {machine.Balance:C}";
                machine.AuditLog((logTextProduct));
                Console.WriteLine($"You purchased {selectedProduct.ProductName} for {selectedProduct.Price:C}. You have {machine.Balance:C} remaining. {selectedProduct.Message}");
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
            int money = GetInteger("Please enter bill: $1, $2, $5, $10", null, new int[] { 1, 2, 5, 10 });
            machine.FeedMoney(money);
            string logTextFM = $"{DateTime.UtcNow} FEEDMONEY: {(machine.Balance - money):C} {machine.Balance:C}";
            machine.AuditLog(logTextFM);
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
