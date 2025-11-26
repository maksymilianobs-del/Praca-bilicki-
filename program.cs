using System;
using System.Collections.Generic;

namespace LootboxApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Wallet wallet = new Wallet(200);
            CrateSystem crateSystem = new CrateSystem(wallet);

            crateSystem.AddCrate(new Crate("Skrzynia Podstawowa", 20, new Dictionary<string, int>()
            {
                {"common", 70},
                {"rare", 25},
                {"epic", 4},
                {"legendary", 1}
            }));

            crateSystem.AddCrate(new Crate("Skrzynia Epicka", 100, new Dictionary<string, int>()
            {
                {"common", 40},
                {"rare", 40},
                {"epic", 15},
                {"legendary", 5}
            }));

            crateSystem.AddItem(new Item("Zwykły Miecz", "common"));
            crateSystem.AddItem(new Item("Rzadki Amulet", "rare"));
            crateSystem.AddItem(new Item("Epicka Zbroja", "epic"));
            crateSystem.AddItem(new Item("Legendarny Miecz", "legendary"));

            bool running = true;
            while (running)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Pokaż saldo");
                Console.WriteLine("2. Dodaj środki");
                Console.WriteLine("3. Otwórz skrzynię");
                Console.WriteLine("4. Pokaż ekwipunek");
                Console.WriteLine("5. Wyjście");
                Console.Write("Wybierz opcję: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Saldo: " + wallet.Balance + " coins");
                        break;

                    case "2":
                        Console.Write("Ile dodać: ");
                        int amount = int.Parse(Console.ReadLine());
                        wallet.AddMoney(amount);
                        Console.WriteLine("Nowe saldo: " + wallet.Balance);
                        break;

                    case "3":
                        crateSystem.ShowCrates();
                        Console.Write("Wybierz ID skrzyni: ");
                        int crateId = int.Parse(Console.ReadLine());
                        crateSystem.OpenCrate(crateId);
                        break;

                    case "4":
                        crateSystem.ShowInventory();
                        break;

                    case "5":
                        running = false;
                        break;
                }
            }
        }
    }
}
