/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using CodingameProject.Tests;

namespace CodingameProject.Source
{
    public class LessThanNineCondition : ICondition
    {
        public bool IsFulfilled(int number)
        {
            return number <= 9;
        }
    }
}