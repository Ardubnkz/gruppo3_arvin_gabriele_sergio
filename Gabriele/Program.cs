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
        public List<string> Ordini { get; }

        public Cliente(string nome)
        {
            Nome = nome;
        }

        public void Update()
        {
            Console.WriteLine($"Benvenuto {Nome}, al Pub C#");
        }

        public void AggiungiOrdine(string bevanda)
        {
            Ordini.Add(bevanda);
            Console.WriteLine($"{Nome} ha ordinato: {bevanda}");
        }

        public void MostraOrdini()
        {
            if (Ordini.Count == 0)
            {
                Console.WriteLine($"{Nome} non ha ancora ordinato nulla.");
            }
            else
            {
                Console.WriteLine($"Ordini di {Nome}:");
                foreach (var ordine in Ordini)
                {
                    Console.WriteLine($"- {ordine}");
                }
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

        public class MostraMenu
        {
            public static void Menu()
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Bevande");
                Console.WriteLine("2. Ordini");
                Console.WriteLine("3. Esci");
            }
        }


        public static class Program
        {
            static void Main(string[] args)
            {
                Pub pub = new Pub();
                string bevanda;
                string nome;
                Console.WriteLine($"Come ti chiami?");
                nome = Console.ReadLine();
                Cliente cliente1 = new Cliente(nome);
                pub.AggiungiCliente(cliente1);
                pub.NotificaClienti();
                MostraMenu.Menu();
                int scelta = int.Parse(Console.ReadLine());
                switch (scelta)
                {
                    case 1:
                        Console.WriteLine($"Cosa vuoi ordinare ?");
                        bevanda = Console.ReadLine();
                        cliente1.AggiungiOrdine(bevanda);
                        cliente1.MostraOrdini();
                        break;
                    case 2:
                        cliente1.MostraOrdini();
                        break;
                    case 3:
                        Console.WriteLine($"Arrivederci {cliente1.Nome}!");
                        break;
                    default:
                        Console.WriteLine($"Scelta non valida.");
                        break;
                }
            }
        }
    }
}
