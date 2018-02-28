/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */
   
namespace CodingameProject.Source
{
    public class NoRestrictionCondition : ICondition
    {
        public bool IsFulfilled(int number)
        {
            return true;
        }
    }
}