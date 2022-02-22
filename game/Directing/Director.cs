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
        TextureService textureService = new TextureService();

        List<IStage> StageList = new List<IStage>();
        public Director()
        {
            
        }
        public void GameLoop()
        {
            
        }


    }
}
