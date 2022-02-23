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

        InputService inputService = null;

        
        Vector2 mousePoint = new Vector2( 0.0f, 0.0f );

        int btnState = 0;

        Sprite sprite = null;
        
            Sprite StartGameButton = new Sprite(1, TextureRegistry.BOTTON_TextureID);

        Button btnAction = Button.NONE;
        public PlayMenu(int x, int y, InputService input)
        {
            this.x = x;
            this.y = y;
            inputService = input;
            
            window.SetHitBox(new Raylib_cs.Rectangle(x,y, 256,256));
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
            Raylib_cs.Rectangle hitbox = StartGameButton.GetHitBox();
            if (Raylib_cs.Raylib.CheckCollisionPointRec(mousePoint, StartGameButton.GetHitBox()))
            {
                if (Raylib_cs.Raylib.IsMouseButtonDown(Raylib_cs.MouseButton.MOUSE_BUTTON_LEFT)) btnState = 2;
                    else btnState = 1;

                if (Raylib_cs.Raylib.IsMouseButtonReleased(Raylib_cs.MouseButton.MOUSE_BUTTON_LEFT)) btnAction = Button.Play;
            }
            else
            {
                btnState = 0;
            }
        }
        public void DoOutputs()
        {
            StartGameButton.TextureBounds.x = 34 * btnState;
        }

        public List<Actor> GetCast()
        {
            GetInputs();
            DoUpdates();
            DoOutputs();

            return MenuCast.GetAllActors();
        }


        public Button isButtonPressed()
        {
            return btnAction;
        }

        private void DoSpriteSetup()
        {
            StartGameButton.SetTextureBounds(new Raylib_cs.Rectangle(0, 0, 34, 10));
            StartGameButton.SetHitBox(new Raylib_cs.Rectangle(0, 0, 306, 90));
            StartGameButton.SetPosition(new Vector2(x+12, y+12));
            // StartGameButton.SetTextureID();
            MenuCast.AddActor("play", StartGameButton);
            
            StartGameButton.SetTextureBounds(new Raylib_cs.Rectangle(0, 0, 34, 10));
            StartGameButton.SetHitBox(new Raylib_cs.Rectangle(0, 0, 306, 90));
            StartGameButton.SetPosition(new Vector2(x+12, y+12));
            
            MenuCast.AddActor("play", StartGameButton);
            


        }
    }
}