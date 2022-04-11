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
    class AnimatedSprite
    {
        public Animations anime = new Animations();
        public int stop = 0, currentFrame = 0;
        public Animated currentAnime = Animated.idle, lastAnime = Animated.idle;
        public bool right = true;

        public void up()
        {
            if (currentAnime != lastAnime || currentFrame + 1 == Number())
            {
                currentFrame = 0;
            }
            else
            {
                currentFrame++;
            }
        }
        public bool Hit(Rectangle dest, Rectangle hitbox)
        {
            bool touch = false;
            List<Rectangle> hitboxes = Retrive(dest);
            for (int i = 0; i < hitboxes.Count; i++)
            {
                if (hitboxes[i].Intersects(hitbox))
                {
                    touch = true;
                }
            }
            return touch;
        }
        public bool Hit(Rectangle dest, List<Rectangle> hitbox)
        {
            bool touch = false;
            List<Rectangle> hitboxes = Retrive(dest);
            for (int i = 0; i < hitboxes.Count; i++)
            {
                for (int k = 0; k < hitbox.Count; k++)
                {
                    if (hitboxes[i].Intersects(hitbox[k]))
                    {
                        touch = true;
                    }
                }
            }
            return touch;
        }
        public List<Rectangle> Retrive(Rectangle location)
        {
            if (currentAnime == Animated.Enter)
            {
                return anime.enter[currentFrame].Retrive(location, right);
            }
            else if (currentAnime == Animated.idle)
            {
                return anime.idle[currentFrame].Retrive(location, right);
            }
            else if (currentAnime == Animated.walk)
            {
                return anime.walk[currentFrame].Retrive(location, right);
            }
            else if (currentAnime == Animated.run)
            {
                return anime.run[currentFrame].Retrive(location, right);
            }
            else if (currentAnime == Animated.jump)
            {
                return anime.jump[currentFrame].Retrive(location, right);
            }
            else if (currentAnime == Animated.fallingA)
            {
                return anime.fallingA[currentFrame].Retrive(location, right);
            }
            else if (currentAnime == Animated.fallingH)
            {
                return anime.fallingH[currentFrame].Retrive(location, right);
            }
            else if (currentAnime == Animated.fallingL)
            {
                return anime.fallingL[currentFrame].Retrive(location, right);
            }
            else if (currentAnime == Animated.fallingS)
            {
                return anime.fallingS[currentFrame].Retrive(location, right);
            }
            else if (currentAnime == Animated.recover)
            {
                return anime.recover[currentFrame].Retrive(location, right);
            }
            else if (currentAnime == Animated.attack11)
            {
                return anime.attack11[currentFrame].Retrive(location, right);
            }
            else if (currentAnime == Animated.attack12)
            {
                return anime.attack12[currentFrame].Retrive(location, right);
            }
            else if (currentAnime == Animated.attack13)
            {
                return anime.attack13[currentFrame].Retrive(location, right);
            }
            else if (currentAnime == Animated.attack21)
            {
                return anime.attack21[currentFrame].Retrive(location, right);
            }
            else if (currentAnime == Animated.attack22)
            {
                return anime.attack22[currentFrame].Retrive(location, right);
            }
            else if (currentAnime == Animated.attack23)
            {
                return anime.attack23[currentFrame].Retrive(location, right);
            }
            else if (currentAnime == Animated.attackA1)
            {
                return anime.attackA1[currentFrame].Retrive(location, right);
            }
            else if (currentAnime == Animated.attackA2)
            {
                return anime.attackA2[currentFrame].Retrive(location, right);
            }
            else if (currentAnime == Animated.attackA3)
            {
                return anime.attackA3[currentFrame].Retrive(location, right);
            }
            else if (currentAnime == Animated.blockA)
            {
                return anime.blockA[currentFrame].Retrive(location, right);
            }
            else if (currentAnime == Animated.blockS)
            {
                return anime.blockS[currentFrame].Retrive(location, right);
            }
            else if (currentAnime == Animated.ult)
            {
                return anime.ult[currentFrame].Retrive(location, right);
            }
            else if (currentAnime == Animated.death)
            {
                return anime.death[currentFrame].Retrive(location, right);
            }
            else
            {
                return new List<Rectangle>();
            }
        }
        public int Number()
        {
            if (currentAnime == Animated.Enter)
            {
                return anime.enter.Count;
            }
            else if (currentAnime == Animated.idle)
            {
                return anime.idle.Count;
            }
            else if (currentAnime == Animated.walk)
            {
                return anime.walk.Count;
            }
            else if (currentAnime == Animated.run)
            {
                return anime.run.Count;
            }
            else if (currentAnime == Animated.jump)
            {
                return anime.jump.Count;
            }
            else if (currentAnime == Animated.fallingA)
            {
                return anime.fallingA.Count;
            }
            else if (currentAnime == Animated.fallingH)
            {
                return anime.fallingH.Count;
            }
            else if (currentAnime == Animated.fallingL)
            {
                return anime.fallingL.Count;
            }
            else if (currentAnime == Animated.fallingS)
            {
                return anime.fallingS.Count;
            }
            else if (currentAnime == Animated.recover)
            {
                return anime.recover.Count;
            }
            else if (currentAnime == Animated.attack11)
            {
                return anime.attack11.Count;
            }
            else if (currentAnime == Animated.attack12)
            {
                return anime.attack12.Count;
            }
            else if (currentAnime == Animated.attack13)
            {
                return anime.attack13.Count;
            }
            else if (currentAnime == Animated.attack21)
            {
                return anime.attack21.Count;
            }
            else if (currentAnime == Animated.attack22)
            {
                return anime.attack22.Count;
            }
            else if (currentAnime == Animated.attack23)
            {
                return anime.attack23.Count;
            }
            else if (currentAnime == Animated.attackA1)
            {
                return anime.attackA1.Count;
            }
            else if (currentAnime == Animated.attackA2)
            {
                return anime.attackA2.Count;
            }
            else if (currentAnime == Animated.attackA3)
            {
                return anime.attackA3.Count;
            }
            else if (currentAnime == Animated.blockA)
            {
                return anime.blockA.Count;
            }
            else if (currentAnime == Animated.blockS)
            {
                return anime.blockS.Count;
            }
            else if (currentAnime == Animated.ult)
            {
                return anime.ult.Count;
            }
            else if (currentAnime == Animated.death)
            {
                return anime.death.Count;
            }
            else
            {
                return 0;
            }
        }
        public void Draw(SpriteBatch sb, Rectangle dest, Color col)
        {
            if (currentAnime == Animated.Enter)
            {
                anime.enter[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.idle)
            {
                anime.idle[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.walk)
            {
                anime.walk[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.run)
            {
                anime.run[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.jump)
            {
                anime.jump[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.fallingA)
            {
                anime.fallingA[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.fallingH)
            {
                anime.fallingH[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.fallingL)
            {
                anime.fallingL[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.fallingS)
            {
                anime.fallingS[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.recover)
            {
                anime.recover[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.attack11)
            {
                anime.attack11[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.attack12)
            {
                anime.attack12[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.attack13)
            {
                anime.attack13[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.attack21)
            {
                anime.attack21[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.attack22)
            {
                anime.attack22[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.attack23)
            {
                anime.attack23[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.attackA1)
            {
                anime.attackA1[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.attackA2)
            {
                anime.attackA2[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.attackA3)
            {
                anime.attackA3[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.blockA)
            {
                anime.blockA[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.blockS)
            {
                anime.blockS[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.ult)
            {
                anime.ult[currentFrame].Draw(sb, dest, right, col);
            }
            if (currentAnime == Animated.death)
            {
                anime.death[currentFrame].Draw(sb, dest, right, col);
            }
        }
    }

    enum Animated
    {
        Enter, idle, walk, run, jump, fallingL, fallingH, fallingA, fallingS, recover,
        attack11, attack12, attack13, attack21, attack22, attack23, attackA1, attackA2, attackA3,
        blockS, blockA, ult, death
    }
}
