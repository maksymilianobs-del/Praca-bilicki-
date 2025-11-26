namespace LootboxApp
{
    public class Wallet
    {
        public int Balance { get; private set; }

        public Wallet(int start)
        {
            Balance = start;
        }

        public void AddMoney(int amount)
        {
            Balance += amount;
        }

        public bool Pay(int amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    }
}
