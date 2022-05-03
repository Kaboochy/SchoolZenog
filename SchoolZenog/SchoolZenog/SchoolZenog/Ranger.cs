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
        static Texture2D tex, gg;
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
        public static void SetRTex(Texture2D t, Texture2D g)
        {
            tex = t;
            Projectile.tex = t;
            gg = g;
        }
        public void Update(Rectangle zDest, int move)
        {
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
            if (stop == 0 && ((dest.X < 1480 && dest.X > 1200) || (dest.X < 520 && dest.X > 240)) && timer >= 150)
            {
                currentAnime = Animated.attack11;
                stop = 1;
                timer = 0;
                mis.fire(right, dest);
            }
            //frame update
            up();
            if (stop == 1 && currentFrame + 1 == Number())
            {
                stop = 0;
            }
            if (timer >= 150)
            {
                mis.end();
            }
            green = new Rectangle(dest.X, dest.Y + 15, ((dest.Width * health) / 100), 15);
            mis.Update(move);
            lastAnime = currentAnime;
        }
        public void Draw(SpriteBatch sb)
        {
            if (currentAnime == Animated.Enter)
            {
                sb.Draw(gg, green, Color.Green);
                anime.enter[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.idle)
            {
                sb.Draw(gg, green, Color.Green);
                anime.idle[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.walk)
            {
                sb.Draw(gg, green, Color.Green);
                anime.walk[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.run)
            {
                sb.Draw(gg, green, Color.Green);
                anime.run[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.jump)
            {
                sb.Draw(gg, green, Color.Green);
                anime.jump[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.fallingA)
            {
                sb.Draw(gg, green, Color.Green);
                anime.fallingA[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.fallingH)
            {
                sb.Draw(gg, green, Color.Green);
                anime.fallingH[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.fallingL)
            {
                sb.Draw(gg, green, Color.Green);
                anime.fallingL[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.fallingS)
            {
                sb.Draw(gg, green, Color.Green);
                anime.fallingS[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.recover)
            {
                sb.Draw(gg, green, Color.Green);
                anime.recover[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.attack11)
            {
                sb.Draw(gg, green, Color.Green);
                anime.attack11[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.attack12)
            {
                sb.Draw(gg, green, Color.Green);
                anime.attack12[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.attack13)
            {
                sb.Draw(gg, green, Color.Green);
                anime.attack13[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.attack21)
            {
                sb.Draw(gg, green, Color.Green);
                anime.attack21[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.attack22)
            {
                sb.Draw(gg, green, Color.Green);
                anime.attack22[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.attack23)
            {
                sb.Draw(gg, green, Color.Green);
                anime.attack23[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.attackA1)
            {
                sb.Draw(gg, green, Color.Green);
                anime.attackA1[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.attackA2)
            {
                sb.Draw(gg, green, Color.Green);
                anime.attackA2[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.attackA3)
            {
                sb.Draw(gg, green, Color.Green);
                anime.attackA3[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.blockA)
            {
                sb.Draw(gg, green, Color.Green);
                anime.blockA[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.blockS)
            {
                sb.Draw(gg, green, Color.Green);
                anime.blockS[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.ult)
            {
                sb.Draw(gg, green, Color.Green);
                anime.ult[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.death)
            {
                sb.Draw(gg, green, Color.Green);
                anime.death[currentFrame].Draw(sb, dest, right, col);
            }
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
        public void fire(Boolean Right, Rectangle rDest)
        {
            dest = new Rectangle(rDest.X, rDest.Y + 30, 150, 150);
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