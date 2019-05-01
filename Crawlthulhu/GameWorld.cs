using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;

namespace Crawlthulhu
{
    delegate void DoorEventHandler();

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
        private static GameWorld instance;
        
        private float pauseTime;
        private bool pause = false;
        public Random rnd = new Random();
        public bool resetLevel = false;
        private Texture2D background;
        private Rectangle backgroundRect;
        public float deltaTime;
        public static SpriteFont font;
        public static SpriteFont font2x;
        public static SpriteFont font3x;
        public static SpriteFont font4x;
        public string playerName;
        public Vector2 worldSize { get; set; }
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public List<GameObject> gameObjects = new List<GameObject>();
        public List<GameObject> NewObjects { get; set; } = new List<GameObject>();
        public List<GameObject> RemoveObjects { get; set; } = new List<GameObject>();
        public ContentManager MyContent { get; set; }
        public List<Collider> Colliders { get; set; } = new List<Collider>();
        public List<Collider> RemoveColliders { get; set; } = new List<Collider>();

        private int numberOfEnemies = 0;

        public int NumberOfEnemies
        {
            get
            {
                return numberOfEnemies;
            }
            set
            {
                numberOfEnemies = value;
                if (numberOfEnemies <= 0)
                {
                    OnDoorEvent();
                }
            }
        }

        private bool spawnDoor = false;

        public UI ui = new UI();

        private event DoorEventHandler DoorEvent;

        private int score = 0;
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;              
            }
        }

        public bool chest = false;

        public string[][] collectables = new string[5][];

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

        //sound
        Song song;
        SoundEffect effect;


        private GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1920;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 1080;   // set this value to the desired height of your window
            //graphics.ToggleFullScreen();
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            MyContent = Content;

            DoorEvent += ReactToDoor;
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
            font = Content.Load<SpriteFont>("font");
            font2x = Content.Load<SpriteFont>("font2x");
            font3x = Content.Load<SpriteFont>("font3x");
            font4x = Content.Load<SpriteFont>("font4x");
            background = Content.Load<Texture2D>("Background");
            backgroundRect = new Rectangle(0, 0, 1920, 1080);
            gameObjects.Add(OtherObjectFactory.Instance.Create("crosshair"));
            gameObjects.Add(PlayerFactory.Instance.Create("default"));
            gameObjects.Add(OtherObjectFactory.Instance.Create("doorway"));
            gameObjects.Add(OtherObjectFactory.Instance.Create("doorTrigger"));
            //gameObjects.Add(OtherObjectFactory.Instance.Create("chest"));
            //gameObjects.Add(OtherObjectFactory.Instance.Create("collectable"));

            this.song = Content.Load<Song>("Musica");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;

            gameObjects.Add(OtherObjectFactory.Instance.Create("verticalWallLeft"));
            gameObjects.Add(OtherObjectFactory.Instance.Create("verticalWallRight"));

            NewObjects.Add(DoorPool.Instance.GetObject());
            NewObjects.Add(DoorTriggerPool.Instance.GetObject());

            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.LoadContent(Content);
            }
            ui.LoadContent(Content);
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
            if (!pause)
            {
                pauseTime += deltaTime;
                if (pauseTime > 0.5f)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.P))
                    {
                        pause = true;
                        pauseTime = 0;
                    }
                }

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

                foreach (Collider col in RemoveColliders)
                {
                    Colliders.Remove(col);
                }

                RemoveColliders.Clear();

                if (resetLevel)
                {
                    ResetLevel();
                }
                ui.Update(gameTime);

                //if (!spawnDoor)
                //{
                //    if (numberofEnemies == 0)
                //    {
                //        spawnDoor = true;
                //    }
                //}
                
                //if (spawnDoor)
                //{
                //    //spawnDoor = false;
                //    NewObjects.Add(DoorPool.Instance.GetObject());
                //    NewObjects.Add(DoorTriggerPool.Instance.GetObject());                   
                //}

                base.Update(gameTime);
            }
            else
            {
                pauseTime += deltaTime;
                if (pauseTime > 0.5f)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.P))
                    {
                        pause = false;
                        pauseTime = 0;
                    }
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    Exit();
                }
            }
        }

        protected virtual void OnDoorEvent()
        {
            if(DoorEvent != null)
            {
                DoorEvent();
            }
        }

        private void ReactToDoor()
        {
            Door.Instance.GameObject.Transform.Position = new Vector2(worldSize.X * 0.5f, 38);
            DoorTrigger.Instance.GameObject.Transform.Position = new Vector2(worldSize.X * 0.5f, -50);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.FrontToBack);
            spriteBatch.Draw(background, Vector2.Zero, backgroundRect, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.01f);
            spriteBatch.DrawString(font, $"Health: {Player.Instance.health}", new Vector2(1800, 20), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            spriteBatch.DrawString(font, $"Score: {Score}", new Vector2(40, 20), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);

            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }

            ui.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void ResetLevel()
        {
            Player.Instance.GameObject.Transform.Position = new Vector2(worldSize.X * 0.5f, worldSize.Y * 0.5f);


            foreach (GameObject gameObject in gameObjects)
            {
                if (gameObject != Player.Instance.GameObject
                    && gameObject != Crosshair.Instance.GameObject 
                    && gameObject != Door.Instance.GameObject
                    && gameObject != DoorTrigger.Instance.GameObject
                    )
                {
                    RemoveObjects.Add(gameObject);

                    Door.Instance.GameObject.Transform.Position = new Vector2(worldSize.X * 0.5f, -500);
                    DoorTrigger.Instance.GameObject.Transform.Position = new Vector2(worldSize.X * 0.5f, -500);
                }
            }
            foreach (GameObject gameObject in NewObjects)
            {
                RemoveObjects.Add(gameObject);
            }

            if (chest)
            {
                NewObjects.Add(ChestPool.Instance.GetObject());
                NewObjects.Add(CollectablePool.Instance.GetObject());

                NewObjects.Add(DoorPool.Instance.GetObject());
                NewObjects.Add(DoorTriggerPool.Instance.GetObject());
            }
            else if (!chest)
            {
                int numberOfMeleeEnemies = rnd.Next(1, 5);
                int numberOfRangedEnemies = rnd.Next(1, 5);

                for (int i = 0; i < numberOfMeleeEnemies; i++)
                {
                    NewObjects.Add(MeleeEnemyPool.Instance.GetObject());
                    NumberOfEnemies++;
                }

                for (int i = 0; i < numberOfRangedEnemies; i++)
                {
                    NewObjects.Add(RangedEnemyPool.Instance.GetObject());
                    NumberOfEnemies++;
                }
            }

            chest = false;
            resetLevel = false;
            spawnDoor = false;
        }
    }
}
