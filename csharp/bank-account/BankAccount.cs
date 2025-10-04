public class BankAccount
{
    private decimal balance;
    private bool isOpen;
    
    public void Open()
    {
        if (isOpen)
            throw new InvalidOperationException();
        
        balance = 0;
        isOpen = true;
    }

    public void Close()
    {
        if (!isOpen)
            throw new InvalidOperationException();
        isOpen = false;
    }

    public decimal Balance
    {
        get
        {
            if (!isOpen)
                throw new InvalidOperationException();
            return balance;
        }
    }

    public void Deposit(decimal change)
    {
        if (!isOpen)
            throw new InvalidOperationException();
        if (change <= 0)
            throw new InvalidOperationException();
        balance += change;

    }

    public void Withdraw(decimal change)
    {
        if (change > balance)
            throw new InvalidOperationException();
        if (change <= 0)
            throw new InvalidOperationException();
        if (!isOpen)
            throw new InvalidOperationException();
        balance -= change;
    }
}
