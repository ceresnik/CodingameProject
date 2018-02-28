/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using System.Collections.Generic;

namespace KGood.Source.SumCounter
{
    public class EverySecondNumberSelector : ISumSelector
    {
        public int[] Pick(int[] numbers)
        {
            var result = new List<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i % 2 == 0)
                {
                    result.Add(numbers[i]);
                }
            }
            return result.ToArray();
        }
    }
}