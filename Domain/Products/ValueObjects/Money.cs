namespace Domain.Products.ValueObjects
{
    public class Money
    {
        public decimal Amount { get; private set; }

        public Money(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative.", nameof(amount));
            Amount = amount;
        }

        private Money() { }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
                
            Money other = (Money)obj;
            return Amount == other.Amount;
        }

        public override int GetHashCode()
        {
            return Amount.GetHashCode();
        }
    }
}
