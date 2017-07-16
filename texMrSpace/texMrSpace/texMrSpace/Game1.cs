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
using System.Xml.Linq;

namespace texMrSpace
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState keys;
        KeyboardState prevKeys;
        int X = 0;
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
        Song song;
        List<int> highScores;

        XDocument doc;


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
            song = Content.Load<Song>("boi");
            MediaPlayer.Play(song);
            lol = random.Next(70, GraphicsDevice.Viewport.Width);
            font = Content.Load<SpriteFont>("SpriteFont1");
            bigfont = Content.Load<SpriteFont>("SpriteFont2");
            Wall = new Sprite(new Vector2(0, 0), Content.Load<Texture2D>("walls"), Color.White);
            Stick = new Stick(new Vector2(X, Y), Content.Load<Texture2D>("dude"), Color.CornflowerBlue, 70);
            Stan = new Sprite(new Vector2(0, 0), Content.Load<Texture2D>("stan head"), Color.White);
            Stan.Position = new Vector2(rand.Next(0, GraphicsDevice.Viewport.Width - Stan.Image.Width), rand.Next(0, GraphicsDevice.Viewport.Height - Stan.Image.Height));
            smash = new Smashthing(new Vector2(lol, -580), Content.Load<Texture2D>("lol"), Color.CornflowerBlue, TimeSpan.FromSeconds(0), 5, GraphicsDevice.Viewport.Width);
            _smash = new Smashthing(new Vector2(smash.Position.X - smash.Image.Width - 70, smash.Position.Y), Content.Load<Texture2D>("lol"), Color.CornflowerBlue, TimeSpan.FromSeconds(0), 5, GraphicsDevice.Viewport.Width);
            //doc = new XmlDocument();
            //doc.Load("Scores.xml");

            //XmlElement element = doc.GetElementById("Score");
            // highScore = int.Parse(doc.GetElementById("Score").InnerText);

            highScores = new List<int>();
            doc = XDocument.Load("Scores.xml");

            foreach (XElement score in doc.Root.Elements("Score"))
            {
                highScores.Add(int.Parse(score.Value));
            }

            //you cannot change the value
            //read only
            //foreach(int score in highScores)
            //{

            //}

        }

        protected override void UnloadContent()
        {
            doc.Root.RemoveNodes();

            for (int i = 0; i < highScores.Count; i++)
            {
                XElement score = new XElement("Score", highScores[i]);
                doc.Root.Add(score);
            }
            doc.Save("Scores.xml");

        }
        
        //https://www.youtube.com/watch?v=6sOZmTKctRs

        protected override void Update(GameTime gameTime)
        {
            hitbox = new Rectangle((int)(Stan.Position.X), (int)(Stan.Position.Y), Stan.Image.Width, Stan.Image.Height);
            prevKeys = keys;
            keys = Keyboard.GetState();
            MouseState ms = Mouse.GetState();
            hitbox1 = new Rectangle((int)(ms.X), (int)(ms.Y), 10, 10);
            Stick.Update(gameTime, keys, prevKeys, GraphicsDevice.Viewport.Width);
            smash.Update(gameTime, GraphicsDevice.Viewport.Height, yay);
            _smash.Update(gameTime, GraphicsDevice.Viewport.Height, yay);
            _smash.AlignWith(smash);
            if (keys.IsKeyDown(Keys.R))
            {
                 yay = false;
                 sum = false;
                 Stick.X = 0;
                 Y = 400;
                smash.score = 0;

            }
            if (smash.hitbox.Intersects(Stick.hitbox) || _smash.hitbox.Intersects(Stick.hitbox))
            {
                yay = true;
                Stick.X = 100000;
                //check if score is greater than 3rd high score. if it is, replace 3rd high score with new score
                //check if 3rd high score greater than 2nd high score. if it is, swap the 2nd and 3rd high score
                //check if 2nd high score greater than 1st high score. if it is, swap the 1st and 2nd high score
                smash.deathfunction(highScores);

            }
            if (hitbox.Intersects(hitbox1) && ms.LeftButton == ButtonState.Pressed && sum == false && yay == false)
            {

                smash.deathfunction(highScores);

                smash.score += 20;
                yay = true;
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

            string highScoreText = "High Scores";

            for (int i = 0; i < highScores.Count; i++)
            {
                highScoreText += $"\n{i + 1}.{highScores[i]}";
            }

            spriteBatch.DrawString(font, highScoreText, new Vector2(10, 200), Color.Black);

            if (smash.score >= 20 && yay)
            {
                spriteBatch.DrawString(bigfont, ("YOU WIN :)"), new Vector2(0, 20), Color.Black);
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
