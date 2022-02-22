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
        private TextureType textureType;

        public Actor()
        {
        }

        /// <summary>
        /// Gets the Actor's ID value.
        /// </summary>
        /// <returns>The ID value.</returns>
        public ActorType GetActorType()
        {
            return actorType;
        }

        /// <summary>
        /// Gets the Actor's Position.
        /// </summary>
        /// <returns>The Position.</returns>
        public Raylib_cs.Rectangle GetPosition()
        {
            return HitBox;
        }

        /// <summary>
        /// Gets the Actor's Volocity.
        /// </summary>
        /// <returns>The Volocity.</returns>
        public Vector2 GetVolocity()
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
            int x = (int) ((HitBox.x + velocity.X) + maxX) % maxX;
            int y = (int) ((HitBox.y + velocity.Y) + maxY) % maxY;
            HitBox = new Raylib_cs.Rectangle(x, y, HitBox.width, HitBox.height);
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
        /// Sets the actor's color to the given value.
        /// </summary>
        /// <param name="color">The given color.</param>
        /// <exception cref="ArgumentException">When color is null.</exception>
        public void SetColor(Color color)
        {
            this.color = color;
        }

        /// <summary>
        /// Sets the actor's position to the given value.
        /// </summary>
        /// <param name="position">The given position.</param>
        /// <exception cref="ArgumentException">When position is null.</exception>
        public void SetPosition(Vector2 Position)
        {
            if (Position == null)
            {
                throw new ArgumentException("position can't be null");
            }
            this.HitBox = new Raylib_cs.Rectangle(Position.X, Position.Y, this.HitBox.width, this.HitBox.height);
        }


        /// <summary>
        /// Sets the actor's velocity to the given value.
        /// </summary>
        /// <param name="velocity">The given velocity.</param>
        /// <exception cref="ArgumentException">When velocity is null.</exception>
        public void SetVelocity(Vector2 velocity)
        {
            if (velocity == null)
            {
                throw new ArgumentException("velocity can't be null");
            }
            this.velocity = velocity;
        }

    }
}
