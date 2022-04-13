/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH, Inc., 2022. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using System;
using NUnit.Framework;

namespace SWCraftProject.CupExample
{
    [TestFixture]
    public class CupTests
    {
        [Test]
        public void ANewCupIsEmpty()
        {
            var cup = new Cup();
            Assert.IsTrue(cup.IsEmpty);
        }

        [Test]
        public void AFilledCupIsNotEmpty()
        {
            var cup = new Cup();
            cup.Fill();
            Assert.IsFalse(cup.IsEmpty);
        }

        [Test]
        public void DrinkingFromAFullCupEmptiesIt()
        {
            var cup = new Cup();
            cup.Fill();
            cup.Drink();
            Assert.IsTrue(cup.IsEmpty);
        }

        [Test]
        public void FillingAFullCupOverflows()
        {
            var cup = new Cup();
            cup.Fill();
            Assert.Throws<OverflowException>(() => cup.Fill());
            Assert.IsTrue(cup.IsEmpty);
        }

        [Test]
        public void DrinkingFromAnEmptyCupHasNoEffect()
        {
            var cup = new Cup();
            Assert.DoesNotThrow(() => cup.Drink());
            Assert.IsTrue(cup.IsEmpty);
        }
    }
}