using System;

namespace TextBasedAdventureGame
{
    public class Movement
    {
        public Map map = new Map();
        int[] playerPos = { 0, 0 };
        int[] currentPos = { 0, 0 };

        public void Move(int x, int y)
        {
            currentPos = new int[2] { playerPos[0] + x, playerPos[1] + y };
            if (map.IsABorder(currentPos))
            {
                Console.WriteLine("You can't move. You are at the border!");
                return;
            }
            else
            {
                playerPos = currentPos;
                Console.WriteLine($"Moving --> {playerPos[0]},{playerPos[1]}");
                map.CheckTheMap(playerPos);
            }
        }
        
       

    }
}
