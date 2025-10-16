namespace esercizio_group3
{
    #region
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
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
