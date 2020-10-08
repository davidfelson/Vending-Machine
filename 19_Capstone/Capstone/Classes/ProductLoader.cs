using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
	class ProductLoader
	{
		/*Import Files Method: ImportSnacks()

		StreamReader
		Parse to string array	
		make array[i] fit to constructor in Product Class
		     ...happens automatically at startup of program	
		*/
		
		public List<Product> ProductList { get; set; }
		string filePath = @"C:\Users\Student\GIT\c-module-1-capstone-team-4\19_Capstone\vendingmachine.txt";
		public ProductLoader(string filePath)
		{
			ProductList = new List<Product>();

			using (StreamReader reader = new StreamReader(filePath))
			{

				while (!reader.EndOfStream)
				{
						string eachLine = reader.ReadLine();
						string[] parameter = eachLine.Split("|");
						decimal price = decimal.Parse(parameter[2]);
						Product product = new Product(parameter[0], parameter[1], price, parameter[3]);
						ProductList.Add(product);

				}

			}
			
		}
	}
}