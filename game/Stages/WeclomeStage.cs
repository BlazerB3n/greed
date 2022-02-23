using Raylib_cs;
using Greed;
using Greed.Game.Directing;
using Greed.Game.Casting;
using Greed.Game.Services;
using Greed.Game.Screens;
using Greed.Game.Screens.Menus;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Greed.Game.Screens
{
    
    public class TitleStage : IStage
    {
        private Cast cast = null;
        private InputService keyboardService = null;
        private VideoService videoService = null;
        Stages stage = Stages.TITLE;

        // Dictionary<string, MenuService> menu = null;
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
            // Point velocity = keyboardService.GetDirection();
            
            // Point direction = new Point(-1, 0);
            // direction = direction.Scale(SYSTEM_SETTINGS.CELL_SIZE);

            robot.SetVelocity(keyboardService.Scale(SYSTEM_SETTINGS.CELL_SIZE, new Vector2(-1, 0)));
           
            // if (keyboardService.GetEnter())
            // {
            //     stage = Stages.GAME;
            // }else{
            //     stage = Stages.TITEL;
            // }

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

            // foreach (Actor actor in artifacts)
            // {
            //     if (robot.GetPosition().Equals(actor.GetPosition()))
            //     {
            //         Sprite artifact = (Sprite) actor;
            //         string message = artifact.GetMessage();
            //         banner.SetText(message);
            //     }
            // } 
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
            
            // robot.setTexturePosition(new Point(0,0));
            robot.SetTextureBounds(new Raylib_cs.Rectangle(64*8,64*5,64,64));
            cast.AddActor("robot", robot);

            // load the messages
            // List<string> messages = File.ReadAllLines(SYSTEM_SETTINGS.DATA_PATH).ToList<string>();

            // // create the artifacts
            // for (int i = 0; i < SYSTEM_SETTINGS.DEFAULT_ARTIFACTS; i++)
            // {
            //     // string text = ((char)random.Next(33, 126)).ToString();
            //     string message = messages[i];

            //     int x = random.Next(1, SYSTEM_SETTINGS.COLS);
            //     int y = random.Next(1, SYSTEM_SETTINGS.ROWS);
            //     Point position = new Point(x, y);
            //     position = position.Scale(SYSTEM_SETTINGS.CELL_SIZE);

                
            //     int Rx = random.Next(1, SYSTEM_SETTINGS.COLS);
            //     int Ry = random.Next(1, SYSTEM_SETTINGS.ROWS);
            //     Point Rposition = new Point(Rx, Ry);
            //     Rposition = Rposition.Scale(SYSTEM_SETTINGS.CELL_SIZE);


            //     int r = random.Next(0, 256);
            //     int g = random.Next(0, 256);
            //     int b = random.Next(0, 256);
            //     Casting.Color color = new Casting.Color(r, g, b);

            //     Sprite artifact = new Sprite(i+10, 0);
            //     artifact.setTexturePosition(Rposition);
            //     // artifact.SetText(text);
            //     // artifact.SetFontSize(FONT_SIZE);
            //     artifact.SetColor(color);
            //     artifact.SetPosition(position);
            //     artifact.SetMessage(message);
            //     newCast.AddActor("artifacts", artifact);

                
            // }

            // create the menu
            List<Actor> other = new List<Actor>();
            other.AddRange(cast.GetAllActors());

            Console.WriteLine("Setup TITLE Cast");

            return cast;
        }
    }
}