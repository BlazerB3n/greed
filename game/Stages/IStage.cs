using test.Game.Directing;

namespace test.Game.Services
{
    public interface IStage
    {
        void GetInputs();

        void DoUpdates();

        Stages DoOutputs();


    }
}