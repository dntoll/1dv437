using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MinimalGame.model
{
    class Collision
    {
        private Vector2 position;
        private Vector2 normal;
        public Collision(Vector2 position, Vector2 normal)
        {
            this.position = position;
            this.normal = normal;
        }

        internal Microsoft.Xna.Framework.Vector2 GetNormal()
        {
            return normal;
        }

        internal Microsoft.Xna.Framework.Vector2 GetCollisionPosition()
        {
            return position;
        }
    }
}
