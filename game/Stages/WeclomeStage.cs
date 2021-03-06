using Raylib_cs;
using Greed.Game.Directing;
using Greed.Game.Casting;
using Greed.Game.Services;
using Greed.Game.Screens.Menus;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Greed.Game.Screens
{
    
    public class TitleStage : IStage
    {
        private Cast cast = null;
        private InputService inputService = null;
        private VideoService videoService = null;
        Stages stage = Stages.TITLE;

        List<IMenu> menu = null;

        int menuIndex = 0;

        public TitleStage(InputService inputService, VideoService videoService)
        {
            this.inputService = inputService;
            this.videoService = videoService;
            menu = SetupMenus();
            cast = SetupCast();
        }
        
        /// <summary>
        /// Gets directional input from the keyboard and applies it to the robot.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void GetInputs()
        {
            Actor robot = cast.GetFirstActor("robot");
            
            robot.SetVelocity(inputService.Scale(SYSTEM_SETTINGS.CELL_SIZE, new Vector2(1, 0)));
           

        }

        /// <summary>
        /// Updates the robot's position and resolves any collisions with artifacts.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public Stages DoUpdates()
        {
            Banner banner = (Banner) cast.GetFirstActor("banner");
            Sprite robot = (Sprite) cast.GetFirstActor("robot");
            // List<Actor> artifacts = cast.GetActors("artifacts");

            // banner.SetText("");
            int maxX = SYSTEM_SETTINGS.MAX_X;
            int maxY = SYSTEM_SETTINGS.MAX_Y;
            robot.MoveNext(maxX, maxY);

            switch (menu[menuIndex].GetButtonPressed())
            {
                case ButtonType.PLAY:
                    stage = Stages.GAME;
                    break;
                case ButtonType.SETTINGS:
                    menuIndex = 1;
                    break;
                case ButtonType.PAUSE:
                    menuIndex = 3;
                    break;
                case ButtonType.PREVEUS:
                    menuIndex = 0;
                    break;
                case ButtonType.RULES:
                    menuIndex = 2;
                    break;
                case ButtonType.NONE:
                    break;
                default:
                    stage = Stages.TITLE;
                    break;

            }


            return stage;
        }

        /// <summary>
        /// Draws the actors on the screen.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public List<Actor> DoOutputs()
        {

            List<Actor> actors = cast.GetAllActors();
            // videoService.ClearBuffer();

            videoService.DrawActors(actors);
            videoService.DrawActors(menu[menuIndex].GetCast());
            // videoService.FlushBuffer();
            
           

            return actors;
        }

        private Cast SetupCast()
        {
            Cast cast = new Cast();

            // create the banner with ID -1;
            Banner banner = new Banner();
            banner.SetMessage("WELCOME TO GREED");
            banner.FontSize = 30;
            // banner.SetFont(30);
            banner.SetColor(new Color(12, 24, 124, 255));
            banner.SetPosition(new Vector2(SYSTEM_SETTINGS.CELL_SIZE, 0));
            cast.AddActor("banner", banner);

            // create the Robot Sprite
            Random random = new Random();
            Sprite robot = new Sprite(1, TextureRegistry.PLAYER_TextureID);

            Vector2 vec =  inputService.Scale(SYSTEM_SETTINGS.CELL_SIZE, new Vector2(20, 20));

            robot.SetHitBox(new Rectangle(vec.X, vec.Y, 64, 64));
            
            robot.SetTextureBounds(new Raylib_cs.Rectangle(64*8,64*5,64,64));
            cast.AddActor("robot", robot);


            vec =  inputService.Scale(SYSTEM_SETTINGS.CELL_SIZE, 
                                                new Vector2(random.Next(3, SYSTEM_SETTINGS.COLS), 
                                                                 random.Next(1, SYSTEM_SETTINGS.ROWS)));
            

            Sprite gem = new Sprite(1, TextureRegistry.ICONS_TextureID);

            gem.SetHitBox(new Rectangle(0, 0, 24, 24));
            gem.SetTextureBounds(new Rectangle(12*24,1*24, 24,24));
            cast.AddActor("gem", gem);
           
            // create the menu
            List<Actor> other = new List<Actor>();
            other.AddRange(cast.GetAllActors());

            Console.WriteLine("Setup TITLE Cast");

            return cast;
        }

        private List<IMenu> SetupMenus()
        {
            List<IMenu> MenuList = new List<IMenu>();
            PlayMenu main = new PlayMenu((SYSTEM_SETTINGS.MAX_X/4), (SYSTEM_SETTINGS.MAX_Y/4), (SYSTEM_SETTINGS.MAX_X/4) , (SYSTEM_SETTINGS.MAX_Y/8) * 3, inputService);

            SettingsMenu settings = new SettingsMenu((SYSTEM_SETTINGS.MAX_X/8), (SYSTEM_SETTINGS.MAX_Y/8), (SYSTEM_SETTINGS.MAX_X/2), (SYSTEM_SETTINGS.MAX_Y/2) , inputService);
            RulesMenu rules = new RulesMenu((SYSTEM_SETTINGS.MAX_X/8), (SYSTEM_SETTINGS.MAX_Y/8), (SYSTEM_SETTINGS.MAX_X/2), (SYSTEM_SETTINGS.MAX_Y/2) , inputService);
           
            MenuList.Add(main);
            MenuList.Add(settings);
            MenuList.Add(rules);

            return MenuList;
        }  
    }
}