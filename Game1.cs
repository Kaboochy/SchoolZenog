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
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState oldKB;
        Rectangle sourceRect, destRect, backgroundSourceRect, backgroundDestRect;
        Texture2D zyText, backgroundText;
        bool right;
        int y, x, frames, backX;
        SoundEffect music;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 960;
            graphics.PreferredBackBufferHeight = 540;
            graphics.ApplyChanges();
            frames = 0;
            sourceRect = new Rectangle((int)x, y, 100, 100);
            destRect = new Rectangle(400, 400, 100, 100);
            backgroundSourceRect = new Rectangle(0, 0, 800, 450);
            backgroundDestRect = new Rectangle(0, 0, 960, 540);
            right = true;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            zyText = this.Content.Load<Texture2D>("ZySpritesheetForNow");
            backgroundText = this.Content.Load<Texture2D>("TestBackground");
            music = Content.Load<SoundEffect>("ThemeOfChunLi");
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            sourceRect.X = x;
            sourceRect.Y = y;
            backgroundSourceRect.X = (int)backX;
            frames++;
            KeyboardState kb = Keyboard.GetState();
            //AUDIO
            if (frames == 1)
                music.Play();
            //WALKING RIGHT
            if (kb.IsKeyDown(Keys.D) && !kb.IsKeyDown(Keys.A))
            {
                y = 310;
                /*
                if (right == false)
                    x = 10;
                    */
                right = true;
                if (frames % 7 == 0)
                {
                    x += 100;
                    if (x >= 610)
                    {
                        x = 10;
                    }
                }
                backX += 1;
            }
            //WALKING LEFT
            if (kb.IsKeyDown(Keys.A) && !kb.IsKeyDown(Keys.D))
            {
                 y = 310;
                /*
                 if (right)
                     x = 10;
                     */
                 right = false;
                 if (frames % 7 == 0)
                 {
                     x += 100;
                     if (x >= 610) //switch to < later cause images move left instead of right
                     {
                        x = 10;
                     }
                 }
                 backX -= 1;
             }
             //IDLE STANCE
             if ((right && !kb.IsKeyDown(Keys.D)) || (right == false && !kb.IsKeyDown(Keys.A)))
             {
                /*
                 if (right)
                 {
                 */
                     x = 10;
                     y = 110;
                 //}
             }
             oldKB = kb;
             base.Update(gameTime);   
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundText, backgroundDestRect, backgroundSourceRect, Color.White);
            spriteBatch.Draw(zyText, destRect, sourceRect, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
