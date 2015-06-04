using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TeamWorkingAllTogether.UI
{
    public class UI
    {
        private SpriteBatch sb;
        private string playerName { get; set; }
        private int totalHealthP1 { get; set; }
        private int currentHealthP1 { get; set; }
        private int totalHealthP2 { get; set; }
        private int currentHealthP2 { get; set; }

        private Texture2D red, black, green;

        private SpriteFont font;

        Rectangle greenRectangle1; 
        Rectangle redRectangle1;
        Rectangle blackRectangle1;

        Rectangle greenRectangle2;
        Rectangle redRectangle2;
        Rectangle blackRectangle2;

        public UI(SpriteBatch sb, SpriteFont font, Texture2D green, Texture2D black, Texture2D red)
        {
            this.totalHealthP1 = 100;
            this.totalHealthP2 = 100;
            this.sb = sb;
            this.font = font;
            this.red = red;
            this.green = green;
            this.black = black;

            greenRectangle1 = new Rectangle(10, 50, totalHealthP1, green.Height);
            redRectangle1 = new Rectangle(10, 50, totalHealthP1, red.Height);
            blackRectangle1 = new Rectangle(10, 50, totalHealthP1, black.Height);

            greenRectangle2 = new Rectangle(850, 50, totalHealthP2, green.Height);
            redRectangle2 = new Rectangle(850, 50, totalHealthP2, red.Height);
            blackRectangle2 = new Rectangle(850, 50, totalHealthP2, black.Height);

        }

        public void receiveHealthUpdate(int healthP1, int healthP2)
        {
            currentHealthP1 = healthP1;
            currentHealthP2 = healthP2;
        }

        public void DrawUI()
        {
            sb.Begin();
            sb.DrawString(font, "Player One Health : ", new Vector2(10,35), Color.MonoGameOrange);                      
            sb.Draw(black, blackRectangle1, Color.White);
            sb.Draw(red, redRectangle1, Color.White);
            sb.Draw(green, greenRectangle1, Color.White);
            sb.DrawString(font, "Player Two Health : ", new Vector2(850, 35), Color.MonoGameOrange);
            sb.Draw(black, blackRectangle2, Color.White);
            sb.Draw(red, redRectangle2, Color.White);
            sb.Draw(green, greenRectangle2, Color.White);
            sb.End();
        }

        public void Update(int currentHealthP1, int currentHealthP2)
        {
            this.currentHealthP1 = currentHealthP1;
            this.currentHealthP2 = currentHealthP2;
            Rectangle updateRect1 = new Rectangle(10, 50, currentHealthP1, green.Height);
            Rectangle updateRect2 = new Rectangle(850, 50, currentHealthP2, green.Height);
            greenRectangle1 = updateRect1;
            greenRectangle2 = updateRect2;

        }

        public void resetHealth()
        {
            currentHealthP1 = 100;
            currentHealthP2 = 100;
        }

        
    }
}
