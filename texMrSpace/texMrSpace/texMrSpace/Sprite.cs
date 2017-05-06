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
    public class Sprite
    {
        private Vector2 _position;
        private Texture2D _image;
        private Color _tint;
        private Rectangle? _source;
        private Vector2 _origin;
        public Vector2 Origin
        {
            get
            {
                return _origin;
            }
            set
            {
                _origin = value;
            }
        }
        public Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }
        public Color Tint
        {
            get
            {
                return _tint;
            }
            set
            {
                _tint = value;
            }
        }
        public Texture2D Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
            }
        }


        

        public Sprite(Vector2 position, Texture2D image, Color tint)
        {
            _position = position;
            _image = image;
            _tint = tint;
            
        }






        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_image, _position, _source, _tint, 0f, _origin, 1f, SpriteEffects.None, 1f);
        }
    }
}

