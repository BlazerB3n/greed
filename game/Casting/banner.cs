using Raylib_cs;

namespace Greed.Game.Casting
{
    public class Banner : Actor
    {
        private string message = "";
        
        public static int FontSize = SYSTEM_SETTINGS.FONT_SIZE;

        public Banner() : base()
        {
        }

        public string GetMessage()
        {
            return message;
        }

        

        public void SetMessage(string Message)
        {
            message = Message;

        }
    }
}
