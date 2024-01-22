using System;
using System.Collections.Generic;
using System.Linq;

namespace TextBasedAdventureGame
{
    public class Map
    {
        int playerHealth = 2;
        public string playerName;
        string riddle = "Riddle: I’m tall when I’m young, and I’m short when I’m old.What am I?";
        List<string> riddleChoices = new List<string>() { "Stick", "Human", "Table", "Candle", "Future"};

        string riddleAnswer = "Candle";
        bool hasSolverItem;

        #region Map Position Variables
        int[] mapBorderHorizontal = { -1, 1 };
        int[] mapBorderVertical = { -1, 1 };
        int[] startPos = { 0, 0 };
        int[] npcPos = { -1, 1 };
        int[] solverItemPos = { -1, -1 };
        int[] clue1Pos = { 0, 1 };
        int[] clue2Pos = { 0, -1 };
        #endregion

        public void CheckTheMap(int[] playerPos)
        {
            if (playerPos.SequenceEqual(startPos)) Console.WriteLine("You are at the starting point.");
            else if (playerPos.SequenceEqual(npcPos))
            {
                Console.WriteLine($"Hey {playerName}, I have a riddle for you which will cause your dead if you don't give the true answer!");
                Console.WriteLine(riddle);
                WriteTheChoices();
                Answer();
            } 
            else if (playerPos.SequenceEqual(solverItemPos))
            {
                Console.WriteLine("You find an item on the ground. It may help you in the future.");
                hasSolverItem = true;
            }
            else if (playerPos.SequenceEqual(clue1Pos)) Console.WriteLine("From here, you can see nearly half part of the room in the dim light.");
            else if (playerPos.SequenceEqual(clue2Pos)) Console.WriteLine("You see some wax pieces on the table.");
            else Console.WriteLine("You see nothing around here.");
        }
        public bool IsABorder(int[] pos)
        {
            if (pos[0] < mapBorderHorizontal[0] || pos[0] > mapBorderHorizontal[1] || pos[1] < mapBorderVertical[0] || pos[1] > mapBorderVertical[1]) return true;
            else return false;
        }
        void Answer()
        {
            var answer = Console.ReadLine();
            if (answer == riddleAnswer)
            {
                Console.WriteLine("Congratulations! Your answer is true. You WIN the game!");
                Program.StartGameEnd();
            }
            else
            {
                if (!riddleChoices.Contains(answer)) Console.WriteLine("Your answer is invalid!");
                else Console.WriteLine("Your answer is incorrect!");

                if(playerHealth > 1)
                {
                    playerHealth--;
                    Console.WriteLine($"You have {playerHealth} more chance. Try again!");
                    Answer();
                }
                else
                {
                    Console.WriteLine("The creature attacked you and YOU DIED!");
                    Program.StartGameEnd();
                }
                
            }

        }

        void WriteTheChoices()
        {
            var number = 1;
            Console.WriteLine("Here are the choices. Write one of them: ");
            foreach (string choice in riddleChoices)
            {
                Console.WriteLine($"{number}. {choice}");
                number++;
            }
            if (hasSolverItem) Console.WriteLine("---Item gives you this answer: " + riddleAnswer);
        }
        
    }
}
