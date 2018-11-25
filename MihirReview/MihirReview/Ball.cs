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
    class Ball : Sprite
    {
        public Vector2 Speed;
        public Rectangle ballhitbox;

        public bool HitLeft;
        public bool HitRight;

        private Vector2 originalPos;

        public Ball(Texture2D tex, Vector2 pos, Vector2 speed) : base(tex, pos)
        {
            Speed = speed;
            originalPos = pos;
        }

        public void Move(Rectangle screenSize)
        {
            HitLeft = false;
            HitRight = false;

            Console.WriteLine(screenSize);
            if (this.Position.X < screenSize.Left)
            {
                Position = originalPos;
                HitLeft = true;
            }
            
            if(this.Position.X + this.Texture.Width > screenSize.Right)
            {
                Position = originalPos;
                HitRight = true;
            }

            if (this.Position.Y < screenSize.Top)
            {
                Speed = new Vector2(Speed.X, Math.Abs(Speed.Y));
            }

            if(this.Position.Y + this.Texture.Height > screenSize.Bottom)
            {
                Speed = new Vector2(Speed.X, -Math.Abs(Speed.Y));
            }
                Position += Speed;

            ballhitbox.Height = Texture.Height;
            ballhitbox.Width = Texture.Width;
            ballhitbox.X = (int)Position.X;
            ballhitbox.Y = (int)Position.Y;
        }

       

    }
}
