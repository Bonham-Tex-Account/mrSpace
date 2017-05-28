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
        public Smashthing(Vector2 position,Texture2D image,Color tint,TimeSpan time,float sped)
            :base(position,image,tint)
        {
            speed = sped;
            timer = time;
        }
        public void Update(GameTime gameTime,int hight)
        {
           if (timer == TimeSpan.FromSeconds(3))
            {
                Y += speed;
            }
           
           
        }
    }
}
