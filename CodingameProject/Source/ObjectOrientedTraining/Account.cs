using System;

namespace CodingameProject.Source.ObjectOrientedTraining
{
    public class Account
    {
        public int Balance { get; private set; }

        public bool IsClosed { get; private set; }

        public bool IsVerified { get; set; }

        private IFreezable accountType { get; set; }

        private Action<string> OnUnfreeze { get; }

        public Account(Action<string> onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
            accountType = new Active(onUnfreeze);
        }

        public void Deposit(int amount)
        {
            if (IsClosed)
            {
                return;
            }
            accountType = accountType.Deposit();
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
            accountType = accountType.Withdraw();
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
            accountType = accountType.Freeze();
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