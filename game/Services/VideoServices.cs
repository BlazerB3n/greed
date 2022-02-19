using System.Collections.Generic;
using Raylib_cs;

using static Greed.SYSTEM_SETTINGS;

namespace Greed.Game.Services
{
    public class VideoServices
    {

        Dictionary<int, Texture2D> Texture = new Dictionary<int, Texture2D>();
        
        List<TextureService> TextureList = null;

        private bool debug;


        public VideoServices(List<TextureService> texturelist, bool debug)
        {
            this.debug = debug;
            this.TextureList = texturelist;
        }
        
        /// <summary>
        /// Closes the window and releases all resources.
        /// </summary>
        public void CloseWindow()
        {
            Raylib.CloseWindow();
        }

        /// <summary>
        /// Clears the buffer in preparation for the next rendering. This method should be called at
        /// the beginning of the game's output phase.
        /// </summary>
        public void ClearBuffer()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib_cs.Color.WHITE);
            if (debug)
            {
                DrawGrid();
            }
        }
        
        /// <summary>
        /// Copies the buffer contents to the screen. This method should be called at the end of
        /// the game's output phase.
        /// </summary>
        public void FlushBuffer()
        {
            Raylib.EndDrawing();
        }

        /// <summary>
        /// Gets the grid's cell size.
        /// </summary>
        /// <returns>The cell size.</returns>
        public int GetCellSize()
        {
            return SYSTEM_SETTINGS.CELL_SIZE;
        }

        /// <summary>
        /// Gets the screen's height.
        /// </summary>
        /// <returns>The height (in pixels).</returns>
        public int GetHeight()
        {
            return SYSTEM_SETTINGS.MAX_Y;
        }

        /// <summary>
        /// Gets the screen's width.
        /// </summary>
        /// <returns>The width (in pixels).</returns>
        public int GetWidth()
        {
            return SYSTEM_SETTINGS.MAX_X;
        }

        /// <summary>
        /// Whether or not the window is still open.
        /// </summary>
        /// <returns>True if the window is open; false if otherwise.</returns>
        public bool IsWindowOpen()
        {
            return !Raylib.WindowShouldClose();
        }

        /// <summary>
        /// Opens a new window with the provided title.
        /// </summary>
        public void OpenWindow()
        {
            Raylib.InitWindow(SYSTEM_SETTINGS.MAX_X, SYSTEM_SETTINGS.MAX_Y, SYSTEM_SETTINGS.CAPTION);
            Raylib.SetTargetFPS(SYSTEM_SETTINGS.FRAME_RATE);
        }

        /// <summary>
        /// Draws a grid on the screen.
        /// </summary>
        private void DrawGrid()
        {
            for (int x = 0; x < SYSTEM_SETTINGS.MAX_X; x += SYSTEM_SETTINGS.CELL_SIZE)
            {
                Raylib.DrawLine(x, 0, x, SYSTEM_SETTINGS.MAX_Y, Raylib_cs.Color.GRAY);
            }
            for (int y = 0; y < SYSTEM_SETTINGS.MAX_Y; y += SYSTEM_SETTINGS.CELL_SIZE)
            {
                Raylib.DrawLine(0, y, SYSTEM_SETTINGS.MAX_X, y, Raylib_cs.Color.GRAY);
            }
        }

        /// <summary>
        /// Converts the given color to it's Raylib equivalent.
        /// </summary>
        /// <param name="color">The color to convert.</param>
        /// <returns>A Raylib color.</returns>
        private Raylib_cs.Color ToRaylibColor(Casting.Color color)
        {
            int r = color.GetRed();
            int g = color.GetGreen();
            int b = color.GetBlue();
            int a = color.GetAlpha();
            return new Raylib_cs.Color(r, g, b, a);
        }
    }
}