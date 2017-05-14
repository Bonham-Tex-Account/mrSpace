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
    class Stick : Sprite
    {

        float speed;

        public Stick(Vector2 position, Texture2D image, Color tint, float speed)
            : base(position, image, tint)
        {

            this.speed = speed;

        }
        public void Update(GameTime gametime, KeyboardState keys,int x)
        {
            if (keys.IsKeyDown(Keys.Left)&& X >= 0)
            {
                X -= speed;
            }
            if (keys.IsKeyDown(Keys.Right)&& X + 50 <= x)
            {
                X += speed;
            }
        }
    }
}
