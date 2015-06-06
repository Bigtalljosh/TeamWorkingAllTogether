using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TeamWorkingAllTogether
{
    class Projectile
    {
        private Vector2 pos, dir;
        private Texture2D tex;
        private Rectangle rect;
        public bool bisHit = false;
        public int timer = 1000;
        float rotation;
        public int playerNum;

        public Projectile(Texture2D t, Vector2 loc, float rot, Vector2 direction, int pn)
        {
            tex = t;
            pos = loc;
            rotation = rot;
            dir = direction;
            playerNum = pn;
        }

        public void Update(GameTime gameTime)
        {
            if (!bisHit)
            {

                pos.X += dir.X * 30;
                pos.Y += dir.Y * 30;
            }
            else
            {
                timer--;
            }
        }

        public void Draw(SpriteBatch sb)
        {

            sb.Draw(tex, rect = new Rectangle((int)(pos.X), (int)pos.Y, 8, 8), null, Color.White, rotation, Vector2.Zero, SpriteEffects.None, 1);

        }

        public Rectangle getRect()
        {
            rect = new Rectangle((int)(pos.X), (int)pos.Y, 8, 8);
            return rect;
        }

        public void setHit()
        {
            bisHit = true;
        }
    }
}
