using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TeamWorkingAllTogether
{
    abstract public class Screen
    {
        public string screenType;
        public virtual void LoadContent() { } 
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}
