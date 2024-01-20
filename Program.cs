using System;
using System.Reflection;

namespace TextBasedAdventureGame
{
    public static class Program
    {
        static Movement playerMovement = new Movement();
        public static bool isGameFinished;
        public static void Main(string[] args)
        {
            playerMovement.map.playerName = GetPlayerName();
            StartMove();
        }

        static string GetPlayerName()
        {
            Console.WriteLine("Please Enter Your Name: ");
            var nameInput = Console.ReadLine();
            return nameInput;
        }
        static void StartMove()
        {
            Console.WriteLine("Please enter a direction to walk around the room!(forward, back, right, left)");
            var movementInput = Console.ReadLine();
            switch (movementInput)
            {
                case "forward":
                    playerMovement.Move(0, 1);
                    break;
                case "back":
                    playerMovement.Move(0, -1);
                    break;
                case "right":
                    playerMovement.Move(1, 0);
                    break;
                case "left":
                    playerMovement.Move(-1, 0);
                    break;
                case "default":
                    Console.WriteLine("Invalid movement direction!");
                    break;

            }
            StartMove();
        }
        public static void StartGameEnd()
        {
            Console.WriteLine("Press R to restart the game!");
            var returnInput = Console.ReadLine();
            if (returnInput == "r" || returnInput == "R")
            {
                var fileName = Assembly.GetExecutingAssembly().Location;
                System.Diagnostics.Process.Start(fileName);
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Your answer is invalid!");
                StartGameEnd();
            }
        }
    }
}
