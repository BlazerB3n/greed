using Greed.Game.Casting;
using Greed.Game.Directing;
using System.Collections.Generic;

namespace Greed.Game.Services
{
    public class PlayMenu : IMenu
    {
        Cast MenuCast = new Cast();

        public PlayMenu() : base()
        {

        }

        public List<Actor> GetCast()
        {
            return null;
        }

        public Button isButtonPressed()
        {
            return 0;
        }


    }
}