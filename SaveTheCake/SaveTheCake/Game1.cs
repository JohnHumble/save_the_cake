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
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Camera camera;
        int screenWidth, screenHeight;

        //units
        Player player1;
        Cake[] cake;
        const int CAKE_COUNT = 4;
        List<Ant> ants;
        Texture2D antBlack;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.IsFullScreen = false;
            this.IsMouseVisible = true;
            screenHeight = graphics.PreferredBackBufferHeight = 768;
            screenWidth = graphics.PreferredBackBufferWidth = 768;
            graphics.ApplyChanges();
            camera = new Camera(screenWidth/2, screenHeight/2, 2);
            cake = new Cake[CAKE_COUNT];
            ants = new List<Ant>();
            base.Initialize();
        }

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
            antBlack = Content.Load<Texture2D>("stc_ant_black");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        Vector2 mouseLoc;
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

            //TODO: create ant spawning logic;
            Vector2 hill1 = new Vector2(100, 120);
            //mouseLoc = new Vector2((Mouse.GetState().X + camera.location.X) * camera.scale, (Mouse.GetState().Y + camera.location.Y) * camera.scale);
            ants.Add(new Ant(hill1, mouseLoc, 1, antBlack));

            foreach (Ant ant in ants)
            {
                ant.setTarget(player1.pLocation());
                ant.update();
            }

            player1.uptate(Keyboard.GetState());
            MouseState mouse = Mouse.GetState();
           // camera = trackPlayer(screenWidth,screenHeight,camera,mouse);

            //track the player
            Vector2 trackLocation = player1.pLocation();
            trackLocation.X -= screenWidth / (2 * camera.scale);
            trackLocation.Y -= screenHeight / (2 * camera.scale);
            camera.setLocation(trackLocation);
            base.Update(gameTime);
        }
        private Camera trackPlayer(int screenWidth, int screenHeight, Camera camera, MouseState mouse)
        {
            // move the camera with the player
            const float DRAG = 2;
            Vector2 cameraOffset = new Vector2();
            cameraOffset.X = -player1.pLocation().X + screenWidth / 2 / camera.scale;
            cameraOffset.Y = -player1.pLocation().Y + screenHeight / 2 / camera.scale;
            Vector2 targetLoc = new Vector2();
            targetLoc.X = mouse.X - screenWidth / 2;
            targetLoc.Y = mouse.Y - screenHeight / 2;
            cameraOffset.X -= targetLoc.X / camera.scale / DRAG;
            cameraOffset.Y -= targetLoc.Y / camera.scale / DRAG;
            camera.setLocation(cameraOffset);
            return camera;
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
            foreach (Ant ant in ants)
            {
                ant.draw(spriteBatch, camera);
            }

          //  spriteBatch.Begin(SpriteSortMode.Texture, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, camera.getTransformation());
           // spriteBatch.Draw(antBlack, mouseLoc, Color.Red);
            base.Draw(gameTime);
        }
    }
}
