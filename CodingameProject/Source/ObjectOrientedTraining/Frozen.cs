﻿using System;

namespace CodingameProject.Source.ObjectOrientedTraining
{
    internal class Frozen : IAccountState
    {
        private Action<string> OnUnfreeze { get; }

        public Frozen(Action<string> onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

        public IAccountState Deposit()
        {
            OnUnfreeze("I'm unfreezed.");
            return new Active(OnUnfreeze);
        }

        public IAccountState Withdraw()
        {
            OnUnfreeze("I'm unfreezed.");
            return new Active(OnUnfreeze);
        }

        public IAccountState Freeze() => this;
        public IAccountState Close()
        {
            throw new NotImplementedException();
        }

        public IAccountState Verify()
        {
            return new Active(OnUnfreeze);
        }
    }
}