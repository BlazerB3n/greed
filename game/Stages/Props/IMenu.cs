using test.Game.Casting;
using test.Game.Directing;
using System.Collections.Generic;

namespace test.Game.Services
{
    public interface IMenu
    {
        List<Actor> GetCast();
        Button isButtonPressed();


    }
}