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
        Smashthing _smash;
        int lol = 0;
        Random random = new Random();
        SpriteFont font;
        SpriteFont bigfont;
        bool yay = false;
        bool sum = false;
        Sprite Stan;
        Rectangle hitbox;
        Rectangle hitbox1;
        Random rand;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        


        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            rand = new Random();
            lol = random.Next(80, GraphicsDevice.Viewport.Width);
            font = Content.Load<SpriteFont>("SpriteFont1");
          bigfont = Content.Load<SpriteFont>("SpriteFont2");
            Wall = new Sprite(new Vector2(0, 0), Content.Load<Texture2D>("walls"), Color.White);
            Stick = new Stick(new Vector2(X, Y), Content.Load<Texture2D>("stick_man"), Color.CornflowerBlue, 5);
            Stan = new Sprite(new Vector2(rand.Next(0,GraphicsDevice.Viewport.Width-Stan.Image.Width),rand.Next(0,GraphicsDevice.Viewport.Height-Stan.Image.Height)), Content.Load<Texture2D>("stan head"), Color.White);
            smash = new Smashthing(new Vector2(lol , -580), Content.Load<Texture2D>("lol"), Color.CornflowerBlue, TimeSpan.FromSeconds(0),5,GraphicsDevice.Viewport.Width);
            _smash = new Smashthing(new Vector2(smash.Position.X-smash.Image.Width-80, smash.Position.Y), Content.Load<Texture2D>("lol"), Color.CornflowerBlue, TimeSpan.FromSeconds(0), 5,GraphicsDevice.Viewport.Width);
        }



        protected override void Update(GameTime gameTime)
        {
            hitbox = new Rectangle((int)(Stan.Position.X), (int)(Stan.Position.Y), Stan.Image.Width,Stan.Image.Height);
            keys = Keyboard.GetState();
            MouseState ms = Mouse.GetState();
            hitbox1 = new Rectangle((int)(ms.X), (int)(ms.Y), 10, 10);
            Stick.Update(gameTime, keys, GraphicsDevice.Viewport.Width);
            smash.Update(gameTime, GraphicsDevice.Viewport.Height,yay);
            _smash.Update(gameTime, GraphicsDevice.Viewport.Height,yay);
            _smash.AlignWith(smash);
            if(smash.hitbox.Intersects(Stick.hitbox)||_smash.hitbox.Intersects(Stick.hitbox))
            {
                yay = true;
                Stick.X = 100000;
            }
            if(hitbox.Intersects(hitbox1)&& ms.LeftButton== ButtonState.Pressed&&sum==false)
            {
                smash.score += 20;
                sum = true;
            }
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            Wall.Draw(spriteBatch);
            Stick.Draw(spriteBatch);
            smash.Draw(spriteBatch);
            _smash.Draw(spriteBatch);
            Stan.Draw(spriteBatch);
            spriteBatch.DrawString(bigfont, string.Format("{0}", smash.score.ToString()), new Vector2(0, 0), Color.CornflowerBlue);
           
            if(smash.score>=20&&yay)
            {
                spriteBatch.DrawString(bigfont, ("YOU WIN :)\nTHE SMASHTHING \nSTILL GOT YOU\n:):):):):):):) "), new Vector2(0, 20), Color.Black);
            }
            else if (yay)
            {
                spriteBatch.DrawString(bigfont, ("YOU LOSE\n #PLAYED "), new Vector2(300, 20), Color.Black);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
