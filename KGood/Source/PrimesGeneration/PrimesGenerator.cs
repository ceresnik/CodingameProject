using System;

namespace KGood.Source.PrimesGeneration
{
    /// <summary>
    /// Refactored by me.
    /// </summary>
    public class PrimesGenerator
    {
        private static int sizeOfArray;

        public static int[] generate(int generationLimit)
        {
            if (generationLimit >= 2) // the only valid case
            {
                // declarations
                sizeOfArray = generationLimit + 1;
                var arrayOfBools = CreateAndInitializeArray();
                GetRidOfKnownNonPrimes(arrayOfBools);
                // sieve
                GetRidOfMultiples(arrayOfBools);

                // how many primes are there?
                var countOfPrimes = GetCountOfPrimes(arrayOfBools);

                //int count = arrayOfBools.Select(x => x.Equals(true)).Count();
                //countOfPrimes = count;

                var primes = MovePrimesIntoTheResult(countOfPrimes, arrayOfBools);
                return primes; // return the primes
            }
            return new int[0]; // return null array if bad input.
        }

        private static int GetCountOfPrimes(bool[] arrayOfBools)
        {
            int countOfPrimes = 0;
            for (int i = 0; i < sizeOfArray; i++)
            {
                if (arrayOfBools[i])
                    countOfPrimes++;
            }
            return countOfPrimes;
        }

        private static int[] MovePrimesIntoTheResult(int countOfPrimes, bool[] arrayOfBools)
        {
            int[] primes = new int[countOfPrimes];
            for (int i = 0, index = 0; i < sizeOfArray; i++)
            {
                if (arrayOfBools[i])
                    primes[index++] = i;
            }
            return primes;
        }

        private static void GetRidOfMultiples(bool[] array)
        {
            for (int i = 2; i < Math.Sqrt(sizeOfArray) + 1; i++)
            {
                if (array[i]) // if i is uncrossed, cross its multiples.
                {
                    for (int j = 2 * i; j < sizeOfArray; j += i)
                        array[j] = false; // multiple is not prime
                }
            }
        }

        private static bool[] CreateAndInitializeArray()
        {
            bool[] array = new bool[sizeOfArray];
            for (int i = 0; i < sizeOfArray; i++)
                array[i] = true;
            return array;
        }

        private static void GetRidOfKnownNonPrimes(bool[] array)
        {
            array[0] = array[1] = false;
        }
    }
}