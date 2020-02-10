using System;
using System.Collections.Generic;
using System.Text;

namespace ND4_Dice.DiceGame
{
    public static class Settings
    {
        public static int NumberOfPlayers { get; set; }
        public static void GetSettingsFromUser()
        {
            GetNumberOfPlayers();
            GetDiceNumber();
        }

        private static void GetDiceNumber()
        {
            int numberOfDice = 3;

            Console.WriteLine("Player will have 3 dices each. Add more or less? (+) or (-)");

            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Add)
                {
                    numberOfDice ++;
                    Console.WriteLine(numberOfDice);
                }
                if (Console.ReadKey(true).Key == ConsoleKey.Subtract)
                {
                    numberOfDice--;
                    Console.WriteLine(numberOfDice);
                }
            }
            Console.WriteLine("We will play with " + numberOfDice + " dices.");

            for (int i = 1; i <= numberOfDice; i++)
            {
                Dice die;
                {
                    die = new Dice();
                }
                GameControler.Dice.Add(die);
            }
        }
              
        private static void GetNumberOfPlayers()
        {
            int numberOfPlayers = 0;
            while (numberOfPlayers <= 0)
            {
                Console.WriteLine("Please input how many players?");
                if (int.TryParse(Console.ReadLine(), out numberOfPlayers))
                {
                    NumberOfPlayers = numberOfPlayers;
                }
            }
        }
    }
}
