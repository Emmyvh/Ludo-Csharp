// <copyright file="BoardTest.cs" company="Emmyvh">
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

    public class BoardTest
    {
        [Test]
        public void WhenAGameIsStartedPlayerOneIsAcitve()
        {
            Board board = new Board();
            Assert.That(board.GetPlayerOne(), Is.EqualTo(board.GetActivePlayer()));
        }

        [Test]
        public void WhenPlayerOneIsActivePlayerTwoIsNext()
        {
            Board board = new Board();
            board.NextPlayer();
            Assert.That(board.GetPlayerTwo(), Is.EqualTo(board.GetActivePlayer()));
        }

        [Test]
        public void WhenPlayerTwoIsActivePlayerThreeIsNext()
        {
            Board board = new Board();
            board.NextPlayer();
            board.NextPlayer();
            Assert.That(board.GetPlayerThree(), Is.EqualTo(board.GetActivePlayer()));
        }

        [Test]
        public void WhenPlayerThreeIsActivePlayerFourIsNext()
        {
            Board board = new Board();
            board.NextPlayer();
            board.NextPlayer();
            board.NextPlayer();
            Assert.That(board.GetPlayerFour(), Is.EqualTo(board.GetActivePlayer()));
        }

        [Test]
        public void WhenPlayerFourIsActivePlayerOneIsNext()
        {
            Board board = new Board();
            board.NextPlayer();
            board.NextPlayer();
            board.NextPlayer();
            board.NextPlayer();
            Assert.That(board.GetPlayerOne(), Is.EqualTo(board.GetActivePlayer()));
        }

        [Test]
        public void WhenPlayerOneIsActiveStartSquareIsIndexZero()
        {
            Board board = new Board();
            Assert.That(board.GetIndexStartSquare(), Is.EqualTo(0));
        }

        [Test]
        public void WhenPlayerTwoIsActiveStartSquareIsIndexNine()
        {
            Board board = new Board();
            board.NextPlayer();
            Assert.That(board.GetIndexStartSquare(), Is.EqualTo(10));
        }

        [Test]
        public void WhenPlayerThreeIsActiveStartSquareIsIndexNineteen()
        {
            Board board = new Board();
            board.NextPlayer();
            board.NextPlayer();
            Assert.That(board.GetIndexStartSquare(), Is.EqualTo(20));
        }

        [Test]
        public void WhenPlayerOneIsActiveStartSquareIsIndexTwentynine()
        {
            Board board = new Board();
            board.NextPlayer();
            board.NextPlayer();
            board.NextPlayer();
            Assert.That(board.GetIndexStartSquare(), Is.EqualTo(30));
        }

        [Test]
        public void WhenPlayerOneIsActiveEndSquareIsIndexThirtynine()
        {
            Board board = new Board();
            Assert.That(board.GetIndexEndSquare(), Is.EqualTo(39));
        }

        [Test]
        public void WhenPlayerTwoIsActiveEndSquareIsIndexEight()
        {
            Board board = new Board();
            board.NextPlayer();
            Assert.That(board.GetIndexEndSquare(), Is.EqualTo(9));
        }

        [Test]
        public void WhenPlayerThreeIsActiveEndSquareIsIndexEightteen()
        {
            Board board = new Board();
            board.NextPlayer();
            board.NextPlayer();
            Assert.That(board.GetIndexEndSquare(), Is.EqualTo(19));
        }

        [Test]
        public void WhenPlayerOneIsActiveEndSquareIsIndexTwentyEight()
        {
            Board board = new Board();
            board.NextPlayer();
            board.NextPlayer();
            board.NextPlayer();
            Assert.That(board.GetIndexEndSquare(), Is.EqualTo(29));
        }

        [Test]
        public void WhenAPlayerHasActivePawnsAListCanBeReturned()
        {
            Board board = new Board();
            board.GetActivePlayer().AddPawn(0);
            board.GetActivePlayer().AddPawn(5);
            Assert.That(board.GetActivePawnList()[0], Is.EqualTo(0));
            Assert.That(board.GetActivePawnList()[1], Is.EqualTo(5));
        }

        [Test]
        public void WhenAPlayerStartsTheyCanPlaceAPawn()
        {
            Board board = new Board();
            board.PlaceNewPawn();
            Assert.True(board.GetField()[0].IsOccupied());
            Assert.That(board.GetActivePawnList()[0], Is.EqualTo(0));
        }

        [Test]
        public void WhenTwoPawnsWantToOccpyTheSameSpaceTheSecondPawnIsNotCreated()
        {
            Board board = new Board();
            board.PlaceNewPawn();
            board.PlaceNewPawn();
            Assert.True(board.GetField()[0].IsOccupied());
            Assert.That(board.GetActivePawnList()[0], Is.EqualTo(0));

            Assert.That(board.GetActivePlayer().GetPawnList().Count(), Is.LessThan(2));
        }

        [Test]
        public void WhenAPlayerHasFourPointsAPawnIsNotCreated()
        {
            Board board = new Board();
            board.GetActivePlayer().AddPoint();
            board.GetActivePlayer().AddPoint();
            board.GetActivePlayer().AddPoint();
            board.GetActivePlayer().AddPoint();
            board.PlaceNewPawn();
            Assert.That(board.GetActivePlayer().GetPawnList().Count, Is.LessThan(1));
        }

        [Test]
        public void WhenADiceIsThrownItGivesARandomNumber()
        {
            Board board = new Board();
            board.PlaceNewPawn();
            Assert.True(board.GetField()[0].IsOccupied());
            board.MakeMovePawn(1);
            Assert.True(0 < board.GetDiceThrow());
            Assert.True(board.GetDiceThrow() < 7);
        }

        [Test]
        public void WhenAPlayerHasAPawnTheyCanMoveIt()
        {
            Board board = new Board();
            board.PlaceNewPawn();
            Assert.True(board.GetField()[0].IsOccupied());
            board.MakeMovePawn(1);
            Assert.False(board.GetField()[0].IsOccupied());
            Assert.True(board.GetField()[board.GetDiceThrow()].IsOccupied());
            Assert.That(board.GetDiceThrow(), Is.EqualTo(board.GetPlayerOne().GetPawnList()[0]));
        }

        [Test]
        public void WhenAPlayerMovesAPawnTheyCanScoreAPoint()
        {
            Board board = new Board();
            board.GetField()[38].AddPawn();
            board.GetActivePlayer().AddPawn(38);
            Assert.True(board.GetField()[38].IsOccupied());
            board.MakeMovePawn(1);
            Assert.False(board.GetField()[38].IsOccupied());
            Assert.That(board.GetPlayerOne().GetScore(), Is.EqualTo(1));
        }

        [Test]
        public void WhenPlayerTwoPassesSquareThirtyNineTheSquareIndexIsReduced()
        {
            Board board = new Board();
            board.NextPlayer();
            board.GetField()[38].AddPawn();
            board.GetActivePlayer().AddPawn(38);
            Assert.True(board.GetField()[38].IsOccupied());
            Assert.That(board.GetPlayerTwo().GetPawnList()[0], Is.EqualTo(38));
            board.MakeMovePawn(1);
            Assert.True(board.GetField()[38 + board.GetDiceThrow() - 40].IsOccupied());
        }

        [Test]
        public void WhenAPlayerDoesNotThrowSixTheNextPlayerGetsToMove()
        {
            Board board = new Board();
            board.PlaceNewPawn();
            Assert.True(board.GetField()[0].IsOccupied());
            board.MakeMovePawn(1);
            Assert.False(board.GetField()[0].IsOccupied());
            Assert.True(board.GetField()[board.GetDiceThrow()].IsOccupied());
            Assert.That(board.GetDiceThrow(), Is.EqualTo(board.GetPlayerOne().GetPawnList()[0]));
            if (board.GetDiceThrow() == 6)
            {
                Assert.That(board.GetActivePlayer(), Is.EqualTo(board.GetPlayerOne()));
            }
            else
            {
                Assert.That(board.GetActivePlayer(), Is.EqualTo(board.GetPlayerTwo()));
            }
        }

        [Test]
        public void WhenPlayerOneHasHadTheirTurnPlayerTwoGetsToMove()
        {
            Board board = new Board();
            board.PlaceNewPawn();
            Assert.True(board.GetField()[0].IsOccupied());
            board.MakeMovePawn(1);
            Assert.False(board.GetField()[0].IsOccupied());
            Assert.True(board.GetField()[board.GetDiceThrow()].IsOccupied());
            Assert.That(board.GetDiceThrow(), Is.EqualTo(board.GetPlayerOne().GetPawnList()[0]));

            if (board.GetDiceThrow() == 6)
            {
                Assert.That(board.GetActivePlayer(), Is.EqualTo(board.GetPlayerOne()));
                board.PlaceNewPawn();
                board.MakeMovePawn(1);
            }
            else
            {
                Assert.That(board.GetActivePlayer(), Is.EqualTo(board.GetPlayerTwo()));
                board.PlaceNewPawn();
                Assert.True(board.GetField()[10].IsOccupied());
                board.MakeMovePawn(1);
                Assert.False(board.GetField()[10].IsOccupied());
                Assert.True(board.GetField()[board.GetDiceThrow() + 10].IsOccupied());
                Assert.That(board.GetDiceThrow() + 10, Is.EqualTo(board.GetPlayerTwo().GetPawnList()[0]));
            }
        }

        [Test]
        public void WhenAGameStartsItHasNotEnded()
        {
            Board board = new Board();
            Assert.False(board.endOfGameCheck());
        }

        [Test]
        public void WhenPlayerOneHasFourPointsTheGameEnds()
        {
            Board board = new Board();
            Assert.False(board.endOfGameCheck());
            board.GetActivePlayer().AddPoint();
            board.GetActivePlayer().AddPoint();
            board.GetActivePlayer().AddPoint();
            board.GetActivePlayer().AddPoint();
            Assert.True(board.endOfGameCheck());
        }

        [Test]
        public void WhenPlayerTwoHasFourPointsTheGameEnds()
        {
            Board board = new Board();
            Assert.False(board.endOfGameCheck());
            board.GetPlayerTwo().AddPoint();
            board.GetPlayerTwo().AddPoint();
            board.GetPlayerTwo().AddPoint();
            board.GetPlayerTwo().AddPoint();
            Assert.True(board.endOfGameCheck());
        }

        [Test]
        public void WhenPlayerThreeHasFourPointsTheGameEnds()
        {
            Board board = new Board();
            Assert.False(board.endOfGameCheck());
            board.GetPlayerThree().AddPoint();
            board.GetPlayerThree().AddPoint();
            board.GetPlayerThree().AddPoint();
            board.GetPlayerThree().AddPoint();
            Assert.True(board.endOfGameCheck());
        }

        [Test]
        public void WhenPlayerFourHasFourPointsTheGameEnds()
        {
            Board board = new Board();
            Assert.False(board.endOfGameCheck());
            board.GetPlayerFour().AddPoint();
            board.GetPlayerFour().AddPoint();
            board.GetPlayerFour().AddPoint();
            board.GetPlayerFour().AddPoint();
            Assert.True(board.endOfGameCheck());
        }

        [Test]
        public void WhenAGameEndsPlayerOneWins()
        {
            Board board = new Board();
            Assert.False(board.endOfGameCheck());
            board.GetActivePlayer().AddPoint();
            board.GetActivePlayer().AddPoint();
            board.GetActivePlayer().AddPoint();
            Assert.That(board.GetPlayerOne().GetScore(), Is.EqualTo(3));

            board.GetField()[38].AddPawn();
            board.GetActivePlayer().AddPawn(38);
            Assert.True(board.GetField()[38].IsOccupied());
            board.MakeMovePawn(1);
            Assert.False(board.GetField()[38].IsOccupied());
            Assert.That(board.GetPlayerOne().GetScore(), Is.EqualTo(4));

            Assert.True(board.endOfGameCheck());
            Assert.That(board.GetPlayerOne(), Is.EqualTo(board.GetActivePlayer()));
            Assert.That(board.GetPlayerOne(), Is.EqualTo(board.GetWinner()));
        }

        [Test]
        public void WhenAGameEndsPlayerTwoWins()
        {
            Board board = new Board();
            Assert.False(board.endOfGameCheck());
            board.GetPlayerTwo().AddPoint();
            board.GetPlayerTwo().AddPoint();
            board.GetPlayerTwo().AddPoint();
            Assert.That(board.GetPlayerTwo().GetScore(), Is.EqualTo(3));

            board.NextPlayer();
            board.GetField()[8].AddPawn();
            board.GetActivePlayer().AddPawn(8);
            Assert.True(board.GetField()[8].IsOccupied());
            board.MakeMovePawn(1);
            Assert.False(board.GetField()[8].IsOccupied());
            Assert.That(board.GetPlayerTwo().GetScore(), Is.EqualTo(4));

            Assert.True(board.endOfGameCheck());
            Assert.That(board.GetPlayerTwo(), Is.EqualTo(board.GetActivePlayer()));
            Assert.That(board.GetPlayerTwo(), Is.EqualTo(board.GetWinner()));
        }

        [Test]
        public void WhenAGameEndsPlayerThreeWins()
        {
            Board board = new Board();
            Assert.False(board.endOfGameCheck());
            board.GetPlayerThree().AddPoint();
            board.GetPlayerThree().AddPoint();
            board.GetPlayerThree().AddPoint();
            Assert.That(board.GetPlayerThree().GetScore(), Is.EqualTo(3));

            board.NextPlayer();
            board.NextPlayer();
            board.GetField()[18].AddPawn();
            board.GetActivePlayer().AddPawn(18);
            Assert.True(board.GetField()[18].IsOccupied());
            board.MakeMovePawn(1);
            Assert.False(board.GetField()[18].IsOccupied());
            Assert.That(board.GetPlayerThree().GetScore(), Is.EqualTo(4));

            Assert.True(board.endOfGameCheck());
            Assert.That(board.GetPlayerThree(), Is.EqualTo(board.GetActivePlayer()));
            Assert.That(board.GetPlayerThree(), Is.EqualTo(board.GetWinner()));
        }

        [Test]
        public void WhenAGameEndsPlayerFourWins()
        {
            Board board = new Board();
            Assert.False(board.endOfGameCheck());
            board.GetPlayerFour().AddPoint();
            board.GetPlayerFour().AddPoint();
            board.GetPlayerFour().AddPoint();
            Assert.That(board.GetPlayerFour().GetScore(), Is.EqualTo(3));

            board.NextPlayer();
            board.NextPlayer();
            board.NextPlayer();
            board.GetField()[28].AddPawn();
            board.GetActivePlayer().AddPawn(28);
            Assert.True(board.GetField()[28].IsOccupied());
            board.MakeMovePawn(1);
            Assert.False(board.GetField()[28].IsOccupied());
            Assert.That(board.GetPlayerFour().GetScore(), Is.EqualTo(4));

            Assert.True(board.endOfGameCheck());
            Assert.That(board.GetPlayerFour(), Is.EqualTo(board.GetActivePlayer()));
            Assert.That(board.GetPlayerFour(), Is.EqualTo(board.GetWinner()));
        }

        [Test]
        public void WhenASquareIsOccupiedByPlayerTwoTheirPawnCanBeRemoved()
        {
            Board board = new Board();
            Assert.False(board.endOfGameCheck());
            board.GetField()[6].AddPawn();
            board.GetPlayerTwo().AddPawn(6);
            Assert.True(board.GetField()[6].IsOccupied());
            Assert.That(board.GetPlayerTwo().GetPawnList()[0], Is.EqualTo(6));

            board.SetIndexOfNewSquare(6);
            board.HitCheck();
            Assert.That(board.GetPlayerTwo().GetPawnList().Count(), Is.LessThan(1));
        }

        [Test]
        public void WhenASquareIsOccupiedByPlayerThreeTheirPawnCanBeRemoved()
        {
            Board board = new Board();
            Assert.False(board.endOfGameCheck());
            board.GetField()[6].AddPawn();
            board.GetPlayerThree().AddPawn(6);
            Assert.True(board.GetField()[6].IsOccupied());
            Assert.That(board.GetPlayerThree().GetPawnList()[0], Is.EqualTo(6));

            board.SetIndexOfNewSquare(6);
            board.HitCheck();

            Assert.That(board.GetPlayerThree().GetPawnList().Count(), Is.LessThan(1));
        }

        [Test]
        public void WhenASquareIsOccupiedByPlayerFourTheirPawnCanBeRemoved()
        {
            Board board = new Board();
            Assert.False(board.endOfGameCheck());
            board.GetField()[6].AddPawn();
            board.GetPlayerFour().AddPawn(6);
            Assert.True(board.GetField()[6].IsOccupied());
            Assert.That(board.GetPlayerFour().GetPawnList()[0], Is.EqualTo(6));

            board.SetIndexOfNewSquare(6);
            board.HitCheck();

            Assert.That(board.GetPlayerFour().GetPawnList().Count(), Is.LessThan(1));
        }

        [Test]
        public void WhenASquareIsOccupiedByPlayerOneTheirPawnCanBeRemoved()
        {
            Board board = new Board();
            Assert.False(board.endOfGameCheck());
            board.GetField()[6].AddPawn();
            board.GetPlayerOne().AddPawn(6);
            Assert.True(board.GetField()[6].IsOccupied());
            Assert.That(board.GetPlayerOne().GetPawnList()[0], Is.EqualTo(6));

            board.SetIndexOfNewSquare(6);
            board.HitCheck();
            Assert.That(board.GetPlayerOne().GetPawnList().Count(), Is.LessThan(1));
        }
    }
}
