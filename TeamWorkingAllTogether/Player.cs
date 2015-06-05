using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Gaming;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TeamWorkingAllTogether
{
    public class Player
    {
        GamePadInput padInput;
        Input playerInput;

        string playerName;
        int maxHealth;
        public int currentHealth;
        SpriteBatch sb;
        Texture2D playerTexture;
        public Vector2 playerPos;
        public Vector2 velocity;
        float playerMoveSpeed = 15.0f;
        public bool isDead;
        float orienation;
        public Vector2 direction;
        public float rotationInRadians;
        Vector2 centre;


        Rectangle BoundingRect;
        Rectangle SourceRect;

        KeyboardState currentKeyboardState;
        private static MouseState mouseState, lastMouseState;


        public Player(SpriteBatch sb, string playerName, int maxHealth, Texture2D playerTex, Vector2 playerPos)
        {
            this.sb = sb;
            this.playerName = "";
            this.playerName = playerName;
            this.maxHealth = maxHealth;
            playerTexture = playerTex;
            this.playerPos = playerPos;

            //playerMoveSpeed = 15.0f;
            isDead = false;
            currentHealth = maxHealth;
            direction.X = 0;
            direction.Y = -1;
            centre = new Vector2(playerTexture.Width / 2, playerTexture.Height / 2);
        }

        public Player(SpriteBatch sb, string playerName, int maxHealth, Texture2D playerTex, Vector2 playerPos, Input input)
        {
            this.playerInput = input;
            this.sb = sb;
            this.playerName = "";
            this.playerName = playerName;
            this.maxHealth = maxHealth;
            playerTexture = playerTex;
            this.playerPos = playerPos;

            //playerMoveSpeed = 3.0f;
            isDead = false;
            currentHealth = maxHealth;
            direction.X = 0;
            direction.Y = -1;
            centre = new Vector2(playerTexture.Width / 2, playerTexture.Height / 2);
        }
        public Player(SpriteBatch sb, string playerName, int maxHealth, Texture2D playerTex, Vector2 playerPos, GamePadInput input)
        {
            padInput = input;
            this.sb = sb;
            this.playerName = "";
            this.playerName = playerName;
            this.maxHealth = maxHealth;
            playerTexture = playerTex;
            this.playerPos = playerPos;
           // playerMoveSpeed = 3.0f;
            isDead = false;
            currentHealth = maxHealth;
            direction.X = 0;
            direction.Y = -1;
            centre = new Vector2(playerTexture.Width / 2, playerTexture.Height / 2);
        }

        public static float ToAngle(Vector2 vector)
        {
            return (float)Math.Atan2(vector.Y, vector.X);
        }
        
        public void movePlayer()
        {
            playerPos.X += velocity.X;
            playerPos.Y -= velocity.Y;
        }

        public void pickup(string input)
        {
            if(input == "MedKit")
            {
                currentHealth += maxHealth / 20;
                if (currentHealth > maxHealth) currentHealth = maxHealth;
            }
            else if (input == "AmmoBox")
            {
                
            }
        }
        public void Update()
        {
            currentKeyboardState = Keyboard.GetState();
           
            if (playerInput != null && !isDead)
            {
                lastMouseState = Mouse.GetState();

                Vector2 mousevector = new Vector2();
                mousevector.X = lastMouseState.X;
                mousevector.Y = lastMouseState.Y;                

                direction = mousevector - playerPos;
                direction.Normalize();

                rotationInRadians = (float)Math.Atan2((double)direction.Y, (double)direction.X) + MathHelper.PiOver2;

                if (playerInput.pressedW)
                {
                    playerPos.Y -= playerMoveSpeed;
                }

                if (playerInput.pressedS)
                {
                    playerPos.Y += playerMoveSpeed;
                }

                if (playerInput.pressedA)
                {
                    playerPos.X -= playerMoveSpeed;
                }

                if (playerInput.pressedD)
                {
                    playerPos.X += playerMoveSpeed;
                }

                if (playerInput.pressedSpace)
                {
                    currentHealth += 15;
                }
            }
            if (padInput != null)
            {
                velocity.X = padInput.leftThumbstickPos.X * playerMoveSpeed;
                velocity.Y = padInput.leftThumbstickPos.Y * playerMoveSpeed;
               // playerPos.X += padInput.leftThumbstickPos.X * 5;
               // playerPos.Y -= padInput.leftThumbstickPos.Y * 5;

                if (padInput.rightThumbstickPos.X != 0 && padInput.rightThumbstickPos.Y != 0)
                {                    
                    rotationInRadians = (float)Math.Atan2((double)padInput.rightThumbstickPos.X, (double)padInput.rightThumbstickPos.Y);
                    direction.X = padInput.rightThumbstickPos.X;
                    direction.Y = padInput.rightThumbstickPos.Y * -1;
                    direction.Normalize();
                }
            }
        }

        public void checkDeath()
        {
            if(currentHealth < 1)
            {
                isDead = true;
            }
        }

        public int beenHit()
        {
            currentHealth -= 1;
            return currentHealth;
        }

        public Rectangle getRect()
        {
            Rectangle rec = new Rectangle((int)playerPos.X - (playerTexture.Width/2) + (int)velocity.X, (int)playerPos.Y - (playerTexture.Height / 2) - (int)velocity.Y, playerTexture.Width, playerTexture.Height);
            return rec;
        }

        public void Draw()
        {

            sb.Draw(playerTexture, new Rectangle((int)playerPos.X, (int)playerPos.Y, playerTexture.Width, playerTexture.Height), null, Color.White, rotationInRadians, centre, SpriteEffects.None, 1);
;
        }
    }
}
