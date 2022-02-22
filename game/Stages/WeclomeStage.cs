
using Greed.Game.Directing;
using Greed.Game.Casting;
using Greed.Game.Services;
using System.Collections.Generic;

namespace Greed.Game.Services

{
    public class WeclomeStage: IStage
    {
        Cast cast = new Cast();
        InputService inputService = new InputService();

        Sprite Main = new Sprite();
        public WeclomeStage()
        {
            cast = setupCast();
        }

        public void GetInputs()
        {

        }

        public Stages DoUpdates()
        {
            float x = Main.GetPosition().x;
            float y = Main.GetPosition().y;
            if (x > SYSTEM_SETTINGS.MAX_X)
            {
                x = 0;
            }
            Main.SetPosition(x, y);
        }

        public List<Actor> DoOutputs()
        {
            return cast.GetAllActors();
        }

        private Cast setupCast()
        {
            Main.SetPosition(50,50);
            Main.SetTextureType(TextureType.icon);
            cast.AddActor("textiure", Main);
        }


    }
}