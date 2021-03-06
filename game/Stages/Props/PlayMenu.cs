using Greed.Game.Services;
using Greed.Game.Casting;
using Greed.Game.Directing;
using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;

namespace Greed.Game.Screens.Menus
{
    public class PlayMenu : IMenu
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
        Vector2 touchPoint;

        Button settings = null;
        Button Play = null;
        Button rules = null;

        public PlayMenu(int x, int y, int width, int height, InputService input)
        {
            this.x = x;
            this.y = y;
            inputService = input;
            this.height = height;
            this.width = width;

            Play = new Button(x + (width/16), y + (height/16),"PLAY", 34);
            settings = new Button(x + (width/16), y + (height/16)*5, "SETTINGS", 34 );
            rules = new Button(x + (width/8), y + (height/8)*6, "RULES", 24);

            window.SetHitBox(new Raylib_cs.Rectangle(x,y, width, height));
            window.SetColor(new Color(20 ,14, 124, 255));
            MenuCast.AddActor("backgrond", window);
            DoSpriteSetup();
        }

        public void GetInputs()
        {
            mousePoint = Raylib_cs.Raylib.GetMousePosition();
        }
        public void DoUpdates()
        {
            buttonPressed = ButtonType.NONE;

            if(settings.isButtonPressed(mousePoint)) buttonPressed = ButtonType.SETTINGS;

            
            if(Play.isButtonPressed(mousePoint)) buttonPressed = ButtonType.PLAY;

            if(rules.isButtonPressed(mousePoint)) buttonPressed = ButtonType.RULES;
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

        private void DoSpriteSetup()
        {
            MenuCast.AddActorList("button", settings.GetCast());
            MenuCast.AddActorList("play", Play.GetCast());
            MenuCast.AddActorList("rules", rules.GetCast());


        }

    }
}