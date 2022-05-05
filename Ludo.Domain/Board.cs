// <copyright file="Board.cs" company="Emmyvh">
// Copyright (c) Emmyvh. All rights reserved.
// </copyright>

namespace Ludo.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Board
    {
        private Player playerOne;
        private Player playerTwo;
        private Player playerThree;
        private Player playerFour;
        private Player activePlayer;
        private Player winner;
        private Dice dice;
        private int diceThrow;
        private List<Square> field;
        private int startSquareIndex;
        private int endSquareIndex;
        private int indexOfOldSquare;
        private int indexOfNewSquare;

        public Board()
        {
            this.dice = new Dice();
            this.playerOne = new Player();
            this.playerTwo = new Player();
            this.playerThree = new Player();
            this.playerFour = new Player();
            this.activePlayer = this.playerOne;

            this.field = new List<Square>();
            for (int i = 0; i < 40; i++)
            {
                this.field.Add(new Square());
            }
        }

        public Player GetPlayerOne()
        {
            return this.playerOne;
        }

        public Player GetPlayerTwo()
        {
            return this.playerTwo;
        }

        public Player GetPlayerThree()
        {
            return this.playerThree;
        }

        public Player GetPlayerFour()
        {
            return this.playerFour;
        }

        public Player GetActivePlayer()
        {
            return this.activePlayer;
        }

        public Player GetWinner()
        {
            return this.winner;
        }

        public List<Square> GetField()
        {
            return this.field;
        }

        public List<int> GetActivePawnList()
        {
            return this.GetActivePlayer().GetPawnList();
        }

        public int GetDiceThrow()
        {
            this.diceThrow = this.dice.GetDiceThrow();
            return this.diceThrow;
        }

        public int GetIndexStartSquare()
        {
            if (this.activePlayer == this.playerOne)
            {
                this.startSquareIndex = 0;
            }
            else if (this.activePlayer == this.playerTwo)
            {
                this.startSquareIndex = 10;
            }
            else if (this.activePlayer == this.playerThree)
            {
                this.startSquareIndex = 20;
            }
            else if (this.activePlayer == this.playerFour)
            {
                this.startSquareIndex = 30;
            }

            return this.startSquareIndex;
        }

        public int GetIndexEndSquare()
        {
            if (activePlayer == playerOne)
            {
                this.endSquareIndex = GetIndexStartSquare() + 39;
            }
            else if (this.activePlayer == this.playerTwo)
            {
                this.endSquareIndex = GetIndexStartSquare() + 39 - 40;
            }
            else if (this.activePlayer == this.playerThree)
            {
                this.endSquareIndex = GetIndexStartSquare() + 39 - 40;
            }
            else if (this.activePlayer == this.playerFour)
            {
                this.endSquareIndex = GetIndexStartSquare() + 39 - 40;
            }

            return this.endSquareIndex;
        }

        public void SetIndexOfNewSquare(int index)
        {
            this.indexOfNewSquare = index;
        }

        public void RemoveOldPawn(int pawnNumber)
        {
            this.GetField()[indexOfOldSquare].RemovePawn();
            this.GetActivePlayer().LosePawn(indexOfOldSquare);
        }

        public void PointCheck(int pawnNumber)
        {
            if (this.indexOfOldSquare + this.diceThrow >= GetIndexEndSquare() && this.indexOfOldSquare < GetIndexEndSquare())
            {
                this.GetActivePlayer().AddPoint();
            }
            else
            {
                if (this.indexOfOldSquare + this.diceThrow > 39)
                {
                    this.indexOfNewSquare = this.indexOfOldSquare + this.diceThrow - 40;
                }
                else
                {
                    this.indexOfNewSquare = this.indexOfOldSquare + this.diceThrow;
                }

                this.HitCheck();

                this.ReturnPawn(pawnNumber);
            }
        }

        public void HitCheck()
        {
            if (this.GetPlayerOne().GetPawnList().Contains(this.indexOfNewSquare))
            {
                this.GetPlayerOne().GetPawnList().Remove(this.indexOfNewSquare);
            }
            else if (this.GetPlayerTwo().GetPawnList().Contains(this.indexOfNewSquare))
            {
                this.GetPlayerTwo().GetPawnList().Remove(this.indexOfNewSquare);
            }
            else if (this.GetPlayerThree().GetPawnList().Contains(this.indexOfNewSquare))
            {
                this.GetPlayerThree().GetPawnList().Remove(this.indexOfNewSquare);
            }
            else if (this.GetPlayerFour().GetPawnList().Contains(this.indexOfNewSquare))
            {
                this.GetPlayerFour().GetPawnList().Remove(this.indexOfNewSquare);
            }
        }

        public void ReturnPawn(int pawnNumber)
        {
            this.GetField()[this.indexOfNewSquare].AddPawn();
            this.GetActivePlayer().AddPawn(this.indexOfNewSquare);
        }

        public void CheckForWinner()
        {
            if (this.playerOne.GetScore() == 4)
            {
                this.winner = this.playerOne;
            }
            else if (this.playerTwo.GetScore() == 4)
            {
                this.winner = this.playerTwo;
            }
            else if (this.playerThree.GetScore() == 4)
            {
                this.winner = this.playerThree;
            }
            else if (this.playerFour.GetScore() == 4)
            {
                this.winner = this.playerFour;
            }
        }

        public void NextPlayer()
        {
            if (this.activePlayer == this.playerOne)
            {
                this.activePlayer = this.playerTwo;
            }
            else if (this.activePlayer == this.playerTwo)
            {
                this.activePlayer = this.playerThree;
            }
            else if (this.activePlayer == this.playerThree)
            {
                this.activePlayer = this.playerFour;
            }
            else if (this.activePlayer == this.playerFour)
            {
                this.activePlayer = this.playerOne;
            }
        }

        public bool endOfGameCheck()
        {
            if (this.playerOne.GetScore() == 4 || this.playerTwo.GetScore() == 4 || this.playerThree.GetScore() == 4
                    || this.playerFour.GetScore() == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PlaceNewPawn()
        {
            int index = GetIndexStartSquare();
            this.GetPlayerOne().GetPawnList().Remove(index);
            this.GetPlayerTwo().GetPawnList().Remove(index);
            this.GetPlayerThree().GetPawnList().Remove(index);
            this.GetPlayerFour().GetPawnList().Remove(index);
            this.GetField()[GetIndexStartSquare()].AddPawn();
            this.GetActivePlayer().AddPawn(GetIndexStartSquare());
        }

        public void MakeMovePawn(int pawnNumber)
        {
            this.dice.SetDiceThrow();
            this.GetDiceThrow();
            this.indexOfOldSquare = GetActivePawnList()[pawnNumber - 1];

            this.RemoveOldPawn(pawnNumber);

            this.PointCheck(pawnNumber);

            this.CheckForWinner();

            if (this.diceThrow != 6 && !(endOfGameCheck()))
            {
                this.NextPlayer();
            }
        }
    }
}
