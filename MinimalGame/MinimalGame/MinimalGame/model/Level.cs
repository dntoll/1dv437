using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MinimalGame.model
{
    class Level
    {
        public const int SIZE_X = 10;
        public const int SIZE_Y = 10;

        internal Vector2 getBallStartPosition()
        {
            return new Vector2(SIZE_X / 2, SIZE_Y / 2);
        }

        internal Vector2 getPadStartPosition()
        {
            return new Vector2(SIZE_X / 2, SIZE_Y-1);
        }

        internal Collision Collide(Vector2 position, float radius)
        {
             if (position.X + radius > Level.SIZE_X)
            {
                return new Collision(position + (new Vector2(radius, 0)), new Vector2(-1, 0));
            }
            else if (position.X - radius < 0)
            {
                return new Collision(position + (new Vector2(-radius, 0)), new Vector2(1, 0));
                
            }

            if (position.Y - radius < 0)
            {
                return new Collision(position + (new Vector2(0, -radius)), new Vector2(0, 1));
            }

            return null;
        }
    }
}
