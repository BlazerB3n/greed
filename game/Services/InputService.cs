using Raylib_cs;
using test.Game.Casting;
using System.Numerics;

namespace test.Game.Services
{
    public class InputService
    {
        private int cellSize = SYSTEM_SETTINGS.CELL_SIZE;
        public InputService()
        {
        }

        public Vector2 GetDirection()
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

            Vector2 direction = new Vector2(dx, dy);
            direction = Scale(SYSTEM_SETTINGS.CELL_SIZE, direction);

            return direction;
        }
        
        public bool GetEnter()
        {
            return Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER);
        } 

        /// <summary>
        /// Whether or not this Point is equal to the given one.
        /// </summary>
        /// <param name="other">The point to compare.</param>
        /// <returns>True if both x and y are equal; false if otherwise.</returns>
        // public bool Equals(Point other)
        // {
        //     return this.x == other.GetX() && this.y == other.GetY();
        // }

        /// <summary>
        /// Adds the given point to this one by summing the x and y values.
        /// </summary>
        /// <param name="other">The point to add.</param>
        /// <returns>The sum as a new Point.</returns>
        public Vector2 Add(Vector2 first, Vector2 second)
        {
            float x = first.X + second.X;
            float y = first.Y + second.Y;
            return new Vector2(x, y);
        }

        /// <summary>
        /// Scales the point by multiplying the x and y values by the provided factor.
        /// </summary>
        /// <param name="factor">The scaling factor.</param>
        /// <returns>A scaled instance of Point.</returns>
        public Vector2 Scale(int factor, Vector2 point)
        {
            float x = point.X * factor;
            float y = point.Y * factor;
            return new Vector2(x, y);
        }

    }
}
