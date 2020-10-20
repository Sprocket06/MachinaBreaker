using Chroma.Graphics;
using Chroma.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace MachinaBreaker.Entities
{
    class Player
    {
        public Texture SpriteSheet;
        public Vector2 Position = Vector2.Zero;
        private Rectangle[] TileMap;
        private int TileCount;
        private int Speed = 5;
        private int CurrentFrame = 0;
        private float AnimTimer = 0f;

        public Player(Texture sheet)
        {
            SpriteSheet = sheet;
            TileCount = (SpriteSheet.Height / 32) * (SpriteSheet.Width / 32);
            TileMap = new Rectangle[TileCount];
            for(int y = 0; y < SpriteSheet.Height / 32; y++)
            {
                for(int x = 0; x < SpriteSheet.Width / 32; x++)
                {
                    TileMap[y * (SpriteSheet.Height / 32) + x] = new Rectangle(x*32, y*32, 32, 32);
                }
            }
        }

        public void Update(float dt)
        {
            AnimTimer += dt;
            if(AnimTimer >= 0.25)
            {
                CurrentFrame = (CurrentFrame + 1) % 3;
                AnimTimer = 0f;
            }
            Vector2 dV = new Vector2(0);
            if(Keyboard.IsKeyDown(KeyCode.Left))
            {
                dV.X += -1;
            }
            if(Keyboard.IsKeyDown(KeyCode.Right))
            {
                dV.X += 1;
            }
            if(Keyboard.IsKeyDown(KeyCode.Up))
            {
                dV.Y -= 1;
            }
            if(Keyboard.IsKeyDown(KeyCode.Down))
            {
                dV.Y += 1;
            }
            dV = dV * Speed;
            Position += dV;

        }

        public void Draw(RenderContext ctx)
        {
            ctx.DrawTexture(SpriteSheet, Position, Vector2.One, Vector2.Zero, 0f, TileMap[CurrentFrame]);
        }
        
    }
}
