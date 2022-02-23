using Raylib_cs;
using Greed.Game.Casting;
using System.Numerics;

namespace Greed.Game.Services
{
    public class InputService
    {
        public InputService()
        {
        }
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

        public Vector2 GetDirection()
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

            Vector2 direction = new Vector2(dx, dy);
            direction = Scale(SYSTEM_SETTINGS.CELL_SIZE, direction);

            return direction;
        }
    }
}
