using Greed.Game.Directing;
using Greed.Game.Casting;
using System.Collections.Generic;

namespace Greed.Game.Screens
{
    public interface IStage
    {
        void GetInputs();

        Stages DoUpdates();

        List<Actor> DoOutputs();


    }
}