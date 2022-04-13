/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH, Inc., 2022. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using NUnit.Framework;
using static SWCraftProject.LeapYear.Year;

namespace SWCraftProject.LeapYear
{
    [TestFixture]
    public class YearTests
    {
        [Test]
        public void Year2022IsNoLeapYear()
        {
            // a simple example to start you off
            Assert.IsFalse(IsLeapYear(2022));
        }
        [Test]
        public void Year2020IsLeapYear()
        {
            Assert.IsTrue(IsLeapYear(2020));
        }

        [Test]
        public void Year200IsNoLeapYear()
        {
            Assert.IsFalse(IsLeapYear(200));
        }

        [Test]
        public void Year400IsLeapYear()
        {
            Assert.IsTrue(IsLeapYear(400));
        }
        // E.g., ,  and 1900 are not leap years, but , 2000 and 1984 are.
        [Test]
        public void Year2021IsNoLeapYear()
        {
            Assert.IsFalse(IsLeapYear(2021));
        }

        [Test]
        public void A_year_is_a_leap_year_if_it_is_divisible_by_400(
            [Range(400, 4000, 400)] int year)
        {
            Assert.IsTrue(IsLeapYear(year));
        }
    }
}