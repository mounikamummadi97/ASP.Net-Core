namespace Unit_testing_Sample
{
    public class BankAccount
    {
        private readonly string m_CustomerName;
        private double m_balance;
        public const string DebitAmountExceedBalanceMessage = "Debit amount exceeds balance";
        private BankAccount(string v) 
        { 
        }
        public BankAccount(string customerName, double balance)
        {
            m_CustomerName = customerName;
            m_balance = balance;
        }
        public string CustomerName
        {
            get { return m_CustomerName; }
        }
        public double Balance
        {
            get { return m_balance; }
        }
        public void Debit(double amount)
        {
            if(amount > m_balance) 
            {
                throw new ArgumentOutOfRangeException("amount",DebitAmountExceedBalanceMessage);
            }
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }
            m_balance -= amount;
        }
        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance += amount;
        }

    }
}
  