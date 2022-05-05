// <copyright file="PlayerTest.cs" company="Emmyvh">
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

    public class PlayerTest
    {
    [Test]
    public void WhenAPlayerStartsTheirScoreIsZero()
        {
            Player playerOne = new Player();
            Assert.That(playerOne.GetScore(), Is.EqualTo(0));
        }

    [Test]
    public void WhenAPlayerScoresAPointTheirScoreIsAltered()
        {
            Player playerOne = new Player();
            playerOne.AddPoint();
            Assert.That(playerOne.GetScore(), Is.EqualTo(1));
        }

    [Test]
    public void WhenAplayerStartsTheyOccupyZeroSquares()
        {
            Player playerOne = new Player();
            Assert.That(playerOne.GetPawnList().Count(), Is.EqualTo(0));
        }

    [Test]
    public void WhenAPlayerPlaysAPawnTheyHaveOnePawn()
        {
            Player playerOne = new Player();
            playerOne.AddPawn(0);
            Assert.That(playerOne.GetPawnList().Count, Is.EqualTo(1));
            Assert.That(playerOne.GetPawnList()[0], Is.EqualTo(0));
        }

    [Test]
    public void WhenAPlayerHasAPawnTheyCanLoseIt()
        {
            Player playerOne = new Player();
            playerOne.AddPawn(0);
            playerOne.LosePawn(0);
            Assert.That(playerOne.GetPawnList().Count, Is.EqualTo(0));
        }

    [Test]
    public void WhenAPlayerHasFourPawnsTheyCannotGetMore()
        {
            Player playerOne = new Player();
            playerOne.AddPawn(0);
            playerOne.AddPawn(1);
            playerOne.AddPawn(2);
            playerOne.AddPawn(3);
            playerOne.AddPawn(4);
            Assert.That(playerOne.GetPawnList().Count, Is.EqualTo(4));
            Assert.That(playerOne.GetPawnList()[0], Is.EqualTo(0));
            Assert.That(playerOne.GetPawnList()[1], Is.EqualTo(1));
            Assert.That(playerOne.GetPawnList()[2], Is.EqualTo(2));
            Assert.That(playerOne.GetPawnList()[3], Is.EqualTo(3));
        }

    [Test]
    public void WhenPawnsAreLostSquaresOccupiedCannotGoBelowZero()
        {
            Player playerOne = new Player();
            playerOne.LosePawn(0);
            Assert.That(playerOne.GetPawnList().Count, Is.EqualTo(0));
        }

    [Test]
    public void WhenAPlayerHasScoredAPointThisIsStillCountedAsAnActivePawn()
        {
            Player playerOne = new Player();
            playerOne.AddPoint();
            playerOne.AddPoint();
            playerOne.AddPawn(0);
            playerOne.AddPawn(1);
            playerOne.AddPawn(2);
            Assert.That(playerOne.GetPawnList().Count, Is.EqualTo(2));
            Assert.That(playerOne.GetPawnList()[0], Is.EqualTo(0));
            Assert.That(playerOne.GetPawnList()[1], Is.EqualTo(1));
        }
    }
}
