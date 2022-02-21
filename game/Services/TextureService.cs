using Raylib_cs;
using test.Game.Directing;

namespace test.Game.Services
{

    public class TextureSerivce
    {
        public TextureSerivce()
        {

        }

        public void SetupTextures()
        {
            TextureRegistry.PLAYER = Raylib.LoadTexture(TextureRegistry.TEXTURE_PATH_Battler);
            TextureRegistry.BOTTON = Raylib.LoadTexture(TextureRegistry.TEXTURE_PATH_BUTTONS);
            TextureRegistry.ICONS = Raylib.LoadTexture(TextureRegistry.TEXTURE_PATH_icons);

            // Raylib.LoadTextureCubemap

            TextureRegistry.BOTTON_TextureID = (int) TextureRegistry.BOTTON.id;
            TextureRegistry.PLAYER_TextureID = (int) TextureRegistry.PLAYER.id;
            TextureRegistry.ICONS_TextureID = (int) TextureRegistry.ICONS.id;
        }
        
    }
}
