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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState oldKB, kb;
        MouseState oldmouse, mouse;
        Rectangle destRect, backgroundSourceRect, backgroundDestRect, rangerSourceRect, rangerDestRect, projectileSourceRect, projectileRect, zyGreen, rangerGreen;
        Texture2D zyText, backgroundText, rangerText, blackText, whiteText, art;
        bool right, fire, projectileTimerBool;
        int frames, attackframes, combo, projectileTimer, rangerHealth, zyHealth;
        double backX, rangerX, projectileX;
        SoundEffect music;
        Color rangerColor, zyColor;
        Gamestate gameState;
        Zy zy;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            IsMouseVisible = true;
            graphics.ApplyChanges();
            //Zy
            destRect = new Rectangle(800, 750, 300, 300);
            zyGreen = new Rectangle(50, 50, 500, 50);
            zyColor = new Color(255, 255, 255);
            zyHealth = 1000;
            right = true;
            attackframes = 0;
            combo = 1;
            //Bachground
            backgroundSourceRect = new Rectangle(0, 0, 800, 450);
            backgroundDestRect = new Rectangle(0, 0, 1920, 1080);
            //ranger
            rangerSourceRect = new Rectangle(0, 0, 50, 50);
            rangerDestRect = new Rectangle((int)rangerX, 820, 200, 200);
            rangerGreen = new Rectangle(50, 50, 500, 15);
            rangerColor = new Color(255, 255, 255);
            rangerX = 2000;
            rangerHealth = 100;
            fire = false;
            //projectile
            projectileSourceRect = new Rectangle(0, 200, 50, 50);
            projectileRect = new Rectangle((int)projectileX, 870, 120, 120);
            projectileX = 2000;
            projectileTimer = 0;
            projectileTimerBool = false;
            //ELSE
            frames = 0;
            oldmouse = Mouse.GetState();
            gameState = Gamestate.start;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            zyText = Content.Load<Texture2D>("Zy_Sprite");
            rangerText = Content.Load<Texture2D>("Ranger_Sprite");
            backgroundText = Content.Load<Texture2D>("TestBackground");
            blackText = Content.Load<Texture2D>("Rectangle");
            whiteText = Content.Load<Texture2D>("White_Square");
            art = Content.Load<Texture2D>("Start_Screen");
            music = Content.Load<SoundEffect>("ThemeOfChunLi");

            zy = new Zy(zyText);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            backgroundSourceRect.X = (int)backX;
            rangerDestRect.X = (int)rangerX;
            projectileRect.X = (int)projectileX;
            kb = Keyboard.GetState();
            mouse = Mouse.GetState();
            //GAMESTATES
            if (kb.IsKeyDown(Keys.Enter) && !oldKB.IsKeyDown(Keys.Enter) && gameState == Gamestate.start)
            {
                gameState = Gamestate.play;
            }
            if (gameState == Gamestate.play)
            {
                frames++;
                if (frames % 30 == 0)
                    zyColor = Color.White;
                //AUDIO
                if (frames == 1)
                    music.Play();
                //MOVEMENT
                if (frames % 7 == 0)
                    zy.Update(kb, mouse);
                if (zy.stop != 1)
                {
                    //RIGHT
                    if (kb.IsKeyDown(Keys.D) && !kb.IsKeyDown(Keys.A))
                    {
                        destRect.X = 800;
                        if (kb.IsKeyDown(Keys.LeftShift))
                        {
                            backX += 1.5;
                            rangerX -= 3.55;
                            projectileX -= 3.55;
                        }
                        else
                        {
                            backX += .7;
                            rangerX -= 1.65;
                            projectileX -= 1.65;
                        }
                        right = true;
                    }
                    //LEFT
                    if (kb.IsKeyDown(Keys.A) && !kb.IsKeyDown(Keys.D))
                    {
                        destRect.X = 710;
                        if (kb.IsKeyDown(Keys.LeftShift))
                        {
                            backX -= 1.5;
                            rangerX += 3.55;
                            projectileX += 3.55;
                        }
                        else
                        {
                            backX -= .7;
                            rangerX += 1.65;
                            projectileX += 1.65;
                        }
                        right = false;
                    }
                }
                //Damage
                else
                {
                    attackframes++;
                    if (!right)
                        if (zy.Hit(destRect, rangerDestRect) && attackframes > 17)
                        {
                            rangerHealth -= 20;
                            rangerColor = Color.Red;
                        }
                }
                if (attackframes > 30)
                {
                    {
                        attackframes = 0;
                        combo = 1;
                        rangerColor = Color.White;
                    }
                }
                //ZY HEALTH
                zyGreen.Width = zyHealth;
                //RANGER
                if (rangerHealth > 0)
                {
                    //RANGER HEALTHBAR
                    rangerGreen.Width = rangerHealth;
                    rangerGreen.X = rangerDestRect.X + 40;
                    rangerGreen.Y = rangerDestRect.Y + 15;
                    //RANGER POSITION
                    if (rangerX < 1500)
                    {
                        rangerSourceRect.X = 50;
                        if ((projectileTimer % 300 == 0) || projectileTimer == 0)
                        {
                            fire = true;
                            projectileTimerBool = true;
                        }
                    }
                    //RANGER SHOOTING
                    if (fire)
                    {
                        projectileX--;
                        List<Rectangle> hit = zy.Retrive(destRect);
                        for (int i = 0; i < hit.Count; i++)
                        {
                            if (projectileRect.Intersects(hit[1]))
                            {
                                fire = false;
                                projectileX = rangerX + 30;
                                if (attackframes < 3)
                                {
                                    zyColor = Color.Red;
                                    zyHealth -= 100;
                                }
                                else
                                    zyColor = Color.White;
                            }
                        }
                    }

                    //TIMER
                    if (projectileTimerBool)
                    {
                        projectileTimer++;
                    }
                }
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
            if (gameState == Gamestate.play)
            {
                spriteBatch.Draw(backgroundText, backgroundDestRect, backgroundSourceRect, Color.White);
                //HITBOX
                {
                    List<Rectangle> hit = zy.Retrive(destRect);
                    for (int i = 0; i < hit.Count; i++)
                    {
                        spriteBatch.Draw(whiteText, hit[i], new Color(70, 0, 0, -100));
                    }
                }
                //ranger ENEMY
                if (rangerHealth > 0)
                {
                    spriteBatch.Draw(rangerText, rangerDestRect, rangerSourceRect, rangerColor);
                    spriteBatch.Draw(whiteText, rangerGreen, Color.LimeGreen);
                }
                //ZY
                zy.Draw(spriteBatch, destRect, zyColor);
                //PROJECTILE
                if (rangerHealth > 0)
                    spriteBatch.Draw(rangerText, projectileRect, projectileSourceRect, Color.White);
                //HUD
                spriteBatch.Draw(whiteText, zyGreen, Color.LimeGreen);
            }
            if (gameState == Gamestate.start)
            {
                spriteBatch.Draw(art, new Rectangle(0, 0, 1920, 1080), Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
    enum Gamestate
    {
        start,
        play,
        end
    }
}
