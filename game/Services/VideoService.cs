using Raylib_cs;
using System.Collections.Generic;
using System.Numerics;
using Greed.Game.Casting;
using Greed.Game.Directing;
using static Greed.SYSTEM_SETTINGS;

namespace Greed.Game.Services
{
    public class VideoService
    {
        // List<Texture2D> ListTexture = new List<Texture2D>();
        // TextureService textureService = null;

        List<TextureService> TextureList = null;
        Dictionary<int, Texture2D> textures = new Dictionary<int, Texture2D>();
        
        private bool debug = false;
        public VideoService(bool debug, List<TextureService> texturelist)
        {
            this.debug = debug;
            this.TextureList = texturelist;

        }

        public void OpenWindow()
        {
            Raylib.InitWindow(SYSTEM_SETTINGS.MAX_X, SYSTEM_SETTINGS.MAX_Y, SYSTEM_SETTINGS.CAPTION);
            Raylib.SetTargetFPS(SYSTEM_SETTINGS.FRAME_RATE);
            
            foreach (TextureService item in TextureList)
            {
                // ListTexture.Add(Raylib.LoadTextureFromImage(item.GetTexture()));
                textures.Add(item.GetTextureID(), Raylib.LoadTextureFromImage(item.GetTexture()));
                item.UnloadTexture();
            } 



        }

        public bool IsWindowOpen()
        {
            return !Raylib.WindowShouldClose();
        }

        public void CloseWindow()
        {
            Raylib.CloseWindow();
        }

        public void StartFrameRender()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib_cs.Color.WHITE);
            if (debug)
            {
                DrawGrid();
            }

        }
        
        public void endFrameRender()
        {
            Raylib.EndDrawing();
        }

        public void DrawActors(List<Actor> actors)
        {
            foreach (Actor actor in actors)
            {
                int id = (int) actor.GetActorID();
                if (id > -1)
                {
                    switch (id)
                    {
                        case -1:
                            DrawBanner(actor);
                            break;
                        case 2:
                            DrawBox(actor);
                            break;
                        case 3:
                            DrawSprite(actor);
                            break;
                        case 1:
                            DrawSprite(actor);
                            break;
                        
                        
                        default:
                            break;
                    } 
                }
                else
                {
                    DrawBanner(actor);
                }
            }
        }
        
        private void DrawBox(Actor actor)
        {
        
            Raylib.DrawRectangleRec(actor.GetHitBox(), actor.GetColor());
        }
        // private void DrawSprite(Sprite actor)
        // {
        //         Raylib.DrawTexturePro(, new Rectangle(0, 0, (float) 34, 
        //                         (float) 10), new Rectangle(0,0, 1020, 300), new Vector2(0,0) , 0 , Color.WHITE);
        // }
/// <summary>
        /// Draws the given actor's text on the screen.
        /// </summary>
        /// <param name="actor">The actor to draw.</param>
        public void DrawSprite(Actor actor)
        {

            
            Rectangle hitBox = actor.GetHitBox();
            
            int x = (int) hitBox.x;
            int y = (int) hitBox.y;

            // int x = actor.GetPosition().GetX();
            // int y = actor.GetPosition().GetY();
            // int fontSize = actor.GetFontSize();

            Raylib_cs.Color color = actor.GetColor();
            Sprite sprite = (Sprite) actor;
            
            int id = (int) sprite.GetTextureID();

            if (id == -1)
            {
                Raylib.DrawRectangleRec(sprite.GetTextureBounds(), color);
                return;
            }

            // else if (!textures.ContainsKey(id))
            // {
                
            //     textures.Add(id, Raylib.LoadTextureFromImage(TextureList[id].GetTexture()));
            //     TextureList.RemoveAt(id);
            //     // textures[id] = Raylib.LoadTextureFromImage(sprite.GetTexture());
            // }

            Texture2D texture = textures[id];

            Raylib.DrawTexturePro(texture, sprite.GetTextureBounds(), hitBox, new Vector2(0,0) , 0 , color);
            
            // Raylib.DrawTextureRec(texture, sprite.GetRectangle(), new System.Numerics.Vector2( x, y), color);
            
        }
        private void DrawButton(Actor actor)
        {

        }
        
        private void DrawBanner(Actor actor)
        {
            Banner banner = (Banner) actor;
            int x = (int) banner.GetPossition().X;
            int y = (int) banner.GetPossition().Y;
            Raylib.DrawText(banner.GetMessage(), x,y,banner.FontSize, banner.GetColor());
        }
        
        /// <summary>
        /// Draws a grid on the screen.
        /// </summary>
        private void DrawGrid()
        {
            for (int x = 0; x < SYSTEM_SETTINGS.MAX_X; x += SYSTEM_SETTINGS.CELL_SIZE)
            {
                Raylib.DrawLine(x, 0, x, SYSTEM_SETTINGS.MAX_Y, Raylib_cs.Color.GRAY);
            }
            for (int y = 0; y < SYSTEM_SETTINGS.MAX_Y; y += SYSTEM_SETTINGS.CELL_SIZE)
            {
                Raylib.DrawLine(0, y, SYSTEM_SETTINGS.MAX_X, y, Raylib_cs.Color.GRAY);
            }
        } 
    }
}
