using Raylib_cs;

namespace Greed.Game.Directing
{
    
    public enum Stages
    {
        TITLE,
        GAME,
        END
    }

    public enum ActorType
    {
        Banner,
        Sprite,
        Box,
        Button
    }
    public enum TextureType
    {
        Box,
        Player,
        Button,
        icon
    }
    public enum Button
    {
        Play,
        pause,
        settings,
        END
    }

    public struct Texture
    {
        public int TEXTURE_ID;
        public string TEXTURE_PATH;
    }
    
    // public struct TextureRegistry
    // {
    //     public List<Texture> Textures = new List<Texture>();
    // //     public static int BUTTON_TextureID = 0;
    // //     public static string TEXTURE_PATH_BUTTONS = "Data/Textures/Button_play.png";

    // //     public static int PLAYER_TextureID = 1;
    // //     public static string TEXTURE_PATH_Battler = "Data/Textures/battler_1_1.png";

    // //     public static int ICONS_TextureID = 2;
    // //     public static string TEXTURE_PATH_icons = "Data/Textures/icons_vx.png";
    // }
}