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
        bool GamePaused = false;

        List<IMenu> menu = null;
int frame = 0;
        public GameStage(InputService inputService, VideoService videoService)
        {
            this.inputService = inputService;
            this.videoService = videoService;
            // menu = GUI;
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
            
            Vector2 direction =  inputService.GetDirection();
            direction.Y = 0;
            robot.SetVelocity( direction);

            // pause the game
           if (Raylib.IsKeyPressed(KeyboardKey.KEY_P))
           {
               if (GamePaused)
               {
                    GamePaused = false;
               }
               else
               {
                    GamePaused = true;
               }
           }
            
        }

        /// <summary>
        /// Updates the robot's position and resolves any collisions with artifacts.
        /// </summary>
        public Stages DoUpdates()
        {
            if (frame == SYSTEM_SETTINGS.FRAME_RATE && !GamePaused)
            {
                frame = 0;
            }else
            {
                frame ++;
            }
            
            int maxX = SYSTEM_SETTINGS.MAX_X;
            int maxY = SYSTEM_SETTINGS.MAX_Y;
            Random random = new Random();
            Vector2 vec1;
            Vector2 vec2;

            

            Banner banner = (Banner) cast.GetFirstActor("banner");
            Sprite robot = (Sprite) cast.GetFirstActor("robot");
            // List<Actor> artifacts = cast.GetActors("artifacts");

            // banner.SetText("");
            robot.MoveNext(maxX, maxY);


            if (frame%6 == 0 && frame != 0 && !GamePaused)
            {
                for (int i = 0; i < random.Next(4); i++)
                {
                    vec1 = inputService.Scale(SYSTEM_SETTINGS.CELL_SIZE, 
                                                new Vector2(random.Next(1, SYSTEM_SETTINGS.COLS), 
                                                            random.Next(1, SYSTEM_SETTINGS.ROWS)));
                    
                    // Create Ruby Sprite
                    Sprite ruby = new Sprite(1, TextureRegistry.ICONS_TextureID);
                    ruby.SetHitBox(new Rectangle(vec1.X, 0, 64, 64));
                    int textureOffset = random.Next(9,9+7);
                    ruby.score = (textureOffset - 8);
                    ruby.SetTextureBounds(new Rectangle(textureOffset*24,1*24, 24,24));
                    cast.AddActor("ruby", ruby);
                    
                    // Create Rock Sprite
                    vec2 = inputService.Scale(SYSTEM_SETTINGS.CELL_SIZE, 
                                                new Vector2(random.Next(1, SYSTEM_SETTINGS.COLS), 
                                                            random.Next(1, SYSTEM_SETTINGS.ROWS)));
                    if (vec1 == vec2){
                        
                    vec2 = inputService.Scale(SYSTEM_SETTINGS.CELL_SIZE, 
                                                new Vector2(random.Next(1, SYSTEM_SETTINGS.COLS), 
                                                            random.Next(1, SYSTEM_SETTINGS.ROWS)));
                    }

                    textureOffset = random.Next(13, 16);

                    Sprite rock = new Sprite(1, TextureRegistry.ICONS_TextureID);
                    rock.SetHitBox(new Rectangle(vec2.X, 0, 64, 64));
                    rock.SetTextureBounds(new Rectangle(textureOffset*24,6*24, 24,24));
                    rock.score = -1 * (textureOffset - 12) * 5;
                    cast.AddActor("rock", rock);
                    
                }

                foreach (Actor ruby in cast.GetActors("ruby"))
                {
                    if(ruby.GetPossition().Y >= SYSTEM_SETTINGS.MAX_Y )
                    {
                        cast.RemoveActor("ruby", ruby);
                    }
                    
                    Vector2 velocity = inputService.Scale(SYSTEM_SETTINGS.CELL_SIZE, new Vector2(0, 1));
                    Vector2 rubyPOS = ruby.GetPossition();
                    float x = (rubyPOS.X + velocity.X);
                    float y = (rubyPOS.Y + velocity.Y);
                    Vector2 pos = new Vector2(x,y);
                    ruby.SetPosition(pos);
                
                }

                foreach (Actor rock in cast.GetActors("rock"))
                {
                    
                    if(rock.GetPossition().Y >= SYSTEM_SETTINGS.MAX_Y )
                    {
                        cast.RemoveActor("ruby", rock);
                    }
                    
                    Vector2 velocity = inputService.Scale(SYSTEM_SETTINGS.CELL_SIZE, new Vector2(0, 1));
                    Vector2 rubyPOS = rock.GetPossition();

                    float x = (rubyPOS.X + velocity.X);
                    float y = (rubyPOS.Y + velocity.Y);
                    Vector2 pos = new Vector2(x,y);
                    rock.SetPosition(pos);
                }
            }
            
                foreach (Actor ruby in cast.GetActors("ruby"))
                {
                    
                    if (ruby.GetPossition() == robot.GetPossition())
                    {
                        robot.score += ruby.score;
                        cast.RemoveActor("ruby", ruby);
                    }
                    // Console.WriteLine("ruby score:")
                
                }

                foreach (Actor rock in cast.GetActors("rock"))
                {
                    if (rock.GetPossition() == robot.GetPossition())
                    {
                        robot.score += rock.score;
                        cast.RemoveActor("rock", rock);
                    }
                }
            banner.SetMessage("Total Score: " + robot.score);
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
            Sprite robot = (Sprite) cast.GetFirstActor("robot");
            // videoService.DrawActors(actors); 
            // videoService.DrawActors(menu[0].GetCast());
            // videoService.FlushBuffer();
            
           

            return actors;
        }


        private Cast SetupCast()
        {
            Cast cast = new Cast();

            // create the banner with ID -1;
            Banner banner = new Banner();

            banner.FontSize = 30;
            // banner.SetFont(30);
            banner.SetColor(Color.BLACK);
            banner.SetPosition(new Vector2(SYSTEM_SETTINGS.CELL_SIZE, 0));
            
            //bannerbackground
            Actor bannerbackground = new Actor(2);
            bannerbackground.SetHitBox(new Rectangle(0, 0, SYSTEM_SETTINGS.MAX_X, 24));
            
            bannerbackground.SetColor(new Color(133, 23, 234, 150));
            cast.AddActor("bannerbackground", bannerbackground);
            cast.AddActor("banner", banner);

            // create the Robot Sprite
            Random random = new Random();
            Sprite robot = new Sprite(1, TextureRegistry.PLAYER_TextureID);
            robot.score = 0;
            Vector2 vec =  inputService.Scale(SYSTEM_SETTINGS.CELL_SIZE, 
                                                new Vector2(random.Next(1, SYSTEM_SETTINGS.COLS), 
                                                                 random.Next(1, SYSTEM_SETTINGS.ROWS)));
            robot.SetHitBox(new Rectangle(SYSTEM_SETTINGS.MAX_X/2, SYSTEM_SETTINGS.MAX_Y-64-16, 64, 64));
            
            robot.SetTextureBounds(new Raylib_cs.Rectangle(64*2,64*5,64,64));
            cast.AddActor("robot", robot);

            // // Create Ruby Sprite
            // Sprite ruby = new Sprite(1, TextureRegistry.ICONS_TextureID);

            // ruby.SetHitBox(new Rectangle(vec.X, 24, 64, 64));
            
            // ruby.SetTextureBounds(new Rectangle(9*24,1*24, 24,24));
            
            // cast.AddActor("ruby", ruby);

            // vec =  inputService.Scale(SYSTEM_SETTINGS.CELL_SIZE, 
            //                                     new Vector2(random.Next(1, SYSTEM_SETTINGS.COLS), 
            //                                                      random.Next(1, SYSTEM_SETTINGS.ROWS)));
            // // Create Rock Sprite
            // Sprite rock = new Sprite(1, TextureRegistry.ICONS_TextureID);

            // rock.SetHitBox(new Rectangle(vec.X, 24, 64, 64));
            
            
            // rock.SetTextureBounds(new Rectangle(14*24,1*24, 24,24));
            // cast.AddActor("rock", rock);

            // create the menu
            List<Actor> other = new List<Actor>();
            other.AddRange(cast.GetAllActors());

            Console.WriteLine("Setup GAME Cast");

            return cast;
        }
    }
}