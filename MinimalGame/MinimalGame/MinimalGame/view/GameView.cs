using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MinimalGame.model;
using Microsoft.Xna.Framework.Input;

namespace MinimalGame.view
{
    class GameView : model.IModelListener
    {
        private model.GameModel model;
        private SpriteBatch spriteBatch;
        private Texture2D ballTexture;
        private Camera camera;
        private ParticleSystem particleSystem;
        private Texture2D particleTexture;
        private Texture2D padTexture;
        private Texture2D levelTexture;
        


        public GameView(MinimalGame.model.GameModel model, SpriteBatch spriteBatch, Texture2D ballTexture, Texture2D particleTexture, Texture2D padTexture, Texture2D levelTexture, Camera camera)
        {
            this.model = model;
            this.spriteBatch = spriteBatch;
            this.ballTexture = ballTexture;
            this.particleTexture = particleTexture;
            this.padTexture = padTexture;
            this.levelTexture = levelTexture;
            this.camera = camera;
            particleSystem = null;
        }

        internal void Draw(float elapsedTimeSeconds)
        {
            if (particleSystem != null)
            {
                particleSystem.Update(elapsedTimeSeconds);
            }

            Vector2 modelBallCenter = this.model.getBall().GetCenter();
            Rectangle ballViewRect = camera.translateRect(modelBallCenter, model.getBall().GetRadius());

            Vector2 modelPadCenterTop = this.model.getPad().GetCenterTopPosition();
            Rectangle padViewRect = camera.translateRectFromCenterTop(modelPadCenterTop, model.getPad().GetRadius());


            //DRAW
            spriteBatch.Begin();

            for (int x = 0; x < Level.SIZE_X; x++)
            {
                for (int y = 0; y < Level.SIZE_Y; y++)
                {
                    Vector2 brickCenterTop = new Vector2(0.5f + x, y);
                    Rectangle brickViewRect = camera.translateRectFromCenterTop(brickCenterTop, 0.5f);
                    spriteBatch.Draw(levelTexture, brickViewRect, Color.White);
                }
            }

            if (particleSystem != null)
            {
                particleSystem.Draw(spriteBatch, camera, particleTexture);
            }

            spriteBatch.Draw(padTexture, padViewRect, Color.White);
            
            spriteBatch.Draw(ballTexture, ballViewRect, Color.White);

           
            
            
            spriteBatch.End();
        }



        internal bool PlayerWantsToQuit()
        {
            return GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape);
        }

        internal bool PlayerGoesLeft()
        {
            return Keyboard.GetState().IsKeyDown(Keys.Left);
        }

        internal bool PlayerGoesRight()
        {
            return Keyboard.GetState().IsKeyDown(Keys.Right);
        }

        public void BallWallCollision(Microsoft.Xna.Framework.Vector2 modelPosition, Vector2 direction)
        {
            particleSystem = new ParticleSystem(modelPosition, direction);
        }
    }
}
