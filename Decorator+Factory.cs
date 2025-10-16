namespace esercizio_group3
{

	#region  Bevande base

	public interface IBevanda
	{
		public string Descrizione();
		public double Costo();
	}
	
  
    class Mojito : IBevanda
	{
		public string Descrizione() { return "Mojito"; }
		public double Costo() { return 8.00; }
	}

	class Spritz : IBevanda
	{
		public string Descrizione() { return "Spritz"; }
		public double Costo() { return 7.00; }
	}

	class Negroni : IBevanda
	{
		public string Descrizione() { return "Negroni"; }
		public double Costo() { return 9.00; }
	}

	class Martini : IBevanda
	{
		public string Descrizione() { return "Martini"; }
		public double Costo() { return 10.00; }
	}

	class CocaCola : IBevanda
	{
		public string Descrizione() { return "Coca Cola"; }
		public double Costo() { return 3.00; }
	}

	#endregion


	#region Decorator

	abstract class DecorazioneBevanda : IBevanda
	{
		protected IBevanda bevanda;

		public DecorazioneBevanda(IBevanda bevanda)
		{
			this.bevanda = bevanda;
		}

		public abstract string Descrizione();
		public abstract double Costo();
	}

	class ZestLime : DecorazioneBevanda
	{
		public ZestLime(IBevanda bevanda) : base(bevanda) { }
		public override string Descrizione() { return bevanda.Descrizione() + " + Zest di Lime"; }
		public override double Costo() { return bevanda.Costo() + 0.50; }
	}

	class ZestLimone : DecorazioneBevanda
	{
		public ZestLimone(IBevanda bevanda) : base(bevanda) { }
		public override string Descrizione() { return bevanda.Descrizione() + " + Zest di Limone"; }
		public override double Costo() { return bevanda.Costo() + 0.50; }
	}

	class ZestArancia : DecorazioneBevanda
	{
		public ZestArancia(IBevanda bevanda) : base(bevanda) { }
		public override string Descrizione() { return bevanda.Descrizione() + " + Zest d'Arancia"; }
		public override double Costo() { return bevanda.Costo() + 0.50; }
	}

	class Fragola : DecorazioneBevanda
	{
		public Fragola(IBevanda bevanda) : base(bevanda) { }
		public override string Descrizione() { return bevanda.Descrizione() + " + Fragola"; }
		public override double Costo() { return bevanda.Costo() + 1.00; }
	}

	class Ananas : DecorazioneBevanda
	{
		public Ananas(IBevanda bevanda) : base(bevanda) { }
		public override string Descrizione() { return bevanda.Descrizione() + " + Ananas"; }
		public override double Costo() { return bevanda.Costo() + 1.00; }
	}

	class Cocco : DecorazioneBevanda
	{
		public Cocco(IBevanda bevanda) : base(bevanda) { }
		public override string Descrizione() { return bevanda.Descrizione() + " + Cocco"; }
		public override double Costo() { return bevanda.Costo() + 1.50; }
	}

	class LimoneEssiccato : DecorazioneBevanda
	{
		public LimoneEssiccato(IBevanda bevanda) : base(bevanda) { }
		public override string Descrizione() { return bevanda.Descrizione() + " + Limone Essiccato"; }
		public override double Costo() { return bevanda.Costo() + 0.80; }
	}

	class AranciaEssiccata : DecorazioneBevanda
	{
		public AranciaEssiccata(IBevanda bevanda) : base(bevanda) { }
		public override string Descrizione() { return bevanda.Descrizione() + " + Arancia Essiccata"; }
		public override double Costo() { return bevanda.Costo() + 0.80; }
	}

	#endregion

	#region Creazione cocktail (factory method)

	static class BevandaFactory
	{
		public static IBevanda Crea(string tipo)
		{
			switch (tipo.ToLower())
			{
				case "mojito": return new Mojito();
				case "spritz": return new Spritz();
				case "negroni": return new Negroni();
				case "martini": return new Martini();
				case "cocacola": return new CocaCola();
				default: return null;
			}
		}
	}

    #endregion


    class Barman
    {
        public void PreparaBevanda(Pub pub)
        {
            Console.WriteLine("Scegli la bevanda:");
            Console.WriteLine("1. Mojito");
            Console.WriteLine("2. Spritz");
            Console.WriteLine("3. Negroni");
            Console.WriteLine("4. Martini");
            Console.WriteLine("5. CocaCola");
            string sceltaBevanda = Console.ReadLine().Trim();
            string tipo = sceltaBevanda switch
            {
                "1" => "mojito",
                "2" => "spritz",
                "3" => "negroni",
                "4" => "martini",
                "5" => "cocacola",
                _ => null
            };

            IBevanda bevanda = BevandaFactory.Crea(tipo);
            if (bevanda == null)
            {
                Console.WriteLine("Tipo di bevanda non riconosciuto.");
                return;
            }

            while (true)
            {
                Console.WriteLine("Vuoi aggiungere una decorazione? (s/n)");
                string risposta = Console.ReadLine()?.Trim().ToLower();
                if (risposta != "s") break;

                Console.WriteLine("Scegli una decorazione:");
                Console.WriteLine("1. Zest di Lime");
                Console.WriteLine("2. Zest di Limone");
                Console.WriteLine("3. Zest d'Arancia");
                Console.WriteLine("4. Fragola");
                Console.WriteLine("5. Ananas");
                Console.WriteLine("6. Cocco");
                Console.WriteLine("7. Limone Essiccato");
                Console.WriteLine("8. Arancia Essiccata");
                string scelta = Console.ReadLine()?.Trim();

                switch (scelta)
                {
                    case "1": bevanda = new ZestLime(bevanda); break;
                    case "2": bevanda = new ZestLimone(bevanda); break;
                    case "3": bevanda = new ZestArancia(bevanda); break;
                    case "4": bevanda = new Fragola(bevanda); break;
                    case "5": bevanda = new Ananas(bevanda); break;
                    case "6": bevanda = new Cocco(bevanda); break;
                    case "7": bevanda = new LimoneEssiccato(bevanda); break;
                    case "8": bevanda = new AranciaEssiccata(bevanda); break;
                    default: Console.WriteLine("Scelta non valida."); break;
                }
            }


            RegistroOrdini.GetInstance().RegistraOrdine(bevanda.Descrizione());

            pub.NotificaClienti();

            Console.WriteLine($"Bevanda preparata: {bevanda.Descrizione()} - Prezzo: {bevanda.Costo():0.00}€");
        }
    }
}














		