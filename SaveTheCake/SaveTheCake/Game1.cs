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

namespace SaveTheCake
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Camera camera;
        int screenWidht, screenHeight;

        //units
        Player player1;
        Cake[] cake;
        const int CAKE_COUNT = 4;

        public Game1()
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
            // TODO: Add your initialization logic here
            screenHeight = graphics.PreferredBackBufferHeight;
            screenWidht = graphics.PreferredBackBufferWidth;
            camera = new Camera(screenWidht/2, screenHeight/2, 1);
            cake = new Cake[CAKE_COUNT];

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

            // TODO: use this.Content to load your game content here
            Texture2D player1Text = Content.Load<Texture2D>("stc_Player");
            player1 = new Player(new Vector2(0, 0), player1Text, new Vector2(0, 0));
            Texture2D cakeTexture = Content.Load<Texture2D>("stc_Cake");
            const int CAKE_OFFSET = 32;
            cake[0] = new Cake(new Vector2(CAKE_OFFSET, 0), cakeTexture);
            cake[1] = new Cake(new Vector2(-CAKE_OFFSET, 0), cakeTexture);
            cake[2] = new Cake(new Vector2(0, CAKE_OFFSET), cakeTexture);
            cake[3] = new Cake(new Vector2(0, -CAKE_OFFSET), cakeTexture);

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            player1.uptate(Keyboard.GetState());

            //track the player
            Vector2 trackLocation = player1.pLocation();
            trackLocation.X -= screenWidht / (2 * camera.scale);
            trackLocation.Y -= screenHeight / (2 * camera.scale);
            camera.setLocation(trackLocation);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(128,222,92));

            // TODO: Add your drawing code here
            player1.draw(spriteBatch,camera);
            for (int i = 0; i < CAKE_COUNT; i++)
            {
                cake[i].draw(spriteBatch, camera);
            }

            base.Draw(gameTime);
        }
    }
}
