using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Crawlthulhu
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
        private static GameWorld instance;

        public float deltaTime;
        public Vector2 worldSize { get; set; }
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public List<GameObject> gameObjects = new List<GameObject>();
        public List<GameObject> NewObjects { get; set; } = new List<GameObject>();
        public List<GameObject> RemoveObjects { get; set; } = new List<GameObject>();
        public ContentManager MyContent { get; set; }

        public static GameWorld Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new GameWorld();
                }
                return instance;
            }
        }

        private GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1920;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 1080;   // set this value to the desired height of your window
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            MyContent = Content;
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
            worldSize = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            gameObjects.Add(PlayerFactory.Instance.Create("default"));
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

            foreach(GameObject gameObject in gameObjects)
            {
                gameObject.LoadContent(Content);
            }

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Update(gameTime);
            }

            foreach (GameObject go in RemoveObjects)
            {
                gameObjects.Remove(go);
            }

            RemoveObjects.Clear();

            foreach (GameObject go in NewObjects)
            {
                gameObjects.Add(go);
            }

            NewObjects.Clear();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
