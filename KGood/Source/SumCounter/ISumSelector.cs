/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */

namespace KGood.Source.SumCounter
{
    public interface ISumSelector
    {
        int[] Pick(int[] numbers);
    }
}