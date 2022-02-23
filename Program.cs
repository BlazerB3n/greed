﻿using System;
using System.Collections.Generic;
using Raylib_cs;
using test.Game.Directing;
using test.Game.Services;


namespace test
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

            InputService keyboardService = new InputService();
            VideoService videoService 
                = new VideoService(false, TexturesList);

            Director director = new Director(keyboardService, videoService);
            
            director.GameLoop();
        }
    }
}
