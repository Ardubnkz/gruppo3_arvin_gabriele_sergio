using System;
using System.Collections.Generic;   

namespace esercizio_group3
{
    public interface IObserver
    {
        void Update();
    }

    public interface IObservable
    {
        void AggiungiCliente(IObserver observer);
        void RimuoviCliente(IObserver observer);
        void NotificaClienti();
    }

    public class Cliente : IObserver
    {
        public string Nome { get; }
        public Cliente(string nome)
        {
            Nome = nome;
        }
        public void Update()
        {
            Console.WriteLine($"Benvenuto {Nome}, al Pub C#");
        }
    }
    public class Pub : IObservable
{
    private readonly List<IObserver> _clienti = new List<IObserver>();

    public void AggiungiCliente(IObserver observer)
    {
        _clienti.Add(observer);
    }

    public void RimuoviCliente(IObserver observer)
    {
        _clienti.Remove(observer);
    }

    public void NotificaClienti()
    {
        foreach (var cliente in _clienti)
            cliente.Update();
    }
}


    public static class Program
    {
        static void Main(string[] args)
        {
            Pub pub = new Pub();
            Cliente cliente1 = new Cliente("Gabriele");
            Cliente cliente2 = new Cliente("Arvin");
            Cliente cliente3 = new Cliente("Sergio");
            pub.AggiungiCliente(cliente1);
            pub.AggiungiCliente(cliente2);
            pub.AggiungiCliente(cliente3);
            pub.NotificaClienti();
            Barman barman = new Barman();
            barman.PreparaBevanda(pub);
        }
    }
}
