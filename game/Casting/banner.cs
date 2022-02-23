using Raylib_cs;
using Greed.Game.Directing;

namespace Greed.Game.Casting
{
    public class Banner : Actor
    {
        private string message = "";

        public int FontSize = SYSTEM_SETTINGS.FONT_SIZE;
        public Banner(int ID) : base(ID)
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

        public void SetFont(int FontSize)
        {
            this.FontSize = FontSize;
        }
    }
}
