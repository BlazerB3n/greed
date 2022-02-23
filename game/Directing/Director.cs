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
        private InputService inputService = null;
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
        /// <param name="inputService">The given KeyboardService.</param>
        /// <param name="videoService">The given VideoService.</param>
        public Director(InputService inputService, VideoService videoService)
        {
            this.inputService = inputService;
            this.videoService = videoService;

            menus = SetupMenus();
            
            SetupStages(inputService, videoService, menus);

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


        private void SetupStages(InputService inputService, VideoService videoService, 
                                        List<IMenu> menu)
        {
            // GameStage gameStage = new GameStage(keyboardService, videoService);
            // TitleStage titleStage = new TitleStage(keyboardService, videoService, menu);
            TitleStage welcomeStage = new TitleStage(inputService, videoService, menu);
            GameStage gameStage = new GameStage(inputService, videoService, menu);
            
            stagelist.Add(Stages.TITLE, welcomeStage);
            stagelist.Add(Stages.GAME, gameStage);
            // stagelist.Add(GAME, gameStage);
        }

        private List<IMenu> SetupMenus()
        {
            //Dictionary<string, MenuService> MenuList = new Dictionary<string, MenuService>();
            List<IMenu> MenuList = new List<IMenu>();
            PlayMenu main = new PlayMenu(200, 200, inputService);

            MenuList.Add(main);

            return MenuList;
        }
    }
}
