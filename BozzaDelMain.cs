class Programma
{
    static void Main (string[]args)

    {
        Console.WriteLine($"==0GESTIONE PUB==");
    
    RegistroOrdini registro = RegistroOrdini.Instance;
    Barman barman = new Barman();
        bool continua = true;

        while (continua)
        {
            Console.WriteLine($"Menu");
            Console.WriteLine($"1. Ordina una bevanda");
            Console.WriteLine($"2. Crea una bevanda");
            Console.WriteLine($"3. Visualizza tutti gli ordini");
            Console.WriteLine($"4. Esci");
            Console.Write($"Scelta:");

            string scelta = ConsoleReadLine();
            Console.WriteLine();

            switch (scelta)
            {
                case "1":
                OrdinaDalMenu(registro,barman); // da fare metodo
                break;
                case "2":
                CreaBevandaPersonalizzata(registro,barman); // idem
                break;
                case"3":
                registro.MostraTuttiordini(); //idem
                break;
                case"4":
                CompletaoRDINE(registro);
                break;
                case"5"
                Console.WriteLine($"Arrivederci");
                continua = false;
                break;
                default:
                Console.WriteLine($"Scelta non valida");
                break;
            }
            if (continua && scelta !="3")
            {
                Console.WriteLine($"Premi un tasto per continuare");
                Console.ReadKey();

                
            }
                
                
            }
    }
            
            

            
            
            
            
        }

    }
}