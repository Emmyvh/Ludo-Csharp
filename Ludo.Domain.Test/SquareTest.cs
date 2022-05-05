// <copyright file="SquareTest.cs" company="Emmyvh">
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

    public class SquareTest
    {
    [Test]
    public void WhenASquareIsCreatedItDoesNotHoldAPawn()
        {
            Square square = new Square();
            bool status = square.IsOccupied();
            Assert.False(status);
        }

    [Test]
    public void WhenASquareIsCreatedItCanHoldAPawn()
        {
            Square square = new Square();
            square.AddPawn();
            bool status = square.IsOccupied();
            Assert.True(status);
        }

    [Test]
    public void WhenAPawnIsMovedASquareDoesNoLongerHoldOne()
        {
            Square square = new Square();
            square.AddPawn();
            square.RemovePawn();
            bool status = square.IsOccupied();
            Assert.False(status);
        }
    }
}
