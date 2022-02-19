using Greed.Game.Director;

namespace Greed.Game.Services
{
    
    public interface IStage
    {
        void GetInputs();

        void DoUpdates();

        Stages DoOutputs();


    }
}