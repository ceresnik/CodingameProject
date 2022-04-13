/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH, Inc., 2022. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using System;

namespace SWCraftProject.CupExample
{
    public class Cup
    {
        public Cup()
        {
            IsEmpty = true;
        }

        public bool IsEmpty { get; set; }

        public void Fill()
        {
            if (IsEmpty == false)
            {
                IsEmpty = true;
                throw new OverflowException("Cup was already filled.");
            }
            IsEmpty = false;
        }

        public void Drink()
        {
            IsEmpty = true;
        }
    }
}