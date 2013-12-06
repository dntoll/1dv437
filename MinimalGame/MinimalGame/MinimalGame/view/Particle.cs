using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MinimalGame.view
{
    class Particle
    {
        
        private static Vector2 acceleration = new Vector2(0, 10);
        private static float maxLifeTime = 1.0f;
        private static float minSize = 0.05f;
        private static float maxsize = 0.1f;
        private static float minSpeed = 0.9f;
        private static float maxSpeed = 13.5f;


        private float simulationTimeSeconds;
        private float size;
        private float delayTimeSeconds;
        private int seed;
        private Vector2 position;
        private Vector2 velocity;

        
        public Particle(int seed, Vector2 modelPosition, Vector2 direction)
        {
            this.seed = seed;
            respawn(modelPosition, direction);
        }

        private void respawn(Vector2 modelPosition, Vector2 direction)
        {
            this.position = new Vector2(modelPosition.X, modelPosition.Y);
            simulationTimeSeconds = 0;

            Random rand = new Random(seed);
            
            //RANDOMIZE SPEED
            velocity = new Vector2((float)(rand.NextDouble() * 2.0 - 1.0), (float)(rand.NextDouble() * 2.0 - 1.0));
            velocity.Normalize();

            velocity = direction * 0.75f + velocity*0.25f;
            float particleSpeed = minSpeed + ((float)(rand.NextDouble()) * (maxSpeed - minSpeed));
            velocity *= particleSpeed;

            //RANDOMIZE SIZE
            size = minSize + ((float)(rand.NextDouble()) * (maxsize - minSize));

            //RANDOMIZE DELAY
            delayTimeSeconds = (float)(rand.NextDouble()) * 0.1f;
        }
        


        internal void Update(float elapsedTimeSeconds)
        {
            simulationTimeSeconds += elapsedTimeSeconds;


            if (isAlive())
            {
                position = position + velocity * elapsedTimeSeconds;
                velocity = velocity + acceleration * elapsedTimeSeconds;
            }
        }


        internal void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D texture)
        {
            if (isAlive())
            {
                Rectangle ballViewRect = camera.translateRect(position, size);


                float t = getTimeLivedSeconds() / maxLifeTime;
                if (t > 1.0f)
                {
                    t = 1.0f;
                    return;
                }

                float startValue = 1.0f;
                float endValue = 0.0f;

                float visibility = endValue * t + (1.0f - t) * startValue;



                Color color = new Color(visibility, visibility, visibility, visibility);
                spriteBatch.Draw(texture, ballViewRect, color);
            }
            

        }

        

        private float getTimeLivedSeconds()
        {
            if (isAlive())
            {
                return simulationTimeSeconds - delayTimeSeconds;
            }
            else
            {
                return 0;
            }
        }

        private bool isAlive()
        {
            return simulationTimeSeconds > delayTimeSeconds;
        }
    }
}
