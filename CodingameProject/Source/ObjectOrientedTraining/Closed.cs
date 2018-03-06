/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */
   
using System;

namespace CodingameProject.Source.ObjectOrientedTraining
{
    class Closed : IAccountState
    {
        private Action<string> OnUnfreeze { get; }

        public Closed(Action<string> onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

        public IAccountState Deposit()
        {
            return this;
        }

        public IAccountState Withdraw()
        {
            return this;
        }

        public IAccountState Freeze()
        {
            return this;
        }

        public IAccountState Close()
        {
            return this;
        }

        public IAccountState Verify()
        {
            return new Active(OnUnfreeze);
        }
    }
}