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
        private InputService keyboardService = null;
        private VideoService videoService = null;
        Stages stage = Stages.TITLE;

        List<IMenu> menu = null;

        public TitleStage(InputService keyboardService, VideoService videoService, List<IMenu> GUI)
        {
            this.keyboardService = keyboardService;
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
        /// <param name="cast">The given cast.</param>
        public void GetInputs()
        {
            Actor robot = cast.GetFirstActor("robot");

            robot.SetVelocity(keyboardService.Scale(SYSTEM_SETTINGS.CELL_SIZE, new Vector2(-1, 0)));
           

        }

        /// <summary>
        /// Updates the robot's position and resolves any collisions with artifacts.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public Stages DoUpdates()
        {
            Banner banner = (Banner) cast.GetFirstActor("banner");
            Sprite robot = (Sprite)cast.GetFirstActor("robot");
            // List<Actor> artifacts = cast.GetActors("artifacts");

            // banner.SetText("");
            int maxX = SYSTEM_SETTINGS.MAX_X;
            int maxY = SYSTEM_SETTINGS.MAX_Y;
            robot.MoveNext(maxX, maxY);
             if (menu[0].isButtonPressed() == Button.Play)
            {
                stage = Stages.GAME;
            }else{
                stage = Stages.TITLE;
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

            // videoService.DrawActors(actors);
            videoService.DrawActors(menu[0].GetCast());
            // videoService.FlushBuffer();
            
           

            return actors;
        }

        private Cast SetupCast()
        {
            Cast cast = new Cast();

            // create the banner with ID -1;
            Banner banner = new Banner(-1);

            banner.SetMessage("WELCOME TO FIND THE KITTY");
            banner.FontSize = 30;
            // banner.SetFont(30);
            banner.SetColor(new Color(12, 24, 124, 255));
            banner.SetPosition(new Vector2(SYSTEM_SETTINGS.CELL_SIZE, 0));
            cast.AddActor("banner", banner);

            // create the Robot Sprite
            Random random = new Random();
            Sprite robot = new Sprite(1, TextureRegistry.PLAYER_TextureID);
            Vector2 vec =  keyboardService.Scale(SYSTEM_SETTINGS.CELL_SIZE, 
                                                new Vector2(random.Next(1, SYSTEM_SETTINGS.COLS), 
                                                                 random.Next(1, SYSTEM_SETTINGS.ROWS)));
            robot.SetHitBox(new Rectangle(vec.X, vec.Y, 64, 64));
            
            robot.SetTextureBounds(new Raylib_cs.Rectangle(64*8,64*5,64,64));
            cast.AddActor("robot", robot);

           
            // create the menu
            List<Actor> other = new List<Actor>();
            other.AddRange(cast.GetAllActors());

            Console.WriteLine("Setup TITLE Cast");

            return cast;
        }
    }
}