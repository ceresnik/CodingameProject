using System;

namespace CodingameProject.Source.ObjectOrientedTraining
{
    public class Account
    {
        public int Balance { get; private set; }

        public IAccountState State { get; private set; }

        public Account(Action<string> onUnfreeze) 
            : this(onUnfreeze, new NotVerified(onUnfreeze))
        {
        }

        public Account(Action<string> onUnfreeze, IAccountState state)
        {
            this.State = state;
        }

        public void Deposit(int amount)
        {
            State = State.Deposit(() => Balance += amount);
        }

        public void Withdraw(int amount)
        {
            State = State.Withdraw(() => Balance -= amount);
        }

        public void Freeze()
        {
            State = State.Freeze();
        }

        public void Close()
        {
            State = State.Close();
        }

        public void Verify()
        {
            State = State.Verify();
        }
    }
}