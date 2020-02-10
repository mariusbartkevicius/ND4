using System;
using System.Collections.Generic;
using System.Text;

namespace ND4_Dice.DiceGame
{
    public class Dice
    {
        public Dice(int numberOfSides = 6)
        {
        }

        public int Roll()
        {
            Random rand = new Random();
            return rand.Next(1, 6);
        }
    }
}
