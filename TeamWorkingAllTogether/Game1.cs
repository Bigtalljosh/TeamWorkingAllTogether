using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace TeamWorkingAllTogether
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Components
        //Screen CurrentScreen;
        UI.UI UI;
        Helpers helper = new Helpers();
        Player player;
        Player playerTwo;
        Player enemy;
        Input input;

        List<Wall> walls;
        List<List<bool>> gridArray;
        MapGenerator mapGen = new MapGenerator();
        Rectangle floorRect;

        Camera cam;
        //Resources
        SpriteFont font;

        Texture2D blackHealth;
        Texture2D redHealth;
        Texture2D greenHealth;

        Texture2D playerTex;
        Texture2D enemyTex;
        Texture2D playerTwoTex;
        Texture2D floorTex;

        List<Texture2D> wallTextures = new List<Texture2D>();

        List<Projectile> bullets = new List<Projectile>();
        List<Texture2D> bulletTextures = new List<Texture2D>();
        Random rand = new Random();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            this.IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
                        
            gridArray = mapGen.GenerateMap(21);
            walls = mapGen.generateWalls(wallTextures, gridArray);
            floorRect = new Rectangle(0, 0, gridArray.Count * 128 * 2, gridArray[0].Count * 128 * 2);
            cam = new Camera();
            cam.Pos = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);
            cam.Zoom = 1.0f;

            //player pos
            player.playerPos.X = ((gridArray.Count / 4) + 0.5f) * wallTextures[0].Width;
            player.playerPos.Y = 2 * wallTextures[0].Height;
            playerTwo.playerPos.X = ((player.playerPos.X - (0.5f * wallTextures[0].Width)) * 3) - (0.5f * wallTextures[0].Width);
            playerTwo.playerPos.Y = (gridArray[0].Count - 2) * wallTextures[0].Height;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("font");

            List<Texture2D> itemTextures = new List<Texture2D>();
            itemTextures.Add(Content.Load<Texture2D>("Pip"));
            itemTextures.Add(Content.Load<Texture2D>("MedKit"));
            itemTextures.Add(Content.Load<Texture2D>("AmmoBox"));
            itemTextures.Add(Content.Load<Texture2D>("Explosion"));

            blackHealth = Content.Load<Texture2D>("TEX_HealthBarBorder");
            redHealth = Content.Load<Texture2D>("TEX_HealthBarRedFill");
            greenHealth = Content.Load<Texture2D>("TEX_HealthBarGreenFill");
            playerTex = Content.Load<Texture2D>("TEX_PlayerSprite");
            
            playerTwoTex = Content.Load<Texture2D>("TEX_PlayerSprite");
            wallTextures.Add(Content.Load<Texture2D>("wall1"));
            wallTextures.Add(Content.Load<Texture2D>("wall2"));
            wallTextures.Add(Content.Load<Texture2D>("wall3"));
            floorTex = Content.Load<Texture2D>("floor");

            UI = new TeamWorkingAllTogether.UI.UI(spriteBatch, font, greenHealth, blackHealth, redHealth);
            input = new Input();

            player = new Player(spriteBatch, "Josh", 100, playerTex, Vector2.Zero, input);
                        
            playerTwo = new Player(spriteBatch, "SecondPlayer", 100, playerTwoTex, new Vector2(500, 50), input);

            for (int i = 1; i < 9; i++)
            {
                bulletTextures.Add(Content.Load<Texture2D>(string.Concat("TEX_Bullet", i)));
            }
            
        }

        protected override void UnloadContent()
        {  }

        protected override void Update(GameTime gameTime)
        {

            //switch(CurrentScreen.screenType)
            //{
            //    case "TitleScreen":
            //        CurrentScreen = new TitleScreen();
            //        break;

            //    case "GameScreen":
            //        CurrentScreen = new GameScreen();
            //        break;

            //    case "Credits":
            //        CurrentScreen = new Credits();
            //        break;
            //}

            input.Update(gameTime);

            if (input.pressedEscape)
                Exit();

            if (input.pressedEnter)
                graphics.ToggleFullScreen();

            bool bCollide = false;

            //check player 1 with walls
            foreach (Wall w in walls)
            {
                if (helper.isItColliding(player.getRect(), w.getRect()))
                {
                    bCollide = true;
                }
            }

            if (!bCollide)
            {
                //move player
                player.movePlayer();
                bCollide = false;
            }

            //check player 2 with walls
            foreach (Wall w in walls)
            {

                if (helper.isItColliding(playerTwo.getRect(), w.getRect()))
                {
                    bCollide = true;
                }

            }

            if (!bCollide)
            {
                //move player 2
                playerTwo.movePlayer();
                bCollide = false;
            }

            // check collide bullets
            foreach (Wall w in walls)
            {
                foreach (Projectile b in bullets)
                {
                    if (helper.isItColliding(b.getRect(), w.getRect()))
                    {
                        b.setHit();
                    }
                }
            }


            if (input.pressedE)
            {
                int randomIndex = rand.Next(1, 8);
                bullets.Add(new Projectile(bulletTextures[randomIndex], new Vector2(player.playerPos.X, player.playerPos.Y + rand.Next(0, 8)), player.rotationInRadians, player.direction,1));
            }

            //if (padInput.rightTriggerPressed && !player.isDead)
            //{
            //    int randomIndex = rand.Next(1, 8);
            //    bullets.Add(new Projectile(bulletTextures[randomIndex], new Vector2(player.playerPos.X , player.playerPos.Y  + rand.Next(0, 8)), player.rotationInRadians, player.direction, 1));
            //}
            //if (padInput2.rightTriggerPressed && !playerTwo.isDead)
            //{
            //    int randomIndex = rand.Next(1, 8);
            //    bullets.Add(new Projectile(bulletTextures[randomIndex], new Vector2(playerTwo.playerPos.X, playerTwo.playerPos.Y + rand.Next(0, 8)), playerTwo.rotationInRadians, playerTwo.direction, 2));
            //}

            bCollide = false;
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update(gameTime);
                // collide with players
                if (bullets[i].playerNum == 2 && helper.isItColliding(bullets[i].getRect(), player.getRect()))
                {
                    bCollide = true;
                    player.beenHit();
                }
                if (bullets[i].playerNum == 1 && helper.isItColliding(bullets[i].getRect(), playerTwo.getRect()))
                {
                    bCollide = true;
                    playerTwo.beenHit();
                }
                if (bullets[i].timer < 0 || bCollide)
                {
                    bullets.Remove(bullets[i]);
                }
            }

            UI.receiveHealthUpdate(player.currentHealth, playerTwo.currentHealth);

            if (!playerTwo.isDead) playerTwo.Update();
            if (!player.isDead) player.Update();

            UI.Update(player.currentHealth, playerTwo.currentHealth);

            // find point between players
            Vector2 point;
            point.X = 0.5f * player.playerPos.X + 0.5f * playerTwo.playerPos.X;
            point.Y = 0.5f * player.playerPos.Y + 0.5f * playerTwo.playerPos.Y;
            cam.Pos = point;
            float distance = Vector2.Distance(player.playerPos, playerTwo.playerPos);
            if (distance > 500) cam.Zoom = 500 / distance;
            //MathHelper.Clamp(cam.Zoom,0, 0.5f);
            base.Update(gameTime);
            player.checkDeath();
            playerTwo.checkDeath();

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.Deferred,
                     BlendState.AlphaBlend,
                      SamplerState.LinearWrap,
                       null,
                      null,
                     null,
                      cam.get_transformation(GraphicsDevice,
                                             GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width,
                                             GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height));

            spriteBatch.Draw(floorTex, Vector2.Zero, floorRect, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0.5f);
            for (int i = 0; i < walls.Count; i++)
            {
                walls[i].Draw(spriteBatch);
            }

            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Draw(spriteBatch);
            }

            playerTwo.Draw();
            player.Draw();
            spriteBatch.End();
            UI.DrawUI();
            base.Draw(gameTime);
        }
    }
}
