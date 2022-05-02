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
    class Zy : AnimatedSprite
    {
        KeyboardState kb, oldKb = new KeyboardState();
        MouseState mouse, oldMouse = new MouseState();
        public int combo = 0;
        public bool shield = false;
        public bool ult;
        public bool faint = false;
        public Zy(Texture2D tex)
        {
            for (int i = 0; i < 5; i++)
            {
                anime.enter.Add(new Animation(tex, i, 0, 150, @"Content/Zy_enter.txt"));
            }
            for (int i = 0; i < 6; i++)
            {
                anime.idle.Add(new Animation(tex, i, 1, 150, @"Content/Zy_idle.txt"));
            }
            for (int i = 0; i < 6; i++)
            {
                anime.walk.Add(new Animation(tex, i, 2, 150, @"Content/Zy_walk.txt"));
            }
            for (int i = 0; i < 6; i++)
            {
                anime.run.Add(new Animation(tex, i, 3, 150, @"Content/Zy_run.txt"));
            }
            for (int i = 0; i < 3; i++)
            {
                anime.jump.Add(new Animation(tex, i, 4, 150, @"Content/Zy_jump.txt"));
            }
            for (int i = 0; i < 2; i++)
            {
                anime.fallingL.Add(new Animation(tex, i, 5, 150, @"Content/Zy_fallingL.txt"));
            }
            for (int i = 0; i < 2; i++)
            {
                anime.fallingH.Add(new Animation(tex, i, 6, 150, @"Content/Zy_fallingH.txt"));
            }
            for (int i = 0; i < 3; i++)
            {
                anime.fallingA.Add(new Animation(tex, i, 7, 150, @"Content/Zy_fallingA.txt"));
            }
            for (int i = 0; i < 2; i++)
            {
                anime.fallingS.Add(new Animation(tex, i, 8, 150, @"Content/Zy_fallingS.txt"));
            }
            for (int i = 0; i < 7; i++)
            {
                anime.recover.Add(new Animation(tex, i, 9, 150, @"Content/Zy_recover.txt"));
            }
            for (int i = 0; i < 3; i++)
            {
                anime.attack11.Add(new Animation(tex, i, 10, 150, @"Content/Zy_attack11.txt"));
            }
            for (int i = 0; i < 4; i++)
            {
                anime.attack12.Add(new Animation(tex, i, 11, 150, @"Content/Zy_attack12.txt"));
            }
            for (int i = 0; i < 4; i++)
            {
                anime.attack13.Add(new Animation(tex, i, 12, 150, @"Content/Zy_attack13.txt"));
            }
            for (int i = 0; i < 5; i++)
            {
                anime.attack21.Add(new Animation(tex, i, 13, 150, @"Content/Zy_attack21.txt"));
            }
            for (int i = 0; i < 4; i++)
            {
                anime.attack22.Add(new Animation(tex, i, 14, 150, @"Content/Zy_attack22.txt"));
            }
            for (int i = 0; i < 6; i++)
            {
                anime.attack23.Add(new Animation(tex, i, 15, 150, @"Content/Zy_attack23.txt"));
            }
            for (int i = 0; i < 5; i++)
            {
                anime.attackA1.Add(new Animation(tex, i, 16, 150, @"Content/Zy_attackA1.txt"));
            }
            for (int i = 0; i < 6; i++)
            {
                anime.attackA2.Add(new Animation(tex, i, 17, 150, @"Content/Zy_attackA2.txt"));
            }
            for (int i = 0; i < 3; i++)
            {
                anime.attackA3.Add(new Animation(tex, i, 18, 150, @"Content/Zy_attackA3.txt"));
            }
            for (int i = 0; i < 1; i++)
            {
                anime.blockS.Add(new Animation(tex, i, 19, 150, @"Content/Zy_blockS.txt"));
            }
            for (int i = 0; i < 1; i++)
            {
                anime.blockA.Add(new Animation(tex, i, 20, 150, @"Content/Zy_blockA.txt"));
            }
            for (int i = 0; i < 8; i++)
            {
                anime.ult.Add(new Animation(tex, i, 21, 150, @"Content/Zy_ult.txt"));
            }
            for (int i = 0; i < 8; i++)
            {
                anime.death.Add(new Animation(tex, i, 22, 150, @"Content/Zy_death.txt"));
            }
        }
        public void Update(KeyboardState Kb, MouseState Mouse, Rectangle destRect)
        {
            kb = Kb;
            mouse = Mouse;
            //idle
            if (stop == 0)
            {
                currentAnime = Animated.idle;
            }
            //movement
            if (kb.IsKeyDown(Keys.D) && !kb.IsKeyDown(Keys.A) && stop == 0)
            {
                currentAnime = Animated.walk;
                right = true;
            }
            if (kb.IsKeyDown(Keys.A) && !kb.IsKeyDown(Keys.D) && stop == 0)
            {
                currentAnime = Animated.walk;
                right = false;
            }
            if (currentAnime == Animated.walk && kb.IsKeyDown(Keys.LeftShift))
            {
                currentAnime = Animated.run;
            }
            //attack 2
            if (mouse.LeftButton == ButtonState.Pressed && oldMouse.LeftButton == ButtonState.Released && stop == 0 && combo == 0)
            {
                currentAnime = Animated.attack21;
                stop = 1;
            }
            if ((mouse.LeftButton == ButtonState.Pressed && oldMouse.LeftButton == ButtonState.Released && stop == 0 && combo != 0) 
                || (combo == 1 && lastAnime == Animated.attack21 && currentFrame > 3))
            {
                currentAnime = Animated.attack22;
                stop = 1;
            }
            if ((mouse.LeftButton == ButtonState.Pressed && oldMouse.LeftButton == ButtonState.Released && stop == 0 && combo != 0) 
                || (combo == 2 && lastAnime == Animated.attack22 && currentFrame > 2))
            {
                currentAnime = Animated.attack23;
                stop = 1;
            }
            if (kb.IsKeyDown(Keys.A) || kb.IsKeyDown(Keys.D) || lastAnime == Animated.idle)
            {
                combo = 0;
            }

            //Jump
            if (kb.IsKeyDown(Keys.Space) && oldKb.IsKeyUp(Keys.Space))
            {
                currentAnime = Animated.jump;
                stop = 2;
            }
            if (stop == 1 && currentFrame + 1 == Number() || stop == 2 && currentFrame + 1 == Number() && destRect.Y >= 750 || (stop == 3 && mouse.RightButton == ButtonState.Released))
            {
                stop = 0;
                destRect.Y = 750;
            }
            if (stop == 2 && currentFrame + 1 == Number() && destRect.Y < 750)
            {
                currentFrame--;
            }
            //Block
            if (mouse.RightButton == ButtonState.Pressed && stop == 0 && shield)
            {
                stop = 3;
                currentAnime = Animated.blockS;
            }
            if (mouse.RightButton == ButtonState.Pressed && stop == 3 && !shield)
            {
                stop = 0;
                currentAnime = Animated.idle;
            }
            //Ult
            if (kb.IsKeyDown(Keys.Q) && ult == true)
            {
                stop = 5;
                currentAnime = Animated.ult;
            }
            if (stop == 5 && currentFrame == 7)
                stop = 0;
            //TAKING DAMAGE
            if(stop == 4)
            {
                currentAnime = Animated.fallingL;
            }
            if (stop == 4 && currentFrame + 1 == Number() && destRect.Y < 750)
            {
                currentFrame--;
            }
            if (stop == 4 && currentFrame + 1 == Number() && destRect.Y >= 750)
            {
                stop = 6;
                currentAnime = Animated.recover;
                if (faint)
                    stop = 10;
            }
            if(stop == 6 && currentFrame == 6)
            {
                stop = 0;
                currentAnime = Animated.idle;
            }
            //FAINT
            if(stop == 10)
            {
                currentAnime = Animated.recover;
                currentFrame = 0;
            }
            /* //DEBUGGING
            Console.WriteLine("stop = " + stop);
            Console.WriteLine("currentAnime = " + currentAnime);
            Console.WriteLine("currentFrame = " + currentFrame);
            Console.WriteLine("destRect.Y = " + destRect.Y);
            */
            //frame update
            up();
            //Other
            oldKb = kb;
            oldMouse = mouse;
            lastAnime = currentAnime;
        }
    }
}