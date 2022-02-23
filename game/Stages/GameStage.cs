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
    
    public class GameStage : IStage
    {
        private Cast cast = null;
        private InputService inputService = null;
        private VideoService videoService = null;
        Stages stage = Stages.GAME;

        List<IMenu> menu = null;

        public GameStage(InputService inputService, VideoService videoService, List<IMenu> GUI)
        {
            this.inputService = inputService;
            this.videoService = videoService;
            menu = GUI;
            cast = SetupCast();
        }

        public void RunAct()
        {
            GetInputs();
            DoUpdates();
            DoUpdates();
        }


        /// <summary>
        /// Gets directional input from the keyboard and applies it to the robot.
        /// </summary>
        public void GetInputs()
        {
            Actor robot = cast.GetFirstActor("robot");

            robot.SetVelocity(inputService.Scale(SYSTEM_SETTINGS.CELL_SIZE, new Vector2(-1, 0)));
           

        }

        /// <summary>
        /// Updates the robot's position and resolves any collisions with artifacts.
        /// </summary>
        public Stages DoUpdates()
        {
            Banner banner = (Banner) cast.GetFirstActor("banner");
            Sprite robot = (Sprite) cast.GetFirstActor("robot");
            // List<Actor> artifacts = cast.GetActors("artifacts");

            // banner.SetText("");
            int maxX = SYSTEM_SETTINGS.MAX_X;
            int maxY = SYSTEM_SETTINGS.MAX_Y;
            robot.MoveNext(maxX, maxY);
            return stage;
        }

        /// <summary>
        /// Draws the actors on the screen.
        /// </summary>
        public List<Actor> DoOutputs()
        {
            
            List<Actor> actors = cast.GetAllActors();
            // videoService.ClearBuffer();
            Banner banner = (Banner) cast.GetFirstActor("banner");
            // videoService.DrawActors(actors);
            // videoService.DrawActors(menu[0].GetCast());
            // videoService.FlushBuffer();
            
            banner.SetMessage("Total Score: ");
           

            return actors;
        }

        private Cast SetupCast()
        {
            Cast cast = new Cast();

            // create the banner with ID -1;
            Banner banner = new Banner(-1);

            banner.FontSize = 30;
            // banner.SetFont(30);
            banner.SetColor(new Color(12, 24, 124, 255));
            banner.SetPosition(new Vector2(SYSTEM_SETTINGS.CELL_SIZE, 0));
            cast.AddActor("banner", banner);

            // create the Robot Sprite
            Random random = new Random();
            Sprite robot = new Sprite(1, TextureRegistry.PLAYER_TextureID);
            Vector2 vec =  inputService.Scale(SYSTEM_SETTINGS.CELL_SIZE, 
                                                new Vector2(random.Next(1, SYSTEM_SETTINGS.COLS), 
                                                                 random.Next(1, SYSTEM_SETTINGS.ROWS)));
            robot.SetHitBox(new Rectangle(vec.X, vec.Y, 64, 64));
            
            robot.SetTextureBounds(new Raylib_cs.Rectangle(64*8,64*5,64,64));
            cast.AddActor("robot", robot);

           
            // create the menu
            List<Actor> other = new List<Actor>();
            other.AddRange(cast.GetAllActors());

            Console.WriteLine("Setup GAME Cast");

            return cast;
        }
    }
}