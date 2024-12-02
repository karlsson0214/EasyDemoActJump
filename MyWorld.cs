using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMonoGame;

namespace EasyDemoActJump 
{
    internal class MyWorld : World
    {
        public MyWorld() : base(800, 600)
        {
            // Tile background with the file "bluerock" in the Content folder.
            BackgroundTileName = "bluerock";

            Add(new Player(), "kangaroo", 400, 100);

            // ground - bottom
            for (int x = 0; x < 825; x += 25)
            {
                Add(new Ground(), "brick", x, 550);
            }
            // platforms to left
            for (int y = 150; y <= 450; y += 100)
            {
                for (int x = 0; x < 325; x += 25)
                {
                    Add(new Ground(), "brick", x, y);
                }
            }
            // elevator
            Ground elevator = new Ground();
            elevator.IsMoveable = true;
            Add(elevator, "brick", 350, 450);


        }
    }
}
