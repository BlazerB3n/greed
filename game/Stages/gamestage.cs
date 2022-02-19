using Raylib_cs;
using Greed.Game.Director;
using Greed.Game.Casting;
using Greed.Game.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Greed.Game.Screens
{
    public class GameStage : IStage
    {
        private Cast cast = null;
        private KeyboardServices keyboardService = null;
        private VideoServices videoService = null;
        Stages stage = Stages.GAME;

        public GameStage(KeyboardServices keyboardService, VideoServices videoService)
        {
            this.keyboardService = keyboardService;
            this.videoService = videoService;
            cast = SetupCast();
        }
        public void GetInputs()
        {
            while (videoService.IsWindowOpen())
            {
                keyboardService.GetDirection();
            }
        }
        public void DoUpdates()
        {

        }

        public Stages DoOutputs()
        {
            videoService.FlushBuffer();
            return stage;
        }

        private Cast SetupCast()
        {

            return cast;
        }
    }
}