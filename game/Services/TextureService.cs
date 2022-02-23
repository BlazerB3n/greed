// using Raylib_cs;
// using test.Game.Directing;

// namespace test.Game.Services.Video
// {

//     public class TextureSerivce
//     {
//         public TextureSerivce()
//         {

//         }

//         public void SetupTextures()
//         {
//             TextureRegistry.PLAYER = Raylib.LoadTexture(TextureRegistry.TEXTURE_PATH_Battler);
//             TextureRegistry.BOTTON = Raylib.LoadTexture(TextureRegistry.TEXTURE_PATH_BUTTONS);
//             TextureRegistry.ICONS = Raylib.LoadTexture(TextureRegistry.TEXTURE_PATH_icons);

//             // Raylib.LoadTextureCubemap

//             TextureRegistry.BOTTON_TextureID = (int) TextureRegistry.BOTTON.id;
//             TextureRegistry.PLAYER_TextureID = (int) TextureRegistry.PLAYER.id;
//             TextureRegistry.ICONS_TextureID = (int) TextureRegistry.ICONS.id;
//         }
        
//     }
// }

using Raylib_cs;

namespace test.Game.Services
{
    public class TextureService
    {
        private Image Texture;
        private int ID;
        public TextureService(string texture, int ID)
        {
            this.Texture = Raylib.LoadImage(texture);
            this.ID = ID;
        }

        public Image GetTexture()
        {
            return Texture;
        }
        public int GetTextureID()
        {
            return ID;
        }
        public void UnloadTexture()
        {
            Raylib.UnloadImage(Texture);
        }

        public void SetTexture(string texture)
        {
            this.Texture = Raylib.LoadImage(texture);
        }

    }
}