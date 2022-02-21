using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;
using test.Game.Services;

namespace test.Game.Directing
{

    public class Director
    {
        VideoSerivce videoSerivce = new VideoSerivce();
        TextureSerivce textureSerivce = new TextureSerivce();

        List<IStage> StageList = new List<IStage>();
        public Director()
        {
            
        }
        public void GameLoop()
        {
            
        }


    }
}
