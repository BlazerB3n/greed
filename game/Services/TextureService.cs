using Raylib_cs;
using System.Collections.Generic;
using Greed.Game.Directing;

namespace Greed.Game.Services
{

    public class TextureService
    {

        Dictionary<int, Texture2D> textureList = new Dictionary<int, Texture2D>();
        public TextureService()
        {

        }

        public Dictionary<int, Texture2D> SetupTextures()
        {
            
            // TextureRegistry.PLAYER = Raylib.LoadTexture(TextureRegistry.TEXTURE_PATH_Battler);
            // TextureRegistry.BOTTON = Raylib.LoadTexture(TextureRegistry.TEXTURE_PATH_BUTTONS);
            // TextureRegistry.ICONS = Raylib.LoadTexture(TextureRegistry.TEXTURE_PATH_icons);
            
            // textureList.Add(TextureRegistry.PLAYER_TextureID, Raylib.LoadTexture(TextureRegistry.TEXTURE_PATH_Battler));
            // textureList.Add(TextureRegistry.BUTTON_TextureID, Raylib.LoadTexture(TextureRegistry.TEXTURE_PATH_BUTTONS));
            // textureList.Add(TextureRegistry.ICONS_TextureID, Raylib.LoadTexture(TextureRegistry.TEXTURE_PATH_icons));
            
            // // Raylib.LoadTextureCubemap

            // TextureRegistry.BOTTON_TextureID = (int) textureList[0].id;
            // TextureRegistry.PLAYER_TextureID = (int) textureList[1].id;
            // TextureRegistry.ICONS_TextureID = (int) textureList[2].id;
            Texture Button = new Texture();
            Button.TEXTURE_ID = 0;
            Button.TEXTURE_PATH = "Data/Textures/Button_play.png";
                textureList.Add(Button.TEXTURE_ID, Raylib.LoadTexture(Button.TEXTURE_PATH));

            Texture Batteler = new Texture();
            Batteler.TEXTURE_ID = 1;
            Batteler.TEXTURE_PATH = "Data/Textures/battler_1_1.png";
                textureList.Add(Batteler.TEXTURE_ID, Raylib.LoadTexture(Batteler.TEXTURE_PATH));

            Texture Icons = new Texture();
            Icons.TEXTURE_ID = 2;
            Icons.TEXTURE_PATH = "Data/Textures/icons_vx.png";
                textureList.Add(Icons.TEXTURE_ID, Raylib.LoadTexture(Icons.TEXTURE_PATH));

            return textureList;
        }
        
    }
}
