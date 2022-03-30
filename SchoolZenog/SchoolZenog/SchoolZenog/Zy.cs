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
        KeyboardState kb, oldKb;
        MouseState mouse, oldMouse;
        public Zy(Texture2D tex)
        {
            for (int i = 0; i < 5; i++)
            {
                anime.enter.Add(new Animation(tex, i, 1, @"Content/Hitboxes/Zy/Zy_enter.txt"));
            }
            for (int i = 0; i < 8; i++)
            {
                anime.idle.Add(new Animation(tex, i, 1, @"Content/Hitboxes/Zy/Zy_idle.txt"));
            }
            for (int i = 0; i < 6; i++)
            {
                anime.walk.Add(new Animation(tex, i, 1, @"Content/Hitboxes/Zy/Zy_walk.txt"));
            }
            for (int i = 0; i < 6; i++)
            {
                anime.run.Add(new Animation(tex, i, 1, @"Content/Hitboxes/Zy/Zy_run.txt"));
            }
            for (int i = 0; i < 3; i++)
            {
                anime.jump.Add(new Animation(tex, i, 1, @"Content/Hitboxes/Zy/Zy_jump.txt"));
            }
            for (int i = 0; i < 2; i++)
            {
                anime.fallingL.Add(new Animation(tex, i, 1, @"Content/Hitboxes/Zy/Zy_fallingL.txt"));
            }
            for (int i = 0; i < 2; i++)
            {
                anime.fallingH.Add(new Animation(tex, i, 1, @"Content/Hitboxes/Zy/Zy_fallingH.txt"));
            }
            for (int i = 0; i < 3; i++)
            {
                anime.fallingA.Add(new Animation(tex, i, 1, @"Content/Hitboxes/Zy/Zy_fallingA.txt"));
            }
            for (int i = 0; i < 2; i++)
            {
                anime.fallingS.Add(new Animation(tex, i, 1, @"Content/Hitboxes/Zy/Zy_fallingS.txt"));
            }
            for (int i = 0; i < 7; i++)
            {
                anime.recover.Add(new Animation(tex, i, 1, @"Content/Hitboxes/Zy/Zy_recover.txt"));
            }
            for (int i = 0; i < 3; i++)
            {
                anime.attack11.Add(new Animation(tex, i, 1, @"Content/Hitboxes/Zy/Zy_attack11.txt"));
            }
            for (int i = 0; i < 4; i++)
            {
                anime.attack12.Add(new Animation(tex, i, 1, @"Content/Hitboxes/Zy/Zy_attack12.txt"));
            }
            for (int i = 0; i < 4; i++)
            {
                anime.attack13.Add(new Animation(tex, i, 1, @"Content/Hitboxes/Zy/Zy_attack13.txt"));
            }
            for (int i = 0; i < 5; i++)
            {
                anime.attack21.Add(new Animation(tex, i, 1, @"Content/Hitboxes/Zy/Zy_attack21.txt"));
            }
            for (int i = 0; i < 4; i++)
            {
                anime.attack22.Add(new Animation(tex, i, 1, @"Content/Hitboxes/Zy/Zy_attack22.txt"));
            }
            for (int i = 0; i < 6; i++)
            {
                anime.attack23.Add(new Animation(tex, i, 1, @"Content/Hitboxes/Zy/Zy_attack23.txt"));
            }
            for (int i = 0; i < 5; i++)
            {
                anime.attackA1.Add(new Animation(tex, i, 1, @"Content/Hitboxes/Zy/Zy_attackA1.txt"));
            }
            for (int i = 0; i < 6; i++)
            {
                anime.attackA2.Add(new Animation(tex, i, 1, @"Content/Hitboxes/Zy/Zy_attackA2.txt"));
            }
            for (int i = 0; i < 3; i++)
            {
                anime.attackA3.Add(new Animation(tex, i, 1, @"Content/Hitboxes/Zy/Zy_attackA3.txt"));
            }
            for (int i = 0; i < 1; i++)
            {
                anime.blockS.Add(new Animation(tex, i, 1, @"Content/Hitboxes/Zy/Zy_blockS.txt"));
            }
            for (int i = 0; i < 1; i++)
            {
                anime.blockA.Add(new Animation(tex, i, 1, @"Content/Hitboxes/Zy/Zy_blockA.txt"));
            }
            for (int i = 0; i < 8; i++)
            {
                anime.ult.Add(new Animation(tex, i, 1, @"Content/Hitboxes/Zy/Zy_ult.txt"));
            }
            for (int i = 0; i < 8; i++)
            {
                anime.death.Add(new Animation(tex, i, 1, @"Content/Hitboxes/Zy/Zy_death.txt"));
            }
        }
    }
}
