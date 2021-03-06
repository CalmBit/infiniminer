﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using StateMasher;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace Infiniminer.States
{
    public class TitleState : State
    {
        Texture2D texMenu;
        Rectangle drawRect;
        string nextState = null;

        /// ====== PLEXIGLASS VARIABLES ======= \\\
        SpriteFont uiFont;

        public override void OnEnter(string oldState)
        {
            Sm.IsMouseVisible = true;

            texMenu = Sm.LoadContent<Texture2D>("menus/tex_menu_title");
            uiFont = Sm.LoadContent<SpriteFont>("font_04b08");

            drawRect = new Rectangle(Sm.GraphicsDevice.Viewport.Width / 2 - 1024 / 2,
                                     Sm.GraphicsDevice.Viewport.Height / 2 - 768 / 2,
                                     1024,
                                     1024);
        }

        public override void OnLeave(string newState)
        {

        }

        public override string OnUpdate(GameTime gameTime, KeyboardState keyState, MouseState mouseState)
        {
            // Do network stuff.
            //(_SM as InfiniminerGame).UpdateNetwork(gameTime);

            return nextState;
        }

        public override void OnRenderAtEnter(GraphicsDevice graphicsDevice)
        {

        }

        public override void OnRenderAtUpdate(GraphicsDevice graphicsDevice, GameTime gameTime)
        {
            SpriteBatch spriteBatch = new SpriteBatch(graphicsDevice);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            spriteBatch.Draw(texMenu, drawRect, Color.White);
            spriteBatch.DrawString(uiFont, "[PLEXIGLASS EDITION]", new Vector2(Sm.GraphicsDevice.Viewport.Width-500, Sm.GraphicsDevice.Viewport.Height - 50), Color.White);
            spriteBatch.End();
        }

        public override void OnKeyDown(Keys key)
        {
            if (key == Keys.Escape)
            {
                Sm.Exit();
            }
        }

        public override void OnKeyUp(Keys key)
        {

        }

        public override void OnMouseDown(MouseButton button, int x, int y)
        {
            nextState = "Infiniminer.States.ServerBrowserState";
            P.PlaySound(InfiniminerSound.ClickHigh);
        }

        public override void OnMouseUp(MouseButton button, int x, int y)
        {

        }

        public override void OnMouseScroll(int scrollDelta)
        {

        }
    }
}
