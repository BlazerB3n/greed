using Raylib_cs;
using Greed.Game.Directing;

namespace Greed.Game.Services
{

    public class TextureService
    {
        public TextureService()
        {

        }

        public void SetupTextures()
        {
            TextureRegistry.PLAYER = Raylib.LoadTexture(TextureRegistry.TEXTURE_PATH_Battler);
            TextureRegistry.BUTTON = Raylib.LoadTexture(TextureRegistry.TEXTURE_PATH_BUTTONS);
            TextureRegistry.ICONS = Raylib.LoadTexture(TextureRegistry.TEXTURE_PATH_icons);

            // Raylib.LoadTextureCubemap

            TextureRegistry.BUTTON_TextureID = (int) TextureRegistry.BUTTON.id;
            TextureRegistry.PLAYER_TextureID = (int) TextureRegistry.PLAYER.id;
            TextureRegistry.ICONS_TextureID = (int) TextureRegistry.ICONS.id;
        }
        
    }
}
