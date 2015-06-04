using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TeamWorkingAllTogether
{
    public class GamePadInput
    {
        public bool rightTriggerPressed, startButtonPressed;
        public Vector2 leftThumbstickPos, rightThumbstickPos;
        public PlayerIndex index;
        public GamePadInput(PlayerIndex pi)
        {
            index = pi;
        }
        public void Update(GameTime gameTime)
        {
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

            if (GamePad.GetState(index).IsButtonDown(Buttons.Start))
            {
                startButtonPressed = true;
            }
            if (GamePad.GetState(index).IsButtonUp(Buttons.Start))
            {
                startButtonPressed = false;
            }
            
        }                    
    }
}
