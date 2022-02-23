using Raylib_cs;
using Greed.Game.Directing;

namespace Greed.Game.Casting
{
    public class Sprite : Actor
    {
        /// the part of the texture image to be displayed by the sprite
        /// posX = x on the png
        /// posY = y on the png
        /// width = the width of the portopn of the png to be displayed
        /// height = the height of the portopn of the png to be displayed
        // private Rectangle TextureBounds = new Rectangle(posX, posY, width, height);
        public Rectangle TextureBounds = new Rectangle(0, 0, 0, 0);
        private TextureType textureType;
        int TextureID;
        public Sprite(int ID, int TextureID) : base(ID)
        {
            this.TextureID = TextureID;
        }
        public Rectangle GetTextureBounds()
        {
            return TextureBounds;
            
        }

        public void SetTextureBounds(Rectangle TextureBounds)
        {
            this.TextureBounds = TextureBounds;

        }

        public int GetTextureID()
        {
            return TextureID;
            
        }

        public void SetTextureID(int TextureID)
        {
            this.TextureID  = TextureID;
        }

        // public TextureType GetTextureType()
        // {
        //     return textureType;
            
        // }

        // public void SetTextureType(TextureType textureType)
        // {
        //     this.textureType  = textureType;
        // }
    }
}
