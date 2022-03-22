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

namespace SchoolZenog
{
    class Animation
    {
        Rectangle source;
        List<Rectangle> hitbox;
        Texture2D tex;
        SpriteBatch spriteBatch;

        public Animation(Texture2D tex, int a, int b)
        {
            this.tex = tex;
            source = new Rectangle(a * 150, b * 150, 150, 150);
            hitbox = this.Hitox(this.tex, source);
        }
        private List<Rectangle> Hitox(Texture2D tex, Rectangle source)
        {
            List<Rectangle> Hits = new List<Rectangle>();

            return Hits;
        }
    }
}
