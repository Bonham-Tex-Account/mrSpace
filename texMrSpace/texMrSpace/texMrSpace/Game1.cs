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

namespace texMrSpace
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState keys;
        int X = 700;
        int Y = 400;
        Stick Stick;
        Sprite Wall;
        Smashthing smash;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {


            base.Initialize();
        }


        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);


            Wall = new Sprite(new Vector2(0, 0), Content.Load<Texture2D>("lol"), Color.White);
            Stick = new Stick(new Vector2(X, Y), Content.Load<Texture2D>("stick-figure1"), Color.CornflowerBlue, 5);
            smash = new Smashthing(new Vector2(0, 0), Content.Load<Texture2D>("walls"), Color.CornflowerBlue, TimeSpan.FromSeconds(0),5);
        }



        protected override void Update(GameTime gameTime)
        {
            keys = Keyboard.GetState();
            Stick.Update(gameTime, keys, GraphicsDevice.Viewport.Width);


            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            Wall.Draw(spriteBatch);
            Stick.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
