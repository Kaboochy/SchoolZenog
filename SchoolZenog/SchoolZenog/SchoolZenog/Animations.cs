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
