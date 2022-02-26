using Greed.Game.Casting;
using Greed.Game.Directing;
using Greed.Game.Services;
using System.Collections.Generic;
using System.Numerics;
using System;
using Raylib_cs;

namespace Greed.Game.Screens.Menus
{
    public class ButtonIcon
    {
        Cast cast = new Cast();

        Sprite icon = null;
        Sprite texture = new Sprite(1, TextureRegistry.BOTTON_TextureID);

        int btnState = 0;

        bool btnAction = false;

        int x;
        int y;
        int width;
        int height;

        public ButtonIcon(int x, int y, Rectangle iconTextureBounds, int TextureID)
        {
            this.x = x;
            this.y = y;
            icon = new Sprite(1, TextureID);
            // this.width = width;
            // this.height = height;
            Vector2 size = new Vector2(24,24);
            // Vector2 size = Raylib_cs.Raylib.MeasureTextEx(Raylib.GetFontDefault(), labble, FontSize, 10.0f);
            // Console.WriteLine("SIZE: " + size.X + " Y: " + size.Y);
            texture.SetTextureBounds(new Raylib_cs.Rectangle(0,0, 34, 12));
            texture.SetHitBox(new Raylib_cs.Rectangle(x, y, size.X + (size.X/2), size.Y + (size.Y/2)));
            

            icon.SetHitBox(new Rectangle(0, 0, 36, 36));
            icon.SetPosition(new Vector2(x, y));
            icon.SetTextureBounds(iconTextureBounds);
            
            // icon.FontSize = 34;
            icon.SetColor(Raylib_cs.Color.WHITE);

            cast.AddActor("texture", texture);
            cast.AddActor("label", icon);


        }
        public List<Actor> GetCast()
        {
            return cast.GetAllActors();
        }
        public bool isButtonPressed(Vector2 mousePosition)
        {
            btnAction = false;

            foreach (Actor item in cast.GetActors("texture"))
            {
                if(item.GetActorID() > 0)
                {
                    Sprite sprite = (Sprite) item;
                    // Raylib_cs.Rectangle hitbox = item.GetHitBox();
                    if (Raylib_cs.Raylib.CheckCollisionPointRec(mousePosition, item.GetHitBox()))
                    {
                        if (Raylib_cs.Raylib.IsMouseButtonDown(Raylib_cs.MouseButton.MOUSE_BUTTON_LEFT)) btnState = 2;
                            else btnState = 1;

                        if (Raylib_cs.Raylib.IsMouseButtonReleased(Raylib_cs.MouseButton.MOUSE_BUTTON_LEFT)) btnAction = true;
                    }
                    else
                    {
                        btnState = 0;
                    } 
                    
                    sprite.TextureBounds.x = 34 * btnState;
                 
                }else
                {

                }
            }
            return btnAction;
        }


    }
}