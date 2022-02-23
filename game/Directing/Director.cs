using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;
using Greed.Game.Services;
using Greed.Game.Casting;
using Greed.Game.Screens.Menus;
using Greed.Game.Screens;

namespace Greed.Game.Directing
{

    public class Director
    {
        private InputService keyboardService = null;
        private VideoService videoService = null;

        Stages stage = Stages.TITLE;
        // private Dictionary<Stages, IStage> stages = null;
            // SET UP THE stages
        Dictionary<Stages, IStage> stagelist = new Dictionary<Stages, IStage>();
        // Dictionary<string, MenuService> menus = null;
        List<IMenu> menus = null;

    // StartStage startStage = null;
    // TitleStage titleStage = null;
        /// <summary>
        /// Constructs a new instance of Director using the given KeyboardService and VideoService.
        /// </summary>
        /// <param name="keyboardService">The given KeyboardService.</param>
        /// <param name="videoService">The given VideoService.</param>
        public Director(InputService keyboardService, VideoService videoService)
        {
            this.keyboardService = keyboardService;
            this.videoService = videoService;

            menus = SetupMenus();
            
            SetupStages(keyboardService, videoService, menus);

        }
        public void GameLoop()
        {
            Stages TMP = Stages.TITLE;

            videoService.OpenWindow();

            while (videoService.IsWindowOpen())
            {
                videoService.StartFrameRender();

                stagelist[stage].GetInputs();
                TMP = stagelist[stage].DoUpdates();
                List<Actor> actors = stagelist[stage].DoOutputs();

                videoService.DrawActors(actors);

                videoService.endFrameRender();
                stage = TMP;
            }
            videoService.CloseWindow();
        }


        private void SetupStages(InputService keyboardService, VideoService videoService, 
                                        List<IMenu> menu)
        {
            // GameStage gameStage = new GameStage(keyboardService, videoService);
            // TitleStage titleStage = new TitleStage(keyboardService, videoService, menu);
            TitleStage weclomeStage = new TitleStage(keyboardService, videoService, menu);
            
            stagelist.Add(Stages.TITLE, weclomeStage);
            // stagelist.Add(TITEL, titleStage);
            // stagelist.Add(GAME, gameStage);
        }

        private List<IMenu> SetupMenus()
        {
            //Dictionary<string, MenuService> MenuList = new Dictionary<string, MenuService>();
            List<IMenu> MenuList = new List<IMenu>();
            PlayMenu main = new PlayMenu(200, 200, keyboardService);

            MenuList.Add(main);

            return MenuList;
        }
    }
}
