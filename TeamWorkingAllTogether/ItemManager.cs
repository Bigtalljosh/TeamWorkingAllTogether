using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TeamWorkingAllTogether
{
    class ItemManager {
        public List<Item> items = new List<Item>();
        public ItemManager(List<Texture2D> itemTextures, List<List<bool>> gridArray) {
            //for(int x = 0; x < gridArray.Count; x++) {
            //    for (int y = 0; y < gridArray[x].Count; y++)
            //        CreateItem(itemTextures[1], new Vector2((x * 128) + 64, (y * 128) + 64), "MedKit", true);
            //}
        }

        public void CreateItem(Texture2D itemTexture, Vector2 position, string type, bool isDestroyable = false, bool isObstacle = false, bool canMove = false)
        {
            Item item = new Item();
            item.Initialize(itemTexture, position, type, isDestroyable, isObstacle, canMove);
            item.canMove = true;
            items.Add(item);
        }

        public void CheckCollisions(Player player)
        {
            foreach (Item item in items)
            {
                if (item.GetRect().Intersects(player.getRect()))
                {
                    if (item.isDestroyable)
                    {
                        item.IsActive = false;
                    }
                    //player.pickup(item.type);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
           
            foreach (Item item in items)
            {
                if (item.IsActive)
                    item.Draw(spriteBatch);
            }
          
        }
    }
}
