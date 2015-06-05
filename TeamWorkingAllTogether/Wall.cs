using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTest
{
    class Wall
    {
        Vector2 Pos;
        Texture2D tex;
        Rectangle rect;
        public Wall(Texture2D t ,int width,int height)
        {
            Pos = new Vector2(width * t.Width,height * t.Height);
            tex = t;
            rect = new Rectangle(0, 0, t.Width, t.Height);
        }
        public Rectangle getRect()
        {
            Rectangle rec = new Rectangle((int)Pos.X, (int)Pos.Y, tex.Width, tex.Height);
            return rec;
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, Pos);
        }
    }
}
