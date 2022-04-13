/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH, Inc., 2022. All rights reserved
   ------------------------------------------------------------------------------------------------- */

namespace SWCraftProject.LeapYear
{
    public class Year
    {
        public static bool IsLeapYear(int year)
        {
            bool isDivisibleBy4 = year % 4 == 0;
            bool isNotDivisibleBy100 = year % 100 != 0;
            bool isDivisibleBy400 = year % 400 == 0;
            return isDivisibleBy4 && isNotDivisibleBy100 || isDivisibleBy400;
        }
    }
}
