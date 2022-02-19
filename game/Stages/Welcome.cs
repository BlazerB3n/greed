using Raylib_cs;
using Greed;
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
    
    public class TitleStage : IStage
    {
        private Cast cast = null;
        private KeyboardServices keyboardService = null;
        private VideoServices videoService = null;
        Stages stage = Stages.TITLE;

        public TitleStage(KeyboardServices keyboardService, VideoServices videoService)
        {
            this.keyboardService = keyboardService;
            this.videoService = videoService;
            cast = SetupCast();
        }

        /// <summary>
        /// Gets directional input from the keyboard and applies it to the robot.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void GetInputs()
        {

            if (keyboardService.GetEnter())
            {
                stage = Stages.GAME;
            }
            else
            {
                stage = Stages.TITLE;
            }

        }

        /// <summary>
        /// Updates the robot's position and resolves any collisions with artifacts.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void DoUpdates()
        {

        }

        /// <summary>
        /// Draws the actors on the screen.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public Stages DoOutputs()
        {
            return stage;
        }

        private Cast SetupCast()
        {

            return cast;
        }
    }
}