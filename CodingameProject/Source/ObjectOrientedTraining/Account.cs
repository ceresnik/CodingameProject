using System;

namespace CodingameProject.Source.ObjectOrientedTraining
{
    public class Account
    {
        public int Balance { get; private set; }

        public IAccountState AccountState { get; private set; }

        public Account(Action<string> onUnfreeze)
        {
            AccountState = new NotVerified(onUnfreeze);
        }

        public void Deposit(int amount)
        {
            AccountState = AccountState.Deposit(() => Balance += amount);
        }

        public void Withdraw(int amount)
        {
            AccountState = AccountState.Withdraw(() => Balance -= amount);
        }

        public void Freeze()
        {
            AccountState = AccountState.Freeze();
        }

        public void Close()
        {
            AccountState = AccountState.Close();
        }

        public void Verify()
        {
            AccountState = AccountState.Verify();
        }
    }
}