using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MinimalGame.model;
using MinimalGame.view;

namespace MinimalGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class XNAGameController : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameModel model;
        GameView view;

        public XNAGameController()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            model = new GameModel();
            
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D particleTexture = Content.Load<Texture2D>("glitter");
            Texture2D boxTexture = Content.Load<Texture2D>("bubbles");
            Texture2D padTexture = Content.Load<Texture2D>("pad");
            Texture2D levelTexture = Content.Load<Texture2D>("level");

            


            Camera camera = new Camera(GraphicsDevice.Viewport);
            view = new GameView(model, spriteBatch, boxTexture, particleTexture, padTexture, levelTexture, camera);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            
            // Allows the game to exit

            if (view.PlayerWantsToQuit())
            {
                this.Exit();
            }

            if (view.PlayerGoesLeft())
            {
                model.MovePadLeft();
            }
            else if (view.PlayerGoesRight())
            {
                model.MovePadRight();
            }
            else
            {
                model.StopPad();
            }


            model.Update((float)gameTime.ElapsedGameTime.TotalSeconds, view);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            
            GraphicsDevice.Clear(Color.CornflowerBlue);

            view.Draw((float)gameTime.ElapsedGameTime.TotalSeconds);

            base.Draw(gameTime);
        }
    }
}
