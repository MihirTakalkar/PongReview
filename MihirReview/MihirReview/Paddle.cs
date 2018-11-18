using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MihirReview
{
    class Paddle : Sprite
    {
        public Vector2 Speed;
        public Rectangle paddlehitbox;

        public Paddle(Texture2D tex, Vector2 pos, Vector2 speed) : base(tex, pos)
        {
            Speed = speed;
        }

        public void moveup(Rectangle screenSize)
        {
            if(this.Position.Y < screenSize.Top)
            {
                Position = new Vector2(Position.X, 0);
            }
            Position -= Speed;

            paddlehitbox.Height = Texture.Height;
            paddlehitbox.Width = Texture.Width;
            paddlehitbox.X = (int)Position.X;
            paddlehitbox.Y = (int)Position.Y;
        }
        public void movedown(Rectangle screenSize)
        {
            if (this.Position.Y + Texture.Height > screenSize.Bottom)
            {
                Position = new Vector2(Position.X, screenSize.Height - Texture.Height + 5);
            }
            Position += Speed;

            paddlehitbox.Height = Texture.Height;
            paddlehitbox.Width = Texture.Width;
            paddlehitbox.X = (int)Position.X;
            paddlehitbox.Y = (int)Position.Y;

        }
    }
}
