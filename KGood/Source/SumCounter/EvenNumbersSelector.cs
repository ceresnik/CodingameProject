/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2018. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using System.Collections.Generic;

namespace KGood.Source.SumCounter
{
    public class EvenNumbersSelector : ISumSelector
    {
        private readonly bool evenNumbersOnly;

        public EvenNumbersSelector(bool evenNumbersOnly)
        {
            this.evenNumbersOnly = evenNumbersOnly;
        }

        public int[] Pick(int[] numbers)
        {
            var result = new List<int>();
            foreach (int number in numbers)
            {
                if (evenNumbersOnly == false || number % 2 == 0)
                {
                    result.Add(number);
                }
            }
            return result.ToArray();
        }
    }
}