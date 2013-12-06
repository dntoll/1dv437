﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MinimalGame.model
{
    class Ball
    {

        Vector2 ballCenterModelPosition;
        Vector2 ballVelocity;


        public Ball(Microsoft.Xna.Framework.Vector2 vector2)
        {
            // TODO: Complete member initialization
            this.ballCenterModelPosition.X = vector2.X;
            this.ballCenterModelPosition.Y = vector2.Y;

            this.ballVelocity = new Vector2(1.0f, 0.5f);
            this.ballVelocity.Normalize();
            this.ballVelocity *= 5.0f;
        }

        

        internal void Update(float elapsedTimeSeconds)
        {
            ballCenterModelPosition += elapsedTimeSeconds * ballVelocity;
        }

        internal Vector2 GetCenter()
        {
            return ballCenterModelPosition;
        }

        internal float GetRadius()
        {
            return 0.5f;
        }

        /*internal void CollideRight()
        {
            if (this.ballVelocity.X > 0)
            {
                this.ballVelocity.X = -this.ballVelocity.X;
            }
        }

        internal void CollideLeft()
        {
            if (this.ballVelocity.X < 0)
            {
                this.ballVelocity.X = -this.ballVelocity.X;
            }
        }

        internal void CollideBottom()
        {
            if (this.ballVelocity.Y > 0)
            {
                this.ballVelocity.Y = -this.ballVelocity.Y;
            }
        }

        internal void CollideTop()
        {
            if (this.ballVelocity.Y < 0)
            {
                this.ballVelocity.Y = -this.ballVelocity.Y;
            }
        }*/

        internal void Collide(Vector2 normal)
        {
            Vector2 R = 2.0f * (-Vector2.Dot(ballVelocity, normal)) * normal + ballVelocity;

            this.ballVelocity = R;
        }
    }
}
