namespace eventHandler
{
    public delegate void BalanceEventHandler(decimal value);
    class Bank
    {
        private decimal bankBalance;
        public event BalanceEventHandler balanceChanged;

        public decimal theBalance
        {
            set
            {
                bankBalance = value;
                balanceChanged(value);
            }
            get
            {
                return bankBalance;
            }
        }
    }

    class BalanceLogger
    {
        public void balanceLog(decimal amount)
        {
            Console.WriteLine("The balance amount is {0}", amount);
        }
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            BalanceLogger logger = new BalanceLogger();

            bank.balanceChanged += logger.balanceLog;

            string deposit;
            do
            {
                Console.WriteLine("How much to deposit?");
                deposit = Console.ReadLine();
                if (!deposit.Equals("exit"))
                {
                    decimal newValue = decimal.Parse(deposit);
                    bank.theBalance += newValue;
                }
            } while (!deposit.Equals("exit"));
        }
    }
}
