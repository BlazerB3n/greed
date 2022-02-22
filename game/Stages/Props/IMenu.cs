using Greed.Game.Casting;
using Greed.Game.Directing;
using System.Collections.Generic;

namespace Greed.Game.Services
{
    public interface IMenu
    {
        List<Actor> GetCast();
        Button isButtonPressed();


    }
}