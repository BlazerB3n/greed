using Raylib_cs;

namespace test.Game.Directing
{
    
    public enum Stages
    {
        TITEL,
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

    public struct TextureRegistry
    {
        public static Texture2D BOTTON;
        public static int BOTTON_TextureID;
        public static string TEXTURE_PATH_BUTTONS = "Data/Textures/Button_play.png";


        public static Texture2D PLAYER;
        public static int PLAYER_TextureID;
        public static string TEXTURE_PATH_Battler = "Data/Textures/battler_1_1.png";


        public static Texture2D ICONS;
        public static int ICONS_TextureID;
        public static string TEXTURE_PATH_icons = "Data/Textures/icons_vx.png";
    }
}
