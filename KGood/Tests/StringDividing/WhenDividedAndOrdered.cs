/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2017. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using System.Linq;
using KGood.Source.StringDividing;
using NUnit.Framework;

namespace KGood.Tests.StringDividing
{
    [TestFixture]
    public class WhenDividedAndOrdered
    {
        [Test]
        public void LongestItemIsFirst()
        {
            StringDivider sut = new StringDivider("aabbbccccdd", 2);
            var result = sut.DivideAndOrder();
            Assert.That(result.First(), Is.EqualTo("bbbcccc"));
        }
        
    }
}