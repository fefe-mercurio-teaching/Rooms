using System;
using System.Collections.Generic;
using System.Text;

namespace Rooms
{
    class Game
    {
        bool inGame = true;
        Room currentRoom;

        public Game()
        {
            Room room1 = new Room();
            room1.description = "Sei nella prima stanza. Puoi andare a destra e a sinistra.";

            Room room2 = new Room();
            room2.description = "Sei nella stanza di sinistra. Qui non c'è niente, puoi solo andare a destra.";

            Room room3 = new Room();
            room3.description = "Sei nella stanza di destra. Qui non c'è niente, puoi solo andare a sinistra.";

            room1.leftRoom = room2;
            room1.rightRoom = room3;

            room2.rightRoom = room1;

            room3.leftRoom = room1;

            currentRoom = room1;
        }

        public void GameCycle()
        {
            do
            {
                Console.Clear();

                Console.WriteLine(currentRoom.description);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    inGame = false;
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow && currentRoom.leftRoom != null)
                {
                    currentRoom = currentRoom.leftRoom;
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow && currentRoom.rightRoom != null)
                {
                    currentRoom = currentRoom.rightRoom;
                }

            } while (inGame);

        }
    }
}
