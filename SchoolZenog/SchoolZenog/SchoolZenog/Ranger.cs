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
    class Ranger : AnimatedSprite
    {
        Rectangle green;
        static Texture2D tex;
        public int health = 100;
        int timer = 0;
        public Projectile mis;

        public Ranger(int a, Texture2D t)
        {
            if (a == 0)
            {
                dest = new Rectangle(2100, 820, 200, 200);
            }
            else if (a == 1)
            {
                dest = new Rectangle(-380, 820, 200, 200);
            }
            else
            {
                dest = new Rectangle(2100, 820, 200, 200);
            }
            green = new Rectangle(dest.X, dest.Y + 15, ((dest.Width * health) / 100), 15);
            mis = new Projectile();
            for (int i = 0; i < 2; i++)
            {
                anime.attack11.Add(new Animation(t, i, 0, 50, @"Content/Ranger/Ranger_Attack11.txt"));
            }
            for (int i = 0; i < 4; i++)
            {
                anime.walk.Add(new Animation(t, i, 1, 50, @"Content/Ranger/Ranger_Walk.txt"));
            }
            for (int i = 0; i < 3; i++)
            {
                anime.idle.Add(new Animation(t, i, 2, 50, @"Content/Ranger/Ranger_Idle.txt"));
            }
            /*
            for (int i = 0; i < 3; i++)
            {
                anime.attack21.Add(new Animation(t, i, 3, 50, @"Content/Ranger/Ranger_Attack21.txt"));
            }
            */
            for (int i = 0; i < 1; i++)
            {
                mis.anime.attack11.Add(new Animation(t, i, 4, 50, @"Content/Ranger/Ranger_Projectile.txt"));
            }
        }
        public static void SetRTex(Texture2D t)
        {
            tex = t;
            Projectile.tex = t;
        }
        public void Update(Rectangle zDest, int move)
        {
            Console.WriteLine("update");
            timer++;
            //idle
            if (stop == 0)
            {
                currentAnime = Animated.idle;
            }
            //side
            if (zDest.X < dest.X)
            {
                right = true;
            }
            if (zDest.X > dest.X)
            {
                right = false;
            }
            //screen movement
            if (!(move == 0))
            {
                if (move == -2)
                {
                    dest.X += 5;
                }
                if (move == -1)
                {
                    dest.X += 2;
                }
                if (move == 1)
                {
                    dest.X -= 2;
                }
                if (move == 2)
                {
                    dest.X -= 5;
                }
            }
            //movement
            if (right && stop == 0 && !(dest.X < 1480 && dest.X > 1200))
            {
                currentAnime = Animated.walk;
                if (dest.X > 1480)
                    dest.X -= 3;
                else
                    dest.X += 3;
            }
            if (!right && stop == 0 && !(dest.X < 520 && dest.X > 240))
            {
                currentAnime = Animated.walk;
                if (dest.X < 520)
                    dest.X += 3;
                else
                    dest.X -= 3;
            }
            //attack
            if (stop == 0 && ((dest.X < 1480 && dest.X > 1200) || (dest.X < 520 && dest.X > 240)) && timer >= 55)
            {
                currentAnime = Animated.attack11;
                stop = 1;
                timer = 0;
                mis.fire(right);
            }
            //frame update
            up();
            if (stop == 1 && currentFrame + 1 == Number())
            {
                stop = 0;
            }
            if (timer >= 55)
            {
                mis.end();
            }
            green = new Rectangle(dest.X, dest.Y + 15, ((dest.Width * health) / 100), 15);
            mis.Update(move);
            lastAnime = currentAnime;
        }
    }

    class Projectile : AnimatedSprite
    {
        public static Texture2D tex;
        public Boolean isFired = false;
        public Projectile()
        {
            dest = new Rectangle(0, 0, 150, 150);
        }
        public void Update(int move)
        {
            if (isFired)
            {
                if (!(move == 0))
                {
                    if (move == -2)
                    {
                        dest.X += 5;
                    }
                    if (move == -1)
                    {
                        dest.X += 2;
                    }
                    if (move == 1)
                    {
                        dest.X -= 2;
                    }
                    if (move == 2)
                    {
                        dest.X -= 5;
                    }
                }
                if (right)
                {
                    dest.X -= 10;
                }
                else
                {
                    dest.X += 10;
                }
            }
            else
            {
                dest = new Rectangle(0, 0, 150, 150);
            }
        }
        public void fire(Boolean Right)
        {
            isFired = true;
            right = Right;
        }
        public void end()
        {
            isFired = false;
        }
        public new void Draw(SpriteBatch sb)
        {
            if (isFired)
            {
                anime.attack11[currentFrame].Draw(sb, dest, right, col);
            }
        }
    }
}