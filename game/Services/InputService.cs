using Raylib_cs;
using System.Numerics;
using Greed.Game.Casting;

namespace Greed.Game.Services
{
    class InputService
    {
        

        public InputService(int CELL_SIZE)
        {
            SYSTEM_SETTINGS.CELL_SIZE = CELL_SIZE;

        }       

        public Point GetDirection()
        {
            int dx = 0;
            int dy = 0;
            

            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                dx = -1;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                dx = 1;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {
                dy = -1;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                dy = 1;
            }
            

        
            Point direction = new Point(dx, dy);
            
            direction = direction.Scale(SYSTEM_SETTINGS.CELL_SIZE);

            return direction;
        }

        
    }
}
