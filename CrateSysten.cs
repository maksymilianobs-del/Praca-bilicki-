using System;
using System.Collections.Generic;

namespace LootboxApp
{
    public class CrateSystem
    {
        private List<Item> Items = new List<Item>();
        private List<Crate> Crates = new List<Crate>();
        private List<Item> Inventory = new List<Item>();
        private Wallet Wallet;
        private Random random = new Random();

        public CrateSystem(Wallet wallet)
        {
            Wallet = wallet;
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void AddCrate(Crate crate)
        {
            Crates.Add(crate);
        }

        public void ShowCrates()
        {
            for (int i = 0; i < Crates.Count; i++)
            {
                Console.WriteLine($"{i}. {Crates[i].Name} - {Crates[i].Price} coins");
            }
        }

        public void ShowInventory()
        {
            if (Inventory.Count == 0)
            {
                Console.WriteLine("Ekwipunek jest pusty.");
                return;
            }

            Console.WriteLine("\n--- EKWIPUNEK ---");
            foreach (var item in Inventory)
            {
                Console.WriteLine($"{item.Name} ({item.Rarity})");
            }
        }

        public void OpenCrate(int id)
        {
            if (id < 0 || id >= Crates.Count)
            {
                Console.WriteLine("Nie znaleziono skrzyni.");
                return;
            }

            Crate crate = Crates[id];

            if (!Wallet.Pay(crate.Price))
            {
                Console.WriteLine("Brak środków.");
                return;
            }

            string rarity = RollRarity(crate.Probabilities);
            Item reward = GetRandomItemByRarity(rarity);

            Inventory.Add(reward);

            Console.WriteLine($"Otrzymałeś: {reward.Name} ({reward.Rarity})");
        }

        private string RollRarity(Dictionary<string, int> probs)
        {
            int total = 0;

            foreach (var p in probs)
                total += p.Value;

            int roll = random.Next(0, total);
            int sum = 0;

            foreach (var p in probs)
            {
                sum += p.Value;
                if (roll < sum)
                    return p.Key;
            }

            return "common";
        }

        private Item GetRandomItemByRarity(string rarity)
        {
            List<Item> pool = Items.FindAll(i => i.Rarity == rarity);
            return pool[random.Next(pool.Count)];
        }
    }
}
