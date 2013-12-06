using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MinimalGame.model
{
    public interface IModelListener
    {
        void BallWallCollision(Vector2 position, Vector2 direction);
    }
}
