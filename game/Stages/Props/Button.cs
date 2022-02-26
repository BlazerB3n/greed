using Greed.Game.Casting;
using Greed.Game.Directing;
using Greed.Game.Services;
using System.Collections.Generic;
using System.Numerics;
using System;
using Raylib_cs;

namespace Greed.Game.Screens.Menus
{
    public class Button
    {
        Cast cast = new Cast();

        Banner text = new Banner();
        Sprite texture = new Sprite(1, TextureRegistry.BOTTON_TextureID);

        int btnState = 0;

        bool btnAction = false;

        int x;
        int y;
        int width;
        int height;

        public Button(int x, int y, string labble, int FontSize)
        {
            this.x = x;
            this.y = y;
            // this.width = width;
            // this.height = height;
            Vector2 size = Raylib_cs.Raylib.MeasureTextEx(Raylib.GetFontDefault(), labble, FontSize, 10.0f);
            Console.WriteLine("SIZE: " + size.X + " Y: " + size.Y);
            texture.SetTextureBounds(new Raylib_cs.Rectangle(0,0, 34, 12));
            texture.SetHitBox(new Raylib_cs.Rectangle(x, y, size.X + (size.X/16), size.Y + (size.Y/2)));
            text.SetPosition(new Vector2(x + (size.X/8), y + (size.Y/4)));

            text.SetMessage(labble);
            
            text.FontSize = FontSize;
            text.SetColor(Raylib_cs.Color.BLACK);

            cast.AddActor("texture", texture);
            cast.AddActor("label", text);


        }
        public List<Actor> GetCast()
        {
            return cast.GetAllActors();
        }
        public bool isButtonPressed(Vector2 mousePosition)
        {
            btnAction = false;
            
            foreach (Actor item in cast.GetAllActors())
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