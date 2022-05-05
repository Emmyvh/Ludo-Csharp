// <copyright file="Player.cs" company="Emmyvh">
// Copyright (c) Emmyvh. All rights reserved.
// </copyright>

namespace Ludo.Domain
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Player
    {
        private int score;
        private List<int> indexListSquaresOccupied;

        public Player()
        {
            this.score = 0;
            this.indexListSquaresOccupied = new List<int>();
        }

        public void AddPoint()
        {
            this.score++;
        }

        public int GetScore()
        {
            return this.score;
        }

        public void AddPawn(int index)
        {
            if (this.indexListSquaresOccupied.Count() + this.score < 4)
            {
                this.indexListSquaresOccupied.Add(index);
            }
        }

        public void LosePawn(int index)
        {
            if (this.indexListSquaresOccupied.Count() > 0)
            {
                this.indexListSquaresOccupied.Remove(index);
            }
        }

        public List<int> GetPawnList()
        {
            return this.indexListSquaresOccupied;
        }
    }
}
