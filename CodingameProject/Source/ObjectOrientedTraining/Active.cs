/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using System;

namespace CodingameProject.Source.ObjectOrientedTraining
{
    class Active : IFreezable
    {
        private readonly Action<string> onUnfreeze;

        public Active(Action<string> onUnfreeze)
        {
            this.onUnfreeze = onUnfreeze;
        }

        public IFreezable Deposit()
        {
            return this;
        }

        public IFreezable Withdraw()
        {
            return this;
        }

        public IFreezable Freeze()
        {
            return new Frozen(onUnfreeze);
        }
    }
}