using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_VendingMachine
{
    internal class VendingMachine
    {
		private List<Product> _allProducts = [];		

		public ImmutableList<Product> AllProducts
		{
			get { return _allProducts.ToImmutableList(); }
		}

		public void RegisterProduct(Product p)
		{
			bool containsItem = _allProducts.Any(item => item.Name == p.Name);
			if (!containsItem) _allProducts.Add(p);

		}

		public void Purchase(string name)
		{
            Product? itemToPurchase = null;

			foreach (var item in _allProducts)
			{
				if (item.Name.ToLower() == name.ToLower())
				{
					itemToPurchase = item;
					break;
				}
			}

			if (itemToPurchase is null)
			{
				throw new ArgumentException("Product bestaat niet !");
			}

			if (!itemToPurchase.IsInStock)
			{
                Console.WriteLine($"Voorraad van {itemToPurchase.Name} is op!");
                return;
            }
					
			itemToPurchase.Buy();
			
		}

		public void ShowInventory()
		{
			foreach (var item in _allProducts)
			{
				item.Describe();
			}
		}

		public static void Explain()
		{
            Console.WriteLine("Dit is een automaat die dranken verkoopt.");
			Console.WriteLine();
            Console.WriteLine("1. Kies een product via naam.");
            Console.WriteLine("2. Als het product nog op voorraad is, krijg je het meteen.");
            Console.WriteLine("3. Is het product uitverkocht? Dan krijg je een melding.");
        }

    } 
}
