using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;

namespace MG
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Player mainPlayer = new Player();
		Texture2D background;
		Vector2 backgroundPosition;
		IO io;

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
			base.Initialize();
			IsMouseVisible = true;
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			Vector2 startPosition = new Vector2(400, 200);
			Texture2D playerTexture = Content.Load<Texture2D>("player");
			mainPlayer.Initialize(playerTexture, startPosition, GraphicsDevice.Viewport);
			background = Content.Load<Texture2D>("background");
			backgroundPosition = new Vector2(0, 0);
			io = new IO(mainPlayer);
			//TODO: use this.Content to load your game content here 
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			// Exit() is obsolete on iOS
			#if !__IOS__ && !__TVOS__
						if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
							Exit();
			#endif

			// TODO: Add your update logic here

			base.Update(gameTime);

			io.Update(Keyboard.GetState(), Mouse.GetState(), gameTime);
			mainPlayer.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

			//TODO: Add your drawing code here
			spriteBatch.Begin(SpriteSortMode.Deferred,
				BlendState.AlphaBlend,
				null, null, null, null,
			    mainPlayer.GetCameraMatrix()
			);
			spriteBatch.Draw(background, backgroundPosition, Color.White);
			mainPlayer.Draw(spriteBatch);
			spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}