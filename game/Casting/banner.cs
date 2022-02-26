using Raylib_cs;
using Greed.Game.Directing;

namespace Greed.Game.Casting
{
    public class Banner : Actor
    {
        private string message = "";

        public int FontSize = SYSTEM_SETTINGS.FONT_SIZE;
        
        /// <summary>
        /// Constructs a new instance of Banner
        /// </summary>
        public Banner() : base(-1)
        {

        }

        /// <summary>
        /// Gets the Banner's text.
        /// </summary>
        /// <returns>The text.</returns>
        public string GetMessage()
        {
            return message;
        }

        

        /// <summary>
        /// sets the banner's color.
        /// </summary>
        /// <param name="Message">The new Message.</param>
        public void SetMessage(string Message)
        {
            message = Message;

        }

        /// <summary>
        /// Sets the banner's font size.
        /// </summary>
        /// <param name="FontSize">The new Font Size.</param>
        public void SetFont(int FontSize)
        {
            this.FontSize = FontSize;
        }
    }
}
