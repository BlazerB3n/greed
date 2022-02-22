using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;
using Greed.Game.Services;

namespace Greed.Game.Directing
{

    public class Director
    {
        VideoService videoService = new VideoService();

        Dictionary<Stages, IStage> StageList = new List<IStage>();

        Stages stage = Stages.TITLE;
        public Director()
        {
            WeclomeStage title = new WeclomeStage();
            StageList.Add(Stages.TITLE, title);

        }
        public void GameLoop()
        {
            videoService.OpenWindow();
            while (videoService.IsWindowOpen)
            {
                switch (stage)
                {
                    case Stages.TITLE:
                        StageList[Stages.TITLE].GetInputs();
                        stage = StageList[Stages.TITLE].DoUpdates();
                        videoService.DrawActors(StageList[Stages.TITLE].DoOutputs());
                        break;
                    case Stages.GAME:
                        break;
                    case Stages.END:
                        break;

                    default:
                }
            }
            
        }



    }
}
