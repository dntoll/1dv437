using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MinimalGame.view
{
    class ParticleSystem
    {
        
       private Particle[] particles;
       private const int MAX_PARTICLES = 10;
 
       public ParticleSystem(Vector2 modelPosition, Vector2 direction)
       {
           particles = new Particle[MAX_PARTICLES];

           for (int i = 0; i < MAX_PARTICLES; i++)
           {
               particles[i] = new Particle(i, modelPosition, direction);
           }

           
       }


        public void Update(float elapsedTime)
        {
            for (int i = 0; i < MAX_PARTICLES; i++)
            {
                particles[i].Update(elapsedTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera cam, Texture2D texture)
        {
            for (int i = 0; i < MAX_PARTICLES; i++)
            {
                particles[i].Draw(spriteBatch, cam, texture);
            }
        }

    }
}
