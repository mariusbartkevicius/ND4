using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ND4_Dice.DiceGame
{
    public static class GameControler
    {

        public static List<Player> Players;
        public static List<Dice> Dice;

        public static void MainMenu()
        {
            bool correctPress = false;
            while (correctPress == false) 
            {
                Console.WriteLine("Press P to start. Press Q to Quit.");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.P)
                {
                     correctPress = true;
                    Start();
                   
                }
                else if (keyInfo.Key == ConsoleKey.Q)
                {
                   correctPress = true;
                   Quit();       
                }
            }
        }

        public static void GameOverMenu()
        {
            bool correctPress = false;
            while (correctPress == false)
            {
                Console.WriteLine("Press R to replay, M - Go to menu, Q - Quit.");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.R)
                {
                    correctPress = true;
                    Start();

                }
                else if (keyInfo.Key == ConsoleKey.M)
                {
                    correctPress = true;
                    MainMenu();
                }
                else if (keyInfo.Key == ConsoleKey.Q)
                {
                    correctPress = true;
                    Quit();
                }
            }
        }

        public static void Start()
        {
            Dice = new List<Dice>();
            Settings.GetSettingsFromUser();
            GetPlayers();
            DisplayPlayers();
            Begin(Players);
            GameOverMenu();
        }

        public static int Quit()
        {
            return 0;
        }

        private static void GetPlayers()
        {
            Players = new List<Player>();

            for (int i = 1; i <= Settings.NumberOfPlayers; i++)
            {
                Player player = new Player(i);
                Players.Add(player);
            }
        }

        public static void DisplayPlayers()
        {
            Console.WriteLine("Players in the game: " + Players.Count);
        }

        public static void Begin(List<Player> players)
        {

            for (int i = 1; i <= 1; i++) 
            {
                foreach (Player p in players)
                {
                    Console.WriteLine("Player " + p.PlayerNumber +  " roll... (Enter to roll)");
                    Console.ReadLine();
                    Console.WriteLine("Player " + p.PlayerNumber + " rolled a " + p.RollDice() + Environment.NewLine);
                }
                GetWinner(players);
            }
        }

        private static void GetWinner(List<Player> players)
        {
            int maxScore = 0;
            List<Player> winners = new List<Player>();
            foreach (Player p in players)
            {
                if (p.Score >= maxScore)
                {
                    maxScore = p.Score;
                }
            }

            foreach (Player p in players)
            {
                if (p.Score == maxScore)
                {
                    winners.Add(p);
                }
            }

            if (winners.Count > 1)
            {
                Console.WriteLine("Tie! Another Round.");
                Begin(winners);
            }
            else
            {
                foreach (Player p in GameControler.Players)
                {
                    if (winners.First().PlayerNumber == p.PlayerNumber)
                    {
                        Console.WriteLine("Player " + winners.First().PlayerNumber + " won!!!");
                    }
                }
                Console.Write(Environment.NewLine);
            }
        }
    }
}
