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
    class stick : Sprite 
    {
       
        public stick(Vector2 position, Texture2D image, Color tint  )
            : base (position, image, tint)
        {
            
        

        }
        public void Update(GameTime gametime, KeyboardState keys)
        {
            if(keys.IsKeyDown(Keys.Left))
            {
                
            }
            if(keys.IsKeyDown(Keys.Right))
            {

            }
        }
    }
}
