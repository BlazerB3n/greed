using Greed.Game.Casting;
using Greed.Game.Directing;
using Greed.Game.Services;
using System.Collections.Generic;
using System.Numerics;
using System;
using Raylib_cs;

namespace Greed.Game.Screens.Menus
{
    public class ButtonUpDown
    {
        Cast cast = new Cast();

        Banner title = new Banner();

        ButtonIcon iconUp = null;
        
        ButtonIcon iconDown = null;

        int btnState = 0;

        bool btnAction = false;

        int x;
        int y;

        public ButtonUpDown(int x, int y, string labble, int FontSize)
        {
            this.x = x;
            this.y = y;
            // icon = new Sprite(1, TextureID);
            // this.width = width;
            // this.height = height;
            // Vector2 size = new Vector2(24,24);
            Vector2 size = Raylib_cs.Raylib.MeasureTextEx(Raylib.GetFontDefault(), labble, FontSize, 10.0f);
            // Console.WriteLine("SIZE: " + size.X + " Y: " + size.Y);
            // texture.SetTextureBounds(new Raylib_cs.Rectangle(0,0, 34, 12));
            // texture.SetHitBox(new Raylib_cs.Rectangle(x, y, size.X + (size.X/2), size.Y + (size.Y/2)));
            this.title.SetMessage(labble);
            this.title.FontSize = FontSize;
            this.title.SetPosition(new Vector2(x,y));

            iconUp = new ButtonIcon( x + (int) ((size.X/16)), y + FontSize, new Rectangle(0, 1*24, 24, 24), TextureRegistry.ICONS_TextureID);
            iconDown = new ButtonIcon(x + (int) ((size.X/8)*3), y + FontSize, new Rectangle(1*24, 1*24, 24, 24), TextureRegistry.ICONS_TextureID);

            cast.AddActor("label", title);

            cast.AddActorList("buttonUP", iconUp.GetCast());
            cast.AddActorList("buttonDonw", iconDown.GetCast());


        }
        public List<Actor> GetCast()
        {
            return cast.GetAllActors();
        }
        public int isButtonPressed(Vector2 mousePosition)
        {

            
            
            if(iconUp.isButtonPressed(mousePosition))
            {
                return 1;
            }
            
            if(iconDown.isButtonPressed(mousePosition))
            {
                return -1;
            }

            return 0;

        }


    }
}