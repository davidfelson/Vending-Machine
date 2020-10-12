using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass]

    //ToDo Test Methods
    public class UnitTest1
    {

        //Product lays = new Product { "A1", "Lays", 3.05M, "Chip", 1 };
        //Product skittles = new Product("B1", "Skittles", 2.35M, "Candy", 3);
        //Product bigRed = new Product("C1", "Big Red", 1.35M, "Gum", 5);
        //Product cokeZero = new Product("D1", "Coke Zero", 2.05M, "Drink", 5);

        private List<Product> TestData = new List<Product>()
        {
            new Product("A1", "Lays", 3.05M, "Chip"),
            new Product("B1", "Skittles", 2.35M, "Candy"),
            new Product("C1", "Big Red", 1.35M, "Gum"),
            new Product("D1", "Coke Zero", 2.05M, "Drink"),

        };

        private Dictionary<string, Product> vendingDictionary = new Dictionary<string, Product>()
        {
                //{"A1", Product },
                //{"B1", skittles},
                //{"C1", bigRed},
                //{"D1", cokeZero}

        };


        //Test FeedMoney()
        [DataTestMethod]
        [DataRow(new int[] {5}, 5, DisplayName = "feed $5 into machine, Balance of 0")]
        [DataRow(new int[] { 1, 2, 5 }, 8, DisplayName = "feed $5, 2, 1, Balance of 0")]
        [DataRow(new int[] {0}, 0, DisplayName = "feed 0, Balance of 0")]

        public void FeedMoneyDataTest(int[] moneyInserted,  double expectedBalanceD)
        {
            //Arrange
            Machine machine = new Machine(TestData);
            //int[] moneyInserted = { 1, 2, 5 };
            //decimal balance = 0M;
            decimal expectedBalance = (decimal)expectedBalanceD;

            //Act
            decimal result = 0;
            foreach (int money in moneyInserted)
            {
                result = machine.FeedMoney(money);
            }

            //Assert
            Assert.AreEqual(expectedBalance, (int) result);
            Assert.AreEqual(expectedBalance, machine.Balance);

        }

        //Test MakeChange()
        [TestMethod]
        public void MakeChangeTestEmptyBalance()
        {
            //Arrange
            int[] expectedArray = new int[] { 0, 0, 0 };
            Machine machine = new Machine(TestData);

            //Act
            int[] result = machine.MakeChange();

            //Assert
            CollectionAssert.AreEqual(expectedArray, result);

        }

        [TestMethod]
        public void MakeChangeTestAfterPurchase()
        {
            //Arrange
            int[] expectedArray = new int[] { 27, 2, 0 };
            Machine machine = new Machine(TestData);
            int feedMoney = 10;
            string productPurchase = "A1";
            machine.FeedMoney(feedMoney);
            machine.DispenseProduct(productPurchase);

            //Act
            int[] result = machine.MakeChange();

            //Assert
            CollectionAssert.AreEqual(expectedArray, result);

        }


        //Test DispenseProduct()
        [TestMethod]
        public void DispenseProductTest()
        {
            
        Machine machine = new Machine(TestData);
            int feedMoney = 10;
            string input = "A1";
            string slotLocation = "A1";
            machine.FeedMoney(feedMoney);
            Product expectedProduct = vendingDictionary[slotLocation];

            //Act
            Product result = machine.DispenseProduct(input);

            //Assert
            Assert.AreEqual(expectedProduct, result);

        }
    }
}
