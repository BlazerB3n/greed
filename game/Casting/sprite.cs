using Raylib_cs;
using test.Game.Directing;

namespace test.Game.Casting
{
    public class Sprite : Actor
    {
        /// the part of the texture image to be displayed by the sprite
        /// posX = x on the png
        /// posY = y on the png
        /// width = the width of the portopn of the png to be displayed
        /// height = the height of the portopn of the png to be displayed

        private Rectangle TextureBounds = new Rectangle(posX, posY, width, height);

        private TextureType textureType;

        public Sprite() : base()
        {
        }

        public Rectangle GetTextureBounds()
        {
            
        }

        public void SetTextureBounds()
        {

        }
    }
}
