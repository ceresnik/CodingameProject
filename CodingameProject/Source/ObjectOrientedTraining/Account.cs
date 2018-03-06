using System;

namespace CodingameProject.Source.ObjectOrientedTraining
{
    public class Account
    {
        public int Balance { get; private set; }

        public bool IsClosed { get; private set; }

        public bool IsVerified { get; set; }

        public IAccountState AccountState { get; private set; }

        public Account(Action<string> onUnfreeze)
        {
            AccountState = new NotVerified(onUnfreeze);
        }

        public void Deposit(int amount)
        {
            if (IsClosed)
            {
                return;
            }
            AccountState = AccountState.Deposit();
            Balance += amount;
        }

        public void Withdraw(int amount)
        {
            if (IsVerified == false)
            {
                return;
            }
            if (IsClosed)
            {
                return;
            }
            AccountState = AccountState.Withdraw();
            Balance -= amount;
        }

        public void Freeze()
        {
            if (IsVerified == false)
            {
                return;
            }
            if (IsClosed)
            {
                return;
            }
            AccountState = AccountState.Freeze();
        }

        public void Close()
        {
            IsClosed = true;
            AccountState = AccountState.Close();
        }

        public void Verify()
        {
            IsVerified = true;
            AccountState = AccountState.Verify();
        }
    }
}