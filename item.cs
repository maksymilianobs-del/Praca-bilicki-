namespace LootboxApp
{
    public class Item
    {
        public string Name { get; set; }
        public string Rarity { get; set; }

        public Item(string name, string rarity)
        {
            Name = name;
            Rarity = rarity;
        }
    }
}
