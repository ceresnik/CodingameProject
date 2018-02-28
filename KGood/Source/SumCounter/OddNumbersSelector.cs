/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using System.Collections.Generic;

namespace KGood.Source.SumCounter
{
    public class OddNumbersSelector : ISumSelector
    {
        private readonly bool oddNumbersOnly;

        public OddNumbersSelector(bool oddNumbersOnly)
        {
            this.oddNumbersOnly = oddNumbersOnly;
        }

        public int[] Pick(int[] numbers)
        {
            var result = new List<int>();
            foreach (int number in numbers)
            {
                if (oddNumbersOnly == false || number % 2 == 1)
                {
                    result.Add(number);
                }
            }
            return result.ToArray();
        }
    }
}