/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH, Inc., 2022. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using System;
using NUnit.Framework;
using static SWCraftProject.LeapYear.Kevlin.Years;

namespace SWCraftProject.LeapYear.Kevlin
{
    public class Leap_year_spec
    {
        [Test]
        public void A_year_is_not_a_leap_year_if_it_is_not_divisible_by_4(
            [Values(2023, 2022, 2021, 2018, 1999, 2)]
            int year)
        {
            Assert.IsFalse(IsLeapYear(year));
        }

        [Test]
        public void A_year_is_a_leap_year_if_it_is_divisible_by_4_but_not_by_100(
            [Values(2020, 2016, 1984, 4)] int year)
        {
            Assert.IsTrue(IsLeapYear(year));
        }

        [Test]
        public void A_year_is_not_a_leap_year_if_it_is_divisible_by_100_but_not_by_400(
            [Values(2100, 1900, 100)] int year)
        {
            Assert.IsFalse(IsLeapYear(year));
        }

        [Test]
        public void A_year_is_a_leap_year_if_it_is_divisible_by_400(
            [Range(400, 4000, 400)] int year)
        {
            Assert.IsTrue(IsLeapYear(year));
        }

        [Test]
        public void A_year_is_supported_if_it_is_positive(
            [Values(1, int.MaxValue)] int year)
        {
            Assert.DoesNotThrow(() => IsLeapYear(year));
        }

        [Test]
        public void A_year_is_not_supported_if_it_is_0()
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => IsLeapYear(0));
        }

        [Test]
        public void A_year_is_not_supported_if_it_is_negative(
            [Values(-1, -4, -100, -400, -1000, int.MinValue)]
            int year)
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => IsLeapYear(year));
        }
    }
}