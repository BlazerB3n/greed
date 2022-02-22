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
        TextureService textureSerivce = new TextureService();

        Dictionary<int, Texture2D> textureList = null;
        public VideoService()
        {

        }

        public void OpenWindow()
        {
            Raylib.InitWindow(SYSTEM_SETTINGS.MAX_X, SYSTEM_SETTINGS.MAX_Y, SYSTEM_SETTINGS.CAPTION);
            Raylib.SetTargetFPS(SYSTEM_SETTINGS.FRAME_RATE);

            textureList = textureSerivce.SetupTextures();



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

        }
        
        public void endFrameRender()
        {
            Raylib.EndDrawing();
        }

        public void DrawActors(List<Actor> actors)
        {
            foreach (Actor actor in actors)
            {
                switch (actor.GetActorType())
                {
                    case ActorType.Banner:
                        DrawBanner((Banner) actor);
                        break;
                    case ActorType.Box:
                        DrawBox((Sprite) actor);
                        break;
                    case ActorType.Button:
                        DrawButton((Sprite) actor);
                        break;
                    case ActorType.Sprite:
                        DrawSprite((Sprite) actor);
                        break;
                    
                    
                    default:
                        break;
                } 
            }
        }
        
        private void DrawBox(Sprite sprite)
        {
            Raylib.DrawRectangleRec(sprite.GetTextureBounds(), sprite.GetColor());
        }
        private void DrawSprite(Sprite sprite)
        {
            Raylib.DrawTexturePro(textureList[sprite.GetTextureID()], sprite.GetTextureBounds(), sprite.GetPosition(), new Vector2(0,0) , 0 , Color.WHITE);
        }

        private void DrawButton(Sprite sprite)
        {

        }
        
        private void DrawBanner(Banner actor)
        {

        }
        
    }
}
