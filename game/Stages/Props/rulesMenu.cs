using Greed.Game.Services;
using Greed.Game.Casting;
using Greed.Game.Directing;
using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;
using System;

namespace Greed.Game.Screens.Menus
{
    public class RulesMenu : IMenu
    {
        Cast  MenuCast = new Cast();

        Actor window = new Sprite(2, -1);
        int x;
        int y;
        int width;
        int height;
        InputService inputService = null;

        ButtonType buttonPressed = ButtonType.NONE;
        
        Vector2 mousePoint = new Vector2( 0.0f, 0.0f );

        int btnState = 0;

        bool button = false;
        Banner Title = new Banner();
        Button prev = null;

         public RulesMenu(int x, int y, int width, int height, InputService input)
        {
            this.x = x;
            this.y = y;
            inputService = input;
            this.height = height;
            this.width = width;
            Title.SetMessage("Rules: ");
            Title.FontSize = 50;
            Title.SetPosition(new Vector2(x + 10, y + 10));
            Title.SetColor(new Color(0,0,0, 255));

            prev = new Button(x + (width/16), y + (height/16) + 50,"Return", 34);

            window.SetHitBox(new Raylib_cs.Rectangle(x,y, width, height));
            window.SetColor(new Color(20, 150, 124, 255));
            MenuCast.AddActor("backgrond", window);
            
            DoButtonSetup();

            MenuCast.AddActor("title", Title);
        }

        public void GetInputs()
        {
            mousePoint = Raylib_cs.Raylib.GetMousePosition();

        }
        public void DoUpdates()
        {
            buttonPressed = ButtonType.NONE;

            if(prev.isButtonPressed(mousePoint)) buttonPressed = ButtonType.PREVEUS;
        }
        public void DoOutputs()
        {
            // StartGameButton.TextureBounds.x = 34 * btnState;
        }

        public List<Actor> GetCast()
        {
            GetInputs();
            DoUpdates();
            DoOutputs();

            return MenuCast.GetAllActors();
        }


        public ButtonType GetButtonPressed()
        {
            return buttonPressed;
        }

        private void DoButtonSetup()
        {
            MenuCast.AddActorList("return", prev.GetCast());

        }




    }
}