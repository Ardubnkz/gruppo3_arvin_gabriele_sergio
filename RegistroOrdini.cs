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
		public void RegistraOrdine(string DescrizioneBevanda)
		{
			Console.WriteLine($"Ordine registrato: {DescrizioneBevanda}");
		}
		public void AggiungiOrdine(string DescrizioneBevanda)
		{
			Console.WriteLine($"Ordine aggiunto al registro: {DescrizioneBevanda}");
		}
	}
}
