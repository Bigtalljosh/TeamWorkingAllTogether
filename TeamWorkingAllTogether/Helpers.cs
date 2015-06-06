using System;
using Microsoft.Xna.Framework;

namespace TeamWorkingAllTogether
{
    class Helpers
    {
        public bool isItColliding(Rectangle rec1, Rectangle rec2)
        {
            if(rec1.Intersects(rec2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public float RotationInRadians(Vector2 vect)
        {
            return (float)Math.Atan2((double)vect.Y, (double)vect.X) + MathHelper.PiOver2;
        }

        public static float ToAngle(Vector2 vector)
        {
            return (float)Math.Atan2(vector.Y, vector.X);
        }
    }
}
