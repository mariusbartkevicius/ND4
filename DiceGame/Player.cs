using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ND4_Dice.DiceGame
{
    public class Player
    {
        
        public Player(int playerNumber)
        {
            PlayerNumber = playerNumber;
        }

        public int Score { get; set; }
        public int PlayerNumber { get; set; }

        public int RollDice()
        {
            int rollScore = 0;
            foreach (Dice die in GameControler.Dice)
            {
                rollScore += die.Roll();
            }
            Score = rollScore;
            return rollScore;
        }
    }
}
