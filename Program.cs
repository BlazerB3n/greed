using System;
using Greed.Game.Casting;


namespace Greed
{
    public struct SYSTEM_SETTINGS
    {
    public static int FRAME_RATE = 12;
    public static int MAX_X = 960;
    public static int MAX_Y = 624;
    public static int CELL_SIZE = 24;
    public static int FONT_SIZE = 24;
    public static int COLS = 40;
    public static int ROWS = 26;
    public static string CAPTION = "Robot Finds Kitten";
    public static string DATA_PATH = "Data/messages.txt";
    public static string TEXTURE_PATH_icons = "Data/Textures/icons_vx.png";
    public static string TEXTURE_PATH_Battler = "Data/Textures/battler_1_1.png";
    public static Color WHITE = new Color(255, 255, 255);
    public static int DEFAULT_ARTIFACTS = 40;
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            
        }
    }
}
