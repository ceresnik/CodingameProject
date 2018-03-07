/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */
   
using System;

namespace CodingameProject.Source.ObjectOrientedTraining
{
    class Closed : IAccountState
    {
        public IAccountState Deposit(Action AddToBalance) => this;

        public IAccountState Withdraw(Action RemoveFromBalance) => this;

        public IAccountState Freeze() => this;

        public IAccountState Close() => this;

        public IAccountState Verify() => this;
    }
}