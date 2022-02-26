using Greed.Game.Casting;
using Greed.Game.Directing;
using System.Collections.Generic;

namespace Greed.Game.Screens.Menus
{
    public interface IMenu
    {
        List<Actor> GetCast();
        ButtonType GetButtonPressed();


    }
}