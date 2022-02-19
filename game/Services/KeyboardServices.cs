using Raylib_cs;
using Greed.Game.Casting;
using System.Numerics;
using Greed;

namespace Greed.Game.Services
{
    public class KeyboardServices
    {
        private int cellSize = 16;
        public KeyboardServices(int cellsize)
        {
            this.cellSize = cellsize;
        }

        public Point GetDirection()
        {
            int dx = 0;
            int dy = 0;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)){
                dx = -1;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)){
                dx = 1;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP)){
                dy = -1;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN)){
                dy = 1;
            }

            Point direction = new Point(dx, dy);
            direction = direction.Scale(cellSize);

            return direction;
        }
        
        public bool GetEnter()
        {
            return Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER);
        } 
    }
}