using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWorkingAllTogether
{
    public class Input
    {        
        public bool pressedW,
                    pressedA,
                    pressedS,
                    pressedD,
                    pressedE,
                    pressedSpace,
                    pressedEscape,
                    pressedEnter,
                    controllerPressedA,
                    leftMousePressed;

        public Input ()
        {
            
        }
        public void Update(GameTime gameTime)
        {                      
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                pressedW = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.W))
            {
                pressedW = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                pressedS = true;
            }       
            if (Keyboard.GetState().IsKeyUp(Keys.S))
            {
                pressedS = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                pressedA = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.A))
            {
                pressedA = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                pressedD = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.D))
            {
                pressedD = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                pressedE = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.E))
            {
                pressedE = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                pressedSpace = true;
            }    
            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                pressedSpace = false;
            }  
            
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                pressedEscape = true;         
            }      
            if (Keyboard.GetState().IsKeyUp(Keys.Escape))
            {
                pressedEscape = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                pressedEnter = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Enter))
            {
                pressedEnter = false;
            }
            
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                leftMousePressed = true;
            }
            if (Mouse.GetState().LeftButton == ButtonState.Released)
            {
                leftMousePressed = true;
            }
         }        
    }
}
