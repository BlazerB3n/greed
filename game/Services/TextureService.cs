using Raylib_cs;
using Greed.Game.Directing;

namespace Greed.Game.Services
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
