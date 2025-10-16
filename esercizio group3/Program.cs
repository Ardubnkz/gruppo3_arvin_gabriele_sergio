namespace esercizio_group3
{
    #region INTERFACE
    interface IPrepataionStrategy
    {
        void Prepare(string nomeBevanda);
    }
    interface IBevanda
    {
        string Getdescrizione();
        double Getcosto();
    }
    interface IObserver
    {
        void Notifica(string message);
    }
    interface Isoggeto
    {
        void registra(IObserver o);
        void rimuovi(IObserver o);
        void notificaTutti(string message);

    }
    interface ICliente
    {
        void OrdinaPronto(string DescrizioneBevanda);
    }
    #endregion

    class RegistroOrdini
    {
        private List<string> ordini = new List<string>();
        private static RegistroOrdini instance;
        private RegistroOrdini() { }
        public static RegistroOrdini Instance
        {
            get
            {
                if (instance == null)
                {
                instance = new RegistroOrdini();
                 }
             return instance;
            }
            
        }
        public void RegistraOrdine(string DescrizioneBevanda)
        {
            Console.WriteLine($"Ordine registrato: {DescrizioneBevanda}");
        }
        public void AggiungiOrdine(string DescrizioneBevanda)
        {
            Console.WriteLine($"Ordine aggiunto al registro: {DescrizioneBevanda}");
        }
        public void MostraOrdini()
        {
            Console.WriteLine("Ordini Registrati");
            foreach (var ordine in ordini)
            {
                Console.WriteLine(ordine);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
