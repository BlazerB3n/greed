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
        Banner = -1,
        Sprite = 1,
        Box,
        Button
    }
    public enum TextureType
    {
        icon,
        Player,
        Button,
        Box
    }
    public enum Button
    {
        NONE,
        Play,
        pause,
        settings,
        END
    }

    public struct TextureRegistry
    {
        public static int BOTTON_TextureID = 1;
        public static string TEXTURE_PATH_BUTTONS = "Data/Textures/Button_play.png";


        public static int PLAYER_TextureID = 2;
        public static string TEXTURE_PATH_Battler = "Data/Textures/battler_1_1.png";


        public static int ICONS_TextureID = 0;
        public static string TEXTURE_PATH_icons = "Data/Textures/icons_vx.png";
    }
}
