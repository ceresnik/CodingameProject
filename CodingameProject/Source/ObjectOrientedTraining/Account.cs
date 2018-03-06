using System;

namespace CodingameProject.Source.ObjectOrientedTraining
{
    public class Account
    {
        public int Balance { get; private set; }

        public bool IsClosed { get; private set; }

        public bool IsVerified { get; set; }

        private IFreezable Freezable { get; set; }

        public Account(Action<string> onUnfreeze)
        {
            Freezable = new Active(onUnfreeze);
        }

        public void Deposit(int amount)
        {
            if (IsClosed)
            {
                return;
            }
            Freezable = Freezable.Deposit();
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
            Freezable = Freezable.Withdraw();
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
            Freezable = Freezable.Freeze();
        }

        public void Close()
        {
            IsClosed = true;
        }

        public void Verify()
        {
            IsVerified = true;
        }
    }
}