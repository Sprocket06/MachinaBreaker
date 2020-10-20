using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using Chroma;
using Chroma.Graphics;
using Chroma.ContentManagement.FileSystem;
using System.IO;
using MachinaBreaker.Entities;
using Chroma.Input.EventArgs;
using Chroma.Input;

namespace MachinaBreaker
{
    class GameCore : Game
    {
        public Texture playerSheet;
        public Player player;

        public GameCore()
        {
            Content = new FileSystemContentProvider(this, Path.Combine(LocationOnDisk, "Assets/"));
        }

        protected override void LoadContent()
        {
            playerSheet = Content.Load<Texture>("ProtoProtagComplete-Sheet.png");
            player = new Player(playerSheet);
            player.Position = new Vector2(Window.Size.Width / 2, Window.Size.Height / 2);
        }

        protected override void KeyPressed(KeyEventArgs e)
        {
            if(e.KeyCode == KeyCode.Escape)
            {
                Quit();
            }
        }

        protected override void Update(float delta)
        {
            player.Update(delta);
        }

        protected override void Draw(RenderContext context)
        {
            player.Draw(context);
        }

    }
}
