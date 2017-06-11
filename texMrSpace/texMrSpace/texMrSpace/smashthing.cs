using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace texMrSpace
{
    class Smashthing : Sprite
    {
        TimeSpan timer = TimeSpan.FromSeconds(0);
        float speed;
        Random random = new Random();
        int _width;
        float time = 3;
        public Rectangle hitbox;
        public int score;
        public Smashthing(Vector2 position,Texture2D image,Color tint,TimeSpan time,float sped,int width)
            :base(position,image,tint)
        {
            speed = sped;
            timer = time;
            _width = width;
        }
        public void Update(GameTime gameTime,int hight,bool yay)
        {
            hitbox = new Rectangle((int)(Position.X), (int)(Position.Y), Image.Width, Image.Height);
            timer += gameTime.ElapsedGameTime;
           if (timer >= TimeSpan.FromSeconds(time))
            {
                Y += speed;
            }
           if (Y>=hight&& yay==false)
            {
                
                timer = TimeSpan.FromSeconds(0);
                Y = -580;
                X = random.Next(80,_width);
                score++;
                time *= 0.90f;
                
            }
           
           
        }

        public void AlignWith(Smashthing smash)
        {
            Position = new Vector2(smash.Position.X - Image.Width - 80, smash.Position.Y);
        }
    }
}
