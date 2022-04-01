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
        public Animations anime;
        public int stop, currentFrame;
        public Animated currentAnime;
        public bool right = true;
        
    }

    enum Animated
    {
        Enter,
        idle,
        walk,
        run,
        jump,
        fallingL,
        fallingH,
        fallingA,
        fallingS,
        recover,
        attack11,
        attack12,
        attack13,
        attack21,
        attack22,
        attack23,
        attackA1,
        attackA2,
        attackA3,
        blockS,
        blockA,
        ult,
        death
    }
}
