/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH, Inc., 2022. All rights reserved
   ------------------------------------------------------------------------------------------------- */
   
using System;

namespace SWCraftProject.LeapYear.Kevlin
{
    public class Years
    {
        public static bool IsLeapYear(int year)
        {
            if (year <= 0)
                throw new ArgumentOutOfRangeException();

            return year % 4 == 0 && year % 100 != 0 || year % 400 == 0;
        }
    }
}