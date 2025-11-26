using System.Collections.Generic;

namespace LootboxApp
{
    public class Crate
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Dictionary<string, int> Probabilities { get; set; }

        public Crate(string name, int price, Dictionary<string, int> probabilities)
        {
            Name = name;
            Price = price;
            Probabilities = probabilities;
        }
    }
}
