using esercizio_group3.Preparation_Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_group3
{
	public class RegistroOrdini
	{
		private static RegistroOrdini instance;
		private RegistroOrdini() { }
		public static RegistroOrdini GetInstance()
		{
			if (instance == null)
			{
				instance = new RegistroOrdini();
			}
			return instance;
		}

		private HashSet<Order> orders = new HashSet<Order>();

		public void AggiungiOrdine(Order order)
		{
			orders.Add(order);
			Console.WriteLine($"Ordine aggiunto al registro: {order.Drink.Descrizione()}");
		}

		public void PrintOrdersByClient(Cliente client)
		{
			Console.WriteLine($"Ordini del cliente {client.Nome}:");
			foreach (Order order in orders)
			{
				if(order.Client == client)
				{
					Console.WriteLine($"{order.Drink.Descrizione()}: {order.Drink.Costo()}");
				}
			}

		}
	}

	public class Order
	{
		public Cliente Client { get; private set; }
		public IBevanda Drink { get; private set; }
		public PreparationType Preparation { get; private set; }

		public Order(Cliente client, IBevanda drink, PreparationType preparation)
		{
			Client = client;
			Drink = drink;
			Preparation = preparation;
		}
	}
}
