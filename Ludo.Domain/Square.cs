// <copyright file="Square.cs" company="Emmyvh">
// Copyright (c) Emmyvh. All rights reserved.
// </copyright>

namespace Ludo.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Square
    {
        private bool hasPawn = false;

        public void AddPawn()
        {
            this.hasPawn = true;
        }

        public void RemovePawn()
        {
            this.hasPawn = false;
        }

        public bool IsOccupied()
        {
            return this.hasPawn;
        }
    }
}
