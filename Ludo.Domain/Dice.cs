// <copyright file="Dice.cs" company="Emmyvh">
// Copyright (c) Emmyvh. All rights reserved.
// </copyright>

namespace Ludo.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Dice
    {
        private int diceThrow = 1;

        private Random random = new Random();

        public int GetDiceThrow()
        {
            return this.diceThrow;
        }

        public void SetDiceThrow()
        {
            this.diceThrow = this.random.Next(1,7);
        }
    }
}