using System;
using Raylib_cs;
using System.Numerics;

using test.Game.Directing;

namespace test.Game.Casting
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


    }
}
