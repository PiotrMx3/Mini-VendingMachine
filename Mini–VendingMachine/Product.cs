using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_VendingMachine
{
    enum DrinkType { Water, Soda, Juice , NotSet}
    internal class Product
    {

		private DrinkType _type = DrinkType.NotSet;
		private int _stock = 0;
		private double _price = 0.00;
		private string _name = "";

		public Product(DrinkType type, int stock, double price, string name)
		{
			Name = name;
			Type = type;
			Stock = stock;
			Price = price;
		}


		public bool IsInStock
		{
			get { return this._stock > 0; }
		}
        public int Stock
		{
			get { return this._stock; }
			set 
			{
                if (value < 0 || value > 999) throw new ArgumentException($"Voorraad van {this._name} is onjuist -> moet tussen 0 en 999");
                this._stock = value; 
			}
		}
		public DrinkType Type
		{
			get { return this._type; }
			private set { this._type = value; }
		}


		public double Price
		{
			get { return this._price; }
			set 
			{
				if (value < 0.00 || value > 100.00) throw new ArgumentException($"Prijs van {this._name} is onjuist -> moet tussen 0.00 en 100.00");
				
				this._price = value; 
			}
		}


		public string Name
		{
			get { return this._name; }
			private set { this._name = value; }		
		}


		public void Describe()
		{
			Console.WriteLine($"[{this._type}] {this._name} – {this._price:F2} euro (stock: {this._stock})");
		}


		public void Buy()
		{
			if(IsInStock)
			{
				Console.WriteLine($"Product {this._name} is gekocht ! ");
				DecreaseStock();
			}
			else
			{
				Console.WriteLine($"Vooraad van {this._name} is op !");
			}

		}

		private void DecreaseStock()
		{
			if (IsInStock)
			{
				this._stock--;
			}
		}
    }
}
