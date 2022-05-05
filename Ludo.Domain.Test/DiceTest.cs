// <copyright file="DiceTest.cs" company="Emmyvh">
// Copyright (c) Emmyvh. All rights reserved.
// </copyright>

namespace Ludo.Domain.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

    public class DiceTest
    {
        [Test]
        public void WhenADiceIsThrownARandomNumberIsReturned()
        {
            Dice dice = new Dice();
            dice.SetDiceThrow();
            Assert.That(dice.GetDiceThrow(), Is.GreaterThan(0));
            Assert.That(dice.GetDiceThrow(), Is.LessThan(7));
        }
    }
}