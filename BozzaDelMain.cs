using esercizio_group3;

class Programma
{

	public static HashSet<Cliente> clients = new HashSet<Cliente>()
	{ 
		new Cliente("Ray"), new Cliente("Sergio"), new Cliente("Arvin"), new Cliente("Gabriele"),
	};

	static void Main(string[] args)

	{
		Console.WriteLine($"==0GESTIONE PUB==");
		Pub pub = new Pub();
		Barman barman = new Barman();
		bool continua = true;

		while (continua)
		{
			Console.WriteLine($"Menu");
			Console.WriteLine($"1. Ordina una bevanda");
			Console.WriteLine($"2. Crea una bevanda");
			Console.WriteLine($"3. Visualizza tutti gli ordini");
			Console.WriteLine($"4. Visualizza gli ordini di un cliente (fai il conto)");
			Console.WriteLine($"5. Esci");
			Console.Write($"Scelta:");

			string scelta = Console.ReadLine();
			Console.WriteLine();

			switch (scelta)
			{
				case "1":
					OrdinaDalMenu(barman, PickClient()); // da fare metodo
					break;
				case "2":
					// CreaBevandaPersonalizzata(registro, barman); // idem
					break;
				case "3":
					RegistroOrdini.Instance.PrintAllOrders(); //idem
					break;
				case "4":
					CompletaOrdine(PickClient());
					break;
				case "5":
					Console.WriteLine($"Arrivederci");
					continua = false;
					break;
				default:
					Console.WriteLine($"Scelta non valida");
					break;
			}
			if (continua && scelta != "3") // ?
			{
				Console.WriteLine($"Premi un tasto per continuare");
				Console.ReadKey();
			}


		}
	}

	static Cliente PickClient()
	{
		Console.WriteLine("Clienti nel bar:");
		foreach (Cliente client in clients)
		{
			Console.WriteLine(client.Nome);
		}

		Console.WriteLine("Inserisci il cliente che sta ordinando");
		string? scelta = Console.ReadLine();
		while(string.IsNullOrWhiteSpace(scelta))
		{
			Console.WriteLine("Inserisci un cliente");
			scelta = Console.ReadLine();
		}

		while (true) 
		{ 
			foreach(Cliente client in clients)
			{
				if(client.Nome == scelta)
				{
					return client;
				}
			}
		}
	}

	static void OrdinaDalMenu(Barman barman, Cliente client)
	{
		RegistroOrdini.Instance.AggiungiOrdine(new Order(client, barman.PreparaBevanda(), esercizio_group3.Preparation_Strategy.PreparationType.None));
	}

	static void CompletaOrdine(Cliente cliente)
	{
		RegistroOrdini.Instance.PrintOrdersByClient(cliente);
	}
}
