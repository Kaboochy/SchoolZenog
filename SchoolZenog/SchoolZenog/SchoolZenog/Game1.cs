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
        KeyboardState oldKB, kb;
        MouseState oldmouse, mouse;
        Rectangle destRect, backgroundSourceRect, backgroundDestRect, rangerSourceRect, rangerDestRect, projectileSourceRect, projectileRect,
            zyGreen, rangerGreen, startRect, settingsRect, quitRect, mouseRect, volumeBar, volumeSlider, backRect;
        Texture2D zyText, backgroundText, rangerText, blackText, whiteText, art;
        bool fire, projectileTimerBool;
        int frames, projectileTimer, rangerHealth, zyHealth;
        double backX, rangerX, projectileX;
        string startText, zenogText, settingsText, quitText, volumeText, backText;
        SoundEffect music;
        Color rangerColor, zyColor, startColor, settingsColor, quitColor;
        Gamestate gameState;
        SpriteFont Font1, zenogFont, tinyFont;
        Zy zy;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            //graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            IsMouseVisible = true;
            graphics.ApplyChanges();
            //Zy
            destRect = new Rectangle(800, 750, 300, 300);
            zyGreen = new Rectangle(50, 50, 500, 50);
            zyColor = new Color(255, 255, 255);
            zyHealth = 1000;
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
            //Start screen
            startText = "START";
            settingsText = "OPTIONS";
            quitText = "QUIT";
            startRect = new Rectangle(790, 540, 320, 120);
            settingsRect = new Rectangle(790, 690, 320, 120);
            quitRect = new Rectangle(790, 840, 320, 120);
            zenogText = "Zenog";
            mouseRect = new Rectangle(10, 10, 10, 10);
            startColor = new Color(100, 100, 100, 1);
            settingsColor = new Color(100, 100, 100, 1);
            quitColor = new Color(100, 100, 100, 1);
            //SETTINGS
            volumeBar = new Rectangle(700, 700, 500, 20);
            volumeSlider = new Rectangle(710, 693, 35, 35);
            volumeText = "VOLUME";
            backRect = new Rectangle(50, 400, 320, 120);
            backText = "BACK";
            //Else
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
            Font1 = Content.Load<SpriteFont>("SpriteFont1");
            zenogFont = Content.Load<SpriteFont>("zenogFont");
            tinyFont = Content.Load<SpriteFont>("tinyFont");
            zy = new Zy(zyText);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            //GENERAL
            backgroundSourceRect.X = (int)backX;
            rangerDestRect.X = (int)rangerX;
            projectileRect.X = (int)projectileX;
            kb = Keyboard.GetState();
            mouse = Mouse.GetState();
            mouseRect.X = mouse.X;
            mouseRect.Y = mouse.Y;
            zyGreen.Width = zyHealth;
            //GAMESTATES
            //START SCREEN LOGIC
            if (gameState == Gamestate.start)
            {
                //START
                if (mouseRect.Intersects(startRect))
                    startColor = new Color(50, 50, 50, 1);
                else
                    startColor = new Color(100, 100, 100, 1);
                if (mouseRect.Intersects(startRect) && mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                    gameState = Gamestate.play;
                //SETTINGS
                if (mouseRect.Intersects(settingsRect))
                    settingsColor = new Color(50, 50, 50, 1);
                else
                    settingsColor = new Color(100, 100, 100, 1);
                if (mouseRect.Intersects(settingsRect) && mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                    gameState = Gamestate.settings;
                //QUIT
                if (mouseRect.Intersects(quitRect))
                    quitColor = new Color(50, 50, 50, 1);
                else
                    quitColor = new Color(100, 100, 100, 1);
                if (mouseRect.Intersects(quitRect) && mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                    Exit();
            }
            //SETTINGS LOGIC
            if (gameState == Gamestate.settings)
            {
                if (mouseRect.Intersects(backRect))
                    quitColor = new Color(50, 50, 50, 1);
                else
                    quitColor = new Color(100, 100, 100, 1);
                if (mouseRect.Intersects(backRect) && mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                    gameState = Gamestate.start;
            }
            //IN GAME LOGIC
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
                    }
                }
                //DEALING DAMAGE
                if (zy.Hit(destRect, rangerDestRect))
                {
                    rangerHealth -= 20;
                    rangerColor = Color.Red;
                }
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
                        projectileX -= 5;
                        List<Rectangle> hit = zy.Retrive(destRect);
                        for (int i = 0; i < hit.Count; i++)
                        {
                            if (projectileRect.Intersects(hit[1]) || projectileX < -30)
                            {
                                fire = false;
                                projectileX = rangerX + 30;
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
            //PLAYSTATE
            if (gameState == Gamestate.play)
            {
                spriteBatch.Draw(backgroundText, backgroundDestRect, backgroundSourceRect, Color.White);
                //HITBOX
                zy.DrawHitbox(spriteBatch, destRect, whiteText);

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
            //START SCREEN
            if (gameState == Gamestate.start)
            {
                //BACKGROUND
                spriteBatch.Draw(art, new Rectangle(0, 0, 1920, 1080), new Color(100, 100, 150, 1));
                //START BOX
                spriteBatch.Draw(whiteText, startRect, startColor);
                spriteBatch.DrawString(Font1, startText, new Vector2(855, 550), Color.Black);
                spriteBatch.Draw(blackText, startRect, Color.White);
                //SETTINGS BOX
                spriteBatch.Draw(whiteText, settingsRect, settingsColor);
                spriteBatch.DrawString(Font1, settingsText, new Vector2(810, 700), Color.Black);
                spriteBatch.Draw(blackText, settingsRect, Color.White);
                //QUIT BOX
                spriteBatch.Draw(whiteText, quitRect, quitColor);
                spriteBatch.DrawString(Font1, quitText, new Vector2(865, 850), Color.Black);
                spriteBatch.Draw(blackText, quitRect, Color.White);
                //LOGO
                spriteBatch.DrawString(zenogFont, zenogText, new Vector2(690, 80), Color.White);
            }
            //SETTINGS
            if (gameState == Gamestate.settings)
            {
                //BACKGROUND
                spriteBatch.Draw(art, new Rectangle(0, 0, 1920, 1080), new Color(100, 100, 150, 1));
                spriteBatch.Draw(whiteText, new Rectangle(400, 400, 1200, 500), startColor);
                //LOGO
                spriteBatch.DrawString(zenogFont, zenogText, new Vector2(690, 80), Color.White);
                //VOLUME BAR
                spriteBatch.DrawString(Font1, settingsText, new Vector2(810, 500), Color.White);
                spriteBatch.Draw(whiteText, volumeBar, Color.White);
                spriteBatch.Draw(whiteText, volumeSlider, Color.White);
                spriteBatch.DrawString(tinyFont, volumeText, new Vector2(540, 680), Color.White);
                //BACK
                spriteBatch.Draw(whiteText, backRect, quitColor);
                spriteBatch.Draw(blackText, backRect, Color.White);
                spriteBatch.DrawString(Font1, backText, new Vector2(100, 400), Color.Black);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
    enum Gamestate
    {
        start,
        settings,
        play,
        pause,
        cutscene,
        end
    }
}