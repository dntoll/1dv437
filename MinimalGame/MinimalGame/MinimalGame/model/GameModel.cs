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
            float timeStep = 0.001f;
            if (elapsedTimeSeconds > 0)
            {
                int numIterations = (int)(timeStep / elapsedTimeSeconds);

                for (int i = 0; i < numIterations; i++)
                {
                    UpdateInternal(timeStep, listener);
                }

                float timeLeft = elapsedTimeSeconds - timeStep * numIterations;
                UpdateInternal(timeLeft, listener);
            }
        }

        private void UpdateInternal(float elapsedTimeSeconds, IModelListener listener)
        {
            thePad.Update(elapsedTimeSeconds, 0, Level.SIZE_X);
            theBall.Update(elapsedTimeSeconds);

            Collision levelCollision = level.Collide(theBall.GetCenter(), theBall.GetRadius());

            if (levelCollision != null)
            {
                theBall.Collide(levelCollision.GetNormal());
                listener.BallWallCollision(levelCollision.GetCollisionPosition(), levelCollision.GetNormal());
            }

            Collision padCollision = thePad.Collide(theBall.GetCenter(), theBall.GetRadius(), theBall.GetYSpeed());

            if (padCollision != null)
            {
                theBall.Collide(padCollision.GetNormal());
                listener.BallWallCollision(padCollision.GetCollisionPosition(), padCollision.GetNormal());
            }
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

        internal Level getLevel()
        {
            return level;
        }
    }
}
