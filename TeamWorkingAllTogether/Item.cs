using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamWorkingAllTogether
{
    class Item {
        public Texture2D mainTexture;
        public Vector2 position;
        private string type;
        private bool isActive = true;
        public bool isDestroyable = false;
        public bool isObstacle = false;
        public bool canMove = false;

        public int Width {
            get { return mainTexture.Width; }
        }

        public int Height {
            get { return mainTexture.Height; }
        }
        public bool IsActive {
            get { return isActive; }
            set { isActive = value;
                if (!value) { position = new Vector2(-200,-200); }
            }
        }


        public Rectangle GetRect() {
            Rectangle rect = new Rectangle((int)position.X, (int)position.Y, mainTexture.Width, mainTexture.Height);
            return rect;
        }

        internal void Initialize(object p, Vector2 position, string type, bool isDestroyable, bool isObstacle, bool canMove)
        {
            throw new NotImplementedException();
        }

        public void Initialize(Texture2D mainTexture, Vector2 position, string type, bool isDestroyable = false, bool isObstacle = false, bool canMove = false) {
            this.mainTexture = mainTexture;
            this.position = position;
            this.type = type;
            this.isDestroyable = isDestroyable;
            this.isObstacle = isObstacle;
            this.canMove = canMove;
        }

        public void Update() {
        }

        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(mainTexture, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
