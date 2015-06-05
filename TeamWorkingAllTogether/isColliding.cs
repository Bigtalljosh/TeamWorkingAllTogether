using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TeamWorkingAllTogether
{
    class isColliding
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

    }
}
