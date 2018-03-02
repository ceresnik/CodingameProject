using System;

namespace CodingameProject.Source.ObjectOrientedTraining
{
    public class Account
    {
        public int Balance { get; private set; }

        public bool IsClosed { get; private set; }

        public bool IsVerified { get; set; }

        public bool IsFreezed { get; set; }

        private Action<string> OnUnfreeze { get; }

        public Account(Action<string> onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }


        public void Deposit(int amount)
        {
            if (IsClosed)
            {
                return;
            }
            if (IsFreezed)
            {
                IsFreezed = false;
                OnUnfreeze("I'm unfreezed.");
            }
            Balance += amount;
        }

        public void Close()
        {
            IsClosed = true;
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
            if (IsFreezed)
            {
                IsFreezed = false;
                OnUnfreeze("I'm unfreezed.");
            }
            Balance -= amount;
        }

        public void Verify()
        {
            IsVerified = true;
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
            IsFreezed = true;
        }
    }
}