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
        SpriteBatch spriteBatch;

        public Animation(Texture2D tex, int a, int b, string path)
        {
            this.tex = tex;
            source = new Rectangle(a * 150, b * 150, 150, 150);
            hitbox = Hitox(path);
        }
        private List<Rectangle> Hitox(string path)
        {
            List<Rectangle> Hits = ReadFileOfIntegers(path);
            return Hits;
        }
        private List<Rectangle> ReadFileOfIntegers(string path)
        {
            List<Rectangle> rects = new List<Rectangle>();
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] num = line.Split(' ');
                        rects.Add(new Rectangle(Convert.ToInt32(num[0]), Convert.ToInt32(num[1]), Convert.ToInt32(num[2]), Convert.ToInt32(num[3])));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return rects;
        }
        public List<Rectangle> Retrive(Vector2 location)
        {
            List<Rectangle> rects = new List<Rectangle>();
            for (int i = 0; i < hitbox.Count; i++)
            {
                rects.Add(new Rectangle(hitbox[i].X + (int)location.X, hitbox[i].Y + (int)location.Y, hitbox[i].Width, hitbox[i].Height));
            }
            return rects;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, location, source, Color.White);
            spriteBatch.End();
        }
    }
}
