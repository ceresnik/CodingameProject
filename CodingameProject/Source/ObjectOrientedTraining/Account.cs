using System;

namespace CodingameProject.Source.ObjectOrientedTraining
{
    public class Account
    {
        public int Balance { get; private set; }

        public bool IsClosed { get; private set; }

        public bool IsVerified { get; set; }

        private Action<string> OnUnfreeze { get; }
        private Action ManageUnfreezing { get; set; }

        public Account(Action<string> onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
            ManageUnfreezing = StayUnfrozen;
        }


        public void Deposit(int amount)
        {
            if (IsClosed)
            {
                return;
            }
            ManageUnfreezing();
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
            ManageUnfreezing();
            Balance -= amount;
        }

        private void UnFreeze()
        {
            OnUnfreeze("I'm unfreezed.");
            ManageUnfreezing = StayUnfrozen;
        }

        private void StayUnfrozen()
        {
            
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
            ManageUnfreezing = UnFreeze;
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