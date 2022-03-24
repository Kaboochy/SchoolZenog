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

namespace SchoolZenog2
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState oldKB;
        MouseState oldmouse;
        Rectangle sourceRect, destRect, backgroundSourceRect, backgroundDestRect;
        Texture2D zyText, backgroundText;
        bool right;
        int y, x, frames, attackframes, combo;
        double backX;
        SoundEffect music;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.ApplyChanges();
            frames = 0;
            attackframes = 0;
            combo = 1;
            sourceRect = new Rectangle((int)x, y, 150, 150);
            destRect = new Rectangle(800, 750, 300, 300);
            backgroundSourceRect = new Rectangle(0, 0, 800, 450);
            backgroundDestRect = new Rectangle(0, 0, 1920, 1080);
            right = true;
            oldmouse = Mouse.GetState();
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            zyText = Content.Load<Texture2D>("ZySpritesheetFinalV4");
            backgroundText = Content.Load<Texture2D>("TestBackground");
            music = Content.Load<SoundEffect>("ThemeOfChunLi");
        }
        protected override void Update(GameTime gameTime)
        {
            sourceRect.X = x;
            sourceRect.Y = y;
            backgroundSourceRect.X = (int)backX;
            frames++;
            KeyboardState kb = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();
            //AUDIO
            if (frames == 1)
                music.Play();
            //Attack
            if (mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released && combo == 1)
            {
                x = 10;
                y = 1950;
                attackframes++;
                combo++;
            }
            if (attackframes == 0)
            {
                //RIGHT
                if (kb.IsKeyDown(Keys.D) && !kb.IsKeyDown(Keys.A))
                {
                    destRect.X = 800;
                    if (kb.IsKeyDown(Keys.LeftShift))
                    {
                        y = 460;
                        backX += 1.5;
                    }
                    else
                    {
                        y = 310;
                        backX += .7;
                    }
                    right = true;
                }
                //LEFT
                if (kb.IsKeyDown(Keys.A) && !kb.IsKeyDown(Keys.D))
                {
                    destRect.X = 710;
                    if (kb.IsKeyDown(Keys.LeftShift))
                    {
                        y = 460;
                        backX -= 1.5;
                    }
                    else
                    {
                        y = 310;
                        backX -= .7;
                    }
                    right = false;
                }
                //IDLE
                if ((!kb.IsKeyDown(Keys.D)) && (!kb.IsKeyDown(Keys.A)))
                {
                    y = 160;
                }
            }
            //ATTTACK LOGIC
            else
            {
                attackframes++;
            }
            if(attackframes > 30)
            {
                {
                    attackframes = 0;
                    combo = 1;
                }   
            }
            //ANIMATION
            if (frames % 7 == 0)
            {
                if (x >= 760)
                {
                    x = 10;
                }
                x += 150;
            }
            //END OF FRAME
            oldKB = kb;
            oldmouse = mouse;
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundText, backgroundDestRect, backgroundSourceRect, Color.White);
            if(right)
                spriteBatch.Draw(zyText, destRect, sourceRect, Color.White);
            else
                spriteBatch.Draw(zyText, destRect, sourceRect, Color.White, 0.0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0.0f);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}