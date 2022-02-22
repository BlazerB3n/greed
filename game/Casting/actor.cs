using System;
using Raylib_cs;
using System.Numerics;

using Greed.Game.Directing;

namespace Greed.Game.Casting
{
    public class Actor
    {
        /// The position of the object on the screen 
        /// and the size of that object
        private Rectangle HitBox = new Rectangle(posX, posY, width, height);

        /// the speed and direction the object is moving 
        private Vector2 velocity = new Vector2(0, 0);

        /// the color tint of object
        private Color color = new Color(255, 255, 255, 255);

        /// the type of actor
        private ActorType actorType; 

        public Actor()
        {
        }

        /// <summary>
        /// Gets the Actor's ID value.
        /// </summary>
        /// <returns>The ID value.</returns>
        public int GetID()
        {
            return ID;
        }

        /// <summary>
        /// Gets the Actor's Position.
        /// </summary>
        /// <returns>The Position.</returns>
        public Raylib_cs.Rectangle GetPosition()
        {
            return position;
        }

        /// <summary>
        /// Gets the Actor's Volocity.
        /// </summary>
        /// <returns>The Volocity.</returns>
        public Point GetVolocity()
        {
            return velocity;
        }

        /// <summary>
        /// Moves the actor to its next position according to its velocity. Will wrap the position 
        /// from one side of the screen to the other when it reaches the maximum x and y 
        /// values.
        /// </summary>
        /// <param name="maxX">The maximum x value.</param>
        /// <param name="maxY">The maximum y value.</param>
        public void MoveNext(int maxX, int maxY)
        {
            int x = (int) ((position.x + velocity.GetX()) + maxX) % maxX;
            int y = (int) ((position.y + velocity.GetY()) + maxY) % maxY;
            position = new Raylib_cs.Rectangle(x, y, position.width, position.height);
        }
        
        /// <summary>
        /// Gets the Actor's color.
        /// </summary>
        /// <returns>The color.</returns>
        public Color GetColor()
        {
            return color;
        }

        /// <summary>
        /// Gets the Actor's scailer value.
        /// </summary>
        /// <returns>The scailer value.</returns>
        public int GetScailer()
        {
            return scailer;
        }

        /// <summary>
        /// Sets the actor's color to the given value.
        /// </summary>
        /// <param name="color">The given color.</param>
        /// <exception cref="ArgumentException">When color is null.</exception>
        public void SetColor(Color color)
        {
            if (color == null)
            {
                throw new ArgumentException("color can't be null");
            }
            this.color = color;
        }

        /// <summary>
        /// Sets the actor's font size to the given value.
        /// </summary>
        /// <param name="fontSize">The given font size.</param>
        /// <exception cref="ArgumentException">
        /// When font size is less than or equal to zero.
        /// </exception>

        public void SetScailer(int Scailer)
        {
            if (Scailer <= 0)
            {
                throw new ArgumentException("fontSize must be greater than zero");
            }
            this.scailer = Scailer;
        }

        /// <summary>
        /// Sets the actor's position to the given value.
        /// </summary>
        /// <param name="position">The given position.</param>
        /// <exception cref="ArgumentException">When position is null.</exception>
        public void SetPosition(Point position)
        {
            if (position == null)
            {
                throw new ArgumentException("position can't be null");
            }
            this.position = new Raylib_cs.Rectangle(position.GetX(), position.GetY(), this.position.width, this.position.height);
        }


        /// <summary>
        /// Sets the actor's velocity to the given value.
        /// </summary>
        /// <param name="velocity">The given velocity.</param>
        /// <exception cref="ArgumentException">When velocity is null.</exception>
        public void SetVelocity(Point velocity)
        {
            if (velocity == null)
            {
                throw new ArgumentException("velocity can't be null");
            }
            this.velocity = velocity;
        }

    }
}
