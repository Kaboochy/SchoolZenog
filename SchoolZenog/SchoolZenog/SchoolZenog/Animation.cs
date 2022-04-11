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
using System.IO;

namespace SchoolZenog
{
    class Animation
    {
        Rectangle source;
        List<Rectangle> hitbox;
        Texture2D tex;
        int size;

        public Animation(Texture2D tex, int a, int b, int d, string path)
        {
            this.tex = tex;
            size = d;
            source = new Rectangle(a * size, b * size, size, size);
            hitbox = new List<Rectangle>();
            hitbox.Add(Hitox(path, (a * 2)));
            hitbox.Add(Hitox(path, (a * 2) + 1));
        }
        private Rectangle Hitox(string path, int c)
        {
            return ReadFileOfIntegers(path, c);
        }
        private Rectangle ReadFileOfIntegers(string path, int c)
        {
            Rectangle rect = new Rectangle();
            string line = File.ReadLines(path).Skip(c - 1).Take(1).First();
            string[] num = line.Split(' ');
            rect = (new Rectangle(Convert.ToInt32(num[0]), Convert.ToInt32(num[1]), Convert.ToInt32(num[2]), Convert.ToInt32(num[3])));
            return rect;
        }
        public List<Rectangle> Retrive(Rectangle location, bool dic)
        {
            List<Rectangle> rects = new List<Rectangle>();
            int a = location.Width / size;
            if (dic)
            {
                for (int i = 0; i < hitbox.Count; i++)
                {
                    rects.Add(new Rectangle(hitbox[i].X * a + location.X, hitbox[i].Y * a + location.Y, hitbox[i].Width * a, hitbox[i].Height * a));
                }
            }
            else
            {
                List<Rectangle> hit = new List<Rectangle>();
                hit = flip(hitbox);
                for (int i = 0; i < hitbox.Count; i++)
                {
                    rects.Add(new Rectangle(hit[i].X * a + (int)location.X, hit[i].Y * a + (int)location.Y, hit[i].Width * a, hit[i].Height * a));
                }
            }
            return rects;
        }
        private List<Rectangle> flip(List<Rectangle> hitbox)
        {
            List<Rectangle> hit = new List<Rectangle>();
            for (int i = 0; i < hitbox.Count; i++)
            {
                hit.Add(new Rectangle((size - hitbox[i].X + hitbox[i].Width), hitbox[i].Y, hitbox[i].Width, hitbox[i].Height));
            }
            return hit;
        }
        public void Draw(SpriteBatch spriteBatch, Rectangle dest, bool right, Color col)
        {
            if (right)
            {
                spriteBatch.Draw(tex, dest, source, col, 0.0f, new Vector2(0, 0), SpriteEffects.None, 0.0f);
            }
            else
            {
                spriteBatch.Draw(tex, dest, source, col, 0.0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0.0f);
            }
        }
    }

    class Animations
    {
        public List<Animation> enter = new List<Animation>();
        public List<Animation> idle = new List<Animation>();
        public List<Animation> walk = new List<Animation>();
        public List<Animation> run = new List<Animation>();
        public List<Animation> jump = new List<Animation>();
        public List<Animation> fallingL = new List<Animation>();
        public List<Animation> fallingH = new List<Animation>();
        public List<Animation> fallingA = new List<Animation>();
        public List<Animation> fallingS = new List<Animation>();
        public List<Animation> recover = new List<Animation>();
        public List<Animation> attack11 = new List<Animation>();
        public List<Animation> attack12 = new List<Animation>();
        public List<Animation> attack13 = new List<Animation>();
        public List<Animation> attack21 = new List<Animation>();
        public List<Animation> attack22 = new List<Animation>();
        public List<Animation> attack23 = new List<Animation>();
        public List<Animation> attackA1 = new List<Animation>();
        public List<Animation> attackA2 = new List<Animation>();
        public List<Animation> attackA3 = new List<Animation>();
        public List<Animation> blockS = new List<Animation>();
        public List<Animation> blockA = new List<Animation>();
        public List<Animation> ult = new List<Animation>();
        public List<Animation> death = new List<Animation>();
    }
}
