using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_group3.Preparation_Strategy
{
	public enum PreparationType
	{
		None,
		Shaked,
		Mixed, 
		OnTheRocks
	}

	public interface IPreparationStrategy
	{
		public PreparationType Type { get; }
		public void Prepare(IBevanda drink);
	}

	public class ShakedPreparation : IPreparationStrategy
	{
		public PreparationType Type => PreparationType.Shaked;
		public void Prepare(IBevanda drink)
		{
			Console.WriteLine($"Il barista sta preparando un {drink.Descrizione()} shakerato");
		}
	}

	public class MixedPreparation : IPreparationStrategy
	{
		public PreparationType Type => PreparationType.Mixed;
		public void Prepare(IBevanda drink)
		{
			Console.WriteLine($"Il barista sta preparando un {drink.Descrizione()} mescolato");
		}
	}

	public class OnTheRocksPreparation : IPreparationStrategy
	{
		public PreparationType Type => PreparationType.Shaked;
		public void Prepare(IBevanda drink)
		{
			Console.WriteLine($"Il barista sta preparando un {drink.Descrizione()} on the rocks");
		}
	}

	public class PreparationContext
	{
		private IPreparationStrategy strategy;

		public void SetStrategy( IPreparationStrategy strategy )
		{
			this.strategy = strategy;
		}

		public void SetStrategy(PreparationType preparationType)
		{
			strategy = preparationType switch
			{
				PreparationType.Shaked => new ShakedPreparation(),
				PreparationType.Mixed => new MixedPreparation(),
				PreparationType.OnTheRocks => new OnTheRocksPreparation(),
			};
		}

		public void PrepareDrink(IBevanda toPrepare)
		{
			if(toPrepare == null)
			{
				Console.WriteLine("Non hai inserito un drink da preparare");
				return;
			}

			if (strategy == null)
			{
				Console.WriteLine($"Il barista non può ancora preparare il tuo {toPrepare.Descrizione()}, non gli hai detto come farlo!");
				return;
			}

			strategy.Prepare(toPrepare);
		}
	}

}
