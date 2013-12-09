using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MinimalGame.model
{
    class Pad
    {
        Vector2 centerTopPosition;
        private float padVelocity;
        private float maxVelocity = 8;


        public Pad(Vector2 startPosition)
        {
            centerTopPosition = startPosition;
            padVelocity = 0.0f;
        }

       

        internal float GetRadius()
        {
            return 0.5f;
        }

        internal Vector2 GetCenterTopPosition()
        {
            return centerTopPosition;
        }

        internal void Update(float elapsedTimeInSeconds, int levelLeft, int levelRight)
        {
            centerTopPosition.X = centerTopPosition.X + elapsedTimeInSeconds * padVelocity;

            if (centerTopPosition.X + GetRadius() > levelRight)
            {
                centerTopPosition.X = levelRight - GetRadius();
            }

            if (centerTopPosition.X - GetRadius() < levelLeft)
            {
                centerTopPosition.X = levelLeft + GetRadius();
            }
        }

        internal void MovePadLeft()
        {
            padVelocity = -maxVelocity;
        }

        internal void MovePadRight()
        {
            padVelocity = maxVelocity;
        }

        internal void StopPad()
        {
            padVelocity = 0.0f;
        }

        internal Collision Collide(Vector2 ballposition, float ballRadius, float ballSpeedY)
        {
            float ballBottomPosition = ballposition.Y + ballRadius;

            if (ballBottomPosition > centerTopPosition.Y &&
                ballposition.Y < centerTopPosition.Y)
            {
                if (ballposition.X < centerTopPosition.X + GetRadius() &&
                    ballposition.X > centerTopPosition.X - GetRadius())
                {
                    if (ballSpeedY > 0)
                    {
                        Vector2 collisionPosition = new Vector2(ballposition.X, centerTopPosition.Y);
                        Vector2 normal = new Vector2(0, -1);

                        return new Collision(collisionPosition, normal);
                    }
                }
            }
            return null;
        }
    }
}
