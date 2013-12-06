using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MinimalGame.model
{
    class GameModel
    {
        Ball theBall;
        Pad thePad;
        Level level;

        public GameModel()
        {
            level = new Level();
            theBall = new Ball(level.getBallStartPosition());
            thePad = new Pad(level.getPadStartPosition());
        }

        public Ball getBall()
        {
            return theBall;
        }

        public void Update(float elapsedTimeSeconds, IModelListener listener)
        {
            thePad.Update(elapsedTimeSeconds, 0, Level.SIZE_X);

            Collision levelCollision = level.Collide(theBall.GetCenter(), theBall.GetRadius());

            if (levelCollision != null)
            {
                theBall.Collide(levelCollision.GetNormal());
                listener.BallWallCollision(levelCollision.GetCollisionPosition(), levelCollision.GetNormal());
            }

            Collision padCollision = thePad.Collide(theBall.GetCenter(), theBall.GetRadius());

            if (padCollision != null)
            {
                theBall.Collide(padCollision.GetNormal());
                listener.BallWallCollision(padCollision.GetCollisionPosition(), padCollision.GetNormal());
            }

            theBall.Update(elapsedTimeSeconds);
        }


        internal void MovePadLeft()
        {
            thePad.MovePadLeft();
        }

        internal void MovePadRight()
        {
            thePad.MovePadRight();
        }

        internal void StopPad()
        {
            thePad.StopPad();
        }

        internal Pad getPad()
        {
            return thePad;
        }
    }
}
