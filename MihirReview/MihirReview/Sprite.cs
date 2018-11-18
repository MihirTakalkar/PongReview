using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MihirReview
{
    class Sprite
    {

        public Texture2D Texture;
        public Vector2 Position;
       
        public Sprite(Texture2D tex, Vector2 pos)
        {
            Texture = tex;
            Position = pos;
       
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

    }
}
