using System;
using System.Collections.Generic;
using System.Linq;

namespace TextBasedAdventureGame
{
    class PlayerMovement
    {
        int[] playerPos = (0, 0);
        int[] currentPos = (0, 0);

        int playerHealth = 2;
        string playerName;

        List<string> riddleChoices = new List<string>("Stick", "Human", "Table");
        string riddleAnswer = "Candle";

        bool hasSolverItem;


        #region MapVariables
        int[] mapBorderX = (-1, 1);
        int[] mapBorderY = (-1, 1);

        int[] startPos = (0, 0);
        int[] npcPos = (-1, 1);
        int[] solverItemPos = (-1, -1);
        int[] clue1Pos = (0, 1);
        int[] clue2Pos = (0, -1);
        #endregion
        public void Move(int x, int y)
        {
            currentPos = (playerPos[0] + x, playerPos[1] + y);
            if (IsABorder(currentPos))
            {
                Console.WriteLine("You can't move. You are at the border!");
                return;
            }
            else
            {
                playerPos = currentPos;
                Console.WriteLine("Moving...");
                CheckTheMap();
            }
        }
        public void CheckTheMap()
        {
            switch (playerPos)
            {
                case startPos:
                    Console.WriteLine("You are at the starting point.");
                    break;
                case npcPos:
                    Console.WriteLine($"Hey + {playerName}, I have a riddle for you which will cause your dead if you don't give the true answer!");
                    WriteTheChoices();
                    Answer();
                    break;
                case solverItemPos:
                    Console.WriteLine("You find an item on the ground. It may help you in the future.");
                    hasSolverItem = true;
                    break;
                case clue1Pos:
                    Console.WriteLine("From here, you can see nearly half part of the room in the dim light.");
                    break;
                case clue2Pos:
                    Console.WriteLine("You see some wax pieces on the table.");
                    break;
                case default:
                    Console.WriteLine("You see nothing around here.");
                    break;
            }

        }
        bool IsABorder(int[] pos)
        {
            if (pos[0] < mapBorderX[0] || pos[0] > mapBorderX[1] || pos[1] < mapBorderY[0] || pos[1] > mapBorderY[1]) return true;
            else return false;
        }
        void Answer()
        {
            var answer = Console.ReadLine();
            if (answer == riddleAnswer)
            {
                Console.WriteLine("Congratulations! Your answer is true. You WIN the game!");
                Console.ReadLine();
            }
            else
            {
                if (!riddleChoices.Contains(answer)) Console.WriteLine("Your answer is invalid! Try Again!");
                else Console.WriteLine("Your answer is incorrect! Try Again!");
                    
                Console.ReadLine();
                playerHealth--;
                Answer();
            }
            
        }

        void WriteTheChoices()
        {
            var number = 1;
            Console.WriteLine("Here are the choices. Write one of them: ");
            foreach (string choice in riddleChoices)
            {
                Console.WriteLine(number + choice);
                number++;
            }
            if (hasSolverItem) Console.WriteLine("Item Solver's answer: " + riddleAnswer);
        }
        
    }
}
