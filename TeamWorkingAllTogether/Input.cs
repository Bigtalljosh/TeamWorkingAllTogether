using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

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
                    leftMousePressed,
                    rightMousePressed,
                    rightTriggerPressed,
                    leftTriggerPressed,
                    controllerPressedA,
                    backButtonPressed,
                    startButtonPressed,
                    isScreenTapped;

        //Gamepad Specific
        public Vector2 leftThumbstickPos, rightThumbstickPos;
        public PlayerIndex index;

        //Touch
        
        public Input ()
        {
            //Keyboard and Mouse
        }

        public Input(PlayerIndex pIndex)
        {
            //Gamepad
            index = pIndex;
        }

        public void Update(GameTime gameTime)
        {
            #region Keyboard
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

            #endregion

            #region Mouse
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                leftMousePressed = true;
            }

            if (Mouse.GetState().LeftButton == ButtonState.Released)
            {
                leftMousePressed = true;
            }

            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                rightMousePressed = true;
            }

            if (Mouse.GetState().RightButton == ButtonState.Released)
            {
                rightMousePressed = true;
            }
            #endregion

            #region Gamepad

            leftThumbstickPos = GamePad.GetState(index).ThumbSticks.Left;
            rightThumbstickPos = GamePad.GetState(index).ThumbSticks.Right;

            if (GamePad.GetState(index).Triggers.Right > 0)
            {
                rightTriggerPressed = true;
            }

            if (GamePad.GetState(index).Triggers.Right == 0)
            {
                rightTriggerPressed = false;
            }

            if (GamePad.GetState(index).Triggers.Left > 0)
            {
                leftTriggerPressed = true;
            }

            if (GamePad.GetState(index).Triggers.Left == 0)
            {
                leftTriggerPressed = false;
            }

            if (GamePad.GetState(index).IsButtonDown(Buttons.Start))
            {
                startButtonPressed = true;
            }

            if (GamePad.GetState(index).IsButtonUp(Buttons.Start))
            {
                startButtonPressed = false;
            }

            if (GamePad.GetState(index).IsButtonDown(Buttons.Back))
            {
                backButtonPressed = true;
            }

            if (GamePad.GetState(index).IsButtonUp(Buttons.Back))
            {
                backButtonPressed = false;
            }

            #endregion

            #region Touch
            //var touchCol = TouchPanel.GetState();

            //TouchLocation touchLoc = new TouchLocation();
            //TouchLocation prevTouchLoc = new TouchLocation();

            //foreach (var touch in touchCol)
            //{
            //    //Check for released touch
            //    if (touch.State != TouchLocationState.Released)
            //        continue;

            //    touchLoc = touch;
            //    prevTouchLoc = touchLoc;
                
                

            //    return touchLoc.Position;
            //}
            #endregion
        }        
    }
}
