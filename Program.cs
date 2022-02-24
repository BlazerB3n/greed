using System;
using System.Collections.Generic;
using Raylib_cs;
using Greed.Game.Directing;
using Greed.Game.Services;


namespace Greed
{
    public struct SYSTEM_SETTINGS
    {
    public static int FRAME_RATE = 12;
    public static int MAX_X = 1280;
    public static int MAX_Y = 720;
    public static int CELL_SIZE = 64;
    public static int FONT_SIZE = 24;
    public static int COLS = 40;
    public static int ROWS = 26;
    public static string CAPTION ="Greed";
    public static string DATA_PATH = "Data/messages.txt";
    public static string TEXTURE_PATH_icons = "Data/Textures/icons_vx.png";
    public static string TEXTURE_PATH_Battler = "Data/Textures/battler_1_1.png";
    public static string TEXTURE_PATH_BUTTONS = "Data/Textures/Button_play.png";
    public static Color WHITE = new Color(255, 255, 255, 255);
    public static int DEFAULT_ARTIFACTS = 40;
    }
    class Program
    {
        static void Main(string[] args)
        {
            // start the game

            TextureService Icons = new TextureService(TextureRegistry.TEXTURE_PATH_icons, TextureRegistry.ICONS_TextureID);
            TextureService Battler = new TextureService(TextureRegistry.TEXTURE_PATH_Battler, TextureRegistry.PLAYER_TextureID);
            TextureService Buttons = new TextureService(TextureRegistry.TEXTURE_PATH_BUTTONS, TextureRegistry.BOTTON_TextureID);


            List<TextureService> TexturesList = new List<TextureService>();
            TexturesList.Add(Buttons);
            TexturesList.Add(Battler);
            TexturesList.Add(Icons);

            InputService inputService = new InputService();
            VideoService videoService 
                = new VideoService(true, TexturesList);

            Director director = new Director(inputService, videoService);
            
            director.GameLoop();
        }
    }
}
