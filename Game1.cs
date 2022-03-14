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
        int y, frames;
        double x, zyX, zyY, backX;
        SoundEffect chunLi;
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
            x = 210;
            y = 30;
            frames = 0;
            zyX = 400;
            zyY = 400;
            backX = 400;
            sourceRect = new Rectangle((int)x, y, 40, 90);
            destRect = new Rectangle((int)zyX, (int)zyY, 150, 150);
            backgroundSourceRect = new Rectangle(0, 0, 800, 450);
            backgroundDestRect = new Rectangle(0, 0, 
                GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            right = true;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            zyText = this.Content.Load<Texture2D>("ZySpritesheetTemp");
            backgroundText = this.Content.Load<Texture2D>("TestBackground");
            chunLi = Content.Load<SoundEffect>("ThemeOfChunLi");
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            sourceRect.X = (int)x;
            sourceRect.Y = y;
            destRect.X = (int)zyX - 20;
            destRect.Y = (int)zyY;
            backgroundSourceRect.X = (int)backX;
            frames++;
            //timer--;
            //AUDIO
            if (frames == 1)
                chunLi.Play();
            KeyboardState kb = Keyboard.GetState();
            //WALKING RIGHT
            if (kb.IsKeyDown(Keys.D) && !kb.IsKeyDown(Keys.A))
            {
                zyText = this.Content.Load<Texture2D>("ZySpritesheetTemp");
                y = 240;
                if (right == false)
                    x = 270;
                right = true;
                if (frames % 7 == 0)
                {
                    x += 40;
                    if (x >= 860)
                    {
                        x = 270;
                    }
                }
                backX += .7;
            }
            //WALKING LEFT
            if (kb.IsKeyDown(Keys.A) && !kb.IsKeyDown(Keys.D))
            {
                 zyText = this.Content.Load<Texture2D>("ZySpritesheetTempLeft");
                 y = 140;
                 if (right)
                     x = 696;
                 right = false;
                 if (frames % 7 == 0)
                 {
                     x -= 62;
                     if (x <= 157)
                     {
                        x = 696;
                     }
                 }
                 backX -= .7;
             }
             //IDLE STANCE + CROUCHING + PUNCHING
             if ((right && !kb.IsKeyDown(Keys.D)) || (right == false && !kb.IsKeyDown(Keys.A)))
             {
                 if (right && !kb.IsKeyDown(Keys.E))
                 {
                     x = 5;
                     y = 130;
                 }
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
