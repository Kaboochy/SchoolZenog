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
        Rectangle destRect, backgroundSourceRect, backgroundDestRect,
            startRect, settingsRect, quitRect, mouseRect,
            volumeBar, volumeSlider, backRect, skipRect, bubbleRect, cutsceneTextRect, zyGreenRect, zyBlueRect;
        Texture2D zyText, backgroundText, blackText, whiteText, art, cutscene1, cutscene2, bubbleText,
            hudText, zyGreenText, zyBlueText, hudGray, zyGreenRText, logo, keybo;
        bool paused, settings;
        int frames, zyHealth, zyShield, introTimer, r, g, b, d, scriptNum,
            enemiesDefeated, score, endScreenBrightness, quitTimer, move;
        double backX, x;
        string startText, zenogText, settingsText, quitText, volumeText, backText,
            skipText, introText, scriptText, cutsceneText, enemiesDefeatedText, scoreText,
            timeText, finalScript, finalText;
        float volume, a;
        Vector2 introTextVect;
        Color zyColor, startColor, settingsColor, quitColor, introTextColor,
            cutsceneColor, cutsceneTextColor, nextColor, endScreenColor;
        Gamestate gameState, oldState;
        SpriteFont Font1, zenogFont, tinyFont;
        Song homeMusic, introMusic, gameMusic, a21, a22, a23, d1, d2, d3, runSound, walkingSound;
        Zy zy;
        //JACOB
        //ENEMIES
        EnemyList enemies;
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
            zyColor = new Color(255, 255, 255);
            zyHealth = 1920;
            zyShield = 1920;
            bubbleRect = new Rectangle(780, 780, 225, 300);
            //Bachground
            backgroundSourceRect = new Rectangle(200, 110, 1920, 1080);
            backgroundDestRect = new Rectangle(0, 0, 1920, 1080);
            //HUD
            zyGreenRect = new Rectangle(260, 0, 1920, 1080);
            zyBlueRect = new Rectangle(247, 0, 1920, 1080);
            enemiesDefeated = 1;
            enemiesDefeatedText = "Takedowns: " + enemiesDefeated;
            score = 0;
            scoreText = "Score: " + score;
            timeText = "" + frames % 60;
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
            settings = false;
            volumeBar = new Rectangle(700, 700, 500, 20);
            volumeSlider = new Rectangle(800, 693, 35, 35);
            volumeText = "MUSIC";
            backRect = new Rectangle(50, 400, 320, 120);
            backText = "BACK";
            volume = .3f;
            paused = false;
            //INTRO
            skipRect = new Rectangle(1720, 880, 200, 200);
            skipText = "SKIP";
            introText = "In the year 2436";
            introTextColor = new Color(r, r, r);
            r = 0;
            introTimer = 0;
            b = 0;
            introTextVect = new Vector2(600, 500);
            //CUTSCENES
            scriptNum = 1;
            cutsceneText = "";
            finalText = "";
            g = 0;
            d = 0;
            a = 1f;
            cutsceneTextColor = new Color(new Vector4(a, a, a, a));
            cutsceneTextRect = new Rectangle(0, 780, 1920, 300);
            cutsceneColor = new Color(d, d, d);
            nextColor = Color.Gray;
            //Else
            frames = 0;
            endScreenBrightness = 0;
            finalScript = "";
            quitTimer = 0;
            endScreenColor = new Color(0, 0, 0, endScreenBrightness);
            oldmouse = Mouse.GetState();
            gameState = Gamestate.home;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //IMAGES
            spriteBatch = new SpriteBatch(GraphicsDevice);
            zyText = Content.Load<Texture2D>("Zy_Sprite");
            backgroundText = Content.Load<Texture2D>("finalBackground2"); //USED TO BE --> ("TestBackground");
            blackText = Content.Load<Texture2D>("Rectangle");
            whiteText = Content.Load<Texture2D>("White_Square");
            art = Content.Load<Texture2D>("Start_Screen");
            cutscene1 = Content.Load<Texture2D>("zenogCutscene2");
            cutscene2 = Content.Load<Texture2D>("zenogCutscene1");
            bubbleText = Content.Load<Texture2D>("Bubble");
            zyBlueText = Content.Load<Texture2D>("zenogHudB");
            zyGreenText = Content.Load<Texture2D>("zenogHudHLarge");
            zyGreenRText = Content.Load<Texture2D>("zenogHudHSmall");
            hudGray = Content.Load<Texture2D>("zenogHudG");
            hudText = Content.Load<Texture2D>("zenogHud");
            logo = Content.Load<Texture2D>("logo");
            keybo = Content.Load<Texture2D>("keyboard");

            //MUSIC
            homeMusic = Content.Load<Song>("PaintTheTownBlack"); //OLD ("Sarabande_Full_Mix"); 
            introMusic = Content.Load<Song>("Odd_Exploitation_Synth_Stem"); //OLD ("Odd_Exploitation_Synth_Stem");
            gameMusic = Content.Load<Song>("BackAlleyBusiness"); //OLD ("Odd_Exploitation_Full_Mix");
            MediaPlayer.Play(homeMusic);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = volume;

            //SOUND EFFECTS
            a21 = Content.Load<Song>("ZyAttack21");
            a22 = Content.Load<Song>("ZyAttack22");
            a23 = Content.Load<Song>("ZyAttack23");
            d1 = Content.Load<Song>("ZyDamage1");
            d2 = Content.Load<Song>("ZyDamage2");
            d3 = Content.Load<Song>("ZyDamage3");
            runSound = Content.Load<Song>("ZyRunning");
            walkingSound = Content.Load<Song>("ZyWalking");

            //FONTS
            Font1 = Content.Load<SpriteFont>("SpriteFont1");
            zenogFont = Content.Load<SpriteFont>("zenogFont");
            tinyFont = Content.Load<SpriteFont>("tinyFont");

            //ELSE
            zy = new Zy(zyText);

            //JACOB
            //ENEMIES
            Ranger.SetRTex(Content.Load<Texture2D>("Ranger_Sprite"), whiteText);
            enemies = new EnemyList(Content.Load<Texture2D>("Ranger_Sprite"));
            enemies.load();
        }
        /* //UNLOAD CONTENT WAS NEVER USED AND I AM NOT STARTING NOW
        protected override void UnloadContent()
        {
        }
        */
        protected override void Update(GameTime gameTime)
        {
            //GENERAL
            IsMouseVisible = true;
            backgroundSourceRect.X = (int)backX;
            kb = Keyboard.GetState();
            mouse = Mouse.GetState();
            mouseRect.X = mouse.X;
            mouseRect.Y = mouse.Y;
            zyGreenRect.Width = zyHealth;
            zyBlueRect.Width = zyShield;
            //GAMESTATES
            if (gameState == Gamestate.cutscene && introTimer == 1)
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(introMusic);
            }
            if (gameState == Gamestate.play && (oldState == Gamestate.home || oldState == Gamestate.loading))
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(gameMusic);
            }
            if (gameState == Gamestate.home && oldState == Gamestate.play)
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(homeMusic);
            }
            oldState = gameState;
            //START SCREEN LOGIC
            if (gameState == Gamestate.home && settings == false)
            {
                //START
                startText = "START";
                if (mouseRect.Intersects(startRect))
                    startColor = new Color(50, 50, 50, 1);
                else
                    startColor = new Color(100, 100, 100, 1);
                if (mouseRect.Intersects(startRect) && mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    gameState = Gamestate.play; //CHANGE THIS TO CUTSCENE LATER BUT THIS IS JUST FOR TESTING AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH
                }
                //SETTINGS
                if (mouseRect.Intersects(settingsRect))
                    settingsColor = new Color(50, 50, 50, 1);
                else
                    settingsColor = new Color(100, 100, 100, 1);
                if (mouseRect.Intersects(settingsRect) && mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    settings = true;
                }
                //QUIT
                if (mouseRect.Intersects(quitRect))
                    quitColor = new Color(50, 50, 50, 1);
                else
                    quitColor = new Color(100, 100, 100, 1);
                if (mouseRect.Intersects(quitRect) && mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                    Exit();
            }
            //SETTINGS LOGIC
            if (settings)
            {
                //BACK
                if (mouseRect.Intersects(backRect))
                    quitColor = new Color(50, 50, 50, 1);
                else
                    quitColor = new Color(100, 100, 100, 1);
                if (mouseRect.Intersects(backRect) && mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                {
                    settings = false;
                }
                //SLIDER
                if (volumeSlider.X > 1200)
                    volumeSlider.X = 1180;
                if (volumeSlider.X < 700)
                    volumeSlider.X = 720;
                if ((mouseRect.Intersects(volumeSlider) && mouse.LeftButton == ButtonState.Pressed) || (mouseRect.Intersects(volumeBar) && mouse.LeftButton == ButtonState.Pressed))
                {
                    if (volumeSlider.X < 1200 && volumeSlider.X > 700)
                        volumeSlider.X = mouse.X - 10;
                }
                if ((mouseRect.Intersects(volumeBar) && mouse.LeftButton == ButtonState.Pressed) && (volumeSlider.X > 700 && volumeSlider.X < 1200))
                    volumeSlider.X = mouse.X - 10;
                //MUSIC VOLUME
                volume = (float)((volumeSlider.X - 700) / 500.0);
                MediaPlayer.Volume = volume;
            }
            //CUTSCENE LOGIC
            if (gameState == Gamestate.cutscene)
            {
                if ((mouseRect.Intersects(skipRect) && mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released && b == 0) || (introTimer > 1200 && b == 0))
                {
                    b = 1;
                    introTimer = 2000;
                }
                introTimer++;
                //STORY BACKGROUND INFORMATION LOGIC
                if (b == 0)
                {
                    if (introTimer > 60 && introTimer < 200 && r < 250)
                    {
                        r += 2;
                        introTextColor = new Color(r, r, r);
                    }
                    if (introTimer > 210 && introTimer < 285 && r > 0)
                    {
                        r -= 5;
                        introTextColor = new Color(r, r, r);
                    }
                    if (introTimer > 300 && introTimer < 600 && r < 250)
                    {
                        r += 2;
                        introTextColor = new Color(r, r, r);
                        introTextVect = new Vector2(200, 450);
                        introText = "Over 99 percent of Earth was wiped out \n       from a large-scale war";
                    }
                    if (introTimer > 600 && introTimer < 675 && r > 0)
                    {
                        r -= 5;
                        introTextColor = new Color(r, r, r);
                    }
                    if (introTimer > 700 && introTimer < 1100 && r < 250)
                    {
                        r += 2;
                        introTextColor = new Color(r, r, r);
                        introTextVect = new Vector2(100, 450);
                        introText = "   Silence stood for the next 200 years \n            until THEY appeared";
                    }
                    if (introTimer > 1110 && introTimer < 1175 && r > 0)
                    {
                        r -= 5;
                        introTextColor = new Color(r, r, r);
                    }
                }
                //ACTUAL CUTSCENES LOGIC
                if (b > 0)
                {
                    if (b == 1 && scriptNum == 1)
                        scriptText = " Zy: Have any enemies reached the walls yet?";
                    if (b == 2 && scriptNum == 1)
                        scriptText = " Nomi: Now we just have to wait and \n       take them down as they come out";
                    //TRANSITION LOGIC
                    if (g == scriptText.Length)
                        nextColor = Color.White;
                    else if (scriptNum == 7 || scriptNum == 13)
                        nextColor = new Color(0, 0, 0, 0);
                    else
                        nextColor = Color.Gray;
                    if (introTimer > 2100 && d < 255 && introTimer < 2400)
                    {
                        a = 1f;
                        cutsceneTextColor = new Color(new Vector4(a, a, a, a));
                        d += 2;
                        cutsceneColor = new Color(d, d, d);
                    }
                    if (introTimer > 2300 && frames % 120 == 0 && g < scriptText.Length && scriptNum == 1)
                    {
                        cutsceneText = cutsceneText + char.ToString(scriptText[g]);
                        g++;
                        r = 255;
                        skipRect = new Rectangle(1600, 800, 100, 50);
                        skipText = "NEXT";
                    }
                    if (g == scriptText.Length && mouseRect.Intersects(skipRect) && mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released && a > .5f && scriptNum < 14)
                    {
                        scriptNum++;
                        g = 0;
                        cutsceneText = "";
                    }
                    if (scriptNum % 2 == 0 && scriptNum < 14)
                    {
                        a -= .05f;
                        cutsceneTextColor = new Color(new Vector4(a, a, a, a));
                        if (a < .05f)
                            scriptNum++;
                    }
                    if (scriptNum > 2 && scriptNum % 2 != 0 && scriptNum < 13)
                    {
                        a = 1f;
                        cutsceneTextColor = new Color(new Vector4(a, a, a, a));
                        if (g < scriptText.Length && scriptNum != 7 && b == 1)
                        {
                            cutsceneText = cutsceneText + char.ToString(scriptText[g]);
                            g++;
                        }
                        if (g < scriptText.Length && b == 2)
                        {
                            cutsceneText = cutsceneText + char.ToString(scriptText[g]);
                            g++;
                        }
                    }
                    if (b == 1)
                    {
                        if (scriptNum == 3)
                            scriptText = " Nomi: Ryan said that they have not left \n       the portal yet so we are ahead of schedule";
                        if (scriptNum == 5)
                            scriptText = " Zy: Race you there!";
                        if (scriptNum == 7)
                        {
                            d -= 2;
                            cutsceneColor = new Color(d, d, d);
                            if (d <= 0)
                                scriptNum = 8;
                        }
                        if (scriptNum == 8)
                        {
                            b = 2;
                            introTimer = 2000;
                            scriptNum = 1;
                            g = 0;
                        }
                    }
                    if (b == 2)
                    {
                        if (scriptNum == 3)
                            scriptText = " Zy: Or we can go in there and stop them \n     before they even get the chance to touch grass";
                        if (scriptNum == 5)
                            scriptText = " Nomi: No human has ever entered a portal before...";
                        if (scriptNum == 7)
                            scriptText = " Zy: Then we will be the first";
                        if (scriptNum == 9)
                            scriptText = " (Zy begins to run towards the portal)";
                        if (scriptNum == 11)
                            scriptText = " Nomi: Those aren't the orders!";
                        if (scriptNum == 13)
                        {
                            d -= 2;
                            cutsceneColor = new Color(d, d, d);
                            if (d <= 0)
                                scriptNum = 14;
                        }
                        if (scriptNum == 14)
                        {
                            gameState = Gamestate.loading;
                            introText = "LOADING";
                            introTimer = 5000;
                            scriptNum = 1;
                        }
                    }
                }
            }
            //LOADING LOGIC
            if (gameState == Gamestate.loading)
            {
                introTextColor = Color.White;
                introTextVect = new Vector2(50, 950);
                if (introTimer == 5000)
                    introText = "LOADING";
                introTimer++;
                if (introTimer == 5030 || introTimer == 5150)
                    introText = "LOADING.";
                if (introTimer == 5060 || introTimer == 5180)
                    introText = "LOADING..";
                if (introTimer == 5090 || introTimer == 5210)
                    introText = "LOADING...";
                if (introTimer == 5120)
                    introText = "LOADING";
                if (introTimer > 5230)
                {
                    gameState = Gamestate.play;
                    introTimer = 1;
                }
            }
            //IN GAME LOGIC
            if (gameState == Gamestate.play)
            {
                //PAUSED GAME
                if (kb.IsKeyDown(Keys.Escape) && oldKB.IsKeyUp(Keys.Escape))
                {
                    if (settings == false)
                    {
                        if (!paused)
                            paused = true;
                        else
                            paused = false;
                    }
                    if (settings)
                    {
                        settings = false;
                    }
                }
                if (paused && settings == false)
                {
                    //RESUME
                    startText = "RESUME";
                    if (mouseRect.Intersects(startRect))
                        startColor = new Color(50, 50, 50, 1);
                    else
                        startColor = new Color(100, 100, 100, 1);
                    if (mouseRect.Intersects(startRect) && mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                    {
                        paused = false;
                    }
                    //SETTINGS
                    if (mouseRect.Intersects(settingsRect))
                        settingsColor = new Color(50, 50, 50, 1);
                    else
                        settingsColor = new Color(100, 100, 100, 1);
                    if (mouseRect.Intersects(settingsRect) && mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                    {
                        settings = true;
                    }
                    //QUIT
                    if (mouseRect.Intersects(quitRect))
                        quitColor = new Color(50, 50, 50, 1);
                    else
                        quitColor = new Color(100, 100, 100, 1);
                    if (mouseRect.Intersects(quitRect) && mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                        gameState = Gamestate.home;
                }
                //NOT PAUSED GAME
                if (!paused)
                {
                    frames++;
                    //ENEMIES LOADING IN
                    if(frames%240==0)
                    {
                        enemies.load();
                    }
                    //IsMouseVisible = false; //DOESNT WORK WITH GREATER THAN 60 FPS
                    //STOP 0 = Movement and idle
                    //STOP 1 = Attacking
                    //STOP 2 = Jumping
                    //move
                    if (zy.currentAnime == Animated.run)
                        move = 2;
                    if (zy.currentAnime == Animated.walk)
                        move = 1;
                    if (zy.currentAnime == Animated.idle)
                        move = 0;
                    if (!zy.right)
                        move *= -1;
                    //FALLING LOGIC
                    if (zy.stop == 4 && destRect.Y < 750)
                    {
                        x -= 1;
                        destRect.Y -= (int)(-1 * Math.Pow(.175 * x, 2) + 5);
                        if (destRect.Y > 750)
                            destRect.Y = 750;
                    }
                    if (zy.stop != 1 && zy.stop != 3 && zy.stop != 6 && zy.stop != 4 && zy.stop != 10)
                    {
                        //RIGHT
                        if (kb.IsKeyDown(Keys.D) && !kb.IsKeyDown(Keys.A))
                        {
                            if (backX >= 1280)
                                backX = 0;
                            destRect.X = 800;
                            if (kb.IsKeyDown(Keys.LeftShift))
                            {
                                backX += 10; //old 5
                            }
                            else
                            {
                                backX += 4; //old 2
                            }
                        }
                        //LEFT
                        if (kb.IsKeyDown(Keys.A) && !kb.IsKeyDown(Keys.D))
                        {
                            if (backX <= 10)
                                backX = 1290;
                            destRect.X = 710;
                            if (kb.IsKeyDown(Keys.LeftShift))
                            {
                                backX -= 10;
                            }
                            else
                            {
                                backX -= 4;
                            }
                        }
                        //JUMPING
                        if (zy.stop == 2)
                        {
                            x += 1;
                            destRect.Y -= (int)(-1 * Math.Pow(.175 * x, 2) + 20);
                            if (destRect.Y > 750)
                                destRect.Y = 750;
                        }
                        else
                            x = 0;
                    }
                    //COMBO LOGIC
                    if (mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released && zy.stop == 1)
                    {
                        if (zy.combo == 0 && zy.lastAnime.Equals(Animated.attack21))
                            zy.combo = 1;
                        else if (zy.combo == 1 && zy.lastAnime.Equals(Animated.attack22))
                            zy.combo = 2;
                    }
                    //SHIELDING LOGIC
                    if (zyShield > 150)
                        zy.shield = true;
                    if (zy.currentAnime.Equals(Animated.blockS) && zyShield > 0)
                    {
                        zyShield -= 20;
                        //blueX +=3;
                    }
                    if (!zy.currentAnime.Equals(Animated.blockS) && zyShield < 1920)
                    {
                        zyShield += 2;
                        //blueX -= (int).3;
                    }
                    if (zyShield <= 0)
                        zy.shield = false;
                    //ULTIMATE
                    if (zyShield >= 1920)
                        zy.ult = true;
                    else
                        zy.ult = false;
                    if (zy.currentAnime.Equals(Animated.ult))
                        zyShield = 0;
                    //GAME ENDING
                    if (zyHealth <= 0)
                    {
                        zy.faint = true;
                    }
                    else
                    {
                        //HUD UPDATES
                        timeText = "" + frames / 60;
                        score = (enemies.numberKilled*25)+((frames/60)*2);
                        scoreText = "Score: " + score;
                    }
                    //DEALING DAMAGE
                    int i = enemies.attack(zy.Retrive(destRect));
                    if (i < 0)
                    {
                        zy.right = false;
                        zy.stop = 4;
                        zyHealth -= 600;
                    }
                    if (i > 0)
                    {
                        zy.right = true;
                        zy.stop = 4;
                        zyHealth -= 600;
                    }
                //GAMEOVER GAMESTATE
                }
                if (zy.stop == 10 && gameState != Gamestate.end)
                {
                    volume -= (float).001;
                    MediaPlayer.Volume = volume;
                    endScreenBrightness++;
                    endScreenColor = new Color(0, 0, 0, endScreenBrightness);
                    if (endScreenBrightness > 300)
                    {
                        zy.stop = 0;
                        gameState = Gamestate.end;
                    }

                }
                //UPDATE STUFF
                if (frames % 7 == 0 && paused == false)
                {
                    zy.Update(kb, mouse, destRect);
                    enemies.Update(destRect, move);
                    //ACTUAL DAMAGE FRAME LOGIC
                    if (zy.stop == 1)
                    {
                        if (zy.combo == 0 && zy.currentFrame == 2)
                        {
                            enemies.attacked(zy.Retrive(destRect), 30);
                        }
                        if (zy.combo == 1 && zy.currentFrame == 1)
                        {
                            enemies.attacked(zy.Retrive(destRect), 70);
                        }
                        if (zy.combo == 2 && zy.currentFrame == 2)
                        {
                            enemies.attacked(zy.Retrive(destRect), 100);
                        }
                    }
                    if(zy.stop == 5 && zy.currentFrame == 6)
                    {
                        enemies.attacked(zy.Retrive(destRect), 100);
                    }
                }
            }
            //GAME OVER LOGIC
            if (gameState == Gamestate.end)
            {
                quitTimer++;
                if (quitTimer % 300 == 0 && quitTimer < 1900)
                    g = 0;
                if (quitTimer < 10)
                {
                    finalScript = " Zy woke up outside the portal with Nomi kneeling by his side\n";
                    g = 0;
                }
                if (quitTimer > 100 && quitTimer % 2 == 0 && g < finalScript.Length && quitTimer < 2000)
                {
                    finalText = finalText + char.ToString(finalScript[g]);
                    g++;
                }
                if (quitTimer > 300)
                    finalScript = " She told him that he was carried out by another cloaked man\n";
                if (quitTimer > 600)
                    finalScript = " The man told her before he left that they should not be fighting\n";
                if (quitTimer > 900)
                    finalScript = " He told her that the enemy was not THEY that appeared\n";
                if (quitTimer > 1200)
                    finalScript = " Rather the enemy is those who locked them away for 200 years\n";
                if (quitTimer > 1500)
                    finalScript = " The enemy is within\n\n\n";
                if (quitTimer > 1800)
                    finalScript = " Mission Stats\n Clock: " + timeText + " seconds\n" + " " + scoreText;
                if (quitTimer > 2000)
                {
                    if (mouseRect.Intersects(quitRect))
                        quitColor = new Color(50, 50, 50, 1);
                    else
                        quitColor = new Color(100, 100, 100, 1);
                    if (mouseRect.Intersects(quitRect) && mouse.LeftButton == ButtonState.Pressed && oldmouse.LeftButton == ButtonState.Released)
                    {
                        Exit(); //CHANGE TO --> gameState = Gamestate.home; <-- if you want to return to menu instead of close game
                    }
                }
                else
                {
                    quitColor = new Color(0, 0, 0, 0);
                }

            }
            //JACOB
            //H THINGY
            if (kb.IsKeyDown(Keys.H) && oldKB.IsKeyUp(Keys.H))
            {
                if (graphics.PreferredBackBufferWidth == 500)
                {
                    graphics.PreferredBackBufferWidth = 1920;
                    graphics.PreferredBackBufferHeight = 1080;
                    graphics.ApplyChanges();
                }
                else
                {
                    graphics.PreferredBackBufferWidth = 500;
                    graphics.PreferredBackBufferHeight = 500;
                    graphics.ApplyChanges();
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
            //PLAYING
            if (gameState == Gamestate.play)
            {
                //BACKGROUND
                spriteBatch.Draw(backgroundText, backgroundDestRect, backgroundSourceRect, Color.White);
                //HITBOX
                //zy.DrawHitbox(spriteBatch, destRect, whiteText);
                //ZY
                enemies.Draw(spriteBatch);
                zy.Draw(spriteBatch, destRect, zyColor);
                //SHIELD
                if (zy.currentAnime.Equals(Animated.blockS) || zy.stop == 10)
                {
                    spriteBatch.Draw(bubbleText, bubbleRect, new Color(0, 0, 0, 155));
                    if (zy.stop == 10)
                    {
                        bubbleRect.Y = 820;
                    }

                }
                //JACOB
                //ENEMIES
                //enemies.Draw(spriteBatch);
                //HUD
                spriteBatch.Draw(zyGreenRText, new Rectangle(221, 0, 1920, 1080), new Rectangle(221, 0, 1920, 1080), Color.White);
                spriteBatch.Draw(zyGreenText, zyGreenRect, new Rectangle(260, 0, 1920, 1080), Color.White);
                spriteBatch.Draw(zyBlueText, zyBlueRect, new Rectangle(247, 0, 1920, 1080), Color.White);
                spriteBatch.Draw(hudGray, new Rectangle(0, 0, 1920, 1080), Color.White);
                spriteBatch.Draw(hudText, new Rectangle(0, 0, 1920, 1080), Color.White);
                spriteBatch.DrawString(tinyFont, "Takedowns: " + enemies.numberKilled, new Vector2(1500, 50), Color.Black);
                spriteBatch.DrawString(tinyFont, scoreText, new Vector2(1555, 150), Color.Black);
                spriteBatch.DrawString(Font1, timeText, new Vector2(1300, 50), Color.Black);
                //GAME OVER DARKNESS
                if (zy.stop == 10)
                {
                    spriteBatch.Draw(whiteText, new Rectangle(0, 0, 1920, 1080), endScreenColor);
                }
                //PAUSED
                if (paused)
                {
                    spriteBatch.Draw(whiteText, new Rectangle(0, 0, 1920, 1080), new Color(0, 0, 0, 155));
                }
                if (settings == false && paused)
                {
                    //START BOX
                    spriteBatch.Draw(whiteText, startRect, startColor);
                    spriteBatch.DrawString(Font1, startText, new Vector2(830, 550), Color.Black);
                    spriteBatch.Draw(blackText, startRect, Color.White);
                    //SETTINGS BOX
                    spriteBatch.Draw(whiteText, settingsRect, settingsColor);
                    spriteBatch.DrawString(Font1, settingsText, new Vector2(810, 700), Color.Black);
                    spriteBatch.Draw(blackText, settingsRect, Color.White);
                    //QUIT BOX
                    spriteBatch.Draw(whiteText, quitRect, quitColor);
                    spriteBatch.DrawString(Font1, quitText, new Vector2(865, 850), Color.Black);
                    spriteBatch.Draw(blackText, quitRect, Color.White);
                }
            }
            //START SCREEN
            if (gameState == Gamestate.home && !settings)
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
                //spriteBatch.DrawString(zenogFont, zenogText, new Vector2(690, 80), Color.White);
                spriteBatch.Draw(logo, new Rectangle(690, 10, 500, 500), Color.White);
            }
            //SETTINGS
            if (settings)
            {
                if (gameState == Gamestate.home)
                {
                    //BACKGROUND
                    spriteBatch.Draw(art, new Rectangle(0, 0, 1920, 1080), new Color(100, 100, 150, 1));
                    spriteBatch.Draw(whiteText, new Rectangle(400, 400, 1200, 500), startColor);
                    //LOGO
                    spriteBatch.Draw(logo, new Rectangle(690, 10, 500, 500), Color.White);
                }
                if(gameState == Gamestate.play)
                {
                    //KEYBINDS
                    spriteBatch.Draw(keybo, new Rectangle(1250, 500, 585,368), Color.White);
                }
                //VOLUME BAR
                spriteBatch.DrawString(Font1, settingsText, new Vector2(810, 500), Color.White);
                spriteBatch.Draw(whiteText, volumeBar, Color.White);
                spriteBatch.Draw(whiteText, volumeSlider, Color.White);
                spriteBatch.DrawString(tinyFont, volumeText, new Vector2(540, 680), Color.White);
                //BACK
                spriteBatch.Draw(whiteText, backRect, quitColor);
                spriteBatch.Draw(blackText, backRect, Color.White);
                spriteBatch.DrawString(Font1, backText, new Vector2(110, 410), Color.Black);
            }
            //CUTSCENE
            if (gameState == Gamestate.cutscene)
            {
                //FIRST PART
                if (b == 0)
                {
                    spriteBatch.DrawString(tinyFont, skipText, new Vector2(1750, 960), Color.Gray);
                    spriteBatch.DrawString(Font1, introText, introTextVect, introTextColor);
                }
                //SECOND PART
                if (b > 0)
                {
                    if (b == 1)
                        spriteBatch.Draw(cutscene1, new Rectangle(0, 0, 1920, 1080), cutsceneColor);
                    if (b == 2)
                        spriteBatch.Draw(cutscene2, new Rectangle(0, 0, 1920, 1080), cutsceneColor);
                    spriteBatch.Draw(whiteText, cutsceneTextRect, new Color(0, 0, 0, d - 100));
                    spriteBatch.DrawString(tinyFont, cutsceneText, new Vector2(100, 800), cutsceneTextColor);
                    if (introTimer > 2300)
                        spriteBatch.DrawString(tinyFont, skipText, new Vector2(1600, 800), nextColor);
                }
            }
            //GAME OVER
            if (gameState == Gamestate.end)
            {
                //FINAL TEXT
                spriteBatch.DrawString(tinyFont, finalText, new Vector2(50, 100), Color.White);
                //QUIT BOX
                spriteBatch.Draw(whiteText, quitRect, quitColor);
                spriteBatch.DrawString(Font1, quitText, new Vector2(865, 850), Color.Black);
                spriteBatch.Draw(blackText, quitRect, Color.White);
            }
            //LOADING
            if (gameState == Gamestate.loading)
            {
                spriteBatch.DrawString(Font1, introText, introTextVect, introTextColor);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
    enum Gamestate
    {
        home,
        loading,
        cutscene,
        play,
        end
    }
}